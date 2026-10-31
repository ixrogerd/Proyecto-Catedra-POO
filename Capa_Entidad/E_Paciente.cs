using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Entidad
{
    // Datos de un paciente. Se usa para registrarlo y para editarlo desde la pantalla del administrador.
    public class E_Paciente
    {
        // ID del paciente. Igual que con el médico, es el mismo ID de su cuenta de usuario.
        // Vale 0 mientras todavía no se ha registrado.
        public int Id { get; set; }

        // Nombre de usuario con el que inicia sesión.
        public string Username { get; set; }

        // Contraseña escrita por la persona. Solo se usa al registrar: la capa de negocio la convierte en hash
        // antes de guardarla. Al editar un paciente queda vacía.
        public string Clave { get; set; }

        // Datos personales.
        public string Nombre { get; set; }
        public string Apellido { get; set; }

        // Fecha de nacimiento (obligatoria en la BD). No puede ser futura.
        public DateTime FechaNacimiento { get; set; }

        // Teléfono y correo son opcionales; el correo, si se llena, no puede repetirse con otro paciente.
        public string Telefono { get; set; }
        public string Correo { get; set; }
    }
}
