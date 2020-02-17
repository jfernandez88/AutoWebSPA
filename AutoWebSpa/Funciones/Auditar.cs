using System;
using AutoWebSpa.RepositorioDeObjetos;
using OpenQA.Selenium;
using AutoWebSpa.Core.Helpers;
using AutoWebSpa.Core;
using NUnit.Framework;
using System.Collections.Generic;
using System.Threading;
using AventStack.ExtentReports;

namespace AutoWebSpa.Funciones
{
    public class Auditar : PantallaPrincipal
    {

        public void ClickAuditar(IWebDriver Driver, ExtentTest Reportes)
        {
            try
            {
                ClickHelpers.Click(Driver, botonAuditar);
                Reportes.Log(Status.Pass,"Click en Auditar");
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }

        public bool  AuditarRegistro(IWebDriver Driver, string Registro,ExtentTest Reportes)
        {
            bool validation = false;
            try
            {
                buscarRegistro(Driver, Registro, Reportes);
                selectRegistro(Driver, Registro, Reportes);
                ClickAuditar(Driver, Reportes);
                WaitHelpers.WaitForElementVisible(Driver,tableAuditoria);


                IList<IWebElement> allOptions = Driver.FindElements(rowTableAuditoria);
                

                foreach (IWebElement we in allOptions)
                {
                    Thread.Sleep(500);
                    string text = we.Text;

                    if (text.Equals("Recuperar") || text.Equals("Anular") ||
                        text.Equals("Modificar") || text.Equals("Agregar"))
                    {
                        validation = true;
                        Reportes.Log(Status.Pass,"Accion realizada "+text);
                    }
                    else
                    {
                        validation = false;
                        Reportes.Log(Status.Fail,"Accion realizada "+text);
                        break;
                    }
                }          
                
                return validation;
            }
            catch (Exception e)
            {          
                Assert.Fail(e.Message);
                return validation;
            }
        }

    }
}
