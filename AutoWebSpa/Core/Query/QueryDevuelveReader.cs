using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using NUnit.Framework;

namespace AutoWebSpa.Core.Query
{
    class QueryDevuelveReader : ManejoSql
    {

        string queryCuotapartistasPorUser = "SELECT c.CodInterfaz as Cuotapartista FROM USUARIOSEXTERNOS e " +
                                            "INNER JOIN USUARIOSEXTCPTREL relacion ON e.CodUsuario = relacion.CodUsuario " +
                                            "INNER JOIN CUOTAPARTISTAS c ON relacion.CodCuotapartista = c.CodCuotapartista " +
                                            "WHERE e.UserID = 'REMPLAZARUSER' ";

        string queryDevuelveUltSolResc = "SELECT Top 1  CONVERT(VARCHAR(10), FechaAcreditacion, 103) as FechaAcreditacion, CONVERT(VARCHAR(10), FechaConcertacion, 103) as FechaConcertacion, NumSolicitud, Importe FROM SOLRESC res " +
                                        "INNER JOIN CUOTAPARTISTAS ctistas ON ctistas.CodCuotapartista = res.CodCuotapartista " +
                                        "WHERE ctistas.CodInterfaz = 'REMPLAZARCUOTAPARTISTA' " +
                                        "ORDER BY NumSolicitud DESC ";


        public List<string> DevolverCuotapartistas(string Usuario)
        {

            List<string> cuotapartistas = new List<string>();
            try
            {
                AbrirConexion();

                string query = queryCuotapartistasPorUser.Replace("REMPLAZARUSER", Usuario);
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


        public List<string> DevolverUltimaSolRescate(string Cuotapartista)
        {

            List<string> cuotapartistas = new List<string>();
            try
            {
                AbrirConexion();

                string query = queryDevuelveUltSolResc.Replace("REMPLAZARCUOTAPARTISTA", Cuotapartista);
                SqlCommand Consulta = new SqlCommand(query, conn);
                SqlDataReader reader = Consulta.ExecuteReader();

                while (reader.Read())
                {

                    cuotapartistas.Add(reader[0].ToString());
                    cuotapartistas.Add(reader[1].ToString());
                    cuotapartistas.Add(reader[2].ToString());
                    cuotapartistas.Add(reader[3].ToString());
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
