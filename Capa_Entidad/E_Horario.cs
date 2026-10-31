using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Entidad
{
    // Un bloque de horario en el que un médico atiende, por ejemplo "lunes de 8:00 a 12:00".
    // Un médico puede tener varios bloques, incluso el mismo día (uno en la mañana y otro en la tarde),
    // siempre que no se traslapen entre sí.
    public class E_Horario
    {
        // ID del horario en la BD. 0 significa que todavía no se ha guardado.
        public int Id { get; set; }

        // Médico dueño de este horario (su ID es el mismo que el de su cuenta de usuario).
        public int IdMedico { get; set; }

        // Día de la semana como número, tal como lo guarda la BD.
        public int Dia { get; set; }              // 1=Lunes ... 7=Domingo

        // Hora en que empieza y hora en que termina la atención.
        // Son TimeSpan porque en SQL Server son columnas de tipo TIME.
        public TimeSpan HoraInicio { get; set; }
        public TimeSpan HoraFin { get; set; }
    }
}