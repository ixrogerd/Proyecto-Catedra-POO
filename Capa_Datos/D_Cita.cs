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
    public class D_Cita
    {
        // Horario semanal del médico para un día (1=Lunes ... 7=Domingo)
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
        public DataTable HorasOcupadas(int idMedico, DateTime fecha)
        {
            return Conexion.Tabla(
                "SELECT Hora FROM Cita WHERE ID_Medico = @M AND Fecha = @F AND ID_Estado <> 3",
                CommandType.Text,
                new SqlParameter("@M", idMedico),
                new SqlParameter("@F", fecha.Date));
        }

        public void Agendar(E_Cita c)
        {
            Conexion.Ejecutar("sp_AgendarCita", CommandType.StoredProcedure,
                new SqlParameter("@ID_Paciente", c.IdPaciente),
                new SqlParameter("@ID_Medico", c.IdMedico),
                new SqlParameter("@Fecha", c.Fecha.Date),
                new SqlParameter("@Hora", c.Hora),
                new SqlParameter("@Motivo", Conexion.Nulo(c.Motivo)));
        }

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
        public int Cancelar(int idCita, int idPaciente)
        {
            return Conexion.Ejecutar(
                "UPDATE Cita SET ID_Estado = 3 WHERE ID_Cita = @C AND ID_Paciente = @P AND ID_Estado = 1" ,
                CommandType.Text,
                new SqlParameter("@C", idCita),
                new SqlParameter("@P", idPaciente));
        }

        // ---------- Médico ----------
        private const string TextoCita =
            "CONVERT(VARCHAR(10), Fecha, 103) + ' ' + LEFT(CONVERT(VARCHAR(8), Hora, 108), 5) + ' - ' + Paciente";

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

        public DataTable CitasPorAtender(int idMedico)
        {
            return Conexion.Tabla(
                "SELECT ID_Cita, Fecha, Hora, Motivo, Paciente, " + TextoCita + " AS Texto " +
                "FROM vw_CitasDetalle WHERE ID_Medico = @M AND Estado = 'Pendiente' ORDER BY Fecha, Hora",
                CommandType.Text,
                new SqlParameter("@M", idMedico));
        }

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

        public int Atender(int idCita, int idMedico, string diagnostico, string tratamiento, string observaciones)
        {
            return Conexion.Ejecutar(
                "UPDATE Cita SET ID_Estado = 2, Diagnostico = @D, Tratamiento = @T, Observaciones = @O " +
                "WHERE ID_Cita = @C AND ID_Medico = @M AND ID_Estado = 1",
                CommandType.Text,
                new SqlParameter("@D", diagnostico),
                new SqlParameter("@T", tratamiento),
                new SqlParameter("@O", Conexion.Nulo(observaciones)),
                new SqlParameter("@C", idCita),
                new SqlParameter("@M", idMedico));
        }

        public DataTable Atencion(int idCita, int idMedico)
        {
            return Conexion.Tabla(
                "SELECT Diagnostico, Tratamiento, Observaciones FROM Cita WHERE ID_Cita = @C AND ID_Medico = @M",
                CommandType.Text,
                new SqlParameter("@C", idCita),
                new SqlParameter("@M", idMedico));
        }

        public DataTable RecetaMedico(int idCita, int idMedico)
        {
            return Conexion.Tabla(
                "SELECT r.Descripcion, r.Indicaciones FROM Receta r JOIN Cita c ON c.ID_Cita = r.ID_Cita " +
                "WHERE r.ID_Cita = @C AND c.ID_Medico = @M",
                CommandType.Text,
                new SqlParameter("@C", idCita),
                new SqlParameter("@M", idMedico));
        }

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