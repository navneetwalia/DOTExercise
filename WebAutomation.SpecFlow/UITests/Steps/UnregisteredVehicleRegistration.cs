using TechTalk.SpecFlow;
using OpenQA.Selenium;
using DoTUITests.PageObjects;
using WebAutomation.SpecFlow.Drivers;

namespace DoTUITests.Steps
{
    [Binding]
    public sealed class UnregisteredVehicleRegistration
    {
        private UnRegisteredVehiclePermit _unRegisteredVehiclePermit;
        private readonly ScenarioContext _scenarioContext;
        private readonly IWebDriver _webDriver;

        public UnregisteredVehicleRegistration(ScenarioContext scenarioContext,IWebDriver webDriver, ConfigurationDriver configurationDriver)
        {
            _scenarioContext = scenarioContext;
            _webDriver = webDriver;
            _unRegisteredVehiclePermit = new UnRegisteredVehiclePermit(scenarioContext, webDriver, configurationDriver);
        }

        #region Given

        [Given(@"the user is on unregistered vehicle permit registration page")]
        public void GivenTheUserIsOnUnregisteredVehiclePermitRegistrationPage()
        {
            _unRegisteredVehiclePermit.NavigateToUrl();
        }


        #endregion

        #region When

        [When(@"the user enters (.*) and other details in step one to calculate fees")]
        public void WhenTheUserEntersVehicleTypeAndOtherDetailsInStepOneToCalculateFees(string vehicleType)
        {
                    _unRegisteredVehiclePermit.EnterPermitDetails(vehicleType);
        }


        #endregion

        [Then("the result should be (.*)")]
        public void ThenTheResultShouldBe(int result)
        {
            //TODO: implement assert (verification) logic

            _scenarioContext.Pending();
        }
    }
}
