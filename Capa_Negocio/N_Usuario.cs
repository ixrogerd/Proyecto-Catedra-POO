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
    // Lógica de las cuentas de usuario: login, listado para el administrador y activar / desactivar cuentas.
    public class N_Usuario
    {
        // La capa de datos, que es la única que habla con SQL Server.
        D_Usuario datos = new D_Usuario();

        // Intenta iniciar sesión. Devuelve una tabla: con una fila si usuario y contraseña son correctos, vacía si no.
        // La contraseña se convierte en hash aquí mismo para compararla con la guardada en la BD.
        public DataTable Login(E_Usuario obj)
        {
            return datos.Login(obj, Seguridad.Sha256(obj.clave));
        }

        // Lista las cuentas para la pantalla de Usuarios. "filtro" busca por usuario o nombre,
        // e "idRol" filtra por tipo de usuario (0 = todos).
        public DataTable Listar(string filtro, int idRol)
        {
            return datos.Listar(filtro, idRol);
        }

        // Cambia el nombre de usuario y, si se escribió una contraseña nueva, también la contraseña.
        public void ActualizarCuenta(int id, string username, string claveNueva)
        {
            // exigirClave = false: en una edición la contraseña puede quedar vacía para conservar la actual.
            Validar.Cuenta(username, claveNueva, false);

            // Sin contraseña nueva mandamos null, y la capa de datos entiende "no la cambies".
            string hash = string.IsNullOrEmpty(claveNueva) ? null : Seguridad.Sha256(claveNueva);
            try { datos.ActualizarCuenta(id, username.Trim(), hash); }
            catch (SqlException ex) { throw Validar.Traducir(ex); }   // por ejemplo, si el usuario ya existe
        }

        // Inhabilita una cuenta (baja lógica: no se borra nada, solo deja de poder entrar).
        // "id" es la cuenta que se quiere inhabilitar e "idRol" es el rol de esa cuenta.
        public void Desactivar(int id, int idRol)
        {
            // Nadie puede quitarse el acceso a sí mismo, porque se quedaría fuera del sistema.
            if (id == Sesion.IdUsuario)
                throw new Exception("No puede inhabilitar su propia cuenta.");

            // Comparamos el rol de la cuenta objetivo con el de quien tiene la sesión abierta.
            // Como esta pantalla solo la usa un administrador, es lo mismo que preguntar
            // "¿la cuenta objetivo también es de un administrador?". Entre administradores no se inhabilitan.
            if (idRol == Sesion.IdRol)
                throw new Exception("No puede inhabilitar la cuenta de un administrador.");
            datos.Desactivar(id);
        }

        // Vuelve a activar una cuenta inhabilitada. Sigue la misma regla de arriba con los administradores.
        public void Reactivar(int id, int idRol)
        {
            if (idRol == Sesion.IdRol)
                throw new Exception("No puede reactivar la cuenta de un administrador.");
            datos.Reactivar(id);
        }
    }
}