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
    public class N_Medico
    {
        D_Medico datos = new D_Medico();

        public DataTable Listar(string filtro) { return datos.Listar(filtro); }

        public void Registrar(E_Medico m)
        {
            Validar.Cuenta(m.Username, m.Clave, true);
            ValidarDatos(m);
            try { datos.Registrar(m, Seguridad.Sha256(m.Clave)); }
            catch (SqlException ex) { throw Validar.Traducir(ex); }
        }

        public void Actualizar(E_Medico m)
        {
            if (m.Id <= 0) throw new Exception("Seleccione un médico.");
            ValidarDatos(m);
            try { datos.Actualizar(m); }
            catch (SqlException ex) { throw Validar.Traducir(ex); }
        }

        private void ValidarDatos(E_Medico m)
        {
            Validar.Requerido(m.Nombre, "nombre", 60);
            Validar.Requerido(m.Apellido, "apellido", 60);
            if (m.IdEspecialidad <= 0) throw new Exception("Seleccione una especialidad.");
            Validar.Telefono(m.Telefono);
            Validar.Correo(m.Correo);
        }
        public void Eliminar(int id)
        {
            if (id <= 0) throw new Exception("Seleccione un médico.");
            new D_Usuario().Desactivar(id);
        }
    }
}
