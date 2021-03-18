using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Util
{
    public class ConnectionDB : IDisposable
    {
        private SqlConnection conn;

        private static ConnectionDB _instance;

        private ConnectionDB()
        {
            conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConexaoSQLServer"].ConnectionString);
            conn.Open();
        }

        public static ConnectionDB GetConnection()
        {
            if (_instance == null)
                _instance = new ConnectionDB();
            return _instance;
        }

        public void ExecQuery(string query)
        {
            var cmd = new SqlCommand
            {
                CommandText = query,
                CommandType = CommandType.Text,
                Connection = conn
            };
            cmd.ExecuteNonQuery();
        }

        public SqlDataReader ExecQueryReturn(string query)
        {
            var cmd = new SqlCommand(query, conn);
            return cmd.ExecuteReader();
        }

        public void Dispose()
        {
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }
        }
    }
}
