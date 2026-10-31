using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Capa_Datos;
using Capa_Entidad;

namespace Capa_Negocio
{
    // Lógica de las recetas médicas.
    // Una cita puede tener máximo UNA receta y en la BD se guarda como texto (no hay tabla de medicamentos),
    // así que aquí convertimos la lista de medicamentos que armó el médico en ese texto.
    public class N_Receta
    {
        // La capa de datos, que es la única que habla con SQL Server.
        D_Receta datos = new D_Receta();

        // Revisa UN medicamento antes de agregarlo a la lista de la pantalla.
        // Los límites de largo están pensados para que, sumando varios medicamentos, quepan en los 500 caracteres que permite la BD.
        public void ValidarMedicamento(E_Medicamento m)
        {
            // Estos cuatro datos son obligatorios en cada medicamento.
            Validar.Requerido(m.Medicamento, "medicamento", 100);
            Validar.Requerido(m.Dosis, "dosis", 50);
            Validar.Requerido(m.Frecuencia, "frecuencia", 50);
            Validar.Requerido(m.Duracion, "duración", 50);

            // Las indicaciones son opcionales; solo limitamos su largo.
            if (m.Indicaciones != null && m.Indicaciones.Length > 150)
                throw new Exception("Las indicaciones no pueden superar 150 caracteres.");
        }

        // Arma la receta con todos los medicamentos de la lista y la guarda.
        public void Emitir(int idCita, int idMedico, List<E_Medicamento> lista)
        {
            // Lo básico primero: tiene que haber una cita elegida y al menos un medicamento.
            if (idCita <= 0)
                throw new Exception("Seleccione la cita de la receta (solo aparecen citas atendidas sin receta).");
            if (lista == null || lista.Count == 0)
                throw new Exception("Debe agregar al menos un medicamento.");

            // En la tabla Receta caben dos textos: "Descripcion" (los medicamentos) e "Indicaciones".
            // Los vamos armando línea por línea con StringBuilder, que es más eficiente que ir sumando strings.
            StringBuilder desc = new StringBuilder();
            StringBuilder ind = new StringBuilder();
            int n = 1;   // numera los medicamentos: 1., 2., 3. ...
            foreach (E_Medicamento m in lista)
            {
                // Una línea por medicamento, con los datos separados por " | ".
                // Ejemplo: "1. Amoxicilina | 500 mg | cada 8 horas | 7 días"
                desc.AppendLine(n + ". " + m.Medicamento + " | " + m.Dosis + " | " + m.Frecuencia + " | " + m.Duracion);

                // Las indicaciones (si las hay) van en el otro texto, con el nombre del medicamento por delante
                // para saber a cuál se refieren.
                if (!string.IsNullOrWhiteSpace(m.Indicaciones))
                    ind.AppendLine(m.Medicamento + ": " + m.Indicaciones.Trim());
                n++;
            }

            // TrimEnd quita el salto de línea que AppendLine deja al final de cada texto.
            string d = desc.ToString().TrimEnd();
            string i = ind.ToString().TrimEnd();

            // Las columnas de la BD miden 500 caracteres: si nos pasamos, avisamos aquí
            // en vez de dejar que SQL Server falle con un error difícil de entender.
            if (d.Length > 500 || i.Length > 500)
                throw new Exception("La receta es muy extensa (máximo 500 caracteres en medicamentos y en indicaciones).");

            // Insertar devuelve cuántas filas se guardaron. Si fue 0, la consulta no encontró una cita válida:
            // no es de este médico, todavía no está atendida o ya tiene receta.
            if (datos.Insertar(idCita, idMedico, d, i) == 0)
                throw new Exception("No se pudo emitir: la cita no es suya, aún no está atendida o ya tiene receta.");
        }
    }
}
