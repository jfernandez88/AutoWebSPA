using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoWebSpa.Core;
using AutoWebSpa.Funciones;
using NUnit.Framework;


namespace AutoWebSpa.TestSuites.Provincias
{
    [TestFixture]
    [Parallelizable]
    public class Provincias : SeleniumExtentReport
    {
        public Provincias() { }
        Login Login = new Login();
        Alta Alta = new Alta();
        Baja Bajas = new Baja();
        Modificar Modificar = new Modificar();
        Detalles Detalles = new Detalles();
        Recuperar Recuperar = new Recuperar();
        Auditar Auditar = new Auditar();
        Random rnd = new Random();


        [Test]
        public void Provincias_Alta()
        {


            int Nro = rnd.Next(900);

            //Alta
            Login.Loguearse("sa", "sasa", Driver, detalleReporte);
            Alta.SeleccionarModulo("Provincias", Driver, detalleReporte);
            Alta.AdicionarElemento(Driver, detalleReporte);
            Alta.selectorGenerico(Driver, "País", "Argentina", detalleReporte, 2);
            Alta.CompletarNumero(Driver, "QAA_" + Nro, "Descripcion", detalleReporte);
            Alta.CompletarCampos(Driver, "Tipo de Riesgo", "Alto", detalleReporte, 2);
            Alta.CompletarCampos(Driver, "Código de Interfaz", "CodInt" + Nro, detalleReporte);
            Alta.CompletarCampos(Driver, "Código de Interfaz Adicional", "CodIntAd" + Nro, detalleReporte);
            Alta.CompletarCampos(Driver, "Código de Interfaz Banco", "CodIntBanco" + Nro, detalleReporte);
            Alta.CompletarCampos(Driver, "Código de DGI", "CodDGI" + Nro, detalleReporte);
            Alta.CompletarCampos(Driver, "Código AFIP", "CodAFIP" + Nro, detalleReporte);

            //Aceptar Registro
            Alta.Aceptar(Driver, detalleReporte);

            //Click en detalles de registro
            Detalles.buscarRegistro(Driver, "QAA_" + Nro, detalleReporte);
            Detalles.selectRegistro(Driver, "QAA_" + Nro, detalleReporte);
            Detalles.clickDetalles(Driver, detalleReporte);

            //Validar Campos
            Detalles.ValidarCampos(Driver, "Alto", detalleReporte);
            Detalles.ValidarCampos(Driver, "CodInt" + Nro, detalleReporte);
            Detalles.ValidarCampos(Driver, "CodIntAd" + Nro, detalleReporte);
            Detalles.ValidarCampos(Driver, "CodIntBanco" + Nro, detalleReporte);
            Detalles.ValidarCampos(Driver, "CodDGI" + Nro, detalleReporte);
            Detalles.ValidarCampos(Driver, "CodAFIP" + Nro, detalleReporte);



        }


        [Test]
        public void Provincias_Baja()
        {

            int Nro = rnd.Next(900);

            //Alta
            Login.Loguearse("sa", "sasa", Driver, detalleReporte);
            Alta.SeleccionarModulo("Provincias", Driver, detalleReporte);
            Alta.AdicionarElemento(Driver, detalleReporte);
            Alta.selectorGenerico(Driver, "País", "Argentina", detalleReporte, 2);
            Alta.CompletarNumero(Driver, "QAA_" + Nro, "Descripcion", detalleReporte);
            Alta.CompletarCampos(Driver, "Tipo de Riesgo", "Alto", detalleReporte, 2);
            Alta.CompletarCampos(Driver, "Código de Interfaz", "CodInt" + Nro, detalleReporte);
            Alta.CompletarCampos(Driver, "Código de Interfaz Adicional", "CodIntAd" + Nro, detalleReporte);
            Alta.CompletarCampos(Driver, "Código de Interfaz Banco", "CodIntBanco" + Nro, detalleReporte);
            Alta.CompletarCampos(Driver, "Código de DGI", "CodDGI" + Nro, detalleReporte);
            Alta.CompletarCampos(Driver, "Código AFIP", "CodAFIP" + Nro, detalleReporte);
            //Aceptar Registro
            Alta.Aceptar(Driver, detalleReporte);

            //Dar Baja
            Bajas.BajaDeRegistro(Driver, "QAA_" + Nro, detalleReporte);
            Bajas.ValidarBaja(Driver, "QAA_" + Nro, detalleReporte);



        }

        [Test]
        public void Provincias_Modificar()
        {

            int Nro = rnd.Next(900);

            // Alta
            Login.Loguearse("sa", "sasa", Driver, detalleReporte);
            Alta.SeleccionarModulo("Provincias", Driver, detalleReporte);
            Alta.AdicionarElemento(Driver, detalleReporte);
            Alta.selectorGenerico(Driver, "País", "Argentina", detalleReporte, 2);
            Alta.CompletarNumero(Driver, "QAA_" + Nro, "Descripcion", detalleReporte);
            Alta.CompletarCampos(Driver, "Tipo de Riesgo", "Alto", detalleReporte, 2);
            Alta.CompletarCampos(Driver, "Código de Interfaz", "CodInt" + Nro, detalleReporte);
            Alta.CompletarCampos(Driver, "Código de Interfaz Adicional", "CodIntAd" + Nro, detalleReporte);
            Alta.CompletarCampos(Driver, "Código de Interfaz Banco", "CodIntBanco" + Nro, detalleReporte);
            Alta.CompletarCampos(Driver, "Código de DGI", "CodDGI" + Nro, detalleReporte);
            Alta.CompletarCampos(Driver, "Código AFIP", "CodAFIP" + Nro, detalleReporte);

            //Aceptar Registro
            Alta.Aceptar(Driver, detalleReporte);

            //Modificar Registro
            Modificar.ModificarRegistro(Driver, "QAA_" + Nro, "Código de Interfaz", "Modificado" + Nro, detalleReporte);

            //Validar Modificación
            Detalles.buscarRegistro(Driver, "QAA_" + Nro, detalleReporte);
            Detalles.selectRegistro(Driver, "QAA_" + Nro, detalleReporte);
            Detalles.clickDetalles(Driver, detalleReporte);

            //Validar Campos
            Detalles.ValidarCampos(Driver, "Modificado" + Nro, detalleReporte);

        }

        [Test]
        public void Provincias_Auditar()
        {

            int Nro = rnd.Next(500);


            // Alta
            Login.Loguearse("sa", "sasa", Driver, detalleReporte);
            Alta.SeleccionarModulo("Provincias", Driver, detalleReporte);
            Alta.AdicionarElemento(Driver, detalleReporte);
            Alta.CompletarDescripcion(Driver, "QAA_" + Nro, detalleReporte);
            Alta.selectorGenerico(Driver, "País", "Argentina", detalleReporte, 2);
            Alta.CompletarCampos(Driver, "Tipo de Riesgo", "Alto", detalleReporte, 2);
            Alta.CompletarCampos(Driver, "Código de Interfaz", "CodInter" + Nro, detalleReporte);
            Alta.CompletarCampos(Driver, "Código de DGI", "CodInter" + Nro, detalleReporte);
            Alta.CompletarCampos(Driver, "Código de Interfaz Adicional", "CodAd" + Nro, detalleReporte);

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
