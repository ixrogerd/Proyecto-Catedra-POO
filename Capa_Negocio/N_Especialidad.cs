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
    public class N_Especialidad
    {
        D_Especialidad datos = new D_Especialidad();

        public DataTable Listar() { return datos.Listar(); }
        public DataTable Buscar(string filtro) { return datos.Buscar(filtro); }
        public void Guardar(E_Especialidad e)
        {
            Validar.Requerido(e.Nombre, "nombre de la especialidad", 80);
            if (e.Descripcion != null && e.Descripcion.Length > 200)
                throw new Exception("La descripción no puede superar 200 caracteres.");
            try
            {
                if (e.Id == 0) datos.Insertar(e); else datos.Actualizar(e);
            }
            catch (SqlException ex) { throw Validar.Traducir(ex); }
        }
        public void Eliminar(int id)
        {
            if (id <= 0) throw new Exception("Seleccione una especialidad.");
            try { datos.Eliminar(id); }
            catch (SqlException ex)
            {
                if (ex.Number == 547)   // choque con llave foránea
                    throw new Exception("No se puede eliminar: hay médicos con esta especialidad.");
                throw;
            }
        }
    }
}
