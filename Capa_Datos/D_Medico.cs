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
    // Acceso a datos de los médicos.
    public class D_Medico
    {
        // Lista los médicos ACTIVOS (usa la vista vw_MedicosActivos, que ya excluye a los inhabilitados).
        // El filtro busca en el nombre completo, el usuario, el correo o la especialidad.
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

        // Registra un médico nuevo con el procedimiento sp_RegistrarMedico, que crea la cuenta (tabla Usuario)
        // y la ficha (tabla Medico) en una sola transacción: o se guardan las dos o no se guarda ninguna.
        // "hash" es la contraseña ya convertida por la capa de negocio.
        public void Registrar(E_Medico m, string hash)
        {
            Conexion.Ejecutar("sp_RegistrarMedico", CommandType.StoredProcedure,
                new SqlParameter("@Username", m.Username),
                new SqlParameter("@PasswordHash", hash),
                new SqlParameter("@Nombre", m.Nombre),
                new SqlParameter("@Apellido", m.Apellido),
                new SqlParameter("@Telefono", Conexion.Nulo(m.Telefono)),   // opcional: vacío -> NULL
                new SqlParameter("@Correo", Conexion.Nulo(m.Correo)),       // opcional: vacío -> NULL
                new SqlParameter("@ID_Especialidad", m.IdEspecialidad));
        }
        
        // Modifica los datos personales y la especialidad. No toca el usuario ni la contraseña (eso va en la pantalla de Usuarios).
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

        // Médicos activos de una especialidad, con el nombre ya unido ("Nombre Apellido") para mostrarlo directo en un combo.
        // Se usa al agendar una cita: primero eligen la especialidad y luego aparecen sus médicos.
        public DataTable PorEspecialidad(int idEspecialidad)
        {
            return Conexion.Tabla(
                "SELECT ID_Medico, Nombre + ' ' + Apellido AS NombreCompleto " +
                "FROM vw_MedicosActivos WHERE ID_Especialidad = @Esp ORDER BY Apellido, Nombre",
                CommandType.Text,
                new SqlParameter("@Esp", idEspecialidad));
        }
    }
}
