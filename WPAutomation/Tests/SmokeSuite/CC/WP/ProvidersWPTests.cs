using NUnit.Framework;
using WPAutomation.PageObjects.MainTabs;
using System;
using System.Collections.Generic;
using System.Text;

namespace WPAutomation.Tests.SmokeSuite.CC.WP
{
    public class ProvidersWPTests : Hooks
    {
        public ProvidersWPTests() : base(BrowserType.Chrome) { }

        private Providers _providersPage;

        [OneTimeSetUp]
        public void Login()
        {
            SelectBrowser(_browserType);
            var loginForm = new LoginForm(Driver);
            loginForm.Open();
            var offeringsPage = loginForm.SignInAsExistingWpUser();
            _providersPage = (Providers) offeringsPage.Header.OpenPageFromNavBar(MainTabName.Providers);
        }

        [OneTimeTearDown]
        public void Logout()
        {
            _providersPage.Header.Logout();
            Driver.Close();
        }

        [Test]
        public void FilterDisplayed()
        {

        }
    }
}
