using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoWebSpa.Core;
using AutoWebSpa.Funciones;
using NUnit.Framework;
using AutoWebSpa.Core.Query;


namespace AutoWebSpa.TestSuites.Actividades
{
 [TestFixture]  
 [Parallelizable]
    public class Actividades : SeleniumExtentReport
    {
        public Actividades()  { }
        Login Login = new Login();
        Alta Alta = new Alta();
        Baja Bajas = new Baja();
        Modificar Modificar = new Modificar();
        Auditar Auditar = new Auditar();
        Detalles Detalles = new Detalles();
        Random rnd = new Random();
        Recuperar Recuperar = new Recuperar();


        [Test]
        public void Actividades_Alta()
        {

            int Nro = rnd.Next(100000);

            //Alta
            Login.Loguearse("sa", "sasa", Driver, detalleReporte);
            Alta.SeleccionarModulo("Actividades", Driver, detalleReporte);
            Alta.AdicionarElemento(Driver, detalleReporte);
            Alta.CompletarDescripcion(Driver, "QAA_"+Nro, detalleReporte);
            Alta.CompletarCampos(Driver, "Tipo de Riesgo", "Alto", detalleReporte, 2);
            Alta.CompletarCampos(Driver, "Código de DGI", "QAA_CodigoDeDGI"+Nro, detalleReporte);
            Alta.CompletarCampos(Driver, "Código de Interfaz", "QAA_CodigoInterfaz"+Nro, detalleReporte);
            Alta.CompletarCampos(Driver, "Código de Interfaz Adicional", "QAA_CodIntAdicional"+Nro, detalleReporte);
            Alta.CompletarCampos(Driver, "Código de Interfaz Banco", "QAA_CodIntBanco"+Nro, detalleReporte);

            //Aceptar Registro
            Alta.Aceptar(Driver, detalleReporte);

            //Click en detalles de registro
            Detalles.buscarRegistro(Driver, "QAA_"+Nro, detalleReporte);
            Detalles.selectRegistro(Driver,"QAA_"+Nro, detalleReporte);
            Detalles.clickDetalles(Driver, detalleReporte);

            //Validar Campos
            Detalles.ValidarCampos(Driver,"QAA_CodigoDeDGI" + Nro, detalleReporte);
            Detalles.ValidarCampos(Driver,"QAA_CodigoInterfaz" + Nro, detalleReporte);
            Detalles.ValidarCampos(Driver,"QAA_CodIntAdicional" + Nro, detalleReporte);
            Detalles.ValidarCampos(Driver,"QAA_CodIntBanco" + Nro, detalleReporte);
            

        }


      

       [Test]
        public void Actividades_Baja()
        {

            int Nro = rnd.Next(100000);

                //Alta
                Login.Loguearse("sa", "sasa", Driver, detalleReporte);
                Alta.SeleccionarModulo("Actividades", Driver, detalleReporte);
                Alta.AdicionarElemento(Driver, detalleReporte);
                Alta.CompletarDescripcion(Driver, "QAA_" + Nro, detalleReporte);
                Alta.CompletarCampos(Driver, "Tipo de Riesgo", "Alto", detalleReporte, 2);
                Alta.CompletarCampos(Driver, "Código de DGI", "QAA_CodigoDeDGI" + Nro, detalleReporte);
                Alta.CompletarCampos(Driver, "Código de Interfaz", "QAA_CodigoInterfaz" + Nro, detalleReporte);
                Alta.CompletarCampos(Driver, "Código de Interfaz Adicional", "QAA_CodIntAdicional" + Nro, detalleReporte);
                Alta.CompletarCampos(Driver, "Código de Interfaz Banco", "QAA_CodIntBanco" + Nro, detalleReporte);

                //Aceptar Registro
                Alta.Aceptar(Driver, detalleReporte);

                //Dar Baja
                Bajas.BajaDeRegistro(Driver, "QAA_" + Nro, detalleReporte);
                Bajas.ValidarBaja(Driver, "QAA_" + Nro, detalleReporte);



        }

        [Test]
        public void Actividades_Modificar()
        {

            int Nro = rnd.Next(100000);

                // Alta
                Login.Loguearse("sa", "sasa", Driver, detalleReporte);
                Alta.SeleccionarModulo("Actividades", Driver, detalleReporte);
                Alta.AdicionarElemento(Driver, detalleReporte);
                Alta.CompletarDescripcion(Driver, "QAA_" + Nro, detalleReporte);
                Alta.CompletarCampos(Driver, "Tipo de Riesgo", "Alto", detalleReporte, 2);
                Alta.CompletarCampos(Driver, "Código de DGI", "QAA_CodigoDeDGI" + Nro, detalleReporte);
                Alta.CompletarCampos(Driver, "Código de Interfaz", "QAA_CodigoInterfaz" + Nro, detalleReporte);
                Alta.CompletarCampos(Driver, "Código de Interfaz Adicional", "QAA_CodIntAdicional" + Nro, detalleReporte);
                Alta.CompletarCampos(Driver, "Código de Interfaz Banco", "QAA_CodIntBanco" + Nro, detalleReporte);

                //Aceptar Registro
                Alta.Aceptar(Driver, detalleReporte);

                //Modificar Registro
                Modificar.ModificarRegistro(Driver, "QAA_" + Nro, "Código de DGI", "Modificado"+Nro,detalleReporte);

                //Validar Modificación
                Detalles.buscarRegistro(Driver, "QAA_" + Nro, detalleReporte);
                Detalles.selectRegistro(Driver, "QAA_" + Nro, detalleReporte);
                Detalles.clickDetalles(Driver, detalleReporte);

                //Validar Campos
                Detalles.ValidarCampos(Driver, "Modificado"+Nro, detalleReporte);

        }

        [Test]
        public void Actividades_Auditar()
        {

            int Nro = rnd.Next(100000);


                // Alta
                Login.Loguearse("sa", "sasa", Driver, detalleReporte);
                Alta.SeleccionarModulo("Actividades", Driver, detalleReporte);
                Alta.AdicionarElemento(Driver, detalleReporte);
                Alta.CompletarDescripcion(Driver, "QAA_" + Nro, detalleReporte);
                Alta.CompletarCampos(Driver, "Tipo de Riesgo", "Alto", detalleReporte, 2);
                Alta.CompletarCampos(Driver, "Código de DGI", "QAA_CodigoDeDGI" + Nro, detalleReporte);
                Alta.CompletarCampos(Driver, "Código de Interfaz", "QAA_CodigoInterfaz" + Nro, detalleReporte);
                Alta.CompletarCampos(Driver, "Código de Interfaz Adicional", "QAA_CodIntAdicional" + Nro, detalleReporte);
                Alta.CompletarCampos(Driver, "Código de Interfaz Banco", "QAA_CodIntBanco" + Nro, detalleReporte);

                //Aceptar Registro
                Alta.Aceptar(Driver, detalleReporte);

                //Modificar Registro
                Modificar.ModificarRegistro(Driver, "QAA_" + Nro, "Código de DGI", "Modificado" + Nro, detalleReporte);

                //Baja de Registro
                Bajas.BajaDeRegistro(Driver, "QAA_" + Nro, detalleReporte);

                //Recuperar registro
                Recuperar.RecuperarRegistro(Driver,"QAA_"+Nro,detalleReporte);
                
                //Auditar Registro
                Assert.IsTrue(Auditar.AuditarRegistro(Driver,"QAA_" + Nro, detalleReporte),"Error en Auditoria");

        }

            

    }
}
