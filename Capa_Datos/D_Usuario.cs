using Capa_Entidad;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Datos
{
    public class D_Usuario
    {
        public DataTable Login(E_Usuario obj, string passwordHash)
        {
            using (SqlConnection cn = new SqlConnection(
                ConfigurationManager.ConnectionStrings["sql"].ConnectionString))
            using (SqlCommand cmd = new SqlCommand("sp_Login", cn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Username", obj.usuario);
                cmd.Parameters.AddWithValue("@PasswordHash", passwordHash);

                DataTable dt = new DataTable();
                new SqlDataAdapter(cmd).Fill(dt);
                return dt;
            }
        }
        public DataTable Listar(string filtro, int idRol)
        {
            return Conexion.Tabla(
                "SELECT * FROM (" +
                " SELECT u.ID_Usuario, u.Username, u.ID_Rol, r.NombreRol AS Rol," +
                " COALESCE(p.Nombre + ' ' + p.Apellido, m.Nombre + ' ' + m.Apellido, a.Nombre + ' ' + a.Apellido) AS Nombre," +
                " COALESCE(p.Correo, m.Correo) AS Correo," +
                " CASE WHEN u.Activo = 1 THEN 'Activo' ELSE 'Inactivo' END AS Estado" +
                " FROM Usuario u" +
                " JOIN Rol r ON r.ID_Rol = u.ID_Rol" +
                " LEFT JOIN Paciente p ON p.ID_Paciente = u.ID_Usuario" +
                " LEFT JOIN Medico m ON m.ID_Medico = u.ID_Usuario" +
                " LEFT JOIN Administrador a ON a.ID_Administrador = u.ID_Usuario) t" +
                " WHERE (@IdRol = 0 OR t.ID_Rol = @IdRol) AND (t.Username LIKE @f OR t.Nombre LIKE @f)" +
                " ORDER BY t.Rol, t.Nombre",
                CommandType.Text,
                new SqlParameter("@f", "%" + filtro + "%"),
                new SqlParameter("@IdRol", idRol));
        }

        public void ActualizarCuenta(int id, string username, string hashNuevo)
        {
            Conexion.Ejecutar(
                "UPDATE Usuario SET Username = @Username, PasswordHash = COALESCE(@Hash, PasswordHash) WHERE ID_Usuario = @Id",
                CommandType.Text,
                new SqlParameter("@Username", username),
                new SqlParameter("@Hash", (object)hashNuevo ?? DBNull.Value),
                new SqlParameter("@Id", id));
        }

        public void Desactivar(int id)
        {
            Conexion.Ejecutar("sp_DesactivarUsuario", CommandType.StoredProcedure,
                new SqlParameter("@ID_Usuario", id));
        }

        public void Reactivar(int id)
        {
            Conexion.Ejecutar("sp_ReactivarUsuario", CommandType.StoredProcedure,
                new SqlParameter("@ID_Usuario", id));
        }
    }

}
