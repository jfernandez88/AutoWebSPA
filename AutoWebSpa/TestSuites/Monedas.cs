using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoWebSpa.Core;
using AutoWebSpa.Funciones;
using NUnit.Framework;


namespace AutoWebSpa.TestSuites.Monedas
{
 [TestFixture]  
 [Parallelizable]
    public class Monedas : SeleniumExtentReport
    {
        public Monedas() { }
        Login Login = new Login();
        Alta Alta = new Alta();
        Baja Bajas = new Baja();
        Modificar Modificar = new Modificar();
        Detalles Detalles = new Detalles();
        Recuperar Recuperar = new Recuperar();
        Auditar Auditar = new Auditar();
        Random rnd = new Random();


        [Test]
        public void Monedas_Alta()
        {


            int Nro = rnd.Next(900);

                //Alta
                Login.Loguearse("sa", "sasa", Driver, detalleReporte);
                Alta.SeleccionarModulo("Monedas", Driver, detalleReporte);
                Alta.AdicionarElemento(Driver, detalleReporte);
                Alta.CompletarDescripcion(Driver, "QAA_"+Nro, detalleReporte);
                Alta.CompletarNumero(Driver,"QA"+Nro,"Simbolo",detalleReporte);
                Alta.CompletarCampos(Driver, "Código de UIF", "CodUIF"+Nro, detalleReporte );
                Alta.CompletarCampos(Driver, "Código CAFCI", "QAA_Código CAFCI" + Nro, detalleReporte);
                Alta.CompletarCampos(Driver, "Código de ISO", "QAA_CodigoDeIso"+Nro, detalleReporte);
                Alta.CompletarCampos(Driver, "Código de Interfaz", "QAA_CodInterfaz"+Nro, detalleReporte);
                Alta.CompletarCampos(Driver, "Código de Interfaz Adicional", "QAA_CodInterfAd"+Nro, detalleReporte);
                Alta.CompletarCampos(Driver, "Código de Interfaz MAE", "QAA_CodIntMAE" + Nro, detalleReporte);
                Alta.CompletarCampos(Driver, "Código de Interfaz Banco", "QAA_CodBanco" + Nro, detalleReporte);
                Alta.CompletarCampos(Driver, "Código Interfaz Agenn", "QAA_CodAgenn" + Nro, detalleReporte);
                Alta.CompletarCampos(Driver, "Código de Interfaz ACSA", "QAA_CodACSA" + Nro, detalleReporte);
                Alta.CompletarCampos(Driver, "Código de Interfaz AFIP", "QAA_CodAFIP" + Nro, detalleReporte);

                //Aceptar Registro
                Alta.Aceptar(Driver, detalleReporte);

                //Click en detalles de registro
                Detalles.buscarRegistro(Driver, "QAA_"+Nro, detalleReporte);
                Detalles.selectRegistro(Driver,"QAA_"+Nro, detalleReporte);
                Detalles.clickDetalles(Driver, detalleReporte);

                //Validar Campos
                Detalles.ValidarCampos(Driver, "CodUIF" + Nro, detalleReporte);
                Detalles.ValidarCampos(Driver, "QA"+Nro, detalleReporte);
                Detalles.ValidarCampos(Driver, "QAA_Código CAFCI" + Nro, detalleReporte);
                Detalles.ValidarCampos(Driver, "QAA_CodigoDeIso" + Nro, detalleReporte);
                Detalles.ValidarCampos(Driver, "QAA_CodInterfaz" + Nro, detalleReporte);
                Detalles.ValidarCampos(Driver, "QAA_CodInterfAd" + Nro, detalleReporte);
                Detalles.ValidarCampos(Driver, "QAA_CodIntMAE" + Nro, detalleReporte);
                Detalles.ValidarCampos(Driver, "QAA_CodBanco" + Nro, detalleReporte);
                Detalles.ValidarCampos(Driver, "QAA_CodAgenn" + Nro, detalleReporte);
                Detalles.ValidarCampos(Driver, "QAA_CodACSA" + Nro, detalleReporte);
                Detalles.ValidarCampos(Driver, "QAA_CodAFIP" + Nro, detalleReporte);



        }

     
        [Test]
        public void Monedas_Baja()
        {

            int Nro = rnd.Next(900);

                //Alta
                Login.Loguearse("sa", "sasa", Driver, detalleReporte);
                Alta.SeleccionarModulo("Monedas", Driver, detalleReporte);
                Alta.AdicionarElemento(Driver, detalleReporte);
                Alta.CompletarDescripcion(Driver, "QAA_" + Nro, detalleReporte);
                Alta.CompletarNumero(Driver, "QA"+Nro, "Simbolo", detalleReporte);
                Alta.CompletarCampos(Driver, "Código de UIF", "CodUIF" + Nro, detalleReporte);
                Alta.CompletarCampos(Driver, "Código CAFCI", "QAA_Código CAFCI" + Nro, detalleReporte);
                Alta.CompletarCampos(Driver, "Código de ISO", "QAA_CodigoDeIso" + Nro, detalleReporte);
                Alta.CompletarCampos(Driver, "Código de Interfaz", "QAA_CodInterfaz" + Nro, detalleReporte);
                Alta.CompletarCampos(Driver, "Código de Interfaz Adicional", "QAA_CodInterfAd" + Nro, detalleReporte);
                Alta.CompletarCampos(Driver, "Código de Interfaz MAE", "QAA_CodIntMAE" + Nro, detalleReporte);
                Alta.CompletarCampos(Driver, "Código de Interfaz Banco", "QAA_CodBanco" + Nro, detalleReporte);
                Alta.CompletarCampos(Driver, "Código Interfaz Agenn", "QAA_CodAgenn" + Nro, detalleReporte);
                Alta.CompletarCampos(Driver, "Código de Interfaz ACSA", "QAA_CodACSA" + Nro, detalleReporte);
                Alta.CompletarCampos(Driver, "Código de Interfaz AFIP", "QAA_CodAFIP" + Nro, detalleReporte);

                //Aceptar Registro
                Alta.Aceptar(Driver, detalleReporte);

                //Dar Baja
                Bajas.BajaDeRegistro(Driver, "QAA_" + Nro, detalleReporte);
                Bajas.ValidarBaja(Driver, "QAA_" + Nro, detalleReporte);

        }

        [Test]
        public void Monedas_Modificar()
        {

            int Nro = rnd.Next(900);

                // Alta
                Login.Loguearse("sa", "sasa", Driver, detalleReporte);
                Alta.SeleccionarModulo("Monedas", Driver, detalleReporte);
                Alta.AdicionarElemento(Driver, detalleReporte);
                Alta.CompletarDescripcion(Driver, "QAA_" + Nro, detalleReporte);
                Alta.CompletarNumero(Driver, "QA"+Nro, "Simbolo", detalleReporte);
                Alta.CompletarCampos(Driver, "Código de UIF", "CodUIF" + Nro, detalleReporte);
                Alta.CompletarCampos(Driver, "Código CAFCI", "QAA_Código CAFCI" + Nro, detalleReporte);
                Alta.CompletarCampos(Driver, "Código de ISO", "QAA_CodigoDeIso" + Nro, detalleReporte);
                Alta.CompletarCampos(Driver, "Código de Interfaz", "QAA_CodInterfaz" + Nro, detalleReporte);
                Alta.CompletarCampos(Driver, "Código de Interfaz Adicional", "QAA_CodInterfAd" + Nro, detalleReporte);
                Alta.CompletarCampos(Driver, "Código de Interfaz MAE", "QAA_CodIntMAE" + Nro, detalleReporte);
                Alta.CompletarCampos(Driver, "Código de Interfaz Banco", "QAA_CodBanco" + Nro, detalleReporte);
                Alta.CompletarCampos(Driver, "Código Interfaz Agenn", "QAA_CodAgenn" + Nro, detalleReporte);
                Alta.CompletarCampos(Driver, "Código de Interfaz ACSA", "QAA_CodACSA" + Nro, detalleReporte);
                Alta.CompletarCampos(Driver, "Código de Interfaz AFIP", "QAA_CodAFIP" + Nro, detalleReporte);

                //Aceptar Registro
                Alta.Aceptar(Driver, detalleReporte);

                //Modificar Registro
                Modificar.ModificarRegistro(Driver, "QAA_" + Nro, "Código de UIF", "Modificado"+Nro,detalleReporte);

                //Validar Modificación
                Detalles.buscarRegistro(Driver, "QAA_" + Nro, detalleReporte);
                Detalles.selectRegistro(Driver, "QAA_" + Nro, detalleReporte);
                Detalles.clickDetalles(Driver, detalleReporte);

                //Validar Campos
                Detalles.ValidarCampos(Driver, "Modificado"+Nro, detalleReporte);

        }


        [Test]
        public void Monedas_Auditar()
        {

            int Nro = rnd.Next(500);

                // Alta
                Login.Loguearse("sa", "sasa", Driver, detalleReporte);
                Alta.SeleccionarModulo("Monedas", Driver, detalleReporte);
                Alta.AdicionarElemento(Driver, detalleReporte);
                Alta.CompletarDescripcion(Driver, "QAA_" + Nro, detalleReporte);
                Alta.CompletarNumero(Driver, "QA" + Nro, "Simbolo", detalleReporte);
                Alta.CompletarCampos(Driver, "Código de UIF", "CodUIF" + Nro, detalleReporte);
                Alta.CompletarCampos(Driver, "Código CAFCI", "QAA_Código CAFCI" + Nro, detalleReporte);
                Alta.CompletarCampos(Driver, "Código de ISO", "QAA_CodigoDeIso" + Nro, detalleReporte);
                Alta.CompletarCampos(Driver, "Código de Interfaz", "QAA_CodInterfaz" + Nro, detalleReporte);
                Alta.CompletarCampos(Driver, "Código de Interfaz Adicional", "QAA_CodInterfAd" + Nro, detalleReporte);
                Alta.CompletarCampos(Driver, "Código de Interfaz MAE", "QAA_CodIntMAE" + Nro, detalleReporte);
                Alta.CompletarCampos(Driver, "Código de Interfaz Banco", "QAA_CodBanco" + Nro, detalleReporte);
                Alta.CompletarCampos(Driver, "Código Interfaz Agenn", "QAA_CodAgenn" + Nro, detalleReporte);
                Alta.CompletarCampos(Driver, "Código de Interfaz ACSA", "QAA_CodACSA" + Nro, detalleReporte);
                Alta.CompletarCampos(Driver, "Código de Interfaz AFIP", "QAA_CodAFIP" + Nro, detalleReporte);

                //Aceptar Registro
                Alta.Aceptar(Driver, detalleReporte);

                //Modificar Registro
                Modificar.ModificarRegistro(Driver, "QAA_" + Nro, "Código de Interfaz", "Modificado" + Nro, detalleReporte);

                //Baja de Registro
                Bajas.BajaDeRegistro(Driver, "QAA_" + Nro, detalleReporte);

                //Recuperar registro
                Recuperar.RecuperarRegistro(Driver, "QAA_" + Nro, detalleReporte);

                //Auditar Registro
                Assert.IsTrue(Auditar.AuditarRegistro(Driver, "QAA_" + Nro, detalleReporte), "Error en Auditoria");

        }


    }
}
