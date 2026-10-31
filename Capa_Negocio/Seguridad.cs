using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
namespace Capa_Negocio
{
    // Todo lo relacionado con proteger contraseñas.
    // Es estática porque no necesita guardar nada: recibe un texto y devuelve otro.
    public static class Seguridad
    {
        // Convierte una contraseña en su "huella" SHA-256 (un texto de 64 caracteres).
        // Esa huella es lo que guardamos en la BD, así nunca se almacena la contraseña real.
        // Es de una sola vía: de la huella no se puede volver a la contraseña; para comprobar un login
        // se calcula la huella de lo que escribió la persona y se compara con la guardada.
        // (Para un sistema real habría que agregarle "sal" o usar algo como PBKDF2; para el proyecto de cátedra alcanza.)
        public static string Sha256(string texto)
        {
            using (SHA256 sha = SHA256.Create())
            {
                // Pasamos el texto a bytes (UTF8) y calculamos el hash.
                byte[] bytes = sha.ComputeHash(Encoding.UTF8.GetBytes(texto));

                // Cada byte se escribe como dos caracteres hexadecimales en minúscula ("x2").
                // Es importante que sea minúscula porque el script de la BD también guarda el hash así
                // (LOWER(CONVERT(...))); si no coincidieran, ningún usuario de prueba podría entrar.
                return string.Concat(bytes.Select(b => b.ToString("x2")));
            }
        }
    }
}
