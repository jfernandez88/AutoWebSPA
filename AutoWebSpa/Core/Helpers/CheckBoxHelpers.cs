using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Runtime.CompilerServices;

namespace AutoWebSpa.Core.Helpers
{
    public static class CheckBoxHelpers
    {
        //SELECCIONAR ELEMENTO DE UN CHECKBOX
        static public void SelectFromCheckBox(IWebDriver driver, IWebElement element, string nombreDelElemento = "")
        {
            try
            {
                if (!element.Selected)
                {
                    element.Click();
                }
            }
            catch (Exception e)
            {
                Assert.Fail(e.ToString());
            }
        }

        static public void SelectFromCheckBox(IWebDriver driver, By ele, string nombreDelElemento = "")
        {
            try
            {
                WaitHelpers.WaitElementExists(driver, ele);
                IWebElement element = driver.FindElement(ele);

                if (!element.Selected)
                {
                    element.Click();
                }
            }
            catch (Exception e)
            {
                Assert.Fail(e.ToString());
            }
        }

        //DESELECCIONAR ELEMENTO DE UN CHECKBOX
        static public void DeselectFromCheckBox(IWebDriver driver, IWebElement element, string nombreDelElemento = "")
        {
            try
            {
                if (element.Selected)
                {
                    element.Click();
                }
            }
            catch (Exception e)
            {
                Assert.Fail(e.ToString());
            }
        }
    }
}
