using OpenQA.Selenium;

namespace WPAutomation.PageObjects.DetailedForms
{
    public class OfferingDetailsForm : DetailsForm
    {
        private readonly string containerXpath = "//*[contains(@class,'aside-offerings-view')]";
        public OfferingDetailsForm(IWebDriver driver) : base(driver)
        {

        }
        public IWebElement Container => _driver.FindElement(By.XPath(containerXpath));
    }
}
