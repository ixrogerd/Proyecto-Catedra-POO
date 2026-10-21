using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
namespace Capa_Negocio
{
    public static class Seguridad
    {
        public static string Sha256(string texto)
        {
            using (SHA256 sha = SHA256.Create())
            {
                byte[] bytes = sha.ComputeHash(Encoding.UTF8.GetBytes(texto));
                return string.Concat(bytes.Select(b => b.ToString("x2")));
            }
        }
    }
}
