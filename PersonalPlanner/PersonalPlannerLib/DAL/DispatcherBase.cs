using System;
using System.Collections.Generic;
using System.Data;
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
                string connectionString = @"Data Source=LAPTOP-54KT3JPH;Initial Catalog=PAV;Trusted_Connection=True";
                connection = new SqlConnection(connectionString);
            }
        }

        protected DataTable ExecutarProcedure(string pProcedure, params object[] pParametros)
        {
            DataTable table = new DataTable("Resultado");

            try
            {
                connection.Open();
                string sql = $"EXEC {pProcedure} {string.Join(",", pParametros.Select(p => $"{(p != null ? $"'{p.ToString()}'" : "NULL")}").ToArray())}";
                SqlCommand comando = new SqlCommand(sql, connection);
                SqlDataReader dataReader = comando.ExecuteReader();
                
                table.Load(dataReader);
                comando.Dispose();
                connection.Close();
            }
            catch (Exception ex)
            {
                if (connection != null && connection.State == ConnectionState.Open)
                    connection.Close();

                throw ex;
            }

            return table;
        }
    }
}
