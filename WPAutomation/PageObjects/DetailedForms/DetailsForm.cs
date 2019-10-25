using OpenQA.Selenium;

namespace WPAutomation.PageObjects.DetailedForms
{
    public class DetailsForm : PageObject
    {
        private readonly string headerControlsXpath = "//header[@class='header-controls']";
        private readonly string closeBtnXPath = "//*[@class='btn-close']";
        private readonly string previousBtnXpath = "//*[contains(@class,'btn-prev')]";
        private readonly string nextBtnXpath = "//*[contains(@class,'btn-next')]";
        private readonly string attributesContainerXPath = "//*[@class='attributes']";
        private readonly string subTabsContainerXpath = "//*[@class='connections offering']";
        private readonly string feedbackHelpBtnXpath = "//*[@class='btn btn-primary']";
        private readonly string printDetailsBtnXpath = "//*[@class='btn btn-primary ng-tns-c25-5 ng-star-inserted']";
        public DetailsForm(IWebDriver driver) : base(driver)
        {

        }

        public IWebElement HeaderControls => _driver.FindElement(By.XPath(headerControlsXpath));
        public IWebElement CloseBtn => _driver.FindElement(By.XPath(closeBtnXPath));
        public IWebElement PreviousBtn => _driver.FindElement(By.XPath(previousBtnXpath));
        public IWebElement NextBtn => _driver.FindElement(By.XPath(nextBtnXpath));
        public IWebElement AttributesContainer => _driver.FindElement(By.XPath(attributesContainerXPath));
        public IWebElement SubTabsContainerXPath => _driver.FindElement(By.XPath(subTabsContainerXpath));
        public IWebElement FeedbackHelpBtn => _driver.FindElement(By.XPath(feedbackHelpBtnXpath));
        public IWebElement PrintDetailsBtn => _driver.FindElement(By.XPath(printDetailsBtnXpath));

        public void Close()
        {
            CloseBtn.Click();
        }

        public void GoToNext()
        {
            NextBtn.Click();
        }

        public void GoToPrevious()
        {
            PreviousBtn.Click();
        }

    }
}
