using System;

namespace Proyecto_Catedra_UDB.Models
{
    public class Usuario
    {
        public int ID_Usuario { get; set; }
        public string Username { get; set; }
        public string Rol { get; set; }
        public int ID_Rol { get; set; }
        public string NombreCompleto { get; set; }

        public Usuario() { }

        public Usuario(int idUsuario, string username, string rol, int idRol, string nombreCompleto = null)
        {
            ID_Usuario = idUsuario;
            Username = username;
            Rol = rol;
            ID_Rol = idRol;
            NombreCompleto = nombreCompleto ?? username;
        }
    }
}
