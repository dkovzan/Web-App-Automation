using OpenQA.Selenium;

namespace WPAutomation.PageObjects.MainTabs
{
    public class Providers : MainTab
    {
        public readonly string TabName = "Wealth Planning Access - Providers";
        public Providers(IWebDriver driver) : base(driver)
        {
            Url += "providers";
        }
    }
}
