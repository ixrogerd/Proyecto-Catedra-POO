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
        // Desactiva la cuenta del usuario con el ID especificado, lanzando una excepción si intenta desactivar su propia cuenta o la de un administrador
        public void Desactivar(int id, int idRol)
        {
            if (id == Sesion.IdUsuario)
                throw new Exception("No puede inhabilitar su propia cuenta.");
            if(idRol == Sesion.IdRol)
                throw new Exception("No puede inhabilitar la cuenta de un administrador.");
            datos.Desactivar(id);
        }
        //reactiva la cuenta del usuario con el ID especificado, lanzando una excepción si intenta reactivar la cuenta de un administrador
        public void Reactivar(int id, int idRol)
        {
            if (idRol == Sesion.IdRol)
                throw new Exception("No puede reactivar la cuenta de un administrador.");
            datos.Reactivar(id);
        }
    }
}
