using OpenQA.Selenium;

namespace UBSAutomation.Pages
{
    class YourLifeGoalsPage : Page
    {
        private IWebElement yourLifeGoalsHeading =>
            driver.FindElement(By.XPath("//h1[contains(text(), 'Your life goals')]"));
        public YourLifeGoalsPage(IWebDriver driver) : base(driver)
        {

        }

        public bool IsYourLifeGoalsHeadingDisplayed()
        {
            return yourLifeGoalsHeading.Displayed;
        }
    }
}
