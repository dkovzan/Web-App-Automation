using NUnit.Framework;
using WPAutomation.PageObjects.ListViews;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;

namespace WPAutomation.PageObjects.MainTabs
{
    public class Offerings : MainTab
    {
        public const string TabNameForRMWP = "Wealth Planning Access - Offerings and Referral Note";
        public const string TabNameForCDCO = "Wealth Planning Access - Offerings";
        
        //Client residence filter
        private readonly string crFilterXpath = "//*[@class='cr-select cr-select-filter']";
        private readonly string crSelectListContainerXpath = "//div/select-list";
        private readonly string crDropdownValuesXpath = "//*[contains(@class,'select-list-item']";
        private readonly string crSelectedValueXpath = "//*[@class='select-label-text']";

        //Bubble filters
        private readonly string bubbleFilterContainerXpath = "//*[@id='svg-container']";
        private readonly string offeringPurposeBubbleFilterXpath = "//*[@class='group-circle-animate']";
        private readonly string offeringPurposeBubblesXpath = "//*[@class='circle-group']";
        private readonly string productServiceTypesBubbleFilterXpath = "//*[@class='chartLayer']";
        private readonly string productServiceTypeBubblesXpath = "//*[@class='node-item']";


        public Offerings(IWebDriver driver) : base(driver)
        {
            Url += "offerings";
        }
        public OfferingsOverviewPane OfferingsOverviewPane => new OfferingsOverviewPane(_driver);
        public IWebElement CrFilter => _driver.FindElement(By.XPath(crFilterXpath));
        public IWebElement CrSelectListContainer => CrFilter.FindElement(By.XPath(crSelectListContainerXpath));
        public IWebElement CrSelectedValue => _driver.FindElement(By.XPath(crSelectedValueXpath));
        public IList<IWebElement> CrDropdownValues => _driver.FindElements(By.XPath(crDropdownValuesXpath));
        public IWebElement BubbleFilterContainer => _driver.FindElement(By.XPath(bubbleFilterContainerXpath));
        public IWebElement OfferingPurposeBubbleFilter => _driver.FindElement(By.XPath(offeringPurposeBubbleFilterXpath));
        public IList<IWebElement> OfferingPurposeBubbles => _driver.FindElements(By.XPath(offeringPurposeBubblesXpath));
        public IWebElement ProductServiceTypesBubbleFilter => _driver.FindElement(By.XPath(productServiceTypesBubbleFilterXpath));
        public IList<IWebElement> ProductServiceLvlBubbles => _driver.FindElements(By.XPath(productServiceTypeBubblesXpath));
        public IWebElement OfferingPurposeBubbleOnProductServiceLvl => ProductServiceLvlBubbles[0];
        public IWebElement FirstProductServiceTypeBubble => ProductServiceLvlBubbles[1];


        public void CheckIsCrFilterWithValuesDisplayed()
        {
            Header.WaitInvisibilityOfLoadingSpinner();
            Assert.IsTrue(CrFilter.Displayed, message: "CR filter is not displayed");
            WaitElementIsClickableByXpath(crFilterXpath);
            CrFilter.Click();
            Assert.IsTrue(CrSelectListContainer.Displayed, message: "CR filter values are not displayed");
            HideCrFilter();
        }

        public void ClickOfferingPurposeBubble(string offeringPurpose)
        {
            Header.WaitInvisibilityOfLoadingSpinner();
            WaitElementIsClickableByXpath(offeringPurposeBubblesXpath);
            var offeringPurposeBubbleElement = OfferingPurposeBubbles.Where(_ => _.GetAttribute("id") == OfferingPurposes.GetValueOrDefault(offeringPurpose)).FirstOrDefault();
            Click(offeringPurposeBubbleElement);
        }

        public void ClickFirstProductServiceTypeBubble()
        {
            if(IsOnOfferingPurposeBubbleLvl())
            {
                ClickOfferingPurposeBubble("Taxation");
            }
            Header.WaitInvisibilityOfLoadingSpinner();
            WaitElementIsClickableByXpath(productServiceTypeBubblesXpath);
            FirstProductServiceTypeBubble.Click();
        }

        public bool IsOnOfferingPurposeBubbleLvl()
        {
            try
            {
                return OfferingPurposeBubbleFilter.Displayed;
            }
            catch (NoSuchElementException ex)
            {
                Console.WriteLine(ex);
                return false;
            }
        }

        public static readonly Dictionary<string, string> OfferingPurposes = new Dictionary<string, string>
        {
            { "Succession", "circle-group-0" },
            { "WealthStructuring", "circle-group-1" },
            { "Relocation", "circle-group-2" },
            { "WealthOverview", "circle-group-3" },
            { "Philanthropy", "circle-group-4" },
            { "WealthPlanningRelated", "circle-group-5" },
            { "RetirementPension", "circle-group-6" },
            { "Taxation", "circle-group-7"}
        };

        public static readonly Dictionary<string, string> ProductServiceTypes = new Dictionary<string, string>
        {
            { "Accounting", "node-5281"},
            { "LegalServices", "node-5283" }

        };

        public void HideCrFilter()
        {
            if (CrSelectListContainer.Displayed)
            {
                WaitElementIsClickableByXpath(crFilterXpath);
                Click(CrFilter);
            }
        }

    }
}
