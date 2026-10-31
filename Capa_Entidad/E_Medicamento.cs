using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Entidad
{
    // Un renglón de la receta: un medicamento con su dosis, frecuencia y duración.
    // esto NO es una tabla de la BD. La receta se guarda como texto en la tabla Receta;
    // esta clase solo sirve para ir armando la lista en pantalla y que la capa de negocio
    // la convierta en ese texto cuando el médico emite la receta.
    public class E_Medicamento
    {
        // Nombre del medicamento, por ejemplo "Amoxicilina".
        public string Medicamento { get; set; }

        // Cuánto tomar cada vez, por ejemplo "500 mg".
        public string Dosis { get; set; }

        // Cada cuánto, por ejemplo "cada 8 horas".
        public string Frecuencia { get; set; }

        // Por cuánto tiempo, por ejemplo "7 días".
        public string Duracion { get; set; }

        // Comentario extra para este medicamento (por ejemplo "tomar con alimentos"). Es opcional.
        public string Indicaciones { get; set; }
    }
}