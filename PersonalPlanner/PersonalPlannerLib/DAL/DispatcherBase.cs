using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalPlannerLib.DAL
{
    class DispatcherBase
    {
        static SqlConnection connection;

        public DispatcherBase()
        {
            if (connection == null)
            {
                string connectionString = @"Data Source=LAPTOP-54KT3JPH;Initial Catalog=PAV;User ID=supervisor;Password=123456";
                connection = new SqlConnection(connectionString);
            }
        }

        protected SqlDataReader ExecutarProcedure(string pProcedure, params object[] pParametros)
        {
            connection.Open();
            string sql = $"EXEC {pProcedure} {string.Join(",", pParametros.Select(p => p.ToString()).ToArray())}";
            SqlCommand comando = new SqlCommand(sql, connection);
            SqlDataReader dataReader = comando.ExecuteReader();
            comando.Dispose();
            connection.Close();

            return dataReader;
        }
    }
}
