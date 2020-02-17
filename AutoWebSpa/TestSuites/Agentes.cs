using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoWebSpa.Core;
using AutoWebSpa.Funciones;
using NUnit.Framework;

namespace AutoWebSpa.TestSuites.Agentes
{
    [TestFixture]
    [Parallelizable]
    public class Agentes : SeleniumExtentReport
    {
        public Agentes() { }
        Login Login = new Login();
        Alta Alta = new Alta();
        Baja Bajas = new Baja();
        Modificar Modificar = new Modificar();
        Detalles Detalles = new Detalles();
        Recuperar Recuperar = new Recuperar();
        Auditar Auditar = new Auditar();
        Random rnd = new Random();



        [Test]
        public void Agentes_Alta()
        {

            int Nro = rnd.Next(900);

            //Alta
            Login.Loguearse("sa", "sasa", Driver, detalleReporte);
            Alta.SeleccionarModulo("Agentes", Driver, detalleReporte);
            Alta.AdicionarElemento(Driver, detalleReporte);

            //Completar Datos Generales
            Alta.CompletarDescripcion(Driver, "QAA_" + Nro,detalleReporte);
            Alta.CompletarNumero(Driver, Nro.ToString(),"NumeroAgente", detalleReporte);
            Alta.CompletarCampos(Driver, "Tipo de Agente", "Agente de Bolsa", detalleReporte, 2);

            Alta.selectorGenerico(Driver, "Tipo de Contribuyente ","CONSUMIDOR FINAL", detalleReporte);
            Alta.selectorGenerico(Driver, "Emisor", "Acindar", detalleReporte);

            Alta.CompletarCampos(Driver, "CUIT", "30619689255", detalleReporte);
            Alta.CompletarCampos(Driver, "Código de Interfaz", "Codin"+Nro, detalleReporte);
            Alta.CheckGenerico(Driver, "Afecta Margen de Liquidez");

            //Domicilio
            Alta.ClickEnLink(Driver,"Domicilio",detalleReporte);
            Alta.CompletarCampos(Driver, "Calle", "Calle"+Nro, detalleReporte);
            Alta.CompletarCampos(Driver, "Altura Calle", "5"+ Nro, detalleReporte);
            Alta.CompletarCampos(Driver, "Piso", "16", detalleReporte);
            Alta.CompletarCampos(Driver, "Departamento", "Dep" + Nro, detalleReporte);
            Alta.CompletarCampos(Driver, "Localidad", "Localidad" + Nro, detalleReporte);
            Alta.CompletarCampos(Driver, "Código Postal", "2"+Nro, detalleReporte);
            Alta.selectorGenerico(Driver,"País","Argentina",detalleReporte);
            Alta.selectorGenerico(Driver, "Provincia", "Cordoba", detalleReporte);
            Alta.CompletarCampos(Driver,"Email","Test@email.com",detalleReporte);
            Alta.CompletarCampos(Driver,"Teléfono",3+Nro.ToString(),detalleReporte);
            Alta.CompletarCampos(Driver,"Fax",4+Nro.ToString(),detalleReporte);
            Alta.CompletarCampos(Driver,"Contacto",5+Nro.ToString(),detalleReporte);

            //Observaciones
            Alta.ClickEnLink(Driver,"Observaciones",detalleReporte);
            Alta.CompletarNumero(Driver,"Observaciones"+Nro,"Observaciones",detalleReporte);

            //Aceptar
            Alta.Aceptar(Driver,detalleReporte);

            //Click en detalles de registro
            Detalles.buscarRegistro(Driver, "QAA_" + Nro, detalleReporte);
            Detalles.selectRegistro(Driver, "QAA_" + Nro, detalleReporte);
            Detalles.clickDetalles(Driver, detalleReporte);

            //Validar Campos Datos Generales
            Detalles.ValidarCampos(Driver, "CONSUMIDOR FINAL", detalleReporte);
            Detalles.ValidarCampos(Driver, "Acindar", detalleReporte);
            Detalles.ValidarCampos(Driver, "30-61968925-5", detalleReporte);
            Detalles.ValidarCampos(Driver, "Codin" + Nro, detalleReporte);
            Detalles.ValidarCampos(Driver, "Afecta Margen de Liquidez", detalleReporte);

            //Validar Domicilio
            Alta.ClickEnLink(Driver,"Domicilio",detalleReporte);

            Detalles.ValidarCampos(Driver, "CONSUMIDOR FINAL", detalleReporte);
            Detalles.ValidarCampos(Driver, "Calle" + Nro, detalleReporte);
            Detalles.ValidarCampos(Driver, "5" + Nro, detalleReporte);
            Detalles.ValidarCampos(Driver, "16", detalleReporte);
            Detalles.ValidarCampos(Driver, "Dep" + Nro, detalleReporte);
            Detalles.ValidarCampos(Driver, "Localidad" + Nro, detalleReporte);
            Detalles.ValidarCampos(Driver, "2" + Nro, detalleReporte);
            Detalles.ValidarCampos(Driver, "Argentina", detalleReporte);
            Detalles.ValidarCampos(Driver, "Cordoba", detalleReporte);
            Detalles.ValidarCampos(Driver, "Test@email.com", detalleReporte);
            Detalles.ValidarCampos(Driver, "3"+Nro.ToString(), detalleReporte);
            Detalles.ValidarCampos(Driver, "4"+Nro.ToString(), detalleReporte);
            Detalles.ValidarCampos(Driver, "5"+Nro.ToString(), detalleReporte);

            //Observaciones
            Alta.ClickEnLink(Driver, "Observaciones", detalleReporte);
            Detalles.ValidarCampos(Driver, "Observaciones"+Nro, detalleReporte);

        }


        [Test]
        public void Agentes_Baja()
        {

            int Nro = rnd.Next(900);

                //Alta
                Login.Loguearse("sa", "sasa", Driver, detalleReporte);
                Alta.SeleccionarModulo("Agentes", Driver, detalleReporte);
                Alta.AdicionarElemento(Driver, detalleReporte);

                //Completar Datos Generales
                Alta.CompletarDescripcion(Driver, "QAA_" + Nro, detalleReporte);
                Alta.CompletarNumero(Driver, Nro.ToString(), "NumeroAgente", detalleReporte);
                Alta.CompletarCampos(Driver, "Tipo de Agente", "Agente de Bolsa", detalleReporte, 2);

                Alta.selectorGenerico(Driver, "Tipo de Contribuyente ", "CONSUMIDOR FINAL", detalleReporte);
                Alta.selectorGenerico(Driver, "Emisor", "Acindar", detalleReporte);

                Alta.CompletarCampos(Driver, "CUIT", "30619689255", detalleReporte);
                Alta.CompletarCampos(Driver, "Código de Interfaz", "Codin" + Nro, detalleReporte);
                Alta.CheckGenerico(Driver, "Afecta Margen de Liquidez");

                //Domicilio
                Alta.ClickEnLink(Driver, "Domicilio", detalleReporte);
                Alta.CompletarCampos(Driver, "Calle", "Calle" + Nro, detalleReporte);
                Alta.CompletarCampos(Driver, "Altura Calle", "5" + Nro, detalleReporte);
                Alta.CompletarCampos(Driver, "Piso", "16", detalleReporte);
                Alta.CompletarCampos(Driver, "Departamento", "Dep" + Nro, detalleReporte);
                Alta.CompletarCampos(Driver, "Localidad", "Localidad" + Nro, detalleReporte);
                Alta.CompletarCampos(Driver, "Código Postal", "2" + Nro, detalleReporte);
                Alta.selectorGenerico(Driver, "País", "Argentina", detalleReporte);
                Alta.selectorGenerico(Driver, "Provincia", "Cordoba", detalleReporte);
                Alta.CompletarCampos(Driver, "Email", "Test@email.com", detalleReporte);
                Alta.CompletarCampos(Driver, "Teléfono", 3 + Nro.ToString(), detalleReporte);
                Alta.CompletarCampos(Driver, "Fax", 4 + Nro.ToString(), detalleReporte);
                Alta.CompletarCampos(Driver, "Contacto", 5 + Nro.ToString(), detalleReporte);

                //Observaciones
                Alta.ClickEnLink(Driver, "Observaciones", detalleReporte);
                Alta.CompletarNumero(Driver, "Observaciones" + Nro, "Observaciones", detalleReporte);

                //Aceptar Registro
                Alta.Aceptar(Driver, detalleReporte);

                //Dar Baja
                Bajas.BajaDeRegistro(Driver, "QAA_" + Nro, detalleReporte);
                Bajas.ValidarBaja(Driver, "QAA_" + Nro, detalleReporte);



        }

        [Test]
        public void Agentes_Modificar()
        {

            int Nro = rnd.Next(900);
                //Alta
                Login.Loguearse("sa", "sasa", Driver, detalleReporte);
                Alta.SeleccionarModulo("Agentes", Driver, detalleReporte);
                Alta.AdicionarElemento(Driver, detalleReporte);

                //Completar Datos Generales
                Alta.CompletarDescripcion(Driver, "QAA_" + Nro, detalleReporte);
                Alta.CompletarNumero(Driver, Nro.ToString(), "NumeroAgente", detalleReporte);
                Alta.CompletarCampos(Driver, "Tipo de Agente", "Agente de Bolsa", detalleReporte, 2);

                Alta.selectorGenerico(Driver, "Tipo de Contribuyente ", "CONSUMIDOR FINAL", detalleReporte);
                Alta.selectorGenerico(Driver, "Emisor", "Acindar", detalleReporte);

                Alta.CompletarCampos(Driver, "CUIT", "30619689255", detalleReporte);
                Alta.CompletarCampos(Driver, "Código de Interfaz", "Codin" + Nro, detalleReporte);
                Alta.CheckGenerico(Driver, "Afecta Margen de Liquidez");

                //Domicilio
                Alta.ClickEnLink(Driver, "Domicilio", detalleReporte);
                Alta.CompletarCampos(Driver, "Calle", "Calle" + Nro, detalleReporte);
                Alta.CompletarCampos(Driver, "Altura Calle", "5" + Nro, detalleReporte);
                Alta.CompletarCampos(Driver, "Piso", "16", detalleReporte);
                Alta.CompletarCampos(Driver, "Departamento", "Dep" + Nro, detalleReporte);
                Alta.CompletarCampos(Driver, "Localidad", "Localidad" + Nro, detalleReporte);
                Alta.CompletarCampos(Driver, "Código Postal", "2" + Nro, detalleReporte);
                Alta.selectorGenerico(Driver, "País", "Argentina", detalleReporte);
                Alta.selectorGenerico(Driver, "Provincia", "Cordoba", detalleReporte);
                Alta.CompletarCampos(Driver, "Email", "Test@email.com", detalleReporte);
                Alta.CompletarCampos(Driver, "Teléfono", 3 + Nro.ToString(), detalleReporte);
                Alta.CompletarCampos(Driver, "Fax", 4 + Nro.ToString(), detalleReporte);
                Alta.CompletarCampos(Driver, "Contacto", 5 + Nro.ToString(), detalleReporte);

                //Observaciones
                Alta.ClickEnLink(Driver, "Observaciones", detalleReporte);
                Alta.CompletarNumero(Driver, "Observaciones" + Nro, "Observaciones", detalleReporte);

                //Aceptar Registro
                Alta.Aceptar(Driver, detalleReporte);

                //Modificar Registro
                Modificar.ModificarRegistro(Driver, "QAA_" + Nro, "Código de Interfaz", "Modificado", detalleReporte);

                //Validar Modificación
                Detalles.buscarRegistro(Driver, "QAA_" + Nro, detalleReporte);
                Detalles.selectRegistro(Driver, "QAA_" + Nro, detalleReporte);
                Detalles.clickDetalles(Driver, detalleReporte);

                //Validar Campos
                Detalles.ValidarCampos(Driver, "Modificado", detalleReporte);

        }


        [Test]
        public void Agentes_Auditar()
        {

            int Nro = rnd.Next(500);

                //Alta
                Login.Loguearse("sa", "sasa", Driver, detalleReporte);
                Alta.SeleccionarModulo("Agentes", Driver, detalleReporte);
                Alta.AdicionarElemento(Driver, detalleReporte);

                //Completar Datos Generales
                Alta.CompletarDescripcion(Driver, "QAA_" + Nro, detalleReporte);
                Alta.CompletarNumero(Driver, Nro.ToString(), "NumeroAgente", detalleReporte);
                Alta.CompletarCampos(Driver, "Tipo de Agente", "Agente de Bolsa", detalleReporte, 2);

                Alta.selectorGenerico(Driver, "Tipo de Contribuyente ", "CONSUMIDOR FINAL", detalleReporte);
                Alta.selectorGenerico(Driver, "Emisor", "Acindar", detalleReporte);

                Alta.CompletarCampos(Driver, "CUIT", "30619689255", detalleReporte);
                Alta.CompletarCampos(Driver, "Código de Interfaz", "Codin" + Nro, detalleReporte);
                Alta.CheckGenerico(Driver, "Afecta Margen de Liquidez");

                //Domicilio
                Alta.ClickEnLink(Driver, "Domicilio", detalleReporte);
                Alta.CompletarCampos(Driver, "Calle", "Calle" + Nro, detalleReporte);
                Alta.CompletarCampos(Driver, "Altura Calle", "5" + Nro, detalleReporte);
                Alta.CompletarCampos(Driver, "Piso", "16", detalleReporte);
                Alta.CompletarCampos(Driver, "Departamento", "Dep" + Nro, detalleReporte);
                Alta.CompletarCampos(Driver, "Localidad", "Localidad" + Nro, detalleReporte);
                Alta.CompletarCampos(Driver, "Código Postal", "2" + Nro, detalleReporte);
                Alta.selectorGenerico(Driver, "País", "Argentina", detalleReporte);
                Alta.selectorGenerico(Driver, "Provincia", "Cordoba", detalleReporte);
                Alta.CompletarCampos(Driver, "Email", "Test@email.com", detalleReporte);
                Alta.CompletarCampos(Driver, "Teléfono", 3 + Nro.ToString(), detalleReporte);
                Alta.CompletarCampos(Driver, "Fax", 4 + Nro.ToString(), detalleReporte);
                Alta.CompletarCampos(Driver, "Contacto", 5 + Nro.ToString(), detalleReporte);

                //Observaciones
                Alta.ClickEnLink(Driver, "Observaciones", detalleReporte);
                Alta.CompletarNumero(Driver, "Observaciones" + Nro, "Observaciones", detalleReporte);

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
