using Capa_Datos;
using Capa_Entidad;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Negocio
{
    public class N_Usuario
    {
        D_Usuario datos = new D_Usuario();

        public DataTable Login(E_Usuario obj)
        {
            return datos.Login(obj, Seguridad.Sha256(obj.clave));
        }
        public DataTable Listar(string filtro, int idRol)
        {
            return datos.Listar(filtro, idRol);
        }

        public void ActualizarCuenta(int id, string username, string claveNueva)
        {
            Validar.Cuenta(username, claveNueva, false);
            string hash = string.IsNullOrEmpty(claveNueva) ? null : Seguridad.Sha256(claveNueva);
            try { datos.ActualizarCuenta(id, username.Trim(), hash); }
            catch (SqlException ex) { throw Validar.Traducir(ex); }
        }

        public void Desactivar(int id)
        {
            if (id == Sesion.IdUsuario)
                throw new Exception("No puede inhabilitar su propia cuenta.");
            datos.Desactivar(id);
        }

        public void Reactivar(int id) { datos.Reactivar(id); }
    }
}
