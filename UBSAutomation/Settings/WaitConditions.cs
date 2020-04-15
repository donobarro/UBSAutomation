using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace UBSAutomation.Settings
{
    class WaitConditions
    {
        public static Func<IWebDriver, IWebElement> ElementNotDisplayed(IWebElement element)
        {
            return (Func<IWebDriver, IWebElement>)(driver =>
            {
                try
                {
                    Console.WriteLine(element.GetAttribute("style") + " + " + element.GetAttribute("class"));
                    return element != null && !element.Displayed ? element : (IWebElement)null;

                }
                catch (StaleElementReferenceException ex)
                {
                    return (IWebElement)null;
                }
            });
        }
    }
}
