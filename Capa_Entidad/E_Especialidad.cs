using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Entidad
{
    // Una especialidad médica (Pediatría, Cardiología, etc.).
    // Es solo un contenedor de datos: el formulario la llena y la capa de negocio la valida antes de guardarla.
    public class E_Especialidad
    {
        // ID que le pone la BD (es autonumérico). Si vale 0, la especialidad es nueva y todavía no se guardó;
        // con ese 0 la capa de negocio sabe que debe hacer un INSERT en vez de un UPDATE.
        public int Id { get; set; }

        // Nombre de la especialidad. No se puede repetir (la BD tiene un UNIQUE) y mide máximo 80 caracteres.
        public string Nombre { get; set; }

        // Texto opcional que explica de qué trata la especialidad. Máximo 200 caracteres.
        public string Descripcion { get; set; }
    }

}
