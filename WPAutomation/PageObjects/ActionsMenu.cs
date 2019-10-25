using OpenQA.Selenium;
using System.Collections.Generic;

namespace WPAutomation.PageObjects
{
    public class ActionsMenu : PageObject
    {
        private readonly string containerXpath = "//div[@class='actions' or @class='actions active']";
        private readonly string actionsMenuBtnXpath = "//app-actions/div";
        private readonly string actionsMenuOptionsXpath = "/div[@class='actions-dropdown']/div[@class='actions-holder']/nav/ul/li/a/span";
        public ActionsMenu(IWebDriver driver) : base(driver)
        {

        }

        public IWebElement Container => _driver.FindElement(By.XPath(containerXpath));
        public IWebElement ActionsMenuBtn => _driver.FindElement(By.XPath(actionsMenuBtnXpath));
        public IList<IWebElement> ActionsMenuOptions => Container.FindElements(By.XPath(actionsMenuOptionsXpath));

        public bool IsActionsMenuOpened()
        {
            WaitElementIsClickableByXpath(actionsMenuBtnXpath);
            ActionsMenuBtn.Click();
            return HasClass(ActionsMenuBtn, "active");
        }
    }
}
