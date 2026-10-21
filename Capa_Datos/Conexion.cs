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
    internal static class Conexion
    {
        public static SqlConnection Crear()
        {
            return new SqlConnection(ConfigurationManager.ConnectionStrings["sql"].ConnectionString);
        }

        // Texto vacío -> NULL en la BD
        public static object Nulo(string s)
        {
            return string.IsNullOrWhiteSpace(s) ? (object)DBNull.Value : s.Trim();
        }

        public static DataTable Tabla(string sql, CommandType tipo, params SqlParameter[] ps)
        {
            using (SqlConnection cn = Crear())
            using (SqlCommand cmd = new SqlCommand(sql, cn))
            using (SqlDataAdapter da = new SqlDataAdapter(cmd))
            {
                cmd.CommandType = tipo;
                cmd.Parameters.AddRange(ps);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        public static void Ejecutar(string sql, CommandType tipo, params SqlParameter[] ps)
        {
            using (SqlConnection cn = Crear())
            using (SqlCommand cmd = new SqlCommand(sql, cn))
            {
                cmd.CommandType = tipo;
                cmd.Parameters.AddRange(ps);
                cn.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }

}
