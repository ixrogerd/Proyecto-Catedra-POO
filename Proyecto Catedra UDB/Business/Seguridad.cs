using System.Security.Cryptography;
using System.Text;

namespace Proyecto_Catedra_UDB.Business
{
    public static class Seguridad
    {
        /// <summary>SHA-256 en hexadecimal minuscula (igual que LOWER(CONVERT(..., 2)) en SQL Server).</summary>
        public static string Hash(string textoPlano)
        {
            using (SHA256 sha = SHA256.Create())
            {
                byte[] bytes = sha.ComputeHash(Encoding.UTF8.GetBytes(textoPlano));
                StringBuilder sb = new StringBuilder(bytes.Length * 2);
                foreach (byte b in bytes)
                    sb.Append(b.ToString("x2"));
                return sb.ToString();
            }
        }
    }
}
