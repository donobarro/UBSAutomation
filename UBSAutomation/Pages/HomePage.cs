using System;
using System.Runtime.Remoting.Messaging;
using OpenQA.Selenium;
using System.Threading;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using UBSAutomation.Settings;

namespace UBSAutomation.Pages
{
    class HomePage : Page
    {
        private IWebElement mainMenu => driver.FindElement(By.XPath("//ul[@id='mainmenu']"));
        private IWebElement wealthManagementMenuButton => mainMenu.FindElement(By.XPath("//li//a[contains(text(), 'Wealth Management')]"));

        private IWebElement wealthManagementMenu => wealthManagementMenuButton.FindElement(By.XPath("//div[contains(@style, 'display: block;')]"));

        private IWebElement yourLifeGoals => mainMenu.FindElement(By.XPath(
            "//span[.//a[text()='Your life goals']]"));

        private IWebElement ubsLogo => driver.FindElement(By.XPath("//img[@alt='UBS logo, to home page']"));

        private IWebElement acceptCookiesButton =>
            driver.FindElement(By.XPath("//a[text()='Agree to all']"));

        private IWebElement selectDomicileButton => driver.FindElement(By.XPath("//button[contains(text(),'Select domicile')]"));

        private IWebElement selectDomicileMenu => driver.FindElement(
            By.XPath("//button[contains(text(),'Select domicile')]/following-sibling::ul[contains(@style, 'display: block;')]"));

        private IWebElement selectDomicileRegionDropdown =>
            selectDomicileMenu.FindElement(By.XPath("//li[contains(@class, 'domicileSelection__item--region')]"));

        private IWebElement selectDomicileCountryDropdown =>
            selectDomicileMenu.FindElement(By.XPath("//li[contains(@class,'domicileSelection__item--country') and .//button[not(@disabled)]]"));
        public HomePage(IWebDriver driver) : base(driver)
        {
  
        }

        public void ClickWealthManagementMenu()
        {
            wealthManagementMenuButton.Click();
        }

        public bool IsPageDisplayed()
        {
            return ubsLogo.Displayed;
        }

        public bool IsWealthManagementMenuDisplayed()
        {
            //Thread.Sleep(5000); uncomment this to confirm that menu really appears
            return wealthManagementMenu.Displayed;
        }

        public bool IsSelectDomicileMenuDisplayed()
        {
            return selectDomicileMenu.Displayed;
        }

        public void ClickYourLifeGoalsButton()
        {
            yourLifeGoals.Click();
        }

        public void ClickSelectDomicileButton()
        {
            selectDomicileButton.Click();
        }

        public void SelectDomicileRegionFromDropdown(string region)
        {
            selectDomicileRegionDropdown.Click();
            selectDomicileRegionDropdown.FindElement(By.XPath("//li/button[contains(text(), '" + region + "')]")).Click();
        }

        public void SelectDomicileCountryFromDropdown(string country)
        {
            //waiting for region dropdown to hide
            new WebDriverWait(driver, TimeSpan.FromSeconds(10))
                .Until(WaitConditions
                    .ElementNotDisplayed(selectDomicileRegionDropdown.FindElement(By.XPath("//ul[contains(@class, 'domicileSelection__list--region')]"))));
            selectDomicileCountryDropdown.Click();
            selectDomicileCountryDropdown.FindElement(By.XPath("//li/a[contains(text(), '" + country + "')]")).Click();
        }

    }
}
