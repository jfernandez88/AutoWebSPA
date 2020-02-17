using System;
using AutoWebSpa.RepositorioDeObjetos;
using OpenQA.Selenium;
using AutoWebSpa.Core.Helpers;
using AutoWebSpa.Core;
using NUnit.Framework;
using AventStack.ExtentReports;

namespace AutoWebSpa.Funciones
{
    public class Baja : PantallaPrincipal 
    {
        public void ClickElminarElemento(IWebDriver Driver, ExtentTest Reportes)
        {
            try
            {
                ClickHelpers.Click(Driver, botonEliminar);
                if (ElementHelpers.ValidateExist(Driver, botonConfirmar))
                    ClickHelpers.Click(Driver, botonConfirmar);
                Reportes.Log(Status.Pass,"Eliminar elemento");
            }
            catch (Exception e)
            {
                Reportes.Log(Status.Fail, "Eliminar elemento");
                Assert.Fail(e.Message);
            }

        }

        public void BajaDeRegistro(IWebDriver Driver, string registro,ExtentTest Reportes)
        {
            try
            {
                buscarRegistro(Driver, registro, Reportes);
                selectRegistro(Driver, registro, Reportes);
                ClickElminarElemento(Driver, Reportes);
                Reportes.Log(Status.Pass,"Baja de Registro");              
            }
            catch (Exception e)
            {
                Reportes.Log(Status.Fail, "Baja de Registro");
                Assert.Fail(e.Message);
            }

        }

        public void ValidarBaja(IWebDriver Driver, string registro, ExtentTest Reportes)
        {
            try
            {
                buscarRegistro(Driver, registro, Reportes);
                selectRegistro(Driver, registro, Reportes);
                WaitHelpers.WaitForElementVisible(Driver, filaElminada);
                Assert.IsTrue(ElementHelpers.ExistsElement(Driver, filaElminada),"No se realizó baja al reg: "+registro);
                Reportes.Log(Status.Pass,"Validar Baja");
                

            }
            catch (Exception e)
            {
                Reportes.Log(Status.Fail, "Validar Baja");
                Assert.Fail(e.Message);
            }

        }
        



    }
}
