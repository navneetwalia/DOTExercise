using OpenQA.Selenium;
using TechTalk.SpecFlow;
using WebAutomation.SpecFlow.Drivers;

namespace DoTUITests.PageObjects
{
    class UnRegisteredVehiclePermit : BasePageAction
    {
        private readonly ConfigurationDriver _configurationDriver;
        private readonly ScenarioContext _scenarioContext;
        private readonly IWebDriver _driver;
        private readonly string pageUrl = "https://www.vicroads.vic.gov.au/registration/limited-use-permits/unregistered-vehicle-permits/get-an-unregistered-vehicle-permit";
        private readonly string pageTitle = "Get an Unregistered Vehicle Permit: VicRoads";
        private readonly string pageContent = "Step 1 of 7 : Calculate fee";


        private By _vehicleTypeDropDown = By.Id("ph_pagebody_0_phthreecolumnmaincontent_0_panel_VehicleType_DDList");
        
        public UnRegisteredVehiclePermit(ScenarioContext scenarioContext, IWebDriver driver, ConfigurationDriver configurationDriver)
        {

            _scenarioContext = scenarioContext;
            _driver = driver;
            _configurationDriver = configurationDriver;

        }

        public UnRegisteredVehiclePermit Verify()
        {
            Verify(pageUrl, pageTitle, pageContent);
            return this;
        }

        public UnRegisteredVehiclePermit NavigateToUrl()
        {
            Verify();
            _driver.Navigate().GoToUrl(pageUrl);
            return this;
        }

        public UnRegisteredVehiclePermit EnterPermitDetails(string vehicleType)
        {
            _driver.FindElement(_vehicleTypeDropDown).FindElement(By.XPath(".//option[contains(text(),'vehicleType')]")).Click();
            return this;
        }
    }
}
