using NUnit.Framework;
using AutoWebSpa.Core;
using System;
using AutoWebSpa.Funciones;
using AutoWebSpa.Core.Query;


namespace AutoWebSpa.TestSuites
{


    [TestFixture]
    [Parallelizable]
    public class TestSuite_Movimientos : Hooks
    {

        public TestSuite_Movimientos() : base(BrowerType.Chrome) { }
        FunLogin Login = new FunLogin();
        FunPrincipal principal = new FunPrincipal();
        FunMovimientos movimientos = new FunMovimientos();
        string modulo = "Movimientos";
        ManejadorDeReportes Reportes = new ManejadorDeReportes();


        public void Movimientos_Descargar_PDF_XLSX_Comprobante_006()
        {
            string caso = "Movimientos_Descargar_PDF_XLSX_Comprobante_006";
            try
            {
                //Inicio reporte y  Agrego datos
                Reportes.IniciarReporte("Movimientos_Descargar_PDF_XLSX_Comprobante_006");

                //Creo Variables Requeridas para los datos                
                string user = Datos.ReadData(caso, "Usuario").Trim();
                string pass = Datos.ReadData(caso, "Contraseña").Trim();

                //1 - Paso Login
                //Login.Loguearse(user, pass, Driver);
                //Reportes.ReportarPasosDePrueba("PASS", "Login", "Login Ok " + user + " " + pass);

                //2 -  Seleccionar Movimientos
                principal.SeleccionarMovimientos(Driver);

                //3 - Click en Exportar a Excel
                movimientos.ExportarExcel(Driver, "Movimientos.xlsx");
                Reportes.ReportarPasosDePrueba("PASS", "Exportar a Excel", "Se descargo el archivo correctamente");

                //4 -  Click en Exportar a PDF
                movimientos.ExportarEnPDF(Driver, "Movimientos.pdf");
                Reportes.ReportarPasosDePrueba("PASS", "Exportar a PDF", "Se descargo el archivo correctamente");

                //Genero Reporte
                Reportes.GenerarReporte(modulo, caso, "PASS", "CASO OK", Driver);

            }
            catch (Exception e)
            {
                Reportes.GenerarReporte(modulo, caso, "FAIL", e.Message, Driver);
                Assert.Fail(e.Message);
            }

        }


        public void Principal_BotonSalir_012()
        {
            string caso = "Principal_BotonSalir_012";
            try
            {
                //Inicio reporte y  Agrego datos
                Reportes.IniciarReporte(caso);

                //Creo Variables Requeridas para los datos                
                string user = Datos.ReadData(caso, "Usuario").Trim();
                string pass = Datos.ReadData(caso, "Contraseña").Trim();

                //1 - Paso Login
                Login.Loguearse(user, pass, Driver);
                Reportes.ReportarPasosDePrueba("PASS", "Login", "Login Ok " + user + " " + pass);

                //2 - Seleccionar Cuenta
                Base.Esperar(5, principal.BotonSeleccionarCuenta, Driver);
                Driver.FindElement(principal.BotonSeleccionarCuenta).Click();
                Reportes.ReportarPasosDePrueba("PASS", "Click en Seleccionar Cuenta", "ok");

                //3 - Click En Salir
                Base.Esperar(5, principal.BotonSalir, Driver);
                Driver.FindElement(principal.BotonSalir).Click();
                Reportes.ReportarPasosDePrueba("PASS", "Click en Boton Salir", "ok");

                //4 -  Validar que regrese a la pantalla de Login
                Login.Loguearse(user, pass, Driver);
                Reportes.ReportarPasosDePrueba("PASS", "Validar que regrese a la pantalla de Login", "ok");

                //Genero Reporte
                Reportes.GenerarReporte(modulo, caso, "PASS", "CASO OK", Driver);

            }
            catch (Exception e)
            {
                Reportes.GenerarReporte(modulo, caso, "FAIL", e.Message, Driver);
                Assert.Fail(e.Message);
            }

        }




    }

}




