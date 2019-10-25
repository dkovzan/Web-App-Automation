using NUnit.Allure.Attributes;
using NUnit.Allure.Core;
using NUnit.Framework;
using WPAutomation.PageObjects.MainTabs;

namespace WPAutomation.Tests.SmokeSuite.CC
{
    [TestFixture]
    [AllureNUnit]
    [AllureLink("https://github.com/unickq/allure-nunit")]
    public class LoginFormTestsSuite : Hooks
    {
        public LoginFormTestsSuite() : base(BrowserType.Chrome) {}

        private LoginForm _loginForm;

        [SetUp]
        public void InitializeTest()
        {
            SelectBrowser(_browserType);
            _loginForm = new LoginForm(Driver);
            _loginForm.Open();
        }

        [TearDown]
        public void CleanUp()
        {
            Driver.Close();
        }

        [Test]
        public void LoginPageTitle()
        {
            Assert.AreEqual("Wealth Planning Access", Driver.Title, message: "Login page title is incorrect");
        }

        [Test]
        public void AuthorizationWP()
        {
            var offeringsPage = _loginForm.SignIn("u30111", "AIPxVfBJp1A+1");
            Assert.AreEqual(Offerings.TabNameForRMWP, offeringsPage.Header.Logo.Text, message: "Not an offerings page is opened");
            Assert.AreEqual(offeringsPage.Url.ToLower(), Driver.Url.ToLower(), message: "Url is incorrect");
        }

        [Test]
        public void AuthorizationRM()
        {
            var offeringsPage = _loginForm.SignIn("u50111", "x+UHhiJ5a6T*_");
            Assert.AreEqual(Offerings.TabNameForRMWP, offeringsPage.Header.Logo.Text, message: "Not an offerings page is opened");
            Assert.AreEqual(offeringsPage.Url.ToLower(), Driver.Url.ToLower(), message: "Url is incorrect");
        }

        [Test]
        public void LoggingOut()
        {
            var offeringsPage = _loginForm.SignIn("u50111", "x+UHhiJ5a6T*_");
            offeringsPage.Header.Logout();
            offeringsPage.Header.WaitInvisibilityOfLoadingSpinner();
            Assert.AreEqual((Base.Host + Base.Env + "login").ToLower(), Driver.Url.ToLower());
        }

        [Test]
        public void SignInBtnDisabledWhenLoginPasswordEmpty()
        {
            Assert.IsTrue(!_loginForm.SignInBtn.Enabled, message: "Sign in button is enabled");
        }

        [Test]
        public void SignInBtnDisabledWhenLoginEmptyPasswordFilled()
        {
            _loginForm.EnterPassword("123456789012");
            Assert.IsTrue(!_loginForm.SignInBtn.Enabled, message: "Sign in button is enabled");
        }

        [Test]
        public void WrongLoginOrPasswordNotExistingUser()
        {
            _loginForm.SignIn("u50111qweq", "x+UHhiJ5a6T*_qwe");
            Assert.IsTrue(_loginForm.ErrorMessage.Displayed, message: "Error message is not displayed");
            Assert.AreEqual("Wrong login or password.", _loginForm.ErrorMessage.Text, message: "Text of error message is wrong");
        }
    }
}