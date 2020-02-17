using System;
using AutoWebSpa.RepositorioDeObjetos;
using OpenQA.Selenium;
using AutoWebSpa.Core.Helpers;
using AutoWebSpa.Core;
using NUnit.Framework;
using AventStack.ExtentReports;

namespace AutoWebSpa.Funciones
{
    public class Alta : PantallaPrincipal
    {

        public void SeleccionarModulo(string Modulo, IWebDriver Driver, ExtentTest Reportes)
        {
            try
            {

                WaitHelpers.WaitElementExists(Driver, inputBuscarModulo);
                InputHelpers.SendKey(Driver, inputBuscarModulo, Modulo);
                By ModuloBuscado = By.XPath("//strong[contains(text(),'" + Modulo + "')]");
                WaitHelpers.WaitElementExists(Driver, ModuloBuscado);
                ClickHelpers.Click(Driver, ModuloBuscado);
                By tituloMenu = By.XPath("//*[@class='tab-pane ng-binding font-blue-sharp active'][contains(text(),'" + Modulo + "')]");
                WaitHelpers.WaitElementExists(Driver, tituloMenu);
                Reportes.Log(Status.Pass,"Seleccionar Modulo "+Modulo);

            }
            catch (Exception e)
            {             
                Reportes.Log(Status.Fail,"Seleccionar Modulo "+Modulo);
                Assert.Fail(e.Message);
            }
            
        }

        public void AdicionarElemento(IWebDriver Driver, ExtentTest Reportes)
        {
            //Click en Alta
            try
            {
                WaitHelpers.WaitElementExists(Driver, botonAdicionarElemento);
                ClickHelpers.Click(Driver, botonAdicionarElemento);
                Reportes.Log(Status.Pass,"Adicionar Elemento");

            }
            catch (Exception e)
            {
                Reportes.Log(Status.Fail,"Adicionar Elemento");
                Assert.Fail(e.Message);
            }
        }


        public void CompletarDescripcion(IWebDriver Driver, string Desc, ExtentTest Reportes)
        {
            try
            {
                By inputDescripción = By.XPath("//*[@name='d.Descripcion']");
                InputHelpers.SendKey(Driver, inputDescripción, Desc);
                Reportes.Log(Status.Pass,"Completar Descripción "+Desc);

            }
            catch (Exception e)
            {
                Reportes.Log(Status.Fail, "Completar Descripción " + Desc);
                Assert.Fail(e.Message);
            }

        }

        public void CompletarNumero(IWebDriver Driver, string Nro, string Campo,ExtentTest Reportes)
        {
            try
            {
                By inputDescripción = By.XPath("//*[@name='d."+Campo+"']");
                InputHelpers.SendKey(Driver, inputDescripción, Nro);
                Reportes.Log(Status.Pass,"Completar número "+Campo+" : "+Nro);

            }
            catch (Exception e)
            {
                Reportes.Log(Status.Fail, "Completar número " + Campo + " : " + Nro);
                Assert.Fail(e.Message);
            }

        }


    }
}
