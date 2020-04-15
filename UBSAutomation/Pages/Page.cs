using OpenQA.Selenium;

namespace UBSAutomation.Pages
{
    class Page
    {
        protected IWebDriver driver;
        public Page(IWebDriver driver)
        {
            this.driver = driver;
        }
    }
}
