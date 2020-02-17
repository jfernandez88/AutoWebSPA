using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace AutoWebSpa.Core.Query
{
    public class QuerysApis : ManejoSql
    {
        string QueryCuentaAnulada = "SELECT c.CodInterfaz as Cuotapartista FROM USUARIOSEXTERNOS e " +
                                    "INNER JOIN USUARIOSEXTCPTREL relacion ON e.CodUsuario = relacion.CodUsuario " +
                                    "INNER JOIN CUOTAPARTISTAS c ON relacion.CodCuotapartista = c.CodCuotapartista " +
                                    "INNER JOIN CPTCTASBANCARIAS banc ON banc.CodCuotapartista = c.CodCuotapartista " +
                                    "WHERE e.UserID = 'REMPLAZARUSER' " +
                                    "AND banc.EstaAnulado != 0 ";



        public List<string> CuentasAnuladas(string Usuario)
        {

            List<string> cuotapartistas = new List<string>();
            try
            {
                AbrirConexion();

                string query = QueryCuentaAnulada.Replace("REMPLAZARUSER", Usuario);
                SqlCommand Consulta = new SqlCommand(query, conn);
                SqlDataReader reader = Consulta.ExecuteReader();

                while (reader.Read())
                {

                    cuotapartistas.Add(reader[0].ToString());

                }

                CerrarConexion();
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
            return cuotapartistas;
        }

    }
}
