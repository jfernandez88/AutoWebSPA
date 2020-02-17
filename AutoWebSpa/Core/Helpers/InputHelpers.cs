using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Threading;

namespace AutoWebSpa.Core.Helpers
{
    public static class InputHelpers
    {
        #region SEND KEY BY 'IWEBELEMENT'
        public static void SendKey(IWebDriver driver,
                                   IWebElement element,
                                   string value,
                                   bool sendEnter = false)
        {
            try
            {
                WaitHelpers.WaitUntilClickeable(driver, element);
                element.Clear();
                element.Click();
                element.SendKeys(value);

                Thread.Sleep(500);
                if (sendEnter == true)
                    element.SendKeys(Keys.Enter);

            }
            catch (Exception e)
            {
                Assert.Fail(e.ToString());
            }
        }
        #endregion
        #region SEND KEY BY 'IWEBELEMENT' SIN CLEAR
        public static void SendKey(IWebDriver driver, IWebElement element,
                                   string value,
                                   bool clear,
                                   string nombreDelElemento = "",
                                   bool sendEnter = false)
        {
            try
            {
                WaitHelpers.WaitUntilClickeable(driver, element, nombreDelElemento);

                if (clear)
                    element.Clear();
                element.SendKeys(value);

                if (sendEnter == true)
                    element.SendKeys(Keys.Enter);



            }
            catch (Exception e)
            {
                Assert.Fail(e.ToString());
            }
        }
        #endregion
        #region SEND KEY BY 'BY'
        public static void SendKey(IWebDriver driver, By element, string value,
                                        string nombreDelElemento = "", bool sendEnter = false)
        {
            try
            {
                WaitHelpers.WaitUntilClickeable(driver, element, nombreDelElemento);

                IWebElement elemento = driver.FindElement(element);
                elemento.Clear();
                elemento.Click();
                elemento.SendKeys(value);


                if (sendEnter == true)
                    elemento.SendKeys(Keys.Enter);
            }
            catch (Exception e)
            {
                Assert.Fail(e.ToString());
            }
        }
        #endregion
        #region SEND KEY BY 'BY' DECIMAL
        public static void SendKeyDecimal(IWebDriver driver, By element, string value,
                                        string nombreDelElemento = "", bool sendEnter = false)
        {
            try
            {
                WaitHelpers.WaitUntilClickeable(driver, element, nombreDelElemento);

                IWebElement elemento = driver.FindElement(element);
                elemento.Clear();
                elemento.Click();
                elemento.SendKeys(value);
                if (sendEnter == true)
                    elemento.SendKeys(Keys.Enter);
            }
            catch (Exception e)
            {
                Assert.Fail(e.ToString());
            }
        }
        #endregion
        #region SEND KEY IMPORT 'IWEBELEMENT'
        public static void SendKeyImport(IWebDriver driver, IWebElement element,
                                   string value)
        {
            try
            {
                element.SendKeys(value);

            }
            catch (Exception e)
            {
                Assert.Fail(e.ToString());
            }
        }
        #endregion
    }
}
