using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.Extensions;
using OpenQA.Selenium.Support.UI;
using System;

namespace WPAutomation.PageObjects
{
    
    public class PageObject
    {
        protected IWebDriver _driver;

        protected WebDriverWait _wait;

        protected Actions _actions;
        
        public PageObject(IWebDriver driver)
        {
            _driver = driver;
            _wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            _actions = new Actions(driver);
        }

        public static bool HasClass(IWebElement element, string classToSearch)
        {
            var classes = element.GetAttribute("class");
            foreach (var c in classes.Split(" "))
            {
                if (c.Equals(classToSearch))
                {
                    return true;
                }
            }

            return false;
        }

        public void Click(IWebElement element)
        {
            _actions.MoveToElement(element).Click().Perform();
        }

        public void WaitInvisibilityOfElementByXpath(string xPath)
        {
            _wait.Until(ExpectedConditions.InvisibilityOfElementLocated(By.XPath(xPath)));
        }

        public void WaitElementIsVisibleByXpath(string xPath)
        {
            _wait.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(xPath)));
        }

        public void WaitElementIsClickableByXpath(string xPath)
        {
            _wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath(xPath)));
        }

        public void ScrollIntoElement(IWebElement element, IWebDriver driver)
        {
            _driver.ExecuteJavaScript("arguments[0].scrollIntoView(true);", element);
        }

        public bool IsDisabled(IWebElement elem)
        {
            return HasClass(elem, "disabled") || !elem.Enabled;
        }

        public bool IsMenuActive(IWebElement menu)
        {
            return HasClass(menu, "active");
        }

    }
}
