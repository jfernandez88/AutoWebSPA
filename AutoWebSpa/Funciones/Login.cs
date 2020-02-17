using System;
using OpenQA.Selenium;
using NUnit.Framework;
using AutoWebSpa.RepositorioDeObjetos;
using AutoWebSpa.Core.Helpers;
using AutoWebSpa.Core;
using AventStack.ExtentReports;

namespace AutoWebSpa.Funciones
{
    class Login : PantallaDeLogin
    {

        public void Loguearse(string User, string Pass, IWebDriver Driver, ExtentTest Report)
        {
            try
            {               
                InputHelpers.SendKey(Driver, inputUser, User);
                InputHelpers.SendKey(Driver, inputPass, Pass);
                ClickHelpers.Click(Driver, botonIniciarSession);
                Assert.IsTrue(ElementHelpers.ValidateExist(Driver,inputBuscarModulo),"ERROR en Login");
                Report.Log(Status.Pass,"Login Ok ");
                Report.Info("User: " + User + " Pass: " + Pass);
            }
            catch(Exception e){
                Report.Log(Status.Fail,"Login Fallo ");
                Report.Info(e.Message);
                Assert.Fail("ERROR en Login");
            }

        }



    }
}
