using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Threading;

namespace UBSAutomation.Settings
{
    class DriverFactory
    {
        private static DriverFactory instance = new DriverFactory();
        private DriverFactory()
        {

        }

        private ThreadLocal<IWebDriver> driver = new ThreadLocal<IWebDriver>();

        public ThreadLocal<IWebDriver> GetWebDriver()
        {
            driver.Value = GetChromeDriver();
            return driver;
        }

        public static DriverFactory GetInstance()
        {
            return instance;
        }
        public static IWebDriver GetChromeDriver()
        {
            var driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            return driver;
        }
    }
}
