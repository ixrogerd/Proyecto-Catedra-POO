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
    public class N_Cita
    {
        public const int DuracionMin = 30;   // duración de cada cita en minutos
        D_Cita datos = new D_Cita();

        // Horas del día del médico; el bool indica si está libre
        private List<KeyValuePair<TimeSpan, bool>> Horas(int idMedico, DateTime fecha)
        {
            var lista = new List<KeyValuePair<TimeSpan, bool>>();
            if (idMedico <= 0 || fecha.Date < DateTime.Today) return lista;

            int dia = ((int)fecha.DayOfWeek + 6) % 7 + 1;   // 1=Lunes ... 7=Domingo (igual que el SP)

            HashSet<TimeSpan> ocupadas = new HashSet<TimeSpan>();
            foreach (DataRow r in datos.HorasOcupadas(idMedico, fecha).Rows)
                ocupadas.Add((TimeSpan)r["Hora"]);

            TimeSpan paso = TimeSpan.FromMinutes(DuracionMin);
            foreach (DataRow h in datos.Horarios(idMedico, dia).Rows)
            {
                TimeSpan ini = (TimeSpan)h["HoraInicio"];
                TimeSpan fin = (TimeSpan)h["HoraFin"];
                for (TimeSpan t = ini; t + paso <= fin; t += paso)
                {
                    // Si es hoy, no ofrecer horas que ya pasaron
                    if (fecha.Date == DateTime.Today && t <= DateTime.Now.TimeOfDay) continue;
                    lista.Add(new KeyValuePair<TimeSpan, bool>(t, !ocupadas.Contains(t)));
                }
            }
            lista.Sort((a, b) => a.Key.CompareTo(b.Key));
            return lista;
        }

        public List<TimeSpan> HorasLibres(int idMedico, DateTime fecha)
        {
            List<TimeSpan> libres = new List<TimeSpan>();
            foreach (var h in Horas(idMedico, fecha))
                if (h.Value) libres.Add(h.Key);
            return libres;
        }

        public DataTable Disponibilidad(int idMedico, DateTime fecha)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Hora", typeof(string));
            dt.Columns.Add("Estado", typeof(string));
            foreach (var h in Horas(idMedico, fecha))
                dt.Rows.Add(h.Key.ToString(@"hh\:mm"), h.Value ? "Disponible" : "Ocupada");
            return dt;
        }

        public void Agendar(E_Cita c)
        {
            if (c.IdMedico <= 0) throw new Exception("Seleccione un médico.");
            if (c.Fecha.Date < DateTime.Today) throw new Exception("No se puede agendar en una fecha pasada.");
            if (c.Hora == TimeSpan.Zero) throw new Exception("Seleccione una hora.");
            if (c.Motivo != null && c.Motivo.Length > 200)
                throw new Exception("El motivo no puede superar 200 caracteres.");

            try { datos.Agendar(c); }
            catch (SqlException ex) { throw Validar.Traducir(ex); }
        }

        public DataTable CitasPaciente(int idPaciente, string estado, DateTime? fecha)
        {
            return datos.CitasPaciente(idPaciente, estado, fecha);
        }

        public DataTable Receta(int idCita, int idPaciente)
        {
            return datos.Receta(idCita, idPaciente);
        }

        public void Cancelar(int idCita, int idPaciente)
        {
            if (idCita <= 0) throw new Exception("Seleccione una cita.");
            if (datos.Cancelar(idCita, idPaciente) == 0)
                throw new Exception("Solo se pueden cancelar sus citas pendientes.");
        }
    }
}