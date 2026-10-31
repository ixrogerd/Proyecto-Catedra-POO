using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Text.RegularExpressions;

namespace Capa_Negocio
{
    // Caja de herramientas con las validaciones que se repiten en varias pantallas.
    // Si algo está mal, lanzan una Exception con un mensaje en español; los formularios la atrapan y se lo muestran al usuario.
    // Es "internal" a propósito: solo la capa de negocio la usa, los formularios nunca la llaman directamente.
    internal static class Validar
    {
        // Revisa que un texto obligatorio no venga vacío ni se pase del largo permitido.
        // "campo" es solo el nombre que aparece en el mensaje; "max" suele ser el tamaño de la columna en la BD.
        public static void Requerido(string valor, string campo, int max)
        {
            if (string.IsNullOrWhiteSpace(valor))
                throw new Exception("El campo " + campo + " es obligatorio.");
            if (valor.Trim().Length > max)
                throw new Exception("El campo " + campo + " no puede superar " + max + " caracteres.");
        }

        // El teléfono es opcional: si viene vacío lo dejamos pasar.
        // Si trae algo, tiene que parecer un teléfono: puede empezar con "+", luego un dígito y después
        // dígitos, guiones o espacios (en total entre 8 y 15 caracteres sin contar el "+").
        public static void Telefono(string t)
        {
            if (string.IsNullOrWhiteSpace(t)) return;
            if (!Regex.IsMatch(t.Trim(), @"^\+?[0-9][0-9\- ]{7,14}$"))
                throw new Exception("El teléfono no es válido.");
        }

        // El correo también es opcional. Solo revisamos el formato básico (algo@algo.algo, sin espacios)
        // y que no pase de 100 caracteres. No comprueba que el correo exista de verdad.
        public static void Correo(string c)
        {
            if (string.IsNullOrWhiteSpace(c)) return;
            if (c.Trim().Length > 100 || !Regex.IsMatch(c.Trim(), @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
                throw new Exception("El correo no es válido.");
        }

        // Valida los datos de una cuenta (usuario y contraseña).
        // "exigirClave" es true cuando se está CREANDO una cuenta (la contraseña es obligatoria)
        // y false cuando se está EDITANDO (si la dejan vacía, se queda la que ya tenía).
        public static void Cuenta(string username, string clave, bool exigirClave)
        {
            Requerido(username, "usuario", 50);
            if (username.Trim().Length < 4)
                throw new Exception("El usuario debe tener al menos 4 caracteres.");
            if (username.Trim().Contains(" "))
                throw new Exception("El usuario no puede tener espacios.");

            // La contraseña se revisa si es obligatoria o si, aunque sea opcional, la persona escribió algo.
            if ((exigirClave || !string.IsNullOrEmpty(clave)) && (clave == null || clave.Length < 6))
                throw new Exception("La contraseña debe tener al menos 6 caracteres.");
        }

        // Convierte errores técnicos de SQL Server en mensajes que una persona pueda entender.
        // Se usa dentro de un catch (SqlException) justo después de intentar guardar algo.
        public static Exception Traducir(SqlException ex)
        {
            // Errores controlados de sp_AgendarCita (los THROW 50001 a 50005 del script):
            // esos mensajes ya vienen escritos en español, así que se pasan tal cual.
            if (ex.Number >= 50001 && ex.Number <= 50005)
                return new Exception(ex.Message);

            // 2627 y 2601 son los números de SQL Server para "ya existe un registro igual" (UNIQUE duplicado).
            // Como el mensaje nombra el índice o la tabla que chocó, lo usamos para saber qué fue lo que se repitió.
            if (ex.Number == 2627 || ex.Number == 2601)
            {
                string m = ex.Message;
                if (m.Contains("UX_Cita_Medico_Horario")) return new Exception("Ese horario ya fue ocupado. Elija otra hora.");
                if (m.Contains("Correo")) return new Exception("Ya existe un registro con ese correo.");
                if (m.Contains("dbo.Usuario")) return new Exception("Ese nombre de usuario ya está en uso.");
                if (m.Contains("dbo.Especialidad")) return new Exception("Esa especialidad ya existe.");
            }

            // Si no reconocemos el error, lo devolvemos igual para no esconder lo que realmente pasó.
            return ex;
        }
    }
}

