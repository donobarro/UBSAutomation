using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using TechTalk.SpecFlow;
using UBSAutomation.Settings;

namespace UBSAutomation.Steps
{
    [Binding]
    public class UBSAutomationSteps
    {
        private static IWebDriver driver;
        private static Pages.Pages pages;

        [BeforeFeature]
        public static void SetUp()
        {
            driver = DriverFactory.GetInstance().GetWebDriver().Value;
            pages = new Pages.Pages(driver);
            pages.SetUBSCookie();

        }


        [Given(@"I navigate to the HomePage")]
        public void GivenINavigateToTheHomePage()
        {
            pages.NavigateTo("http://www.ubs.com");
            pages.HomePage().IsPageDisplayed();
        }

        [Given(@"I navigate to the '(.*)' HomePage")]
        public void GivenINavigateToTheHomePage(string country)
        {
            switch (country)
            {
                case "France":
                    pages.NavigateTo("https://www.ubs.com/fr/en");
                    break;
                case "Austria":
                    pages.NavigateTo("https://www.ubs.com/at/en");
                    break;
                case "Denmark":
                    pages.NavigateTo("https://www.ubs.com/dk/en");
                    break;
                default:
                    pages.NavigateTo("https://www.ubs.com/global/en");
                    break;
            }
        }


        [Given(@"I press Wealth Management button")]
        [When(@"I press Wealth Management button")]
        public void WhenIPressWealthManagementButton()
        {
            pages.HomePage().ClickWealthManagementMenu();
        }

        [When(@"I press Your life goals menu item")]
        public void WhenIPressYourLifeGoalsMenuItem()
        {
            pages.HomePage().ClickYourLifeGoalsButton();
        }

        [Given(@"I press Select domicile button")]
        [When(@"I press Select domicile button")]
        public void WhenIPressSelectDomicileButton()
        {
            pages.HomePage().ClickSelectDomicileButton();
        }

        [When(@"I select region '(.*)' and country '(.*)'")]
        public void WhenISelectRegionAndCountry(string region, string country)
        {
            pages.HomePage().SelectDomicileRegionFromDropdown(region);
            pages.HomePage().SelectDomicileCountryFromDropdown(country);
        }

        [Then(@"I land on the '(.*)' HomePage")]
        public void ThenILandOnTheFinlandHomePage(string country)
        {
            switch (country)
            {
                case "Finland":
                    Assert.AreEqual("https://www.ubs.com/fi/en.html", driver.Url);
                    break;
                case "Austria":
                    Assert.AreEqual("https://www.ubs.com/at/en.html", driver.Url);
                    break;
                case "Denmark":
                    Assert.AreEqual("https://www.ubs.com/dk/en.html", driver.Url);
                    break;

            }
            
        }


        [Then(@"Select domicile menu appears")]
        public void ThenSelectDomicileMenuAppears()
        {
            Assert.IsTrue(pages.HomePage().IsSelectDomicileMenuDisplayed());
        }


        [Then(@"Wealth Management menu appears")]
        public void ThenWealthManagementMenuAppears()
        {
            Assert.IsTrue(pages.HomePage().IsWealthManagementMenuDisplayed());
        }

        [Then(@"Your life goals page appears")]
        public void ThenYourLifeGoalsPageAppears()
        {
            Assert.IsTrue(pages.YourLifeGoalsPage().IsYourLifeGoalsHeadingDisplayed());
        }

        [AfterFeature]
        public static void TearDown()
        {
            driver.Close();
            driver.Dispose();
        }
    }
}
