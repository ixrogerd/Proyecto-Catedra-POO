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
    public class D_Paciente
    {
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

        public void Registrar(E_Paciente p, string hash)
        {
            Conexion.Ejecutar("sp_RegistrarPaciente", CommandType.StoredProcedure,
                new SqlParameter("@Username", p.Username),
                new SqlParameter("@PasswordHash", hash),
                new SqlParameter("@Nombre", p.Nombre),
                new SqlParameter("@Apellido", p.Apellido),
                new SqlParameter("@FechaNacimiento", p.FechaNacimiento.Date),
                new SqlParameter("@Telefono", Conexion.Nulo(p.Telefono)),
                new SqlParameter("@Correo", Conexion.Nulo(p.Correo)));
        }

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
