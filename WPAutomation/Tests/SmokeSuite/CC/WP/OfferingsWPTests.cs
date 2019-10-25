using NUnit.Framework;
using WPAutomation.PageObjects.MainTabs;
using OpenQA.Selenium;
using System;

namespace WPAutomation.Tests.SmokeSuite.CC
{
    [TestFixture]
    public class OfferingsWPTests : Hooks
    {
        public OfferingsWPTests() : base(BrowserType.Chrome) { }

        private Offerings _offeringsPage;

        [OneTimeSetUp]
        public void Login()
        {
            SelectBrowser(_browserType);
            var loginForm = new LoginForm(Driver);
            loginForm.Open();
            _offeringsPage = loginForm.SignInAsExistingWpUser();
        }

        [OneTimeTearDown]
        public void Logout()
        {
            _offeringsPage.Header.Logout();
            Driver.Close();
        }

        [Test, Order(1)]
        public void CrFilterWithValuesDisplay()
        {
            _offeringsPage.CheckIsCrFilterWithValuesDisplayed();
        }

        [Test, Order(2)]
        public void OfferingPurposeBubbleFilterDisplayed()
        {
            Assert.IsTrue(_offeringsPage.OfferingPurposeBubbleFilter.Displayed);
        }

        [Test, Order(3)]
        public void ProductServiceTypeBubbleDisplayed()
        {
            _offeringsPage.ClickOfferingPurposeBubble("Taxation");
            _offeringsPage.Header.WaitInvisibilityOfLoadingSpinner();
            Assert.IsTrue(_offeringsPage.ProductServiceTypesBubbleFilter.Displayed);
        }

        [Test, Order(4)]
        public void OfferingsOverviewPaneDisplayed()
        {
            _offeringsPage.ClickFirstProductServiceTypeBubble();
            _offeringsPage.Header.WaitInvisibilityOfLoadingSpinner();
            Assert.IsTrue(_offeringsPage.OfferingsOverviewPane.Container.Displayed);
        }

        [Test, Order(5)]
        public void ActionsMenuDisplayed()
        {
            Assert.IsTrue(_offeringsPage.OfferingsOverviewPane.ActionsMenu.Container.Displayed);
        }

        [Test, Order(6)]
        public void OfferingsFiltersDisplayed()
        {
            Assert.IsTrue(_offeringsPage.OfferingsOverviewPane.OfferingsFilter.Container.Displayed);
        }

        [Test, Order(7)]
        public void OfferingsDetailsDisplayed()
        {
            _offeringsPage.OfferingsOverviewPane.OfferingsList.ClickFirstOfferingCartInList();
            _offeringsPage.Header.WaitInvisibilityOfLoadingSpinner();
            Assert.IsTrue(_offeringsPage.OfferingsOverviewPane.OfferingDetailsForm.Container.Displayed);
            _offeringsPage.OfferingsOverviewPane.OfferingDetailsForm.Close();
        }

        [Test, Order(8)]
        public void OfferingsOverviewHiddenAfterSelectingSameProductServiceBubble()
        {
            _offeringsPage.ClickFirstProductServiceTypeBubble();
            _offeringsPage.Header.WaitInvisibilityOfLoadingSpinner();
            try
            {
                Assert.IsTrue(!_offeringsPage.OfferingsOverviewPane.Container.Displayed);
            }
            catch (NoSuchElementException ex)
            {
                Console.WriteLine(ex.Message);
                Assert.IsTrue(true);
            }
        }

        



    }
}
