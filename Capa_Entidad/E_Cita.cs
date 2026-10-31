using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Entidad
{
    // Una cita médica tal como viaja entre las capas.
    // Esta clase no tiene lógica: solo carga los datos para pasarlos del formulario
    // a la capa de negocio (que los valida) y de ahí a la capa de datos (que los guarda).
    public class E_Cita
    {
        // Número de la cita en la BD (ID_Cita). Cuando vamos a agendar una nueva todavía no existe, así que queda en 0.
        public int Id { get; set; }

        // Día de la cita. Aquí solo nos importa la fecha; la hora va en la propiedad de abajo.
        public DateTime Fecha { get; set; }

        // Hora de inicio. Es TimeSpan porque en SQL Server la columna es de tipo TIME.
        public TimeSpan Hora { get; set; }

        // Por qué viene el paciente. Es opcional (puede ir vacío) y mide máximo 200 caracteres.
        public string Motivo { get; set; } 

        // Quién pide la cita y con qué médico.
        // el ID del paciente y el del médico
        // son el mismo ID de su cuenta de usuario, por eso salen de Sesion.IdUsuario cuando es quien está logueado.
        public int IdPaciente { get; set; }
        public int IdMedico { get; set; }
    }
}
