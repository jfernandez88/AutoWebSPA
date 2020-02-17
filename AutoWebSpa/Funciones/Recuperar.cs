using System;
using AutoWebSpa.RepositorioDeObjetos;
using OpenQA.Selenium;
using AutoWebSpa.Core.Helpers;
using AutoWebSpa.Core;
using NUnit.Framework;
using AventStack.ExtentReports;

namespace AutoWebSpa.Funciones
{
    public class Recuperar : PantallaPrincipal 
    {
        public void ClickRecuperar(IWebDriver Driver, ExtentTest Reportes)
        {
            try
            {
                ClickHelpers.Click(Driver, botonRecuperar);
                if (ElementHelpers.ExistsElement(Driver, botonConfirmar))
                    ClickHelpers.Click(Driver, botonConfirmar);
                Reportes.Log(Status.Pass,"Click en Recuperar");
            }
            catch (Exception e)
            {
                Reportes.Log(Status.Fail, "Click en Recuperar");
                Assert.Fail(e.Message);
            }

        }

        public void RecuperarRegistro(IWebDriver Driver, string registro,ExtentTest Reportes)
        {
            try
            {
                buscarRegistro(Driver, registro, Reportes);
                selectRegistro(Driver, registro, Reportes);
                ClickRecuperar(Driver, Reportes);
                Reportes.Log(Status.Pass,"Recuperar registro");
            }
            catch (Exception e)
            {
                Reportes.Log(Status.Fail, "Recuperar registro");
                Assert.Fail(e.Message);
            }

        }

        



    }
}
