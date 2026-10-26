using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Text.RegularExpressions;

namespace Capa_Negocio
{
    internal static class Validar
    {
        public static void Requerido(string valor, string campo, int max)
        {
            if (string.IsNullOrWhiteSpace(valor))
                throw new Exception("El campo " + campo + " es obligatorio.");
            if (valor.Trim().Length > max)
                throw new Exception("El campo " + campo + " no puede superar " + max + " caracteres.");
        }

        public static void Telefono(string t)
        {
            if (string.IsNullOrWhiteSpace(t)) return;
            if (!Regex.IsMatch(t.Trim(), @"^\+?[0-9][0-9\- ]{7,14}$"))
                throw new Exception("El teléfono no es válido.");
        }

        public static void Correo(string c)
        {
            if (string.IsNullOrWhiteSpace(c)) return;
            if (c.Trim().Length > 100 || !Regex.IsMatch(c.Trim(), @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
                throw new Exception("El correo no es válido.");
        }

        public static void Cuenta(string username, string clave, bool exigirClave)
        {
            Requerido(username, "usuario", 50);
            if (username.Trim().Length < 4)
                throw new Exception("El usuario debe tener al menos 4 caracteres.");
            if (username.Trim().Contains(" "))
                throw new Exception("El usuario no puede tener espacios.");
            if ((exigirClave || !string.IsNullOrEmpty(clave)) && (clave == null || clave.Length < 6))
                throw new Exception("La contraseña debe tener al menos 6 caracteres.");
        }

        // Convierte errores de duplicado de SQL en mensajes entendibles
        public static Exception Traducir(SqlException ex)
        {
            // Errores controlados de sp_AgendarCita: ya vienen en español
            if (ex.Number >= 50001 && ex.Number <= 50005)
                return new Exception(ex.Message);

            if (ex.Number == 2627 || ex.Number == 2601)
            {
                string m = ex.Message;
                if (m.Contains("UX_Cita_Medico_Horario")) return new Exception("Ese horario ya fue ocupado. Elija otra hora.");
                if (m.Contains("Correo")) return new Exception("Ya existe un registro con ese correo.");
                if (m.Contains("dbo.Usuario")) return new Exception("Ese nombre de usuario ya está en uso.");
                if (m.Contains("dbo.Especialidad")) return new Exception("Esa especialidad ya existe.");
            }
            return ex;
        }
    }
}
