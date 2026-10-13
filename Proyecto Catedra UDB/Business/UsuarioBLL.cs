using System;
using Proyecto_Catedra_UDB.Data;
using Proyecto_Catedra_UDB.Models;

namespace Proyecto_Catedra_UDB.Business
{
    /// <summary>
    /// Capa de Negocio: valida, hashea la contrasena y abre la sesion.
    /// El formulario solo habla con esta clase.
    /// </summary>
    public class UsuarioBLL
    {
        /// <returns>Usuario autenticado, o null si usuario/contrasena son incorrectos.</returns>
        public static Usuario Login(string username, string password)
        {
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrEmpty(password))
                throw new ArgumentException("Usuario y contrasena son requeridos.");

            Usuario usuario = UsuarioDAO.Login(username.Trim(), Seguridad.Hash(password));

            if (usuario != null)
                Sesion.Iniciar(usuario);

            return usuario;
        }
    }
}
