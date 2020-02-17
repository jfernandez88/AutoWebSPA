using AutoWebSpa.Core;
using AutoWebSpa.Core.Helpers;
using AventStack.ExtentReports;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Threading;

namespace AutoWebSpa.RepositorioDeObjetos
{
    public class PantallaPrincipal
    {
        #region Objetos principales
        public By inputBuscarModulo = By.XPath("//*[@placeholder='Buscar']");
        public By botonAdicionarElemento = By.XPath("//*[@class='fa fa-plus-square font-green ng-scope']");
        public By panelDeBusquedaMenus = By.XPath("//strong[contains(text(),'MENU')]");
        public By tituloMenu = By.XPath("//*[@class='tab-pane ng-binding font-blue-sharp active'][contains(text(),'MENU')]");
        public By labelErrores = By.XPath("//span[@ng-bind-html='error']");
        public By ByLblLoading =  By.XPath("//div[@class='loading-message']"); 
        public By botonEliminar = By.XPath("//button[@popover-title = 'Eliminar']");
        public By botonConfirmar = By.XPath("//a[@data-apply= 'confirmation']");
        public By filaElminada = By.XPath("//*[contains(@class,'rowAnulada')]");
        public By botonModificar = By.XPath("//div[@tooltip-text= 'ModificarElemento']/button");
        public By botonAuditar = By.XPath("//button[contains(@ng-click, 'auditoriaItem')]");
        public By tableAuditoria = By.XPath("//div[@options='auditoria.gridAuditoria']//tbody");
        public By rowTableAuditoria = By.XPath("//span[@ng-bind='dataItem.Accion']");
        public By botonRecuperar = By.XPath("//button[@popover-title = 'Recuperar']");

        #endregion


        #region Metodos principales
        public void selectorGenerico(IWebDriver Driver, string title,string Dato , ExtentTest Reportes, int Delay = 2)
        {
            try
            {
                Base.DormirHilo(1);
                By elemento = By.XPath("//span[@title='"+title+"']/..//span/span/input");
                InputHelpers.SendKey(Driver, elemento,Dato);
                Base.DormirHilo(Delay);
                IWebElement aux = Driver.FindElement(elemento);
                aux.SendKeys(Keys.Enter);
                Reportes.Log(Status.Pass,"Completar Campos "+title+" : "+Dato);
          

            }
            catch (Exception e)
            {
                Reportes.Log(Status.Fail, "Completar Campos " + title + " : " + Dato);
                Assert.Fail(e.Message);
            }

        }




        public void buscarRegistro(IWebDriver Driver, string Busqueda, ExtentTest Reportes)
        {
            try
            {
                By inputBusqueda = By.XPath("//*[@id='FieldFilter']");
                InputHelpers.SendKey(Driver, inputBusqueda, Busqueda);
                Reportes.Log(Status.Pass,"Buscar Registro "+Busqueda);
            }
            catch (Exception e)
            {
                Reportes.Log(Status.Fail, "Buscar Registro " + Busqueda);
                Assert.Fail(e.Message);
            }

        }

        public void selectRegistro(IWebDriver Driver, string Busqueda, ExtentTest Reportes)
        {
            try
            {
                By tablaBusqueda = By.XPath("//tbody[@role = 'rowgroup']/tr[position()<3]//*[text()= '" + Busqueda + "']");
                ClickHelpers.Click(Driver, tablaBusqueda);
                Reportes.Log(Status.Pass,"Seleccionar registro "+Busqueda);
            }
            catch (Exception e)
            {
                Reportes.Log(Status.Fail, "Seleccionar registro " + Busqueda);
                Assert.Fail(e.Message);
            }
        }


        public void CompletarCampos(IWebDriver Driver, string Campo, string Dato, ExtentTest Reportes, int Delay = 0)
        {
            try
            {

                By inputCampo = By.XPath("//span[text()='" + Campo + "']/../div[1]//input[not(@class='pointer')]");
                InputHelpers.SendKey(Driver, inputCampo, Dato);
                Base.DormirHilo(Delay);

                IWebElement elemento = Driver.FindElement(inputCampo);
                elemento.SendKeys(Keys.Enter);
                Reportes.Log(Status.Pass,"Compeltar campo "+Campo+" Dato :"+Dato);
            }
            catch (Exception e)
            {
                Reportes.Log(Status.Fail, "Compeltar campo " + Campo + " Dato :" + Dato);
                Assert.Fail(e.Message);
            }
        }

        //table[@role='listbox']//strong[text()='" + text + "']"

        public void Seleccionar(IWebDriver Driver, string Campo, string Dato, ExtentTest Reportes,int Delay = 0)
        {
            try
            {
                By inputCampo = By.XPath("//input[@name= 'd.Campo']/../span/span/input");
                InputHelpers.SendKey(Driver, inputCampo, Dato);
                Base.DormirHilo(Delay);

                IWebElement elemento = Driver.FindElement(inputCampo);
                elemento.SendKeys(Keys.Enter);
                Reportes.Log(Status.Pass,"Seleccionar "+Campo+" Dato :"+Dato);

            }
            catch (Exception e)
            {
                Reportes.Log(Status.Fail, "Seleccionar " + Campo + " Dato :" + Dato);
                Assert.Fail(e.Message);
            }

        }

        public void Aceptar(IWebDriver Driver, ExtentTest Reportes)
        {
            try
            {
                WaitHelpers.WaitElementExists(Driver, By.XPath("//*[contains(text(),'Aceptar')]"));
                ClickHelpers.Click(Driver, By.XPath("//*[contains(text(),'Aceptar')]"));

                if (ElementHelpers.ExistsElement(Driver, labelErrores))
                {
                    Assert.Fail(Driver.FindElement(labelErrores).Text);
                }

                Reportes.Log(Status.Pass,"Aceptar");
            }
            catch (Exception e)
            {
                Reportes.Log(Status.Fail, "Aceptar");
                Assert.Fail(e.Message);
            }
        }

        public void CheckGenerico(IWebDriver Driver,string Value)
        {
            try
            {
                By check = By.XPath("//span[contains(text(),'" + Value + "')]/../..//ins");
                CheckBoxHelpers.SelectFromCheckBox(Driver, check);
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }

        }

        public void ClickEnLink(IWebDriver Driver, string value, ExtentTest Reportes)
        {
            try
            {
                By elemento = By.XPath("//li[.='" + value + "']");
                ClickHelpers.Click(Driver, elemento);
                Reportes.Log(Status.Pass,"Click en Link "+value);
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }


        public bool ValidarAuditoria(IWebDriver Driver)
        {
            bool validation = false;

            #region VALIDACION
            try
            {
                By tableAuditoria = By.XPath("//div[@options='auditoria.gridAuditoria']//tbody");
                WaitHelpers.WaitElementExists(Driver, tableAuditoria);
                WaitHelpers.WaitForElementVisible(Driver, tableAuditoria);

                IList<IWebElement> allOptions = Driver.FindElement(tableAuditoria).FindElements(By.XPath("//span[@ng-bind='dataItem.Accion']"));
                

                foreach (IWebElement we in allOptions)
                {
                    Thread.Sleep(500);
                    string text = we.Text;

                    if (text.Equals("Recuperar") || text.Equals("Anular") ||
                        text.Equals("Modificar") || text.Equals("Agregar"))
                    {
                        validation = true;
                    }
                    else
                    {
                        validation = false;
                        break;
                    }
                }
                if (allOptions.Count != 4)
                    Assert.Fail();

                return validation;

            }
            catch (Exception e)
            {
                
                Assert.Fail(e.ToString());
                return validation;
            }

            #endregion
        }


        #endregion
    }
}
