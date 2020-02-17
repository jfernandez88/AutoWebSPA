using System;
using AutoWebSpa.RepositorioDeObjetos;
using OpenQA.Selenium;
using AutoWebSpa.Core.Helpers;
using AutoWebSpa.Core;
using NUnit.Framework;
using AventStack.ExtentReports;

namespace AutoWebSpa.Funciones
{
    public class Modificar : PantallaPrincipal
    {

        public void ClickModificar(IWebDriver Driver, ExtentTest Reportes)
        {
            try
            {
                ClickHelpers.Click(Driver, botonModificar);
                Reportes.Log(Status.Pass,"Click en Modificar");
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }

        public void ModificarRegistro(IWebDriver Driver, string Registro,string Campo, string Dato,ExtentTest Reportes)
        {
            try
            {
                buscarRegistro(Driver, Registro, Reportes);
                selectRegistro(Driver, Registro, Reportes);
                ClickModificar(Driver, Reportes);
                CompletarCampos(Driver, Campo, Dato, Reportes);
                Aceptar(Driver, Reportes);
                Reportes.Log(Status.Pass,"Modificar Registro");
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }

        public void ValidoModificar(IWebDriver Driver,string Registro,string dato, string campo, ExtentTest Reportes)
        {
            try
            {
                selectRegistro(Driver, Registro,Reportes);


            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }
    }
}
