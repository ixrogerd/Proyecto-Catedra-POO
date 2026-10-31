using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
namespace Capa_Datos
{
    // Acceso a datos de las recetas. Por ahora solo guarda; para consultarlas se usan los métodos de D_Cita.
    public class D_Receta
    {
        // Solo inserta si la cita es del médico, está Atendida y no tiene receta. Devuelve filas insertadas.
        public int Insertar(int idCita, int idMedico, string descripcion, string indicaciones)
        {

            // En vez de un INSERT con VALUES usamos INSERT ... SELECT: el SELECT busca la cita pero únicamente la devuelve
            // si cumple las tres condiciones del WHERE (es de ese médico, ID_Estado = 2 que es "Atendida",
            // y no existe ya una receta para ella). Si alguna falla, el SELECT no devuelve nada y no se inserta nada.
            // Eso protege los datos aunque alguien se salte las validaciones de la pantalla, y por eso
            // la capa de negocio revisa si el resultado fue 0 filas.
            return Conexion.Ejecutar(
                "INSERT INTO Receta (ID_Cita, Descripcion, Indicaciones) " +
                "SELECT c.ID_Cita, @Desc, @Ind FROM Cita c " +
                "WHERE c.ID_Cita = @C AND c.ID_Medico = @M AND c.ID_Estado = 2 " +
                "AND NOT EXISTS (SELECT 1 FROM Receta r WHERE r.ID_Cita = c.ID_Cita)",
                CommandType.Text,
                new SqlParameter("@Desc", descripcion),
                new SqlParameter("@Ind", Conexion.Nulo(indicaciones)),   // sin indicaciones -> NULL
                new SqlParameter("@C", idCita),
                new SqlParameter("@M", idMedico));
        }
    }
}