using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Capa_Datos
{
    // Ayudante que hace el trabajo repetitivo de hablar con SQL Server (abrir conexión, mandar la consulta, cerrar).
    // Es "internal": solo las clases de Capa_Datos pueden usarla. Los formularios y la capa de negocio no deben tocar la BD directamente.
    internal static class Conexion
    {
        // Crea una conexión nueva a la BD (todavía sin abrir).
        // La cadena de conexión se lee del App.config con el nombre "sql"; se lee el App.config del proyecto
        // que arranca el programa (el de los formularios), no uno de esta capa.
        public static SqlConnection Crear()
        {
            return new SqlConnection(ConfigurationManager.ConnectionStrings["sql"].ConnectionString);
        }

        // Texto vacío -> NULL en la BD
        // Sirve para los campos opcionales: si la persona no escribió nada, guardamos NULL en vez de un texto vacío.
        // Además le quita los espacios sobrantes al principio y al final.
        public static object Nulo(string s)
        {
            return string.IsNullOrWhiteSpace(s) ? (object)DBNull.Value : s.Trim();
        }
        // Para consultas que DEVUELVEN datos (SELECT o procedimientos que regresan una tabla).
        // "tipo" dice si "sql" es un texto SQL normal (CommandType.Text) o el nombre de un procedimiento (CommandType.StoredProcedure).
        // Los valores se mandan siempre como parámetros (@algo) y no pegados al texto de la consulta:
        // así evitamos errores con comillas y ataques de inyección SQL.
        public static DataTable Tabla(string sql, CommandType tipo, params SqlParameter[] ps)
        {
            // Los "using" cierran y liberan todo automáticamente al terminar, aunque algo falle.
            using (SqlConnection cn = Crear())
            using (SqlCommand cmd = new SqlCommand(sql, cn))
            using (SqlDataAdapter da = new SqlDataAdapter(cmd))
            {
                cmd.CommandType = tipo;
                cmd.Parameters.AddRange(ps);
                DataTable dt = new DataTable();

                // Fill abre la conexión, trae los datos, los pone en la tabla y vuelve a cerrar.
                da.Fill(dt);
                return dt;
            }
        }

        // Para instrucciones que CAMBIAN datos (INSERT, UPDATE, DELETE o procedimientos que guardan algo).
        // Devuelve cuántas filas se afectaron: sirve para saber si el UPDATE/DELETE realmente encontró algo (0 = no encontró nada).
        
        // Los procedimientos que tienen SET NOCOUNT ON devuelven -1 en vez de la cantidad, así que ese número
        // solo es confiable con instrucciones SQL directas.
        public static int Ejecutar(string sql, CommandType tipo, params SqlParameter[] ps)
        {
            using (SqlConnection cn = Crear())
            using (SqlCommand cmd = new SqlCommand(sql, cn))
            {
                cmd.CommandType = tipo;
                cmd.Parameters.AddRange(ps);

                // Aquí sí abrimos la conexión a mano, porque ExecuteNonQuery no la abre sola como lo hace Fill
                cn.Open();
                return cmd.ExecuteNonQuery();
            }
        }
    }

}
