using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Capa_Datos;
using Capa_Entidad;
namespace Capa_Negocio
{
    public class N_Horario
    {
        D_Horario datos = new D_Horario();

        public DataTable Listar(int idMedico) { return datos.Listar(idMedico); }

        public void Registrar(E_Horario h)
        {
            ValidarHorario(h);
            datos.Insertar(h);
        }

        public void Actualizar(E_Horario h)
        {
            if (h.Id <= 0) throw new Exception("Seleccione un horario.");
            ValidarHorario(h);
            if (datos.CitasPendientesFuera(h.Id, h.IdMedico, h.Dia, h.HoraInicio, h.HoraFin) > 0)
                throw new Exception("Hay citas pendientes que quedarían fuera del nuevo horario. Cancélelas primero.");
            if (datos.Actualizar(h) == 0) throw new Exception("El horario no existe.");
        }

        public void Eliminar(int id, int idMedico)
        {
            if (id <= 0) throw new Exception("Seleccione un horario.");
            if (datos.CitasPendientesFuera(id, idMedico, 0, TimeSpan.Zero, TimeSpan.Zero) > 0)
                throw new Exception("Hay citas pendientes en ese horario. Cancélelas primero.");
            if (datos.Eliminar(id, idMedico) == 0) throw new Exception("El horario no existe.");
        }

        private void ValidarHorario(E_Horario h)
        {
            if (h.Dia < 1 || h.Dia > 7) throw new Exception("Seleccione un día.");
            if (h.HoraFin <= h.HoraInicio)
                throw new Exception("La hora de fin debe ser mayor que la hora de inicio.");
            if (h.HoraInicio.Minutes % N_Cita.DuracionMin != 0 || h.HoraFin.Minutes % N_Cita.DuracionMin != 0)
                throw new Exception("Las horas deben ir en bloques de " + N_Cita.DuracionMin +
                                    " minutos (por ejemplo 08:00 o 08:30).");
            if (datos.HayTraslape(h.IdMedico, h.Dia, h.HoraInicio, h.HoraFin, h.Id))
                throw new Exception("Ese horario se traslapa con otro que ya tiene ese día.");
        }
    }
}