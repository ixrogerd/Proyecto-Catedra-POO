using System;
using System.Configuration;
using System.Data.SqlClient;

namespace Proyecto_Catedra_UDB.Connection
{
    /// <summary>
    /// Conexion centralizada. La cadena se lee de App.config (como en la guia 12).
    /// </summary>
    public static class DbConnection
    {
        private const string NombreCadena = "CitasMedicasConnection";
        private static string _connectionString; // null = usar App.config

        public static string GetConnectionString()
        {
            if (!string.IsNullOrEmpty(_connectionString))
                return _connectionString;

            ConnectionStringSettings cs = ConfigurationManager.ConnectionStrings[NombreCadena];
            if (cs == null || string.IsNullOrWhiteSpace(cs.ConnectionString))
                throw new InvalidOperationException(
                    "No se encontro la cadena de conexion '" + NombreCadena + "' en App.config.");

            return cs.ConnectionString;
        }

        public static void SetConnectionString(string connectionString)
        {
            _connectionString = connectionString;
        }

        public static SqlConnection CreateConnection()
        {
            return new SqlConnection(GetConnectionString());
        }
    }
}