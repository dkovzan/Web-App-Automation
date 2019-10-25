using OpenQA.Selenium;
using System;

namespace WPAutomation.PageObjects.MainTabs
{
    public class LoginForm : MainTab
    {
        private readonly string loginXpath = "//*[@id='login']";
        private readonly string passwordXpath = "//*[@id='password']";
        private readonly string signInBtnXpath = "//*[@class='auth-btn sign']";
        private readonly string errorMessageXpath = "//*[contains(@class,'auth-alert-error')]";

        public LoginForm(IWebDriver driver) : base(driver)
        {
            Url += "login?ssoDisabled";
        }

        public IWebElement Login => _driver.FindElement(By.XPath(loginXpath));

        public IWebElement Password => _driver.FindElement(By.XPath(passwordXpath));

        public IWebElement SignInBtn => _driver.FindElement(By.XPath(signInBtnXpath));

        public IWebElement ErrorMessage => _driver.FindElement(By.XPath(errorMessageXpath));

        public void EnterLogin(string login)
        {
            Login.SendKeys(login);
        }

        public void EnterPassword(string password)
        {
            Password.SendKeys(password);
        }

        public void ClickSignInButton()
        {
            SignInBtn.Click();
        }

        public Offerings SignIn(string login, string password)
        {
            EnterLogin(login);
            EnterPassword(password);
            ClickSignInButton();
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            return new Offerings(_driver);
        }

        public Offerings SignInAsExistingWpUser()
        {
            return SignIn("login", "password");
        }
    }
}
