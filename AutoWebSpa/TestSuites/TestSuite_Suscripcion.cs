using NUnit.Framework;
using AutoWebSpa.Core;
using System;
using AutoWebSpa.Funciones;
using AutoWebSpa.Core.Query;
using System.Collections.Generic;

namespace AutoWebSpa.TestSuites
{


    [TestFixture]
    [Parallelizable]
    public class TestSuite_Suscripcion : Hooks
    {

        public TestSuite_Suscripcion() : base(BrowerType.Chrome) { }
        FunLogin Login = new FunLogin();
        FunPrincipal principal = new FunPrincipal();
        FunOperar operar = new FunOperar();
        ManejadorDeReportes Reportes = new ManejadorDeReportes();
        string modulo = "Suscripcion";
        string moduloRescates = "Rescates";



        public void OperarSuscripcionConPosicionEnDolares_002()
        {
            string caso = "OperarSuscripcionConPosicionEnDolares_002";
            try
            {
                //Inicio reporte y  Agrego datos
                Reportes.IniciarReporte("OperarSuscripcionConPosicionEnDolares_002");

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

                //3 -  Seleccionar Fondo y Suscribir
                operar.SuscribirFondo(fondo, importe, Driver);
                Reportes.ReportarPasosDePrueba("PASS", "Suscribir Numero", fondo + "Importe: " + importe);

                //4 -  Aceptar Condiciones
                operar.AceptarCondiciones(Driver);
                Reportes.ReportarPasosDePrueba("PASS", "Aceptar Condiciones", "ok");

                //5 -  Aceptar Suscripcion
                operar.AceptarSuscripcion(Driver);
                Reportes.ReportarPasosDePrueba("PASS", "Aceptar Suscripción", "ok");

                //6 - Validar confirmacion
                //operar.ValidarConfirmacion(Driver, fondo, importe, cuenta, false);
                //Reportes.ReportarPasosDePrueba("PASS", "Validar Confirmacion", "En el tk se muestra: " + fondo + " " + cuenta + " " + importe);

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


        public void OperarSuscripcionConPosicionEnPesos_003()
        {
            string caso = "OperarSuscripcionConPosicionEnPesos_003";
            try
            {
                //Inicio reporte y  Agrego datos
                Reportes.IniciarReporte("OperarSuscripcionConPosicionEnPesos_003");

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

                //1 -  Seleccionar Cuenta y Seleccionar Operar
                principal.SeleccionarOperar(Driver, NrCuenta);
                Reportes.ReportarPasosDePrueba("PASS", "Seleccionar Cuenta y Seleccionar Operar", "Se selecciono cuenta: " + NrCuenta);

                //3 -  Seleccionar Fondo y Suscribir
                operar.SuscribirFondo(fondo, importe, Driver);
                Reportes.ReportarPasosDePrueba("PASS", "Suscribir Numero", fondo + "Importe: " + importe);

                //4 -  Aceptar Condiciones
                operar.AceptarCondiciones(Driver);
                Reportes.ReportarPasosDePrueba("PASS", "Aceptar Condiciones", "ok");

                //5 -  Aceptar Suscripcion
                operar.AceptarSuscripcion(Driver);
                Reportes.ReportarPasosDePrueba("PASS", "Aceptar Suscripción", "ok");

                //6 - Validar confirmacion
                //operar.ValidarConfirmacion(Driver, fondo, importe, cuenta, false);
                //Reportes.ReportarPasosDePrueba("PASS", "Validar Confirmacion", "En el tk se muestra: " + fondo + " " + cuenta + " " + importe);

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



        public void OperarSuscripcionConImporteMenorMinimo_001()
        {
            string caso = "OperarSuscripcionConImporteMenorMinimo_007";
            try
            {

                QueryCtistaCtaBancariaMinMax s = new QueryCtistaCtaBancariaMinMax("Ailin", "ARS");

                //Inicio reporte y  Agrego datos
                Reportes.IniciarReporte(caso);

                //Creo Variables Requeridas para los datos                
                string fondo = s.fondo;
                string Cuotapartista = s.codCuotapartista;
                string cuenta = s.cuentaBancaria;
                int minimo = Convert.ToInt32(s.importeMinimo);
                int importe = minimo - 1;

                //1 - Paso Login
                Reportes.ReportarPasosDePrueba("PASS", "Login", "Login Ok");

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



        public void Login_SeDespleganCuentasDelUsuario_011()
        {
            string caso = "Login_SeDespleganCuentasDelUsuario_011";
            try
            {
                QueryDevuelveReader consulta = new QueryDevuelveReader();

                //Inicio reporte y  Agrego datos
                Reportes.IniciarReporte(caso);

                //Creo Variables Requeridas para los datos                
                string user = Datos.ReadData(caso, "Usuario").Trim();
                string pass = Datos.ReadData(caso, "Contraseña").Trim();

                //1 - Paso Login
                //Login.Loguearse(user, pass, Driver);
                Reportes.ReportarPasosDePrueba("PASS", "Login", "Login Ok" + user + " " + pass);

                //2 -  Click en seleccionar Cuentas
                List<string> cuotapartistas = consulta.DevolverCuotapartistas(user);

                foreach (var aux in cuotapartistas)
                {
                    principal.SeleccionarCuenta(aux, Driver);
                    Reportes.ReportarPasosDePrueba("PASS", "Click Seleccionar Cuenta", aux);
                }

                //Genero Reporte         
                Reportes.GenerarReporte(modulo, caso, "PASS", "Se seleccionaron las cuentas correctamente", Driver);


            }
            catch (Exception e)
            {
                Reportes.GenerarReporte(modulo, caso, "FAIL", e.Message, Driver);
                Assert.Fail(e.Message);
            }
        }


        public void OperarSuscripcionImporteIgualMinimo()
        {
            string caso = "OperarSuscripcionImporteIgualMinimo";
            try
            {

                QueryCtistaCtaBancariaMinMax s = new QueryCtistaCtaBancariaMinMax("Ailin", "ARS");

                //Inicio reporte y  Agrego datos
                Reportes.IniciarReporte(caso);

                //Creo Variables Requeridas para los datos                
                string user = Datos.ReadData(caso, "Usuario").Trim();
                string pass = Datos.ReadData(caso, "Contraseña").Trim();
                string fondo = Datos.ReadData(caso, "Fondo").Trim();
                string Cuotapartista = Datos.ReadData(caso, "NroCuenta").Trim();
                string cuenta = Datos.ReadData(caso, "Cuenta").Trim();
                string minimo = Datos.ReadData(caso, "Minimo").Trim();
                string importe = minimo;

                //1 - Paso Login
                Login.Loguearse(user, pass, Driver);
                Reportes.ReportarPasosDePrueba("PASS", "Login", "Login Ok" + user + " " + pass);

                //2 -  Seleccionar Cuenta y Seleccionar Operar
                principal.SeleccionarOperar(Driver, Cuotapartista);
                Reportes.ReportarPasosDePrueba("PASS", "Seleccionar Cuenta y Seleccionar Operar", "Se selecciono cuenta: " + Cuotapartista);

                //3 -  Seleccionar Fondo y Suscribir
                operar.SuscribirFondo(fondo, importe, Driver);
                Reportes.ReportarPasosDePrueba("PASS", "Suscribir Numero", fondo + "Importe: " + importe);

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

        [Test]
        public void OperarRescateParcialPorImporte_004()
        {
            string caso = "OperarRescateParcialPorImporte_004";
            try
            {
                //Inicio reporte y  Agrego datos
                Reportes.IniciarReporte("OperarRescateParcialPorImporte_004");

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


                //3 -  Seleccionar Fondo y Rescatar
                operar.RescatarFondo(fondo, importe, "Parcial por Importe", Driver);
                Reportes.ReportarPasosDePrueba("PASS", "Rescatar Fondo", fondo + "Importe: " + importe);

                //4 -  Aceptar Condiciones
                operar.AceptarCondiciones(Driver);
                Reportes.ReportarPasosDePrueba("PASS", "Aceptar Condiciones", "ok");

                //5 -  Aceptar Rescate
                operar.AceptarRescate(Driver);
                Reportes.ReportarPasosDePrueba("PASS", "Aceptar Rescate", "ok");

                //6 - Validar confirmacion
                operar.ValidarConfirmacion(Driver, fondo, importe, cuenta, false);
                Reportes.ReportarPasosDePrueba("PASS", "Validar Confirmacion", "En el tk se muestra: " + fondo + " " + cuenta + " " + importe);

                //7 -  Click en Confirmar
                operar.ConfirmarSuscripcion(Driver);

                //8 - Validar Comprobante
                //operar.ValidarComprobante(fondo, importe, cuenta, "Importe", Driver);

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









