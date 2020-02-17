using NUnit.Framework;
using AutoWebSpa.Core;
using System;
using AutoWebSpa.Funciones;
using AutoWebSpa.Core.Query;
using System.Collections.Generic;
using AutoWebSpa.RepositorioDeObjetos;

namespace AutoWebSpa.TestSuites
{


    [TestFixture]
    [Parallelizable]
    public class TestSuite_ValoresDeCuota : Hooks
    {

        public TestSuite_ValoresDeCuota() : base(BrowerType.Chrome) { }
        FunLogin Login = new FunLogin();
        FunPrincipal principal = new FunPrincipal();
        FunValoresDeCuotaparte valoresDeCuotaparte = new FunValoresDeCuotaparte();
        FunMovimientos movimientos = new FunMovimientos();
        string modulo = "ValoresDeCuota";
        ManejadorDeReportes Reportes = new ManejadorDeReportes();


        public void ValidarPantallaValoresDeCuota_014()
        {
            string caso = "ValidarPantallaValoresDeCuota_014";
            try
            {
                //Inicio reporte y  Agrego datos
                Reportes.IniciarReporte(caso);

                //Creo Variables Requeridas para los datos   
                string cuotapartista = Datos.ReadData(caso, "NroCuenta");
                string user = Datos.ReadData(caso, "Usuario").Trim();
                string pass = Datos.ReadData(caso, "Contraseña").Trim();

                //1 - Paso Login
                //Login.Loguearse(user, pass, Driver);
                //Reportes.ReportarPasosDePrueba("PASS", "Login", "Login Ok " + user + " " + pass);

                //2 - Seleccionar valores de cuota
                principal.SeleccionarValorDeCuotaparte(Driver);
                Reportes.ReportarPasosDePrueba("PASS", "Seleccionar Valores de Cuota", "ok");

                //3 - Validar que se muestre Titulo Valor de Cuotaparte, 
                Base.DormirHilo(1);
                valoresDeCuotaparte.ValidarPantalla(Driver);
                Reportes.ReportarPasosDePrueba("PASS", "Validar Pantalla Valores de Cuotaparte", "ok");

                //Genero Reporte
                Reportes.GenerarReporte(modulo, caso, "PASS", "Caso OK", Driver);

            }
            catch (Exception e)
            {
                Reportes.GenerarReporte(modulo, caso, "FAIL", e.Message, Driver);
                Assert.Fail(e.Message);
            }

        }



        public void ValoresCuotaparte_Pdf_Excel()
        {
            string caso = "ValoresCuotaparte_Pdf_Excel";
            try
            {
                //Inicio reporte y  Agrego datos
                Reportes.IniciarReporte(caso);

                //Creo Variables Requeridas para los datos   
                string cuotapartista = Datos.ReadData(caso, "NroCuenta");
                string user = Datos.ReadData(caso, "Usuario").Trim();
                string pass = Datos.ReadData(caso, "Contraseña").Trim();

                //1 - Paso Login
                //Login.Loguearse(user, pass, Driver);
                //Reportes.ReportarPasosDePrueba("PASS", "Login", "Login Ok " + user + " " + pass);

                //2 - Seleccionar valores de cuota
                principal.SeleccionarValorDeCuotaparte(Driver);
                Reportes.ReportarPasosDePrueba("PASS", "Seleccionar Valores de Cuota", "ok");

                //3 - Validar que se pueda exprotar a pdf y excel
                movimientos.ExportarExcel(Driver, "ValoresCuotaparte.xlsx");
                Reportes.ReportarPasosDePrueba("PASS", "Exportar a Excel", "Se descargo el archivo correctamente");

                //Espera para descarga
                Base.DormirHilo(3);

                movimientos.ExportarEnPDF(Driver, "ValoresCuotaparte.pdf");
                Reportes.ReportarPasosDePrueba("PASS", "Exportar a PDF", "Se descargo el archivo correctamente");

                //Genero Reporte
                Reportes.GenerarReporte(modulo, caso, "PASS", "Caso OK", Driver);

            }
            catch (Exception e)
            {
                Reportes.GenerarReporte(modulo, caso, "FAIL", e.Message, Driver);
                Assert.Fail(e.Message);
            }

        }

    }

}




