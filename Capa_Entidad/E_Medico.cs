using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Entidad
{
    // Datos de un médico. Se usa para registrarlo y para editarlo desde la pantalla del administrador.
    public class E_Medico
    {
        // ID del médico. Es el mismo ID de su cuenta de usuario (la tabla Medico "cuelga" de la tabla Usuario).
        // Vale 0 mientras el médico todavía no se ha registrado.
        public int Id { get; set; }

        // Nombre de usuario con el que inicia sesión (no se puede repetir en todo el sistema).
        public string Username { get; set; }

        // Contraseña tal como la escribe la persona. Solo se usa al REGISTRAR: la capa de negocio la convierte
        // en hash antes de mandarla a la BD, así que nunca se guarda en texto normal.
        // Al editar un médico este campo se deja vacío.
        public string Clave { get; set; }

        // Datos personales.
        public string Nombre { get; set; }
        public string Apellido { get; set; }

        // El teléfono y el correo son opcionales; el correo, si se llena, no puede repetirse con otro médico.
        public string Telefono { get; set; }
        public string Correo { get; set; }

        // ID de la especialidad del médico (llave foránea hacia la tabla Especialidad).
        public int IdEspecialidad { get; set; }
    }
}
