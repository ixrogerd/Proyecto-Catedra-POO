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
    // Acceso a datos de los horarios de atención de los médicos.
    // Casi todas las consultas piden también el ID del médico para que nadie pueda tocar horarios ajenos.
    public class D_Horario
    {
        // Horarios de un médico, ordenados por día y hora.
        // El CASE convierte el número del día (1 a 7) en su nombre para mostrarlo en la tabla,
        // pero también devolvemos el número (DiaSemana) porque lo necesitamos al editar.
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

        // Crea un horario nuevo (el ID lo genera la BD).
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

        // Modifica un horario. Devuelve las filas afectadas: 0 significa que no existe o que no es de ese médico.
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

        // Borra un horario (borrado real). Devuelve las filas afectadas: 0 significa que no existe o que no es de ese médico.
        public int Eliminar(int id, int idMedico)
        {
            return Conexion.Ejecutar(
                "DELETE FROM HorarioDisponible WHERE ID_Horario = @Id AND ID_Medico = @M",
                CommandType.Text,
                new SqlParameter("@Id", id),
                new SqlParameter("@M", idMedico));
        }


        // ¿El rango se cruza con otro horario del mismo día? (idExcluir = el que se está editando)
        // Dos rangos se traslapan cuando cada uno empieza antes de que el otro termine:
        // "@Ini < HoraFin AND @Fin > HoraInicio". Dos bloques pegados (uno termina a las 12:00 y el otro empieza a las 12:00) NO cuentan como traslape.
        // Al editar se pasa el ID del propio horario en idExcluir para que no choque consigo mismo (al crear va 0).
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
        // Se usa antes de editar o borrar un horario, para no dejar a pacientes con una cita en una hora que el médico ya no atiende.
        // Cómo funciona la consulta, paso a paso:
        //  - Se une cada cita con el horario guardado (@H), y deben ser del mismo médico.
        //  - Solo cuentan citas pendientes (estado 1) de hoy en adelante.
        //  - La cuenta con DATEPART/@@DATEFIRST convierte el día de la cita a 1=lunes ... 7=domingo
        //    sin depender de la configuración de idioma del servidor.
        //  - La cita debe caer dentro del horario guardado (de HoraInicio hasta antes de HoraFin).
        //  - El NOT(...) final deja fuera las citas que SEGUIRÍAN cubiertas por el nuevo día y rango.
        //    Al eliminar se manda nuevoDia = 0, que nunca coincide con un día real, así que todas las citas del horario cuentan.
        // Si devuelve más de 0, la capa de negocio no deja continuar.
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