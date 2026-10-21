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
    public class D_Medico
    {
        public DataTable Listar(string filtro)
        {
            return Conexion.Tabla(
                "SELECT ID_Medico, Username, Nombre, Apellido, Telefono, Correo, ID_Especialidad, NombreEspecialidad " +
                "FROM vw_MedicosActivos " +
                "WHERE Nombre + ' ' + Apellido LIKE @f OR Username LIKE @f OR Correo LIKE @f OR NombreEspecialidad LIKE @f " +
                "ORDER BY Apellido, Nombre",
                CommandType.Text,
                new SqlParameter("@f", "%" + filtro + "%"));
        }

        public void Registrar(E_Medico m, string hash)
        {
            Conexion.Ejecutar("sp_RegistrarMedico", CommandType.StoredProcedure,
                new SqlParameter("@Username", m.Username),
                new SqlParameter("@PasswordHash", hash),
                new SqlParameter("@Nombre", m.Nombre),
                new SqlParameter("@Apellido", m.Apellido),
                new SqlParameter("@Telefono", Conexion.Nulo(m.Telefono)),
                new SqlParameter("@Correo", Conexion.Nulo(m.Correo)),
                new SqlParameter("@ID_Especialidad", m.IdEspecialidad));
        }

        public void Actualizar(E_Medico m)
        {
            Conexion.Ejecutar(
                "UPDATE Medico SET Nombre = @Nombre, Apellido = @Apellido, Telefono = @Tel, " +
                "Correo = @Correo, ID_Especialidad = @Esp WHERE ID_Medico = @Id",
                CommandType.Text,
                new SqlParameter("@Nombre", m.Nombre),
                new SqlParameter("@Apellido", m.Apellido),
                new SqlParameter("@Tel", Conexion.Nulo(m.Telefono)),
                new SqlParameter("@Correo", Conexion.Nulo(m.Correo)),
                new SqlParameter("@Esp", m.IdEspecialidad),
                new SqlParameter("@Id", m.Id));
        }
    }
}
