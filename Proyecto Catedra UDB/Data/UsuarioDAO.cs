using System.Data;
using System.Data.SqlClient;
using Proyecto_Catedra_UDB.Connection;
using Proyecto_Catedra_UDB.Models;

namespace Proyecto_Catedra_UDB.Data
{
    /// <summary>
    /// Capa de Datos (DAO). Solo habla con SQL Server; no hashea ni valida reglas de negocio.
    /// </summary>
    public class UsuarioDAO
    {
        /// <param name="passwordHash">Hash SHA-256 (hex minuscula) ya calculado por la capa de negocio.</param>
        /// <returns>Usuario si las credenciales son validas y esta activo; null si no.</returns>
        public static Usuario Login(string username, string passwordHash)
        {
            using (SqlConnection conn = DbConnection.CreateConnection())
            using (SqlCommand cmd = new SqlCommand("sp_Login", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@Username", SqlDbType.VarChar, 50).Value = username;
                cmd.Parameters.Add("@PasswordHash", SqlDbType.VarChar, 256).Value = passwordHash;

                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (!reader.Read())
                        return null;

                    string user = reader.GetString(reader.GetOrdinal("Username"));
                    int ordNombre = reader.GetOrdinal("NombreCompleto");

                    return new Usuario
                    {
                        ID_Usuario = reader.GetInt32(reader.GetOrdinal("ID_Usuario")),
                        Username = user,
                        ID_Rol = reader.GetInt32(reader.GetOrdinal("ID_Rol")),
                        Rol = reader.GetString(reader.GetOrdinal("Rol")),
                        NombreCompleto = reader.IsDBNull(ordNombre) ? user : reader.GetString(ordNombre)
                    };
                }
            }
        }
    }
}