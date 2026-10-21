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
    public class D_Especialidad
    {
        public DataTable Listar()
        {
            return Conexion.Tabla(
                "SELECT ID_Especialidad, NombreEspecialidad, Descripcion FROM Especialidad ORDER BY NombreEspecialidad",
                CommandType.Text);
        }

        public void Insertar(E_Especialidad e)
        {
            Conexion.Ejecutar(
                "INSERT INTO Especialidad (NombreEspecialidad, Descripcion) VALUES (@Nombre, @Desc)",
                CommandType.Text,
                new SqlParameter("@Nombre", e.Nombre),
                new SqlParameter("@Desc", Conexion.Nulo(e.Descripcion)));
        }

        public void Actualizar(E_Especialidad e)
        {
            Conexion.Ejecutar(
                "UPDATE Especialidad SET NombreEspecialidad = @Nombre, Descripcion = @Desc WHERE ID_Especialidad = @Id",
                CommandType.Text,
                new SqlParameter("@Nombre", e.Nombre),
                new SqlParameter("@Desc", Conexion.Nulo(e.Descripcion)),
                new SqlParameter("@Id", e.Id));
        }
        public void Eliminar(int id)
        {
            Conexion.Ejecutar(
                "DELETE FROM Especialidad WHERE ID_Especialidad = @Id",
                CommandType.Text,
                new SqlParameter("@Id", id));
        }
        public DataTable Buscar(string filtro)
        {
            return Conexion.Tabla(
                "SELECT ID_Especialidad, NombreEspecialidad, Descripcion FROM Especialidad " +
                "WHERE NombreEspecialidad LIKE @f OR Descripcion LIKE @f " +
                "ORDER BY NombreEspecialidad",
                CommandType.Text,
                new SqlParameter("@f", "%" + filtro + "%"));
        }
    }
}
