using System;
using AutoWebSpa.RepositorioDeObjetos;
using OpenQA.Selenium;
using AutoWebSpa.Core.Helpers;
using AutoWebSpa.Core;
using NUnit.Framework;
using AventStack.ExtentReports;

namespace AutoWebSpa.Funciones
{
    public class Detalles : PantallaPrincipal
    {

        public void clickDetalles(IWebDriver Driver, ExtentTest Reportes)
        {
            try
            {
                By botonDetalles = By.XPath("//*[@class='fa fa-list ng-scope']");
                ClickHelpers.Click(Driver, botonDetalles);
                Reportes.Log(Status.Pass,"Click en detalles");
            }
            catch (Exception e)
            {
                Reportes.Log(Status.Fail, "Click en detalles");
                Assert.Fail(e.Message);
            }

        }

        public void ValidarCampos(IWebDriver Driver,string dato,ExtentTest Reportes)
        {
            try
            {
                bool bandera = ElementHelpers.ValidateExist(Driver, By.XPath("//*[contains(text(),'" + dato + "')]"));
                Assert.IsTrue(bandera, "No se registro " + dato);
                Reportes.Log(Status.Pass, "Validar Campo "+"Existe "+dato);
            }
            catch (Exception e)
            {
                Reportes.Log(Status.Fail, "Validar Campo " + "Existe " + dato);
                Assert.Fail(e.Message);
            }

        }
    }
}
