using WPAutomation.PageObjects.MainTabs;
using OpenQA.Selenium;
using System.ComponentModel;

namespace WPAutomation.PageObjects
{
    public class Header : PageObject
    {
        private readonly string logoXpath = "//*[@class='logo']";
        private readonly string referralNoteBtnXpath = "//*[contains(@class, 'referral-note')]";
        private readonly string disclaimerActionsBtn = "//div[@class='header-menu' or @class='header-menu active']";
        private readonly string compassBtnXpath = "//*[contains(@class, 'compass')]";

        private readonly string loadingSpinnerXpath = "//*[contains(@class, 'customSpinner')]";

        private readonly string loggedUserInfoXPath = "//*[@class='logged-info']";
        private readonly string logoutBtnXpath = "//button";

        //Navigation bar
        private readonly string navMenuBtnXpath = "//*[@class='nav-opener']";
        private readonly string navBarXpath = "//*[@id='nav']";
        private readonly string offeringsLinkOfNavBarXpath =
            "//*[contains(@class, 'nav-link') and contains(@href, 'offerings')]";
        private readonly string providersLinkOfNavBarXpath =
            "//*[contains(@class, 'nav-link') and contains(@href, 'providers')]";
        private readonly string informationLibraryLinkOfNavBarXpath =
            "//*[contains(@class, 'nav-link') and contains(@href, 'informationLibrary')]";
        private readonly string requestsLinkOfNavBarXpath =
            "//*[contains(@class, 'nav-link') and contains(@href, 'requests')]";
        private readonly string supportLinkOfNavBarXpath =
            "//*[contains(@class, 'nav-link') and contains(@href, 'support')]";

        
        

        public Header(IWebDriver driver) : base(driver)
        {
        }

        public IWebElement Logo => _driver.FindElement(By.XPath(logoXpath));
        public IWebElement NavMenuBtn => _driver.FindElement(By.XPath(navMenuBtnXpath));
        public IWebElement ReferralNoteBtn => _driver.FindElement(By.XPath(referralNoteBtnXpath));
        public IWebElement CompassBtn => _driver.FindElement(By.XPath(compassBtnXpath));
        public IWebElement DisclaimerActionsBtn => _driver.FindElement(By.XPath(disclaimerActionsBtn));
        public IWebElement NavBar => _driver.FindElement(By.XPath(navBarXpath));
        public IWebElement LoadingSpinner => _driver.FindElement(By.XPath(loadingSpinnerXpath));
        public IWebElement OfferingsLinkOfNavBar => _driver.FindElement(By.XPath(offeringsLinkOfNavBarXpath));
        public IWebElement ProvidersLinkOfNavBar => _driver.FindElement(By.XPath(providersLinkOfNavBarXpath));
        public IWebElement InformationLibraryLinkOfNavBar => _driver.FindElement(By.XPath(informationLibraryLinkOfNavBarXpath));
        public IWebElement RequestsLinkOfNavBar => _driver.FindElement(By.XPath(requestsLinkOfNavBarXpath));
        public IWebElement SupportLinkOfNavBar => _driver.FindElement(By.XPath(supportLinkOfNavBarXpath));
        public IWebElement LoggedUserInfo => _driver.FindElement(By.XPath(loggedUserInfoXPath));
        public IWebElement LogoutBtn => LoggedUserInfo.FindElement(By.XPath(logoutBtnXpath));


        public bool IsNavBarOpened()
        {
            return HasClass(NavBar, "opened");
        }

        public void WaitInvisibilityOfLoadingSpinner()
        {
            WaitInvisibilityOfElementByXpath(loadingSpinnerXpath);
        }

        public void OpenNavBar()
        {
            WaitInvisibilityOfLoadingSpinner();
            WaitElementIsClickableByXpath(navMenuBtnXpath);
            NavMenuBtn.Click();
        }

        public MainTab OpenPageFromNavBar(MainTabName pageName)
        {
            if (!IsNavBarOpened())
            {
                OpenNavBar();
            }
            
            WaitElementIsVisibleByXpath(offeringsLinkOfNavBarXpath);
            WaitElementIsClickableByXpath(offeringsLinkOfNavBarXpath);

            switch (pageName)
            {
                case MainTabName.Offerings:
                    OfferingsLinkOfNavBar.Click();
                    return new Offerings(_driver);
                case MainTabName.Providers:
                    ProvidersLinkOfNavBar.Click();
                    return new Providers(_driver);
                case MainTabName.InformationLibrary:
                    InformationLibraryLinkOfNavBar.Click();
                    return new InformationLibrary(_driver);
                case MainTabName.Requests:
                    RequestsLinkOfNavBar.Click();
                    return new Requests(_driver);
                case MainTabName.Support:
                    SupportLinkOfNavBar.Click();
                    return new Support(_driver);

                default:
                    throw new InvalidEnumArgumentException("Invalid page name is set");
            }
            
        }

        public void Logout()
        {
            OpenNavBar();
            WaitElementIsClickableByXpath(logoutBtnXpath);
            Click(LogoutBtn);

        }

    }
}
