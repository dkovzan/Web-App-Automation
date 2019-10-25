using WPAutomation.PageObjects.DetailedForms;
using WPAutomation.PageObjects.Filters;
using OpenQA.Selenium;

namespace WPAutomation.PageObjects.ListViews
{
    public class OfferingsOverviewPane : PageObject
    {
        private readonly string containerXpath = "//*[contains(@class, 'aside-offerings-list')]";
        public OfferingsOverviewPane(IWebDriver driver) : base(driver)
        {

        }
        public OfferingDetailsForm OfferingDetailsForm => new OfferingDetailsForm(_driver);
        public OfferingsList OfferingsList => new OfferingsList(_driver);
        public OfferingsFilter OfferingsFilter => new OfferingsFilter(_driver);
        public ActionsMenu ActionsMenu => new ActionsMenu(_driver);
        public IWebElement Container => _driver.FindElement(By.XPath(containerXpath));
    }
}
