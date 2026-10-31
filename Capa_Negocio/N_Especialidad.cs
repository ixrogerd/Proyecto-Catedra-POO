using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Capa_Datos;
using Capa_Entidad;

namespace Capa_Negocio
{
    // Lógica de las especialidades médicas (el CRUD que usa el administrador).
    public class N_Especialidad
    {
        // La capa de datos, que es la única que habla con SQL Server.
        D_Especialidad datos = new D_Especialidad();

        // Todas las especialidades. Es la que se usa para llenar los combos (por ejemplo al registrar un médico).
        public DataTable Listar() { return datos.Listar(); }

        // Lo mismo, pero filtrando por nombre o descripción. Es la del buscador de la pantalla de Especialidades.
        public DataTable Buscar(string filtro) { return datos.Buscar(filtro); }

        // Sirve para crear y para editar: el Id decide qué se hace.
        // Si Id es 0, la especialidad es nueva (INSERT); si trae un número, ya existe y se actualiza (UPDATE).
        public void Guardar(E_Especialidad e)
        {
            Validar.Requerido(e.Nombre, "nombre de la especialidad", 80);
            if (e.Descripcion != null && e.Descripcion.Length > 200)
                throw new Exception("La descripción no puede superar 200 caracteres.");
            try
            {
                if (e.Id == 0) datos.Insertar(e); else datos.Actualizar(e);
            }
            catch (SqlException ex) { throw Validar.Traducir(ex); } // por ejemplo, si el nombre ya existe
        }

        // Borra una especialidad. Es un borrado real, así que solo se permite si ningún médico la está usando.
        public void Eliminar(int id)
        {
            if (id <= 0) throw new Exception("Seleccione una especialidad.");
            try { datos.Eliminar(id); }
            catch (SqlException ex)
            {
                // 547 es el error de SQL Server cuando un registro todavía está referenciado por otro (llave foránea).
                if (ex.Number == 547)   // choque con llave foránea
                    throw new Exception("No se puede eliminar: hay médicos con esta especialidad.");

                // Cualquier otro error lo dejamos pasar tal cual para no esconderlo.
                throw;
            }
        }
    }
}
