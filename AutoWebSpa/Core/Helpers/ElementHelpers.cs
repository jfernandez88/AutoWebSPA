using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Threading;
using AutoWebSpa.Core.Helpers;

namespace AutoWebSpa.Core.Helpers
{
    static public class ElementHelpers
    {
        public static bool ExistsElement(IWebDriver driver, By element)
        {
            Thread.Sleep(500);
            bool dis = false;
            try
            {
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3);
                dis = driver.FindElement(element).Displayed;
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            }
            catch (Exception )
            {
                return dis = false;
            }
            return dis;
        }
        static public void ScrollToView(IWebDriver driver, IWebElement element)
        {
            if (element.Location.Y > 200)
            {
                ScrollTo(driver, 0, element.Location.Y - 100);
                // Make sure element is in the view but below the top navigation pane
            }

        }
        static public void ScrollToView(IWebDriver driver, By element)
        {
            WaitHelpers.WaitElementExists(driver, element);

            IWebElement ele = driver.FindElement(element);

            if (ele.Location.Y > 200)
            {
                ScrollTo(driver, 0, ele.Location.Y - 100);
                // Make sure element is in the view but below the top navigation pane
            }

        }
        static public void ScrollTo(IWebDriver driver, int xPosition = 0, int yPosition = 0)
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            var sc = String.Format("window.scrollTo({0}, {1})", xPosition, yPosition);
            js.ExecuteScript(sc);
        }
        static public IWebElement ElementVisible(IWebDriver driver, By element)
        {
            WaitHelpers.WaitElementExists(driver, element);

            IList<IWebElement> elements = driver.FindElements(element);

            IWebElement finalElement = null;
            foreach (IWebElement ele in elements)
            {
                if (ele.Displayed && ele.Enabled)
                {
                    finalElement = ele;
                    break;
                }
            }
            return finalElement;
        }

        static public IWebElement ElementVisibleValidation(IWebDriver driver, By element)
        {
            WaitHelpers.WaitElementExists(driver, element);

            IList<IWebElement> elements = driver.FindElements(element);

            IWebElement finalElement = null;
            foreach (IWebElement ele in elements)
            {
                if (ele.Displayed)
                {
                    finalElement = ele;
                    break;
                }
            }
            return finalElement;
        }

        static public bool ValidateExist(IWebDriver Driver, By Element)
        {
            bool dis = false;
            try
            {
                Thread.Sleep(200);
                for (int i = 0; i < 2; i++) { 
                    int contador = Driver.FindElements(Element).Count;
                    if (contador > 0)
                    {
                        dis = true;
                        break;
                    }
                }
            }
            catch (Exception )
            {
                return dis = false;
            }
            return dis;

        }
    }
}
