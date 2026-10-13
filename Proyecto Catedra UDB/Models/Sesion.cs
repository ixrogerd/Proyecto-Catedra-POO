using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Catedra_UDB.Models
{
    /// <summary>Guarda el usuario que inicio sesion (equivale a usuario_nombre/area de la guia 12).</summary>
    public static class Sesion
    {
        public static Usuario UsuarioActual { get; private set; }

        public static bool HayUsuario
        {
            get { return UsuarioActual != null; }
        }

        public static void Iniciar(Usuario usuario)
        {
            UsuarioActual = usuario;
        }

        public static void Cerrar()
        {
            UsuarioActual = null;
        }
    }
}
