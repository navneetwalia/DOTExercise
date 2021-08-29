using NUnit.Framework;
using OpenQA.Selenium;
using System;
using TechTalk.SpecFlow;
using WebAutomation.SpecFlow.Drivers;

namespace DOTExercise.PageObjects
{
    class VehiclePermitSecondStep : BasePageAction
    {
        private readonly ConfigurationDriver _configurationDriver;
        private readonly ScenarioContext _scenarioContext;
        private readonly IWebDriver _driver;
        private readonly string pageUrl = "https://www.vicroads.vic.gov.au/registration/limited-use-permits/unregistered-vehicle-permits/get-an-unregistered-vehicle-permit";
        private readonly string pageTitle = "Get an Unregistered Vehicle Permit : VicRoads";
        private readonly string pageContent = "Step 2 of 7 : Select permit type";
              
        public VehiclePermitSecondStep(ScenarioContext scenarioContext, IWebDriver driver, ConfigurationDriver configurationDriver)
            :base(driver)
        {

            _scenarioContext = scenarioContext;
            _driver = driver;
            _configurationDriver = configurationDriver;

        }

        public VehiclePermitSecondStep Verify()
        {
            Verify(pageUrl, pageTitle, pageContent);
            return this;
        }

        
    }
}
