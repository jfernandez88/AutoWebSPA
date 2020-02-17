using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoWebSpa.Core.Query
{
    public class QueryCtistaCtaBancariaMinMax : ManejoSql
    {

        public string codCuotapartista { get; set; }
        public string importeMinimo { get; set; }
        public string importeMaximo { get; set; }
        public string cuentaBancaria { get; set; }
        public string fondo { get; set; }

        public string rescateMinimo { get; set; }
        public string rescateMaximo { get; set; }

        string queryMinMaxSuscripcion = "SELECT top 1 c.CodInterfaz, ie.CodCondicionIngEgr, convert(decimal, SuscripcionMinima) as susMinima, convert(decimal, SuscripcionMaxima) as susMaxima, ctabanc.NumeroCuenta, f.Nombre as Fondo , convert(decimal, RescateMinimo) as rescateMinimo, convert(decimal, RescateMaximo) as RescateMaximo FROM USUARIOSEXTERNOS e " +
                "INNER JOIN USUARIOSEXTCPTREL relacion ON e.CodUsuario = relacion.CodUsuario " +
                "INNER JOIN CUOTAPARTISTAS c ON relacion.CodCuotapartista = c.CodCuotapartista " +
                "INNER JOIN LIQUIDACIONES liq ON liq.CodCuotapartista = c.CodCuotapartista " +
                "INNER JOIN CONDICIONESINGEGR ie ON liq.CodCondicionIngEgr = ie.CodCondicionIngEgr " +
                "INNER JOIN CPTCTASBANCARIAS ctabanc ON ctabanc.CodCuotapartista = c.CodCuotapartista " +
                "INNER Join FONDOS f ON f.CodFondo = liq.CodFondo " +
                "WHERE e.UserID = 'REMPLAZAR' " +
                "AND SuscripcionMinima > 0 " +
                "AND ctabanc.Descripcion LIKE  '%MONEDA%' " +
                "AND ctabanc.EstaAnulado = 0 " +
                "AND c.CodInterfaz != '2-000001280'" +
                "ORDER BY liq.FechaLiquidacion ";


        public QueryCtistaCtaBancariaMinMax(string Usuario, string Moneda)
        {
            ConsultaMinMaxSuscripcion(Usuario, Moneda);
        }


        public void ConsultaMinMaxSuscripcion(string Usuario, string Moneda)
        {

            AbrirConexion();
            string query = queryMinMaxSuscripcion.Replace("REMPLAZAR", Usuario);
            query = query.Replace("MONEDA", Moneda);
            SqlCommand Consulta = new SqlCommand(query, conn);
            SqlDataReader reader = Consulta.ExecuteReader();

            while (reader.Read())
            {
                codCuotapartista = reader[0].ToString();
                importeMinimo = reader[2].ToString();
                importeMaximo = reader[3].ToString();
                cuentaBancaria = reader[4].ToString();
                fondo = reader[5].ToString();
                rescateMinimo = reader[6].ToString();
                rescateMaximo = reader[7].ToString();
            }
            CerrarConexion();
        }
    }
}
