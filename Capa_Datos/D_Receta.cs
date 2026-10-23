using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
namespace Capa_Datos
{
    public class D_Receta
    {
        // Solo inserta si la cita es del médico, está Atendida y no tiene receta. Devuelve filas insertadas.
        public int Insertar(int idCita, int idMedico, string descripcion, string indicaciones)
        {
            return Conexion.Ejecutar(
                "INSERT INTO Receta (ID_Cita, Descripcion, Indicaciones) " +
                "SELECT c.ID_Cita, @Desc, @Ind FROM Cita c " +
                "WHERE c.ID_Cita = @C AND c.ID_Medico = @M AND c.ID_Estado = 2 " +
                "AND NOT EXISTS (SELECT 1 FROM Receta r WHERE r.ID_Cita = c.ID_Cita)",
                CommandType.Text,
                new SqlParameter("@Desc", descripcion),
                new SqlParameter("@Ind", Conexion.Nulo(indicaciones)),
                new SqlParameter("@C", idCita),
                new SqlParameter("@M", idMedico));
        }
    }
}