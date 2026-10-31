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
    public class D_Horario
    {
        public DataTable Listar(int idMedico, int dia)
        {
            return Conexion.Tabla(
                "SELECT ID_Horario, DiaSemana, " +
                "CASE DiaSemana WHEN 1 THEN N'Lunes' WHEN 2 THEN N'Martes' WHEN 3 THEN N'Miércoles' " +
                "WHEN 4 THEN N'Jueves' WHEN 5 THEN N'Viernes' WHEN 6 THEN N'Sábado' ELSE N'Domingo' END AS Dia, " +
                "HoraInicio, HoraFin " +
                "FROM HorarioDisponible WHERE ID_Medico = @M AND (DiaSemana = @d OR @d = 0) ORDER BY DiaSemana, HoraInicio",
                CommandType.Text,
                new SqlParameter("@M", idMedico),
                new SqlParameter("@d", dia));
        }

        public void Insertar(E_Horario h)
        {
            Conexion.Ejecutar(
                "INSERT INTO HorarioDisponible (ID_Medico, DiaSemana, HoraInicio, HoraFin) VALUES (@M, @D, @Ini, @Fin)",
                CommandType.Text,
                new SqlParameter("@M", h.IdMedico),
                new SqlParameter("@D", h.Dia),
                new SqlParameter("@Ini", h.HoraInicio),
                new SqlParameter("@Fin", h.HoraFin));
        }

        public int Actualizar(E_Horario h)
        {
            return Conexion.Ejecutar(
                "UPDATE HorarioDisponible SET DiaSemana = @D, HoraInicio = @Ini, HoraFin = @Fin " +
                "WHERE ID_Horario = @Id AND ID_Medico = @M",
                CommandType.Text,
                new SqlParameter("@D", h.Dia),
                new SqlParameter("@Ini", h.HoraInicio),
                new SqlParameter("@Fin", h.HoraFin),
                new SqlParameter("@Id", h.Id),
                new SqlParameter("@M", h.IdMedico));
        }

        public int Eliminar(int id, int idMedico)
        {
            return Conexion.Ejecutar(
                "DELETE FROM HorarioDisponible WHERE ID_Horario = @Id AND ID_Medico = @M",
                CommandType.Text,
                new SqlParameter("@Id", id),
                new SqlParameter("@M", idMedico));
        }

        // ¿El rango se cruza con otro horario del mismo día? (idExcluir = el que se está editando)
        public bool HayTraslape(int idMedico, int dia, TimeSpan ini, TimeSpan fin, int idExcluir)
        {
            DataTable dt = Conexion.Tabla(
                "SELECT COUNT(*) FROM HorarioDisponible WHERE ID_Medico = @M AND DiaSemana = @D " +
                "AND ID_Horario <> @Id AND @Ini < HoraFin AND @Fin > HoraInicio",
                CommandType.Text,
                new SqlParameter("@M", idMedico),
                new SqlParameter("@D", dia),
                new SqlParameter("@Id", idExcluir),
                new SqlParameter("@Ini", ini),
                new SqlParameter("@Fin", fin));
            return Convert.ToInt32(dt.Rows[0][0]) > 0;
        }

        // Citas pendientes futuras dentro del horario guardado que NO quedarían cubiertas
        // por el nuevo rango (para eliminar se pasa nuevoDia = 0)
        public int CitasPendientesFuera(int idHorario, int idMedico, int nuevoDia, TimeSpan nuevoIni, TimeSpan nuevoFin)
        {
            DataTable dt = Conexion.Tabla(
                "SELECT COUNT(*) FROM Cita c " +
                "JOIN HorarioDisponible h ON h.ID_Horario = @H AND h.ID_Medico = c.ID_Medico " +
                "WHERE c.ID_Medico = @M AND c.ID_Estado = 1 AND c.Fecha >= CAST(GETDATE() AS DATE) " +
                "AND ((DATEPART(WEEKDAY, c.Fecha) + @@DATEFIRST - 2) % 7) + 1 = h.DiaSemana " +
                "AND c.Hora >= h.HoraInicio AND c.Hora < h.HoraFin " +
                "AND NOT (h.DiaSemana = @ND AND c.Hora >= @NIni AND c.Hora < @NFin)",
                CommandType.Text,
                new SqlParameter("@H", idHorario),
                new SqlParameter("@M", idMedico),
                new SqlParameter("@ND", nuevoDia),
                new SqlParameter("@NIni", nuevoIni),
                new SqlParameter("@NFin", nuevoFin));
            return Convert.ToInt32(dt.Rows[0][0]);
        }
    }
}