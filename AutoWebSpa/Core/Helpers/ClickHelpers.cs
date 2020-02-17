using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Runtime.CompilerServices;

namespace AutoWebSpa.Core.Helpers
{
    public static class ClickHelpers
    {
        public static void Click(IWebDriver driver, IWebElement element,
                                    string nombreDelElemento = "")
        {
            try
            {
                WaitHelpers.WaitUntilClickeable(driver, element, nombreDelElemento);
                element.Click();

            }
            catch (Exception e)
            {
                Assert.Fail(e.ToString());
            }
        }
        public static void Click(IWebDriver driver, By element,
                                                string nombreDelElemento = "")
        {
            try
            {
                WaitHelpers.WaitUntilClickeable(driver, element, nombreDelElemento);
                driver.FindElement(element).Click();

            }
            catch (Exception e)
            {
                Assert.Fail(e.ToString());
            }
        }
        public static void DoubleClick(IWebDriver driver, IWebElement element,
                                    string nombreDelElemento)
        {
            try
            {
                WaitHelpers.WaitUntilClickeable(driver, element, nombreDelElemento);

                //((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].fireEvent('ondblclick');", element);

                /* Actions act = new Actions(driver);
                 act.DoubleClick(element).Build().Perform();*/

                Actions act = new Actions(driver);
                act.MoveToElement(element).DoubleClick().Build().Perform();

            }
            catch (StaleElementReferenceException e)
            {
                Assert.Fail(e.ToString());

            }
            catch (NoSuchElementException e)
            {
                Assert.Fail(e.ToString());

            }
            catch (Exception e)
            {
                Assert.Fail(e.ToString());
            }
        }
        public static void DoubleClick(IWebDriver driver, By element,
                                        string nombreDelElemento)
        {
            try
            {
                WaitHelpers.WaitUntilClickeable(driver, element, nombreDelElemento);

                Actions act = new Actions(driver);
                act.DoubleClick(driver.FindElement(element)).Build().Perform();
            }
            catch (Exception e)
            {
                Assert.Fail(e.ToString());
            }
        }
    }
}
