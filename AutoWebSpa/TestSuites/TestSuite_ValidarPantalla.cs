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
    public class TestSuite_ValidarPantalla : Hooks
    {

        public TestSuite_ValidarPantalla() : base(BrowerType.Chrome) { }
        FunLogin Login = new FunLogin();
        FunPrincipal principal = new FunPrincipal();
        FunMisSolicitudes misSolicitudes = new FunMisSolicitudes();
        FunOperar operar = new FunOperar();
        string Modulo = "ValidarPantalla";
        ManejadorDeReportes Reportes = new ManejadorDeReportes();


        public void ValidarPantalla_Operar_023()
        {
            string caso = "ValidarPantalla_Operar_023";
            try
            {
                //Inicio reporte y  Agrego datos
                Reportes.IniciarReporte(caso);

                string user = Datos.ReadData(caso, "Usuario").Trim();
                string pass = Datos.ReadData(caso, "Contraseña").Trim();

                //1 - Paso Login
                Login.Loguearse(user, pass, Driver);
                Reportes.ReportarPasosDePrueba("PASS", "Login", "Login Ok " + user + " " + pass);

                //2 - Selecciono Cuenta
                principal.SeleccionarOperar(Driver);
                Reportes.ReportarPasosDePrueba("PASS", "Seleccionar Operar", "ok");

                //3 - Validar Boton Ir A Mis Solicitudes
                operar.ValidarBoton_IrAMisSolicitudes(Driver);
                Reportes.ReportarPasosDePrueba("PASS", "Validar Boton", "Ir a mis solicitudes");

                //4 - Vuelvo a Operar
                principal.SeleccionarOperar(Driver);
                Reportes.ReportarPasosDePrueba("PASS", "Volver a Operar", "ok");

                //5 - Valido Boton Ir a Posición
                operar.ValidarBoton_IrPosicion(Driver);
                Reportes.ReportarPasosDePrueba("PASS", "Validar boton", "Ir a Posición");

                //Genero Reporte
                Reportes.GenerarReporte(Modulo, caso, "PASS", "Caso OK", Driver);

            }
            catch (Exception e)
            {
                Reportes.GenerarReporte(Modulo, caso, "FAIL", e.Message, Driver);
                Assert.Fail(e.Message);
            }

        }

    }
}




