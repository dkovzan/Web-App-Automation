using OpenQA.Selenium;
using System.Collections.Generic;

namespace WPAutomation.PageObjects.ListViews
{
    public class OfferingsList : PageObject
    {
        private readonly string containerXpath = "//section[@class='content']";
        private readonly string offeringCarts = "//*[@class='row-container']";
        public OfferingsList(IWebDriver driver) : base(driver)
        {

        }

        public IWebElement Container => _driver.FindElement(By.XPath(containerXpath));
        public IList<IWebElement> OfferingsCarts => _driver.FindElements(By.XPath(offeringCarts));

        public void ClickFirstOfferingCartInList()
        {
            Click(OfferingsCarts[0]);
        }
    }
}
