using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Entidad
{
    public class E_Horario
    {
        public int Id { get; set; }
        public int IdMedico { get; set; }
        public int Dia { get; set; }              // 1=Lunes ... 7=Domingo
        public TimeSpan HoraInicio { get; set; }
        public TimeSpan HoraFin { get; set; }
    }
}