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
    // Acceso a datos de las cuentas de usuario (login, listado y activar / desactivar).
    // Aquí no hay validaciones: eso lo hace la capa de negocio antes de llamar a estos métodos.
    public class D_Usuario
    {
        // Llama al procedimiento sp_Login. Devuelve una fila con los datos de la persona si el usuario y la contraseña
        // (ya convertida en hash) coinciden con una cuenta activa, o una tabla vacía si no.
        // Este método arma su propia conexión en vez de usar Conexion.Tabla, como en la guía 12; hace lo mismo.
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

        // Lista las cuentas para la pantalla de Usuarios. A diferencia de las pantallas de pacientes y médicos,
        // aquí salen TODAS: las activas y las inhabilitadas (por eso se puede reactivar una).
        // - "filtro" busca dentro del usuario o del nombre.
        // - "idRol" filtra por tipo de usuario; 0 significa "todos".
        public DataTable Listar(string filtro, int idRol)
        {
            // La consulta de adentro junta cada usuario con su rol y con su ficha personal.
            // Se usa LEFT JOIN con las tres fichas porque cada usuario solo tiene UNA (paciente, médico o administrador)
            // y las otras dos quedan vacías; COALESCE se queda con la primera que no esté vacía.
            // Se envuelve en un SELECT de afuera para poder filtrar por "Nombre", que es una columna calculada.
            // El truco "@IdRol = 0 OR ..." hace que el filtro de rol solo se aplique cuando mandan un rol distinto de 0.
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

        // Cambia el nombre de usuario y, opcionalmente, la contraseña.
        // "hashNuevo" viene en null cuando no quieren cambiar la contraseña.
        public void ActualizarCuenta(int id, string username, string hashNuevo)
        {
            // COALESCE(@Hash, PasswordHash) significa "usa el hash nuevo si lo hay; si no, deja el que ya estaba".
            // Por eso mandamos DBNull.Value cuando el hash es null.
            Conexion.Ejecutar(
                "UPDATE Usuario SET Username = @Username, PasswordHash = COALESCE(@Hash, PasswordHash) WHERE ID_Usuario = @Id",
                CommandType.Text,
                new SqlParameter("@Username", username),
                new SqlParameter("@Hash", (object)hashNuevo ?? DBNull.Value),
                new SqlParameter("@Id", id));
        }

        // Baja lógica: la cuenta queda inactiva y sus citas pendientes se cancelan (todo eso lo hace el procedimiento).
        // No se borra nada, así el historial de citas y recetas se conserva.
        public void Desactivar(int id)
        {
            Conexion.Ejecutar("sp_DesactivarUsuario", CommandType.StoredProcedure,
                new SqlParameter("@ID_Usuario", id));
        }

        // Deshace la baja lógica: la cuenta vuelve a estar activa y puede iniciar sesión otra vez.
        // (Las citas que se cancelaron al desactivar NO se restauran.)
        public void Reactivar(int id)
        {
            Conexion.Ejecutar("sp_ReactivarUsuario", CommandType.StoredProcedure,
                new SqlParameter("@ID_Usuario", id));
        }
    }

}
