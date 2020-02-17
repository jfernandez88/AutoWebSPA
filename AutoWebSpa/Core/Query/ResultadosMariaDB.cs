using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using NUnit.Framework;

namespace AutoWebSpa.Core.Query
{
    public class ResultadosMariaDB : ManejoSql
    {

        string insertResultado = "INSERT INTO `qaa`.`webspa` (`iteracion`,`test`,`resultado`,`fecha`) VALUES ('RemIt','RemTest','RemRes','RemFecha')";
        string connString = ConfigurationManager.AppSettings["StrConnectionMariaDb"];
        static string connString2 = "Server=192.168.22.70;User ID=jfernandez;Password=maria1945;Database=qaa";

        public void RegistarAsync(string iteracion,string test,string resultado)
        {

            string fecha = DateTime.Now.ToString("yyyy-MM-dd H:mm:ss");

            string query = insertResultado.Replace("RemIt",iteracion);
            query = query.Replace("RemTest", test);
            query = query.Replace("RemRes",resultado);
            query = query.Replace("RemFecha",fecha);
            

            using (var connection = new MySqlConnection(connString))
            {
                connection.Open();

                using (var command = new MySqlCommand(query, connection))
                using (var reader = command.ExecuteReader())
                connection.Close();
            }

        }

        public static string GetUltimaIteracion()
        {
            int it = 0;
            try
            {
                
                string query = "SELECT iteracion FROM webspa ORDER BY iteracion DESC LIMIT 1";


                using (var connection = new MySqlConnection(connString2))
                {
                    connection.Open();

                    using (var command = new MySqlCommand(query, connection))
                    using (var reader = command.ExecuteReader())

                        while (reader.Read())
                        {
                            it = reader.GetInt32(0);
                            int aux = it + 1;
                            it = aux;

                        }

                    connection.Close();
                }

                return it.ToString();
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
                return it.ToString();
            }
        }


    }
}
