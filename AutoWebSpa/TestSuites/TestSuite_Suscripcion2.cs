using NUnit.Framework;
using AutoWebSpa.Core;
using System;
using AutoWebSpa.Funciones;
using AutoWebSpa.Core.Query;
using AutoWebSpa.Core.Helpers;

namespace AutoWebSpa.TestSuites
{
    [TestFixture]
    [Parallelizable]
    public class TestSuite_Suscripcion2 : Hooks
    {

        public TestSuite_Suscripcion2() : base(BrowerType.Chrome) { }
        FunLogin Login = new FunLogin();
        FunPrincipal principal = new FunPrincipal();
        FunOperar operar = new FunOperar();
        ManejadorDeReportes Reportes = new ManejadorDeReportes();
        string modulo = "Suscripcion";


        [Test]
        public void OperarSuscripcionBotonNuevaInversion_001()
        {
            string caso = "OperarSuscripcionBotonNuevaInversion_001";
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
                string importe = Datos.ReadData(caso, "Importe").Trim();

                //1 - Paso Login
                Login.Loguearse(user, pass, Driver);
                Reportes.ReportarPasosDePrueba("PASS", "Login", "Login Ok" + user + " " + pass);

                //2 -  Seleccionar Cuenta y Seleccionar Operar
                principal.SeleccionarOperar(Driver, NrCuenta);
                Reportes.ReportarPasosDePrueba("PASS", "Seleccionar Cuenta y Seleccionar Operar", "Se selecciono cuenta: " + NrCuenta);

                //3 -  Click en boton Nueva Inversion
                ClickHelpers.Click(Driver, operar.BotonNuevaInversion);

                //4 -  Seleccionar Fondo
                operar.SuscribirNuevaInversion(fondo, importe, Driver);

                //4 -  Aceptar Condiciones
                operar.AceptarCondiciones(Driver);
                Reportes.ReportarPasosDePrueba("PASS", "Aceptar Condiciones", "ok");

                //5 -  Aceptar Suscripcion
                operar.AceptarSuscripcion(Driver);
                Reportes.ReportarPasosDePrueba("PASS", "Aceptar Suscripción", "ok");

                //6 - Validar confirmacion
                operar.ValidarConfirmacion(Driver, fondo, importe, cuenta, false);
                Reportes.ReportarPasosDePrueba("PASS", "Validar Confirmacion", "En el tk se muestra: " + fondo + " " + cuenta + " " + importe);

                //7 -  Click en Confirmar
                operar.ConfirmarSuscripcion(Driver);

                //Genero Reporte
                Reportes.GenerarReporte(modulo, caso, "PASS", "CASO OK", Driver);

            }
            catch (Exception e)
            {
                Reportes.GenerarReporte(modulo, caso, "FAIL", e.Message, Driver);
                Assert.Fail(e.Message);
            }

        }



        public void OperarSuscripcionConImporteMayorMaximo_008()
        {
            string caso = "OperarSuscripcionConImporteMayorMaximo_008";
            try
            {

                QueryCtistaCtaBancariaMinMax s = new QueryCtistaCtaBancariaMinMax("Ailin", "ARS");

                //Inicio reporte y  Agrego datos
                Reportes.IniciarReporte(caso);

                //Creo Variables Requeridas para los datos                
                string user = Datos.ReadData(caso, "Usuario").Trim();
                string pass = Datos.ReadData(caso, "Contraseña").Trim();
                string fondo = s.fondo;
                string Cuotapartista = s.codCuotapartista;
                string cuenta = s.cuentaBancaria;
                int maximo = Convert.ToInt32(s.importeMaximo);
                int importe = maximo + 1;

                //1 - Paso Login
                Login.Loguearse(user, pass, Driver);
                Reportes.ReportarPasosDePrueba("PASS", "Login", "Login Ok" + user + " " + pass);

                //2 -  Seleccionar Cuenta y Seleccionar Operar
                principal.SeleccionarOperar(Driver, Cuotapartista);
                Reportes.ReportarPasosDePrueba("PASS", "Seleccionar Cuenta y Seleccionar Operar", "Se selecciono cuenta: " + Cuotapartista);

                //3 -  Seleccionar Fondo y Suscribir
                operar.SuscribirFondo(fondo, importe.ToString(), Driver);
                Reportes.ReportarPasosDePrueba("PASS", "Suscribir Numero", fondo + "Importe: " + importe);

                //4 -  Aceptar Condiciones
                operar.AceptarCondiciones(Driver);
                Reportes.ReportarPasosDePrueba("PASS", "Aceptar Condiciones", "ok");

                //5 -  Aceptar Suscripcion
                operar.AceptarSuscripcion(Driver);
                Reportes.ReportarPasosDePrueba("PASS", "Aceptar Suscripción", "ok");

                //6 -  Se muestra alerta
                if (operar.ExisteMensajeDeAlerta(Driver, 5))
                {
                    //Genero Reporte         
                    Reportes.GenerarReporte(modulo, caso, "PASS", operar.MensajeAlerta(Driver), Driver);
                }
                else
                {
                    Reportes.GenerarReporte(modulo, caso, "FAIL", "No se respeta valor minimo " + s.importeMinimo, Driver);
                    Assert.Fail();
                }


            }
            catch (Exception e)
            {
                Reportes.GenerarReporte(modulo, caso, "FAIL", e.Message, Driver);
                Assert.Fail(e.Message);
            }

        }


        public void OperarSuscripcionVentanaAceptacionTyC_009()
        {
            string caso = "OperarSuscripcionVentanaAceptacionTyC_009";
            try
            {
                //Inicio reporte y  Agrego datos
                QueryCtistaCtaBancariaMinMax s = new QueryCtistaCtaBancariaMinMax("Ailin", "ARS");

                //Inicio reporte y  Agrego datos
                Reportes.IniciarReporte(caso);

                //Creo Variables Requeridas para los datos                
                string user = Datos.ReadData(caso, "Usuario").Trim();
                string pass = Datos.ReadData(caso, "Contraseña").Trim();
                string fondo = s.fondo;
                string Cuotapartista = s.codCuotapartista;
                string cuenta = s.cuentaBancaria;
                int minimo = Convert.ToInt32(s.importeMinimo);
                int importe = minimo + 1;

                //1 - Paso Login
                //Login.Loguearse(user, pass, Driver);
                //Reportes.ReportarPasosDePrueba("PASS", "Login", "Login Ok" + user + " " + pass);

                //2 -  Seleccionar Cuenta y Seleccionar Operar
                principal.SeleccionarOperar(Driver, Cuotapartista);
                Reportes.ReportarPasosDePrueba("PASS", "Seleccionar Cuenta y Seleccionar Operar", "Se selecciono cuenta: " + Cuotapartista);

                //3 -  Seleccionar Fondo y Suscribir
                operar.SuscribirFondo(fondo, importe.ToString(), Driver);
                Reportes.ReportarPasosDePrueba("PASS", "Suscribir Numero", fondo + "Importe: " + importe);

                //4 -  Aceptar Condiciones
                operar.AceptarCondiciones(Driver);
                Reportes.ReportarPasosDePrueba("PASS", "Aceptar Condiciones", "ok");

                //5 -  Destildar Check
                Driver.FindElement(operar.Checkbox_AceptoTerminosCondiciones).Click();
                Reportes.ReportarPasosDePrueba("PASS", "Destildar check Terminos y condiciones", "ok");

                //Clickeo Aceptar
                Driver.FindElement(operar.Boton_AceptarSuscripcion).Click();
                Reportes.ReportarPasosDePrueba("PASS", "Click en Aceptar para verificar el estado del boton", "ok");

                //No se deberia mostrar confirmar
                Base.DormirHilo(2);
                if (Driver.FindElements(operar.Boton_Confirmar).Count != 0)
                {
                    Assert.Fail("El boton Aceptar no deberia estar habilitado");
                }

                //Genero Reporte
                Reportes.GenerarReporte(modulo, caso, "PASS", "CASO OK", Driver);

            }
            catch (Exception e)
            {
                Reportes.GenerarReporte(modulo, caso, "FAIL", e.Message, Driver);
                Assert.Fail(e.Message);
            }

        }



        public void OperarSuscripcionVentanaAceptacionReglamento_010()
        {
            string caso = "OperarSuscripcionVentanaAceptacionReglamento_010";
            try
            {
                //Inicio reporte y  Agrego datos
                QueryCtistaCtaBancariaMinMax s = new QueryCtistaCtaBancariaMinMax("Ailin", "ARS");

                //Inicio reporte y  Agrego datos
                Reportes.IniciarReporte(caso);

                //Creo Variables Requeridas para los datos                
                string user = Datos.ReadData(caso, "Usuario").Trim();
                string pass = Datos.ReadData(caso, "Contraseña").Trim();
                string fondo = s.fondo;
                string Cuotapartista = s.codCuotapartista;
                string cuenta = s.cuentaBancaria;
                int minimo = Convert.ToInt32(s.importeMinimo);
                int importe = minimo + 1;

                //1 - Paso Login
                //Login.Loguearse(user, pass, Driver);
                //Reportes.ReportarPasosDePrueba("PASS", "Login", "Login Ok" + user + " " + pass);

                //2 -  Seleccionar Cuenta y Seleccionar Operar
                principal.SeleccionarOperar(Driver, Cuotapartista);
                Reportes.ReportarPasosDePrueba("PASS", "Seleccionar Cuenta y Seleccionar Operar", "Se selecciono cuenta: " + Cuotapartista);

                //3 -  Seleccionar Fondo y Suscribir
                operar.SuscribirFondo(fondo, importe.ToString(), Driver);
                Reportes.ReportarPasosDePrueba("PASS", "Suscribir Numero", fondo + "Importe: " + importe);

                //4 -  Aceptar Condiciones
                operar.AceptarCondiciones(Driver);
                Reportes.ReportarPasosDePrueba("PASS", "Aceptar Condiciones", "ok");

                //5 -  Destildar Check
                Driver.FindElement(operar.Checkbox_AceptoReglamentoDeGestion).Click();
                Reportes.ReportarPasosDePrueba("PASS", "Destildar check reglamento de gestion", "ok");

                //Clickeo Aceptar
                Driver.FindElement(operar.Boton_AceptarSuscripcion).Click();
                Reportes.ReportarPasosDePrueba("PASS", "Click en Aceptar para verificar el estado del boton", "ok");

                //No se deberia mostrar confirmar
                Base.DormirHilo(2);
                if (Driver.FindElements(operar.Boton_Confirmar).Count != 0)
                {
                    Assert.Fail("El boton Aceptar no deberia estar habilitado");
                }

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





