using NUnit.Framework;
using AutoWebSpa.Core;
using System;
using AutoWebSpa.Funciones;
using AutoWebSpa.Core.Query;

namespace AutoWebSpa.TestSuites
{


    [TestFixture]
    [Parallelizable]
    public class TestSuite_Rescates : Hooks
    {

        public TestSuite_Rescates() : base(BrowerType.Chrome) { }
        FunLogin Login = new FunLogin();
        FunPrincipal principal = new FunPrincipal();
        FunOperar operar = new FunOperar();
        FunMovimientos movimientos = new FunMovimientos();
        ManejadorDeReportes Reportes = new ManejadorDeReportes();
        string modulo = "Rescates";





        public void OperarRescateParcialPorCuotaparte_005()
        {
            string caso = "OperarRescateParcialPorCuotaparte_005";
            try
            {
                //Inicio reporte y  Agrego datos
                Reportes.IniciarReporte("OperarRescateParcialPorCuotaparte_005");

                //Creo Variables Requeridas para los datos                
                string user = Datos.ReadData(caso, "Usuario").Trim();
                string pass = Datos.ReadData(caso, "Contraseña").Trim();
                string NrCuenta = Datos.ReadData(caso, "NroCuenta").Trim();
                string cuenta = Datos.ReadData(caso, "Cuenta").Trim();
                string fondo = Datos.ReadData(caso, "Fondo").Trim();
                string importe = Datos.ReadData(caso, "Importe").Trim();

                //1 - Paso Login
                //Login.Loguearse(user, pass, Driver);
                //Reportes.ReportarPasosDePrueba("PASS", "Login", "Login Ok" + user + " " + pass);

                //2 -  Seleccionar Cuenta y Seleccionar Operar
                principal.SeleccionarOperar(Driver, NrCuenta);
                Reportes.ReportarPasosDePrueba("PASS", "Seleccionar Cuenta y Seleccionar Operar", "Se selecciono cuenta: " + NrCuenta);


                //3 -  Seleccionar Fondo y Rescatar
                operar.RescatarFondo(fondo, importe, "Parcial por Cuotapartes", Driver);
                Reportes.ReportarPasosDePrueba("PASS", "Rescatar Fondo", fondo + "Importe: " + importe);

                //4 -  Aceptar Condiciones
                operar.AceptarCondiciones(Driver);
                Reportes.ReportarPasosDePrueba("PASS", "Aceptar Condiciones", "ok");

                //5 -  Aceptar Rescate
                operar.AceptarRescate(Driver);
                Reportes.ReportarPasosDePrueba("PASS", "Aceptar Rescate", "ok");

                //6 - Validar confirmacion
                operar.ValidarConfirmacion(Driver, fondo, importe, cuenta, true);
                Reportes.ReportarPasosDePrueba("PASS", "Validar Confirmacion", "En el tk se muestra: " + fondo + " " + cuenta + " " + importe);

                //7 -  Click en Confirmar
                operar.ConfirmarSuscripcion(Driver);

                //8 - Validar Comprobante
                //operar.ValidarComprobante(fondo, importe, cuenta, "Cuotaparte", Driver);

                //Genero Reporte
                Reportes.GenerarReporte(modulo, caso, "PASS", "CASO OK", Driver);

            }
            catch (Exception e)
            {
                Reportes.GenerarReporte(modulo, caso, "FAIL", e.Message, Driver);
                Assert.Fail(e.Message);
            }

        }



        public void OperarRescatePorImporteValorMin_016()
        {
            string caso = "OperarRescatePorImporteValorMin_016";
            try
            {
                //Inicio reporte y  Agrego datos
                Reportes.IniciarReporte(caso);

                //Creo Variables Requeridas para los datos                
                string user = Datos.ReadData(caso, "Usuario").Trim();
                string pass = Datos.ReadData(caso, "Contraseña").Trim();
                string NrCuenta = Datos.ReadData(caso, "NroCuenta").Trim();
                string cuenta = Datos.ReadData(caso, "Cuenta").Trim();
                string fondo = Datos.ReadData(caso, "Fondo").Trim();
                string importe = "0";

                //1 - Paso Login
                Login.Loguearse(user, pass, Driver);
                Reportes.ReportarPasosDePrueba("PASS", "Login", "Login Ok" + user + " " + pass);

                //2 -  Seleccionar Cuenta y Seleccionar Operar
                principal.SeleccionarOperar(Driver, NrCuenta);
                Reportes.ReportarPasosDePrueba("PASS", "Seleccionar Cuenta y Seleccionar Operar", "Se selecciono cuenta: " + NrCuenta);


                //3 -  Seleccionar Fondo y Rescatar
                operar.RescatarFondo(fondo, importe, "Parcial por Importe", Driver);
                Reportes.ReportarPasosDePrueba("PASS", "Rescatar Fondo", fondo + "Importe: " + importe);

                //4 - Se muestra mensaje de error
                string error = "Debe ingresar un valor numérico mayor a cero";
                Driver.FindElement(operar.Boton_AceptarRescate).Click();
                Esperar(5, operar.ContenedorError, Driver);
                Assert.IsTrue(Driver.FindElement(operar.ContenedorError).Text.Contains(error), "No se muestra mensaje" + error);
                Reportes.ReportarPasosDePrueba("PASS", "Se muestra mensaje de error", Driver.FindElement(operar.ContenedorError).Text);


                //Genero Reporte
                Reportes.GenerarReporte(modulo, caso, "PASS", "CASO OK", Driver);

            }
            catch (Exception e)
            {
                Reportes.GenerarReporte(modulo, caso, "FAIL", e.Message, Driver);
                Assert.Fail(e.Message);
            }

        }

        /**
        [Test]
        public void OperarRescatePorCuotaparteMenorMin_021()
        {
            string caso = "OperarRescatePorCuotaparteMenorMin_021";
            try
            {
                //Inicio reporte y  Agrego datos
                Reportes.IniciarReporte(caso);
                ManejoDeExcel Datos = new ManejoDeExcel();
                QueryCtistaCtaBancariaMinMax s = new QueryCtistaCtaBancariaMinMax("Ailin", "ARS");
                Datos.PopulateInCollection(pathDataInput + "DataInput2.xls", "Login");

                //Creo Variables Requeridas para los datos                
                string user = Datos.ReadData(caso, "Usuario").Trim();
                string pass = Datos.ReadData(caso, "Contraseña").Trim();
                string fondo = s.fondo;
                string Cuotapartista = s.codCuotapartista;
                string cuenta = s.cuentaBancaria;
                int minimo = Convert.ToInt32(s.rescateMinimo);
                int importe = minimo - 1;

                //1 - Paso Login
                Login.Loguearse(user, pass, Driver);
                Reportes.ReportarPasosDePrueba("PASS", "Login", "Login Ok" + user + " " + pass);

                //2 -  Seleccionar Cuenta y Seleccionar Operar
                principal.SeleccionarOperar(Driver, Cuotapartista);
                Reportes.ReportarPasosDePrueba("PASS", "Seleccionar Cuenta y Seleccionar Operar", "Se selecciono cuenta: " + Cuotapartista);


                //3 -  Seleccionar Fondo y Rescatar
                operar.RescatarFondo(fondo, importe.ToString(), "Parcial por Cuotapartes", Driver);
                Reportes.ReportarPasosDePrueba("PASS", "Rescatar Fondo", fondo + "Importe: " + importe);

                //4 -  Aceptar Condiciones
                operar.AceptarCondiciones(Driver);
                Reportes.ReportarPasosDePrueba("PASS", "Aceptar Condiciones", "ok");

                //5 -  Aceptar Rescate
                operar.AceptarRescate(Driver);
                Reportes.ReportarPasosDePrueba("PASS", "Aceptar Rescate", "ok");

                //6 -  Se muestra alerta
                if (operar.ExisteMensajeDeAlerta(Driver, 5))
                {

                    if (operar.MensajeAlerta(Driver).Contains(s.rescateMinimo.ToString()))
                    {
                        //Genero Reporte         
                        Reportes.GenerarReporte(modulo, caso, "PASS", operar.MensajeAlerta(Driver), Driver);
                    }

                    else
                    {
                        Reportes.ReportarPasosDePrueba("FAIL","Validar Mensaje", "Error en mensaje, se esperaba valor minimo " + s.rescateMinimo);
                        Assert.Fail();
                    }                   
                }
                else
                {
                    Reportes.GenerarReporte(modulo, caso, "FAIL", "No se respeta valor minimo " + s.importeMinimo, Driver);
                    Assert.Fail();
                }


                //Genero Reporte
                Reportes.GenerarReporte(modulo, caso, "PASS", "CASO OK", Driver);

            }
            catch (Exception e)
            {
                Reportes.GenerarReporte(modulo, caso, "FAIL", e.Message, Driver);
                Assert.Fail();
            }

        }
    */

        public void OperarRescatePorCuotaparteMayorMaximo_022()
        {
            string caso = "OperarRescatePorCuotaparteMayorMaximo_022";
            try
            {
                //Inicio reporte y  Agrego datos
                Reportes.IniciarReporte(caso);
                QueryCtistaCtaBancariaMinMax s = new QueryCtistaCtaBancariaMinMax("Ailin", "ARS");

                //Creo Variables Requeridas para los datos                
                string user = Datos.ReadData(caso, "Usuario").Trim();
                string pass = Datos.ReadData(caso, "Contraseña").Trim();
                string fondo = s.fondo;
                string Cuotapartista = s.codCuotapartista;
                string cuenta = s.cuentaBancaria;
                int maximo = Convert.ToInt32(s.rescateMaximo);
                int importe = maximo + 1;

                //1 - Paso Login
                //Login.Loguearse(user, pass, Driver);
                //Reportes.ReportarPasosDePrueba("PASS", "Login", "Login Ok" + user + " " + pass);

                //2 -  Seleccionar Cuenta y Seleccionar Operar
                principal.SeleccionarOperar(Driver, Cuotapartista);
                Reportes.ReportarPasosDePrueba("PASS", "Seleccionar Cuenta y Seleccionar Operar", "Se selecciono cuenta: " + Cuotapartista);


                //3 -  Seleccionar Fondo y Rescatar
                operar.RescatarFondo(fondo, importe.ToString(), "Parcial por Cuotapartes", Driver);
                Reportes.ReportarPasosDePrueba("PASS", "Rescatar Fondo", fondo + "Importe: " + importe);

                //4 -  Aceptar Condiciones
                operar.AceptarCondiciones(Driver);
                Reportes.ReportarPasosDePrueba("PASS", "Aceptar Condiciones", "ok");

                //5 -  Aceptar Rescate
                operar.AceptarRescate(Driver);
                Reportes.ReportarPasosDePrueba("PASS", "Aceptar Rescate", "ok");

                //6 -  Se muestra alerta
                if (operar.ExisteMensajeDeAlerta(Driver, 5))
                {

                    if (operar.MensajeAlerta(Driver).Contains(s.rescateMaximo.ToString()))
                    {
                        //Genero Reporte         
                        Reportes.GenerarReporte(modulo, caso, "PASS", operar.MensajeAlerta(Driver), Driver);
                    }

                    else
                    {
                        Reportes.ReportarPasosDePrueba("FAIL", "Validar Mensaje", "Error en mensaje, se esperaba valor minimo " + s.rescateMaximo);
                        Assert.Fail();
                    }
                }
                else
                {
                    Reportes.GenerarReporte(modulo, caso, "FAIL", "No se respeta valor minimo " + s.rescateMaximo, Driver);
                    Assert.Fail();
                }


                //Genero Reporte
                Reportes.GenerarReporte(modulo, caso, "PASS", "CASO OK", Driver);

            }
            catch (Exception e)
            {
                Reportes.GenerarReporte(modulo, caso, "FAIL", e.Message, Driver);
                Assert.Fail();
            }

        }





        [Test]
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
                Login.Loguearse(user, pass, Driver);
                Reportes.ReportarPasosDePrueba("PASS", "Login", "Login Ok " + user + " " + pass);

                //2 -  Seleccionar Movimientos
                principal.SeleccionarMovimientos(Driver);

                //3 - Click en Exportar a Excel
                movimientos.ExportarExcel(Driver, "Movimientos.xlsx");
                Reportes.ReportarPasosDePrueba("PASS", "Exportar a Excel", "Se descargo el archivo correctamente");

                //4 -  Click en Exportar a PDF
                movimientos.ExportarEnPDF(Driver, "Movimientos.pdf");
                Reportes.ReportarPasosDePrueba("PASS", "Exportar a PDF", "Se descargo el archivo correctamente");

                //Genero Reporte
                Reportes.GenerarReporte("Movimientos", caso, "PASS", "CASO OK", Driver);

            }
            catch (Exception e)
            {
                Reportes.GenerarReporte("Movimientos", caso, "FAIL", e.Message, Driver);
                Assert.Fail(e.Message);
            }

        }


        [Test]
        public void ValoresCuotaparte_Pdf_Excel()
        {
            string caso = "ValoresCuotaparte_Pdf_Excel";
            try
            {
                //Inicio reporte y  Agrego datos
                Reportes.IniciarReporte(caso);

                //1 - Paso Login
                Login.Loguearse("Ailin", "1234", Driver);
                Reportes.ReportarPasosDePrueba("PASS", "Login", "Login Ok " + "Ailin" + " " + "1234");

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
                Reportes.GenerarReporte("ValoresCuotaparte", caso, "PASS", "Caso OK", Driver);

            }
            catch (Exception e)
            {
                Reportes.GenerarReporte("ValoresCuotaparte", caso, "FAIL", e.Message, Driver);
                Assert.Fail(e.Message);
            }

        }


    }

}




