using OpenQA.Selenium;
using System.Collections.Generic;

namespace WPAutomation.PageObjects.Filters
{
    public class Filter : PageObject
    {
        private readonly string addFilterBtnXpath = "//div[contains(class,'filter-add')]";
        private readonly string displayedFiltersXpath = "//div[contains(@class,'filter-box') and not(contains(@class,'hidden'))]";
        public Filter(IWebDriver driver) : base(driver)
        {

        }
        public IWebElement AddFilterBtn => _driver.FindElement(By.XPath(addFilterBtnXpath));
        public IList<IWebElement> DisplayedFilters => _driver.FindElements(By.XPath(displayedFiltersXpath));

    }
}
