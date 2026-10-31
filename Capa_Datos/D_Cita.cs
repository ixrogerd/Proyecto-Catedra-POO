using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Capa_Entidad;
namespace Capa_Datos
{
    // Acceso a datos de las citas. Tiene tres bloques: lo que necesita el cálculo de horas libres,
    // lo del paciente y lo del médico. Casi todo está filtrado por el ID de quien pregunta, para que
    // cada persona vea y toque únicamente sus propias citas.
    public class D_Cita
    {
        // Horario semanal del médico para un día (1=Lunes ... 7=Domingo)
        // Devuelve los bloques en que atiende ese día (por ejemplo 08:00-12:00 y 14:00-17:00).
        public DataTable Horarios(int idMedico, int dia)
        {
            return Conexion.Tabla(
                "SELECT HoraInicio, HoraFin FROM HorarioDisponible " +
                "WHERE ID_Medico = @M AND DiaSemana = @D ORDER BY HoraInicio",
                CommandType.Text,
                new SqlParameter("@M", idMedico),
                new SqlParameter("@D", dia));
        }

        // Horas ya tomadas (las canceladas liberan el horario)
        // Por eso el "ID_Estado <> 3": una cita cancelada ya no ocupa su hora.
        public DataTable HorasOcupadas(int idMedico, DateTime fecha)
        {
            return Conexion.Tabla(
                "SELECT Hora FROM Cita WHERE ID_Medico = @M AND Fecha = @F AND ID_Estado <> 3",
                CommandType.Text,
                new SqlParameter("@M", idMedico),
                new SqlParameter("@F", fecha.Date));
        }

        // Guarda la cita llamando al procedimiento sp_AgendarCita. El procedimiento vuelve a comprobar todo
        // (paciente y médico activos, fecha no pasada, médico que atiende a esa hora, horario libre)
        // y lanza un error con mensaje si algo no cuadra.
        public void Agendar(E_Cita c)
        {
            Conexion.Ejecutar("sp_AgendarCita", CommandType.StoredProcedure,
                new SqlParameter("@ID_Paciente", c.IdPaciente),
                new SqlParameter("@ID_Medico", c.IdMedico),
                new SqlParameter("@Fecha", c.Fecha.Date),
                new SqlParameter("@Hora", c.Hora),
                new SqlParameter("@Motivo", Conexion.Nulo(c.Motivo)));   // el motivo es opcional
        }

        // ---------- Paciente ----------

        // Citas de un paciente. Los dos filtros son opcionales: si "estado" o "fecha" vienen vacíos (null),
        // el "@Estado IS NULL OR ..." deja pasar todo y ese filtro no se aplica.
        // Lee de la vista vw_CitasDetalle, que ya trae unidos los nombres del médico y la especialidad.
        public DataTable CitasPaciente(int idPaciente, string estado, DateTime? fecha)
        {
            return Conexion.Tabla(
                "SELECT ID_Cita, Fecha, Hora, Medico, NombreEspecialidad, Motivo, Estado " +
                "FROM vw_CitasDetalle WHERE ID_Paciente = @P " +
                "AND (@Estado IS NULL OR Estado = @Estado) " +
                "AND (@Fecha IS NULL OR Fecha = @Fecha) " +
                "ORDER BY Fecha DESC, Hora DESC",
                CommandType.Text,
                new SqlParameter("@P", idPaciente),
                new SqlParameter("@Estado", Conexion.Nulo(estado)),
                new SqlParameter("@Fecha", fecha.HasValue ? (object)fecha.Value.Date : DBNull.Value));
        }

        // Solo devuelve la receta si la cita es de ese paciente
        // (el JOIN con Cita y la condición del paciente evitan que alguien vea la receta de otra persona).
        public DataTable Receta(int idCita, int idPaciente)
        {
            return Conexion.Tabla(
                "SELECT r.Descripcion, r.Indicaciones, r.FechaEmision " +
                "FROM Receta r JOIN Cita c ON c.ID_Cita = r.ID_Cita " +
                "WHERE r.ID_Cita = @C AND c.ID_Paciente = @P",
                CommandType.Text,
                new SqlParameter("@C", idCita),
                new SqlParameter("@P", idPaciente));
        }

        // Cancela (estado 3) solo si es suya y está Pendiente (estado 1). Devuelve filas afectadas.
        // Si devuelve 0, la capa de negocio sabe que no se canceló nada (no era suya o ya no estaba pendiente).
        public int Cancelar(int idCita, int idPaciente)
        {
            return Conexion.Ejecutar(
                "UPDATE Cita SET ID_Estado = 3 WHERE ID_Cita = @C AND ID_Paciente = @P AND ID_Estado = 1" ,
                CommandType.Text,
                new SqlParameter("@C", idCita),
                new SqlParameter("@P", idPaciente));
        }

        // ---------- Médico ----------

        // Texto que se muestra en los combos de citas, por ejemplo "26/10/2026 08:00 - Ana López".
        // Se arma en SQL: el estilo 103 da la fecha como dd/mm/yyyy y el 108 da la hora como hh:mm:ss
        // (con LEFT(..., 5) nos quedamos solo con hh:mm).
        private const string TextoCita =
            "CONVERT(VARCHAR(10), Fecha, 103) + ' ' + LEFT(CONVERT(VARCHAR(8), Hora, 108), 5) + ' - ' + Paciente";

        // Citas de un médico, con los mismos filtros opcionales de estado y fecha que las del paciente.
        public DataTable CitasMedico(int idMedico, string estado, DateTime? fecha)
        {
            return Conexion.Tabla(
                "SELECT ID_Cita, Fecha, Hora, Paciente, Motivo, Estado " +
                "FROM vw_CitasDetalle WHERE ID_Medico = @M " +
                "AND (@Estado IS NULL OR Estado = @Estado) " +
                "AND (@Fecha IS NULL OR Fecha = @Fecha) " +
                "ORDER BY Fecha DESC, Hora DESC",
                CommandType.Text,
                new SqlParameter("@M", idMedico),
                new SqlParameter("@Estado", Conexion.Nulo(estado)),
                new SqlParameter("@Fecha", fecha.HasValue ? (object)fecha.Value.Date : DBNull.Value));
        }


        // Citas pendientes del médico (las que todavía puede atender), de la más próxima a la más lejana.
        // Alimenta el combo de la pantalla "Atender cita".
        public DataTable CitasPorAtender(int idMedico)
        {
            return Conexion.Tabla(
                "SELECT ID_Cita, Fecha, Hora, Motivo, Paciente, " + TextoCita + " AS Texto " +
                "FROM vw_CitasDetalle WHERE ID_Medico = @M AND Estado = 'Pendiente' ORDER BY Fecha, Hora",
                CommandType.Text,
                new SqlParameter("@M", idMedico));
        }

        // Citas ya atendidas que todavía NO tienen receta (el NOT EXISTS descarta las que ya la tienen).
        // Alimenta el combo de la pantalla "Emitir receta": son las únicas sobre las que se puede recetar.
        public DataTable CitasParaReceta(int idMedico)
        {
            return Conexion.Tabla(
                "SELECT ID_Cita, Fecha, Hora, Paciente, " + TextoCita + " AS Texto " +
                "FROM vw_CitasDetalle v WHERE v.ID_Medico = @M AND v.Estado = 'Atendida' " +
                "AND NOT EXISTS (SELECT 1 FROM Receta r WHERE r.ID_Cita = v.ID_Cita) " +
                "ORDER BY v.Fecha DESC, v.Hora DESC",
                CommandType.Text,
                new SqlParameter("@M", idMedico));
        }

        // Registra la atención: guarda diagnóstico, tratamiento y observaciones, y cambia el estado a 2 (Atendida).
        // El WHERE exige que la cita sea de ese médico y siga Pendiente (estado 1).
        // Devuelve las filas afectadas: 0 significa que no se pudo atender (no existe, es de otro médico o ya no estaba pendiente).
        public int Atender(int idCita, int idMedico, string diagnostico, string tratamiento, string observaciones)
        {
            return Conexion.Ejecutar(
                "UPDATE Cita SET ID_Estado = 2, Diagnostico = @D, Tratamiento = @T, Observaciones = @O " +
                "WHERE ID_Cita = @C AND ID_Medico = @M AND ID_Estado = 1",
                CommandType.Text,
                new SqlParameter("@D", diagnostico),
                new SqlParameter("@T", tratamiento),
                new SqlParameter("@O", Conexion.Nulo(observaciones)),   // las observaciones son opcionales
                new SqlParameter("@C", idCita),
                new SqlParameter("@M", idMedico));
        }

        // Lo que el médico anotó al atender una cita (solo si la cita es suya).
        public DataTable Atencion(int idCita, int idMedico)
        {
            return Conexion.Tabla(
                "SELECT Diagnostico, Tratamiento, Observaciones FROM Cita WHERE ID_Cita = @C AND ID_Medico = @M",
                CommandType.Text,
                new SqlParameter("@C", idCita),
                new SqlParameter("@M", idMedico));
        }

        // Receta de una cita, vista desde el médico (solo si la cita es suya). Es la misma idea que Receta(),
        // pero comprobando el médico en lugar del paciente.
        public DataTable RecetaMedico(int idCita, int idMedico)
        {
            return Conexion.Tabla(
                "SELECT r.Descripcion, r.Indicaciones FROM Receta r JOIN Cita c ON c.ID_Cita = r.ID_Cita " +
                "WHERE r.ID_Cita = @C AND c.ID_Medico = @M",
                CommandType.Text,
                new SqlParameter("@C", idCita),
                new SqlParameter("@M", idMedico));
        }

        // El médico cancela una de sus citas pendientes. Igual que Cancelar(): devuelve 0 si no se canceló nada.
        public int CancelarMedico(int idCita, int idMedico)
        {
            return Conexion.Ejecutar(
                "UPDATE Cita SET ID_Estado = 3 WHERE ID_Cita = @C AND ID_Medico = @M AND ID_Estado = 1",
                CommandType.Text,
                new SqlParameter("@C", idCita),
                new SqlParameter("@M", idMedico));
        }
    }
}