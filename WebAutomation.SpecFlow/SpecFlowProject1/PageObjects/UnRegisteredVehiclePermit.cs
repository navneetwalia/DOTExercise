using NUnit.Framework;
using OpenQA.Selenium;
using System;
using TechTalk.SpecFlow;
using WebAutomation.SpecFlow.Drivers;

namespace DOTExercise.PageObjects
{
    class UnRegisteredVehiclePermit : BasePageAction
    {
        private readonly ConfigurationDriver _configurationDriver;
        private readonly ScenarioContext _scenarioContext;
        private readonly IWebDriver _driver;
        private readonly string pageUrl = "https://www.vicroads.vic.gov.au/registration/limited-use-permits/unregistered-vehicle-permits/get-an-unregistered-vehicle-permit";
        private readonly string pageTitle = "Get an Unregistered Vehicle Permit : VicRoads";
        private readonly string pageContent = "Step 1 of 7 : Calculate fee";
       

        private string _vehicleTypeId = "ph_pagebody_0_phthreecolumnmaincontent_0_panel_VehicleType_DDList"; 
        private By _vehicleType = By.ClassName("simple-label");
        private string _passengerVehicleId = "ph_pagebody_0_phthreecolumnmaincontent_0_panel_PassengerVehicleSubType_DDList";
        private By _passengerVehicleType = By.XPath("//span[@class='simple-select xlong v_required fn_uvp-calc-update']");
        
        private By _addressText = By.Id("ph_pagebody_0_phthreecolumnmaincontent_0_panel_AddressLine_SingleLine_CtrlHolderDivShown");
        private string _permitDuration = "ph_pagebody_0_phthreecolumnmaincontent_0_panel_PermitDuration_DDList";
        private By _calculateButton = By.Id("ph_pagebody_0_phthreecolumnmaincontent_0_panel_btnCal");
        private By _permit = By.XPath("//span[@class='simple-select v_required medium fn_uvp-calc-update permitdurationelement']/span/span");
        private By _dateDisplayed = By.XPath("//*[@id='PermitDurationModule']/span[2]");
        private By _permitCost = By.XPath("//*[@id='ph_pagebody_0_phthreecolumnmaincontent_0_panel_divfee']/span[1]");
        private By _btnNext = By.Id("ph_pagebody_0_phthreecolumnmaincontent_0_panel_btnNext");
        private By _carryingCap = By.Id("carrying-capacity-content-goods-vehicle");
        private string _carryingCapacity = "ph_pagebody_0_phthreecolumnmaincontent_0_panel_GoodsVehicleSubType_DDList";
        private string _engineCapacity = "ph_pagebody_0_phthreecolumnmaincontent_0_panel_MotorcycleSubType_DDList";

        private const string _defaultAddress = "Unit 7 11 Sample Street, Broadmeadows VIC 3047";
        
      
        public UnRegisteredVehiclePermit(ScenarioContext scenarioContext, IWebDriver driver, ConfigurationDriver configurationDriver)
            :base(driver)
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
            _driver.Navigate().GoToUrl(pageUrl);
            Verify();
            return this;
        }

        public UnRegisteredVehiclePermit EnterPermitDetails(string vehicleTypeOption)
        {
            WaitUntilElementIsVisible(_vehicleType);
            SelectElementById(_vehicleTypeId, vehicleTypeOption);
            switch (vehicleTypeOption)
            {
                case "Passenger vehicle":
                    WaitUntilElementIsVisible(_passengerVehicleType);
                    SelectElementByIndex(_passengerVehicleId);
                    break;
                case "Goods carrying vehicle":
                    WaitUntilElementIsVisible(_carryingCap);
                    SelectElementByIndex(_carryingCapacity);
                    break;
                case "Motorcycle":
                     SelectElementByIndex(_engineCapacity);
                    break;
                default: break;
            }
            EnterText(_addressText, _defaultAddress);
            
            SelectElementByIndex(_permitDuration);
           
            _scenarioContext.TryAdd("PermitDays", GetText(_permit));
            Click(_calculateButton);
            return this;
        }

        public UnRegisteredVehiclePermit ViewPermitDateAndCalculatedFees()
        {
            _scenarioContext.TryGetValue("PermitDays", out string permitDuration);
            int permitDays = int.Parse(permitDuration.Remove(1));
            DateTime permitEndDate = DateTime.Today.AddDays(permitDays-1);
            string permitDateDisplayed = _driver.FindElement(_dateDisplayed).Text;
            string permitDate = permitEndDate.ToString("dd MMMM yyyy");
            Assert.AreEqual(permitDate, permitDateDisplayed, "Permit end date is not displayed correctly");
            Assert.AreEqual(_driver.FindElement(_permitCost).Text, "Your permit will cost:","Permit cost is not displayed");
            return this;
        }

        public VehiclePermitSecondStep ClickNext()
        {
            Click(_btnNext);
            return new VehiclePermitSecondStep(_scenarioContext,driver,_configurationDriver);
        }
    }
}
