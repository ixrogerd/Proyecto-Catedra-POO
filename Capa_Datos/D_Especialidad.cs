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
    // Acceso a datos de las especialidades médicas.
    public class D_Especialidad
    {
        // Todas las especialidades, ordenadas por nombre. Es la que llena los combos de otras pantallas.
        public DataTable Listar()
        {
            return Conexion.Tabla(
                "SELECT ID_Especialidad, NombreEspecialidad, Descripcion FROM Especialidad ORDER BY NombreEspecialidad",
                CommandType.Text);
        }

        // Crea una especialidad nueva. El ID no se manda porque la BD lo genera sola.
        public void Insertar(E_Especialidad e)
        {
            Conexion.Ejecutar(
                "INSERT INTO Especialidad (NombreEspecialidad, Descripcion) VALUES (@Nombre, @Desc)",
                CommandType.Text,
                new SqlParameter("@Nombre", e.Nombre),
                new SqlParameter("@Desc", Conexion.Nulo(e.Descripcion)));  // descripción vacía -> NULL
        }

        // Modifica el nombre y la descripción de una especialidad que ya existe (se identifica por su ID).
        public void Actualizar(E_Especialidad e)
        {
            Conexion.Ejecutar(
                "UPDATE Especialidad SET NombreEspecialidad = @Nombre, Descripcion = @Desc WHERE ID_Especialidad = @Id",
                CommandType.Text,
                new SqlParameter("@Nombre", e.Nombre),
                new SqlParameter("@Desc", Conexion.Nulo(e.Descripcion)),
                new SqlParameter("@Id", e.Id));
        }

        // Borrado real. Si algún médico usa esta especialidad, SQL Server lo rechaza con un error de llave foránea
        // y la capa de negocio lo convierte en un mensaje.
        public void Eliminar(int id)
        {
            Conexion.Ejecutar(
                "DELETE FROM Especialidad WHERE ID_Especialidad = @Id",
                CommandType.Text,
                new SqlParameter("@Id", id));
        }

        // Busca por nombre o por descripción. Los "%" a los lados hacen que el texto pueda estar en cualquier parte
        // (si el filtro viene vacío, queda "%%" y coincide con todo, así que devuelve la lista completa).
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
