using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Capa_Datos;
using Capa_Entidad;

namespace Capa_Negocio
{
    public class N_Receta
    {
        D_Receta datos = new D_Receta();

        public void ValidarMedicamento(E_Medicamento m)
        {
            Validar.Requerido(m.Medicamento, "medicamento", 100);
            Validar.Requerido(m.Dosis, "dosis", 50);
            Validar.Requerido(m.Frecuencia, "frecuencia", 50);
            Validar.Requerido(m.Duracion, "duración", 50);
            if (m.Indicaciones != null && m.Indicaciones.Length > 150)
                throw new Exception("Las indicaciones no pueden superar 150 caracteres.");
        }

        public void Emitir(int idCita, int idMedico, List<E_Medicamento> lista)
        {
            if (idCita <= 0)
                throw new Exception("Seleccione la cita de la receta (solo aparecen citas atendidas sin receta).");
            if (lista == null || lista.Count == 0)
                throw new Exception("Debe agregar al menos un medicamento.");

            StringBuilder desc = new StringBuilder();
            StringBuilder ind = new StringBuilder();
            int n = 1;
            foreach (E_Medicamento m in lista)
            {
                desc.AppendLine(n + ". " + m.Medicamento + " | " + m.Dosis + " | " + m.Frecuencia + " | " + m.Duracion);
                if (!string.IsNullOrWhiteSpace(m.Indicaciones))
                    ind.AppendLine(m.Medicamento + ": " + m.Indicaciones.Trim());
                n++;
            }

            string d = desc.ToString().TrimEnd();
            string i = ind.ToString().TrimEnd();
            if (d.Length > 500 || i.Length > 500)
                throw new Exception("La receta es muy extensa (máximo 500 caracteres en medicamentos y en indicaciones).");

            if (datos.Insertar(idCita, idMedico, d, i) == 0)
                throw new Exception("No se pudo emitir: la cita no es suya, aún no está atendida o ya tiene receta.");
        }
    }
}