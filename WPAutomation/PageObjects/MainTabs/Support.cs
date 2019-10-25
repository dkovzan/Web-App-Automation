using OpenQA.Selenium;

namespace WPAutomation.PageObjects.MainTabs
{
    public class Support : MainTab
    {
        public readonly string TabName = "Wealth Planning Access";
        public Support(IWebDriver driver) : base(driver)
        {
            Url += "support";
        }
    }
}
