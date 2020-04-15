using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;

namespace UBSAutomation.Settings
{
    class DriverFactory
    {
        public static IWebDriver GetChromeDriver()
        {
            var driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            return driver;
        }
    }
}
