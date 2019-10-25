using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using System;

namespace WPAutomation
{
    public class Hooks : Base
    {
        protected readonly BrowserType _browserType;
        public Hooks(BrowserType browserType)
        {
            _browserType = browserType;
        }

        public void SelectBrowser(BrowserType browserType)
        {
            if (browserType == BrowserType.Chrome)
            {
                Driver = new ChromeDriver(Config["chromeDriverPath"]);
                Driver.Manage().Window.Maximize();
            }
            else if (browserType == BrowserType.Edge)
            {
                Driver = new EdgeDriver(Config["edgeDriverPath"]);
                Driver.Manage().Window.Maximize();
            }
            else
            {
                throw new ArgumentException("The browser is not maintainable");
            }
        }
        
    }

    public enum BrowserType
    {
        Chrome,
        Edge
    }

}
