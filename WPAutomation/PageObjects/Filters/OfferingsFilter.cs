using OpenQA.Selenium;

namespace WPAutomation.PageObjects.Filters
{
    public class OfferingsFilter : Filter
    {
        private readonly string containerXpath = "//app-offerings-filters";
        
        //private const string filterNameXpath = "//span[contains(@class,'name')";
        //private const string filterSetValueCounterXpath = "//span[contains(@class,'name')";
        public OfferingsFilter(IWebDriver driver) : base(driver)
        {

        }

        public IWebElement Container => _driver.FindElement(By.XPath(containerXpath));
        
        //public IWebElement FilterName => DisplayedFilters.Select(_ => _.FindElement(By.XPath(filterNameXpath))).FirstOrDefault();
        //public IWebElement FilterSetValueCounter => DisplayedFilters.Select(_ => _.FindElement(By.XPath(filterSetValueCounterXpath))).FirstOrDefault();
    }
}
