using OpenQA.Selenium;

namespace WPAutomation.PageObjects.MainTabs
{
    public class Requests : MainTab
    {
        public readonly string TabName = "Wealth Planning Access - Requests";
        public Requests(IWebDriver driver) : base(driver)
        {
            Url += "requests";
        }

    }
}
