using System;
using OpenQA.Selenium;

namespace UBSAutomation.Pages
{
    class Pages
    {
        private IWebDriver driver;

        public Pages(IWebDriver driver)
        {
            this.driver = driver;
        }

        public HomePage HomePage()
        {
            return new HomePage(driver);
        }

        public YourLifeGoalsPage YourLifeGoalsPage()
        {
            return new YourLifeGoalsPage(driver);
        }

        public void NavigateTo(string url)
        {
            driver.Navigate().GoToUrl(url);
        }
        public void SetUBSCookie()
        {
            driver.Navigate().GoToUrl("http://www.ubs.com");
            Cookie cookie = new Cookie("ubs_cookie_settings_2.0", "0-3-2-1", ".ubs.com", "/", DateTime.Parse("2021-04-08T23:20:35.000Z"));
            driver.Manage().Cookies.AddCookie(cookie);
        }
    }

}
