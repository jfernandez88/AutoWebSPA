using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Configuration;
using System.Threading;

public static class WaitHelpers
{
    private static System.TimeSpan TimeOut = new System.TimeSpan(0, 0, Int32.Parse(ConfigurationManager.AppSettings["implicitWait"]));

    public static void WaitForElementVisible(IWebDriver driver, By Locator, string nombreDelElemento = "")
    {
        Thread.Sleep(Int32.Parse(ConfigurationManager.AppSettings["wait"]));
        (new WebDriverWait(driver, TimeOut)).Until(ExpectedConditions.ElementIsVisible(Locator));

    }

    public static void WaitUntilClickeable(IWebDriver driver, By Locator, string nombreDelElemento = "")
    {
        Thread.Sleep(Int32.Parse(ConfigurationManager.AppSettings["wait"]));
        (new WebDriverWait(driver, TimeOut)).Until(ExpectedConditions.ElementToBeClickable(Locator));

    }

    public static void WaitUntilClickeable(IWebDriver driver, IWebElement Elemento, string nombreDelElemento = "")
    {
        Thread.Sleep(Int32.Parse(ConfigurationManager.AppSettings["wait"]));
        (new WebDriverWait(driver, TimeOut)).Until(ExpectedConditions.ElementToBeClickable(Elemento));

    }

    public static void WaitUntilInvisible(IWebDriver driver, By Locator, string nombreDelElemento = "")
    {
        Thread.Sleep(Int32.Parse(ConfigurationManager.AppSettings["wait"]));
        new WebDriverWait(driver, TimeOut).Until(ExpectedConditions.InvisibilityOfElementLocated(Locator));

    }

    public static void WaitElementExists(IWebDriver driver, By Locator, string nombreDelElemento = "")
    {
        Thread.Sleep(Int32.Parse(ConfigurationManager.AppSettings["wait"]));
        new WebDriverWait(driver, TimeOut).Until(ExpectedConditions.ElementExists(Locator));

    }

    public static void WaitTextToBePresentInElement(IWebDriver driver, IWebElement Locator, string text)
    {
        Thread.Sleep(Int32.Parse(ConfigurationManager.AppSettings["wait"]));
        new WebDriverWait(driver, TimeOut).Until(ExpectedConditions.TextToBePresentInElement(Locator, text));

    }
}
