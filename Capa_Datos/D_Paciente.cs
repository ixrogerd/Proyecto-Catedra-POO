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
    // Acceso a datos de los pacientes. Funciona igual que D_Medico.
    public class D_Paciente
    {
        // Lista los pacientes ACTIVOS (usa la vista vw_PacientesActivos, que ya excluye a los inhabilitados).
        // El filtro busca en el nombre completo, el usuario o el correo.
        public DataTable Listar(string filtro)
        {
            return Conexion.Tabla(
                "SELECT ID_Paciente, Username, Nombre, Apellido, FechaNacimiento, Telefono, Correo " +
                "FROM vw_PacientesActivos " +
                "WHERE Nombre + ' ' + Apellido LIKE @f OR Username LIKE @f OR Correo LIKE @f " +
                "ORDER BY Apellido, Nombre",
                CommandType.Text,
                new SqlParameter("@f", "%" + filtro + "%"));
        }

        // Registra un paciente nuevo con el procedimiento sp_RegistrarPaciente, que crea la cuenta (tabla Usuario)
        // y la ficha (tabla Paciente) en una sola transacción: o se guardan las dos o no se guarda ninguna.
        // "hash" es la contraseña ya convertida por la capa de negocio.
        public void Registrar(E_Paciente p, string hash)
        {
            Conexion.Ejecutar("sp_RegistrarPaciente", CommandType.StoredProcedure,
                new SqlParameter("@Username", p.Username),
                new SqlParameter("@PasswordHash", hash),
                new SqlParameter("@Nombre", p.Nombre),
                new SqlParameter("@Apellido", p.Apellido),
                new SqlParameter("@FechaNacimiento", p.FechaNacimiento.Date),   // .Date quita la hora: la columna es solo de fecha
                new SqlParameter("@Telefono", Conexion.Nulo(p.Telefono)),       // opcional: vacío -> NULL
                new SqlParameter("@Correo", Conexion.Nulo(p.Correo)));          // opcional: vacío -> NULL
        }

        // Modifica los datos personales. No toca el usuario ni la contraseña (eso va en la pantalla de Usuarios).
        public void Actualizar(E_Paciente p)
        {
            Conexion.Ejecutar(
                "UPDATE Paciente SET Nombre = @Nombre, Apellido = @Apellido, FechaNacimiento = @Fecha, " +
                "Telefono = @Tel, Correo = @Correo WHERE ID_Paciente = @Id",
                CommandType.Text,
                new SqlParameter("@Nombre", p.Nombre),
                new SqlParameter("@Apellido", p.Apellido),
                new SqlParameter("@Fecha", p.FechaNacimiento.Date),
                new SqlParameter("@Tel", Conexion.Nulo(p.Telefono)),
                new SqlParameter("@Correo", Conexion.Nulo(p.Correo)),
                new SqlParameter("@Id", p.Id));
        }
    }
}
