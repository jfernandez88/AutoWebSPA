using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Remote;

namespace AutoWebSpa
{
    public class Base
    {

        public IWebDriver Driver;


        public enum BrowerType
        {
            Chrome,
            Firefox,
            IE
        }


        private void seleccionarDriver(BrowerType browserType, bool remoto)
        {
            if (browserType == BrowerType.Chrome)
            {
                if (remoto)
                {
                    DesiredCapabilities cap = DesiredCapabilities.Chrome();
                    cap.SetCapability("browserName", "chrome");

                    Driver = new RemoteWebDriver(new Uri("http://192.168.22.116:4444/wd/hub"), cap);
                }
                else
                {
                    Driver = new ChromeDriver();
                }
            }
            else if (browserType == BrowerType.Firefox)
            {
                Driver = new ChromeDriver();
            }
        }


        public void inicializar(BrowerType Browser, bool Remoto)
        {
            seleccionarDriver(Browser, Remoto);
            Driver.Navigate().GoToUrl(ConfigurationManager.AppSettings["UrlAmbiente"]);
            int implicitWait = int.Parse(ConfigurationManager.AppSettings["ImplicitWait"]);
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(implicitWait);
        }

        public static void Esperar(int Time, By Elemento, IWebDriver Driver)
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(Time));
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(Elemento));
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message + " No se muestra el elemento " + Elemento);
            }
        }

        public static bool EsperarElemento(int Delay, By Elemento, IWebDriver Driver)
        {
            bool bandera = false;

            for (int i = 0; i < Delay; i++)
            {
                Thread.Sleep(2000);
                int a = Driver.FindElements(Elemento).Count;

                if (a > 0)
                {
                    bandera = true;
                    break;
                }

            }

            return bandera;

        }

        public static void DormirHilo(int Delay)
        {
            if (Delay != 0) {
                for (int i = 0; i <= Delay; i++)
                {
                    Thread.Sleep(1000);
                }
            }

        }

        public static void MoverAlElemento(IWebDriver Driver, By Elemento)
        {
            try
            {
                Actions actions = new Actions(Driver);
                var aux = Driver.FindElement(Elemento);
                actions.MoveToElement(aux);
                actions.Perform();
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }


        }


        public static void MoverAWebElement(IWebDriver Driver, IWebElement Elemento)
        {
            try
            {
                Actions actions = new Actions(Driver);
                actions.MoveToElement(Elemento);
                actions.Perform();
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }


        }



        public static bool ArchivoDescargado(string nombreArchivo, int reintentosBusqueda, bool eliminarArchivo)
        {
            /*
            *  Realizar el chequeo si el archivo (nombreArchivo) fue descargado en la carpeta de descarga
            * configurada en el app domain
            * 
            * 
            */

            bool reporteDescargado = false;
            int intentosBusqueda = 0;
            string rutaArchivoCompleta = ConfigurationManager.AppSettings["DownloadPath"] + nombreArchivo;
            rutaArchivoCompleta = rutaArchivoCompleta.Replace("Usuario", Environment.UserName);

            while ((!reporteDescargado) && (intentosBusqueda < reintentosBusqueda))
            {
                if (File.Exists(rutaArchivoCompleta))
                    reporteDescargado = true;
                else
                    Thread.Sleep(2000);

                intentosBusqueda++;
            }

            if (reporteDescargado && eliminarArchivo)
                File.Delete(rutaArchivoCompleta);

            return reporteDescargado;
        }


    }
}
