using System;
using System.Configuration;
using System.Data.SqlClient;
using NUnit.Framework;

namespace AutoWebSpa.Core
{
    public class ManejoSql
    {

        public SqlConnection conn = new SqlConnection();

        public SqlConnection AbrirConexion()
        {
            try
            {
                conn.ConnectionString = ConfigurationManager.AppSettings["StringDeConexion"];
                conn.Open();

            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
            return conn;
        }

        public void CerrarConexion()
        {
            try
            {
                conn.Close();
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }



    }
}
