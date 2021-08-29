using OpenQA.Selenium;
using DOTExercise.PageObjects;
using TechTalk.SpecFlow;
using WebAutomation.SpecFlow.Drivers;

namespace DOTExercise.Steps
{
    [Binding]
    public sealed class UnregisteredVehicleRegistration
    {

        // For additional details on SpecFlow step definitions see https://go.specflow.org/doc-stepdef

        private readonly ScenarioContext _scenarioContext;
        private readonly UnRegisteredVehiclePermit _unRegisteredVehiclePermit;
        private  VehiclePermitSecondStep _vehiclePermitSecondStep;
        public UnregisteredVehicleRegistration(ScenarioContext scenarioContext,IWebDriver webDriver, ConfigurationDriver configurationDriver)
        {
            _scenarioContext = scenarioContext;
            _unRegisteredVehiclePermit = new UnRegisteredVehiclePermit(scenarioContext, webDriver, configurationDriver);
        }

        [Given("the first number is (.*)")]
        public void GivenTheFirstNumberIs(int number)
        {
            //TODO: implement arrange (precondition) logic
            // For storing and retrieving scenario-specific data see https://go.specflow.org/doc-sharingdata
            // To use the multiline text or the table argument of the scenario,
            // additional string/Table parameters can be defined on the step definition
            // method. 

            number = 1;
        }


        #region Given

        [Given(@"the user is on unregistered vehicle permit registration page")]
        public void GivenTheUserIsOnUnregisteredVehiclePermitRegistrationPage()
        {
            _unRegisteredVehiclePermit.NavigateToUrl();
        }

        #endregion

        #region When

        [When(@"the user enters the (.*) and mandatory details")]
        public void WhenTheUserEntersTheVehicleAndMandatoryDetails(string vehicleType)
        {

            _unRegisteredVehiclePermit.EnterPermitDetails(vehicleType);
        }

        [When(@"the user is able to view permit date based on permit duration and calculate fees")]
        public void WhenTheUserIsAbleToViewPermitDateBasedOnPermitDurationAndCalculateFees()
        {
            _unRegisteredVehiclePermit.ViewPermitDateAndCalculatedFees();
        }

        [When(@"the user navigates to step two of permit registration")]
        public void WhenTheUserNavigatesToStepTwoOfPermitRegistration()
        {
            _vehiclePermitSecondStep =_unRegisteredVehiclePermit.ClickNext();
        }

        #endregion

        #region Then

        [Then(@"the select permit type is displayed on step two of vehicle registration")]
        public void ThenTheSelectPermitTypeIsDisplayedOnStepTwoOfVehicleRegistration()
        {
            _vehiclePermitSecondStep.Verify();
        }

        #endregion
    }
}
