using OpenQA.Selenium;

namespace WPAutomation.PageObjects.MainTabs
{
    public class MainTab : PageObject
    {
        public MainTab(IWebDriver driver) : base(driver)
        {
            Url = Base.Host + Base.Env;
            Header = new Header(driver);
        }
        public string Url { get; set; }
        public Header Header { get; }

        public void Open()
        {
            _driver.Navigate().GoToUrl(Url);
        }
    }

    public enum MainTabName
    {
        Offerings,
        Providers,
        InformationLibrary,
        Requests,
        Support
    }
}
