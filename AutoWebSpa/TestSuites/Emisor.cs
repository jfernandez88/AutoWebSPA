using System;
using AutoWebSpa.Core;
using AutoWebSpa.Funciones;
using NUnit.Framework;


namespace AutoWebSpa.TestSuites.Emisor
{
 [TestFixture]  
 [Parallelizable]
    public class Emisor : SeleniumExtentReport
    {
        public Emisor()  { }
        Login Login = new Login();
        Alta Alta = new Alta();
        Baja Bajas = new Baja();
        Modificar Modificar = new Modificar();
        Detalles Detalles = new Detalles();
        Recuperar Recuperar = new Recuperar();
        Auditar Auditar = new Auditar();
        Random rnd = new Random();


        [Test]
        public void Emisor_Alta()
        {


            int Nro = rnd.Next(900);

                //Alta
                Login.Loguearse("sa", "sasa", Driver, detalleReporte);
                Alta.SeleccionarModulo("Emisor", Driver, detalleReporte);
                Alta.AdicionarElemento(Driver, detalleReporte);
                Alta.CompletarDescripcion(Driver, "QAA_"+Nro, detalleReporte);
                Alta.selectorGenerico(Driver,"Grupos Económicos","TELECOM",detalleReporte);
                Alta.selectorGenerico(Driver, "País", "Argentina", detalleReporte);
                Alta.CompletarCampos(Driver, "CUIT", "30-61968925-5" + Nro, detalleReporte);
                Alta.CompletarCampos(Driver, "Código de Interfaz", "CodInter"+Nro, detalleReporte );

                //Aceptar Registro
                Alta.Aceptar(Driver, detalleReporte);

                //Click en detalles de registro
                Detalles.buscarRegistro(Driver, "QAA_"+Nro, detalleReporte);
                Detalles.selectRegistro(Driver,"QAA_"+Nro, detalleReporte);
                Detalles.clickDetalles(Driver, detalleReporte);

                //Validar Campos
                Detalles.ValidarCampos(Driver, "CodInter" + Nro, detalleReporte);
                Detalles.ValidarCampos(Driver, "TELECOM", detalleReporte);
                Detalles.ValidarCampos(Driver, "Argentina", detalleReporte);
                Detalles.ValidarCampos(Driver, "30-61968925-5", detalleReporte);
                Detalles.ValidarCampos(Driver, "CodInter" + Nro, detalleReporte);



        }

     
        [Test]
        public void Emisor_Baja()
        {

            int Nro = rnd.Next(900);

                //Alta
                Login.Loguearse("sa", "sasa", Driver, detalleReporte);
                Alta.SeleccionarModulo("Emisor", Driver, detalleReporte);
                Alta.AdicionarElemento(Driver, detalleReporte);
                Alta.CompletarDescripcion(Driver, "QAA_" + Nro, detalleReporte);
                Alta.selectorGenerico(Driver, "Grupos Económicos", "TELECOM", detalleReporte);
                Alta.selectorGenerico(Driver, "País", "Argentina", detalleReporte);
                Alta.CompletarCampos(Driver, "CUIT", "30-61968925-5" + Nro, detalleReporte);
                Alta.CompletarCampos(Driver, "Código de Interfaz", "CodInter" + Nro, detalleReporte);

                //Aceptar Registro
                Alta.Aceptar(Driver, detalleReporte);

                //Dar Baja
                Bajas.BajaDeRegistro(Driver, "QAA_" + Nro, detalleReporte);
                Bajas.ValidarBaja(Driver, "QAA_" + Nro, detalleReporte);

        }

        [Test]
        public void Emisor_Modificar()
        {

            int Nro = rnd.Next(900);

                //Alta 
                Login.Loguearse("sa", "sasa", Driver, detalleReporte);
                Alta.SeleccionarModulo("Emisor", Driver, detalleReporte);
                Alta.AdicionarElemento(Driver, detalleReporte);
                Alta.CompletarDescripcion(Driver, "QAA_" + Nro, detalleReporte);
                Alta.selectorGenerico(Driver, "Grupos Económicos", "TELECOM", detalleReporte);
                Alta.selectorGenerico(Driver, "País", "Argentina", detalleReporte);
                Alta.CompletarCampos(Driver, "CUIT", "30-61968925-5" + Nro, detalleReporte);
                Alta.CompletarCampos(Driver, "Código de Interfaz", "CodInter" + Nro, detalleReporte);

                //Aceptar Registro
                Alta.Aceptar(Driver, detalleReporte);

                //Modificar Registro
                Modificar.ModificarRegistro(Driver, "QAA_" + Nro, "Código de Interfaz", "Modificado"+Nro,detalleReporte);

                //Validar Modificación
                Detalles.buscarRegistro(Driver, "QAA_" + Nro, detalleReporte);
                Detalles.selectRegistro(Driver, "QAA_" + Nro, detalleReporte);
                Detalles.clickDetalles(Driver, detalleReporte);

                //Validar Campos
                Detalles.ValidarCampos(Driver, "Modificado"+Nro, detalleReporte);

        }

        [Test]
        public void Emisor_Auditar()
        {

            int Nro = rnd.Next(500);

                // Alta
                Login.Loguearse("sa", "sasa", Driver, detalleReporte);
                Alta.SeleccionarModulo("Emisor", Driver, detalleReporte);
                Alta.AdicionarElemento(Driver, detalleReporte);
                Alta.CompletarDescripcion(Driver, "QAA_" + Nro, detalleReporte);
                Alta.selectorGenerico(Driver, "Grupos Económicos", "TELECOM", detalleReporte);
                Alta.selectorGenerico(Driver, "País", "Argentina", detalleReporte);
                Alta.CompletarCampos(Driver, "CUIT", "30-61968925-5" + Nro, detalleReporte);
                Alta.CompletarCampos(Driver, "Código de Interfaz", "CodInter" + Nro, detalleReporte);

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
