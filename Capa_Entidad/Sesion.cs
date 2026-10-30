using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Entidad
{
    public static class Sesion
    {
        public const int Paciente = 1, Medico = 2, Administrador = 3;

        public static int IdUsuario { get; private set; }
        public static string Username { get; private set; }
        public static int IdRol { get; private set; }
        public static string Rol { get; private set; }
        public static string NombreCompleto { get; private set; }

        public static void Limpiar()
        {
            IdUsuario = 0; IdRol = 0;
            Username = Rol = NombreCompleto = null;
        }

        public static void Iniciar(int id, string user, int idRol, string rol, string nombre)
        {
            IdUsuario = id;
            Username = user;
            IdRol = idRol;
            Rol = rol;
            NombreCompleto = nombre;
        }
    }
}
