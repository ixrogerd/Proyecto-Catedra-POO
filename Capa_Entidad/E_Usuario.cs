using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Entidad
{
    // Lo mínimo para iniciar sesión: el usuario y la contraseña que se escriben en el login.
    // Las propiedades van en minúscula porque así las usamos desde la guía 12 de la materia.
    public class E_Usuario
    {
        // Nombre de usuario escrito en el login.
        public string usuario { get; set; }

        // Contraseña escrita en el login, en texto normal. Solo vive el tiempo que tarda el login:
        // la capa de negocio la convierte en hash para compararla con la que está guardada en la BD.
        public string clave { get; set; }
    }
}
