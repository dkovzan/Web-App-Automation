using OpenQA.Selenium;

namespace WPAutomation.PageObjects.MainTabs
{
    public class InformationLibrary : MainTab
    {
        public readonly string TabName = "Wealth Planning Access - Information Library";
        public InformationLibrary(IWebDriver driver) : base(driver)
        {
            Url += "informationLibrary";
        }

    }
}
