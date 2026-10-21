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

        public static int IdUsuario { get; set; }
        public static string Username { get; set; }
        public static int IdRol { get; set; }
        public static string Rol { get; set; }
        public static string NombreCompleto { get; set; }

        public static void Limpiar()
        {
            IdUsuario = 0; IdRol = 0;
            Username = Rol = NombreCompleto = null;
        }
    }
}
