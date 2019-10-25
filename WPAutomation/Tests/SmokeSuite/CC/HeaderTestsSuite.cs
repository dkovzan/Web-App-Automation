using NUnit.Framework;
using WPAutomation.PageObjects;
using WPAutomation.PageObjects.MainTabs;

namespace WPAutomation.Tests.SmokeSuite.CC
{
    [TestFixture]
    public class HeaderTestsSuite : Hooks
    {
        public HeaderTestsSuite() : base(BrowserType.Chrome)
        {

        }

        private Header _header => new Header(Driver);

        [OneTimeSetUp]
        public void Login()
        {
            SelectBrowser(_browserType);
            var loginForm = new LoginForm(Driver);
            loginForm.Open();
            loginForm.SignInAsExistingWpUser();
        }


        [OneTimeTearDown]
        public void Logout()
        {
            _header.Logout();
            Driver.Close();
        }

        [Test, Order(1)]
        public void OpeningNavBar()
        {
            _header.OpenNavBar();
            Assert.IsTrue(_header.IsNavBarOpened(), message: "Navigation bar is not opened");
        }

        [Test, Order(2)]
        public void OpeningProvidersPageFromNavBar()
        {
            var providerPage = _header.OpenPageFromNavBar(MainTabName.Providers);
            Assert.AreEqual("Wealth Planning Access - Providers", _header.Logo.Text, message: "Not an providers page is opened");
            Assert.AreEqual(providerPage.Url.ToLower(), Driver.Url.ToLower(), message: "Url is not correct");
        }

        [Test, Order(3)]
        [Ignore("Information Library is hidden from nav bar")]
        public void OpeningInformationLibraryPageFromNavBar()
        {
            var informationLibraryPage = _header.OpenPageFromNavBar(MainTabName.InformationLibrary);
            Assert.AreEqual("Wealth Planning Access - Information Library", _header.Logo.Text, message: "Not an providers page is opened");
            Assert.AreEqual(informationLibraryPage.Url.ToLower(), Driver.Url.ToLower(), message: "Url is not correct");
        }
    }
}
