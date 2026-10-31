using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Capa_Datos;
using Capa_Entidad;
namespace Capa_Negocio
{
    // Lógica de las citas, tanto para el paciente (agendar, ver, cancelar) como para el médico (atender, recetar, cancelar).
    // Aquí decidimos QUÉ horas se pueden ofrecer; el procedimiento sp_AgendarCita de la BD vuelve a comprobarlo al guardar.
    public class N_Cita
    {
        // Cada cita dura 30 minutos. Todo el sistema (horarios del médico, horas que se ofrecen) se basa en este número.
        public const int DuracionMin = 30;   // duración de cada cita en minutos

        // La capa de datos, que es la única que habla con SQL Server.
        D_Cita datos = new D_Cita();

        // ---------------------------------------------------------------------------------
        // CÁLCULO DE HORAS DISPONIBLES
        // ---------------------------------------------------------------------------------

        // Calcula todas las horas en que un médico atiende un día y marca cuáles siguen libres.
        // Devuelve pares (hora, libre): true = se puede agendar, false = ya la tiene otro paciente.
        private List<KeyValuePair<TimeSpan, bool>> Horas(int idMedico, DateTime fecha)
        {
            var lista = new List<KeyValuePair<TimeSpan, bool>>();

            // Si no hay médico elegido o la fecha ya pasó, no hay nada que ofrecer.
            if (idMedico <= 0 || fecha.Date < DateTime.Today) return lista;

            // El DayOfWeek de C# empieza con domingo = 0, pero en nuestra BD el lunes es 1 y el domingo es 7.
            // Esta cuenta hace la conversión (y da el mismo resultado que el procedimiento sp_AgendarCita).
            int dia = ((int)fecha.DayOfWeek + 6) % 7 + 1;   // 1=Lunes ... 7=Domingo (igual que el SP)

            // Primero juntamos las horas que ya tienen cita ese día (las canceladas no cuentan, la consulta ya las deja fuera).
            // Usamos un HashSet porque preguntar "¿esta hora está ocupada?" es muy rápido.
            HashSet<TimeSpan> ocupadas = new HashSet<TimeSpan>();
            foreach (DataRow r in datos.HorasOcupadas(idMedico, fecha).Rows)
                ocupadas.Add((TimeSpan)r["Hora"]);

            // "paso" es lo que dura una cita, pero en formato de tiempo para poder sumarlo a las horas.
            TimeSpan paso = TimeSpan.FromMinutes(DuracionMin);

            // Recorremos los bloques de horario que el médico configuró para ese día de la semana
            // (puede haber más de uno, por ejemplo mañana y tarde).
            foreach (DataRow h in datos.Horarios(idMedico, dia).Rows)
            {
                TimeSpan ini = (TimeSpan)h["HoraInicio"];
                TimeSpan fin = (TimeSpan)h["HoraFin"];

                // Vamos desde el inicio hasta el fin del bloque, saltando de 30 en 30 minutos.
                // La condición "t + paso <= fin" evita ofrecer una cita que terminaría después de que se acabe el bloque
                // (en un bloque de 8:00 a 12:00, la última cita empieza a las 11:30).
                for (TimeSpan t = ini; t + paso <= fin; t += paso)
                {
                    // Si la fecha es hoy, no tiene sentido ofrecer horas que ya pasaron.
                    if (fecha.Date == DateTime.Today && t <= DateTime.Now.TimeOfDay) continue;

                    // Guardamos la hora y si está libre (o sea, si NO está en el conjunto de ocupadas).
                    lista.Add(new KeyValuePair<TimeSpan, bool>(t, !ocupadas.Contains(t)));
                }
            }

            // Ordenamos de menor a mayor, por si el médico tiene varios bloques y salieron mezclados
            lista.Sort((a, b) => a.Key.CompareTo(b.Key));
            return lista;
        }

        // Solo las horas libres. Es lo que se muestra en el combo de "Agendar cita".
        public List<TimeSpan> HorasLibres(int idMedico, DateTime fecha)
        {
            List<TimeSpan> libres = new List<TimeSpan>();
            foreach (var h in Horas(idMedico, fecha))
                if (h.Value) libres.Add(h.Key);
            return libres;
        }

        // Todas las horas del día con su estado ("Disponible" u "Ocupada"). Es lo que se muestra en la pantalla de Disponibilidad.
        // Se devuelve como DataTable para poder ponerla directo en un DataGridView.
        public DataTable Disponibilidad(int idMedico, DateTime fecha)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Hora", typeof(string));
            dt.Columns.Add("Estado", typeof(string));
            foreach (var h in Horas(idMedico, fecha))
                dt.Rows.Add(h.Key.ToString(@"hh\:mm"), h.Value ? "Disponible" : "Ocupada");
            return dt;
        }


        // ---------------------------------------------------------------------------------
        // PACIENTE
        // ---------------------------------------------------------------------------------

        // Agenda una cita nueva.
        public void Agendar(E_Cita c)
        {
            // Estas validaciones son para dar un mensaje claro cuanto antes.
            // La validación "de verdad" la repite el procedimiento sp_AgendarCita, por si dos pacientes eligen la misma hora al mismo tiempo.
            if (c.IdMedico <= 0) throw new Exception("Seleccione un médico.");
            if (c.Fecha.Date < DateTime.Today) throw new Exception("No se puede agendar en una fecha pasada.");

            // 00:00 no es una hora de atención real, así que lo tomamos como señal de que no eligieron ninguna.
            if (c.Hora == TimeSpan.Zero) throw new Exception("Seleccione una hora.");
            if (c.Motivo != null && c.Motivo.Length > 200)
                throw new Exception("El motivo no puede superar 200 caracteres.");


            // Si el procedimiento rechaza la cita (horario ocupado, médico que no atiende ese día, etc.),
            // Traducir deja el mensaje listo para mostrarlo.
            try { datos.Agendar(c); }
            catch (SqlException ex) { throw Validar.Traducir(ex); }
        }


        // Citas del paciente. "estado" puede ser null (todas) y "fecha" puede ser null (cualquier día).
        public DataTable CitasPaciente(int idPaciente, string estado, DateTime? fecha)
        {
            return datos.CitasPaciente(idPaciente, estado, fecha);
        }

        // Receta de una cita del paciente (vacía si no tiene). La consulta verifica que la cita sea suya.
        public DataTable Receta(int idCita, int idPaciente)
        {
            return datos.Receta(idCita, idPaciente);
        }

        // El paciente cancela una de sus citas.
        public void Cancelar(int idCita, int idPaciente)
        {
            if (idCita <= 0) throw new Exception("Seleccione una cita.");
            // datos.Cancelar devuelve cuántas filas cambió. Si fue 0, la cita no era suya o ya no estaba pendiente.

            if (datos.Cancelar(idCita, idPaciente) == 0)
                throw new Exception("Solo se pueden cancelar sus citas pendientes.");
        }


        // ---------------------------------------------------------------------------------
        // MÉDICO
        // ---------------------------------------------------------------------------------

        // Citas del médico, con los mismos filtros opcionales que las del paciente.
        public DataTable CitasMedico(int idMedico, string estado, DateTime? fecha)
        {
            return datos.CitasMedico(idMedico, estado, fecha);
        }

        // Citas pendientes: las que el médico todavía puede atender.
        public DataTable CitasPorAtender(int idMedico) { return datos.CitasPorAtender(idMedico); }

        // Citas ya atendidas que todavía no tienen receta (las únicas sobre las que se puede emitir una).
        public DataTable CitasParaReceta(int idMedico) { return datos.CitasParaReceta(idMedico); }

        // Diagnóstico, tratamiento y observaciones que el médico anotó al atender la cita.
        public DataTable Atencion(int idCita, int idMedico) { return datos.Atencion(idCita, idMedico); }

        // Receta de una cita del médico (vacía si no tiene).
        public DataTable RecetaMedico(int idCita, int idMedico) { return datos.RecetaMedico(idCita, idMedico); }


        // Registra la atención de una cita: guarda el diagnóstico, el tratamiento y las observaciones, y la pasa a "Atendida".
        public void Atender(int idCita, int idMedico, string diagnostico, string tratamiento, string observaciones)
        {
            if (idCita <= 0) throw new Exception("Seleccione la cita que va a atender.");

            // Diagnóstico y tratamiento son obligatorios; las observaciones son opcionales.
            Validar.Requerido(diagnostico, "diagnóstico", 500);
            Validar.Requerido(tratamiento, "tratamiento", 500);
            if (observaciones != null && observaciones.Length > 500)
                throw new Exception("Las observaciones no pueden superar 500 caracteres.");

            // Si no se actualizó ninguna fila, la cita no existe, es de otro médico o ya no estaba pendiente.
            if (datos.Atender(idCita, idMedico, diagnostico, tratamiento, observaciones) == 0)
                throw new Exception("La cita no existe, no es suya o ya no está pendiente.");
        }

        // El médico cancela una de sus citas pendientes (el horario queda libre otra vez).
        public void CancelarMedico(int idCita, int idMedico)
        {
            if (idCita <= 0) throw new Exception("Seleccione una cita.");
            if (datos.CancelarMedico(idCita, idMedico) == 0)
                throw new Exception("Solo se pueden cancelar sus citas pendientes.");
        }
    }
}