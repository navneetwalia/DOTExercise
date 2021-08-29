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

        [Given("the second number is (.*)")]
        public void GivenTheSecondNumberIs(int number)
        {
            //TODO: implement arrange (precondition) logic
            // For storing and retrieving scenario-specific data see https://go.specflow.org/doc-sharingdata
            // To use the multiline text or the table argument of the scenario,
            // additional string/Table parameters can be defined on the step definition
            // method. 

            number = 2;
        }

        [When("the two numbers are added")]
        public void WhenTheTwoNumbersAreAdded()
        {
            //TODO: implement act (action) logic

            int sum = 3;
        }

        [Then("the result should be (.*)")]
        public void ThenTheResultShouldBe(int result)
        {
            //TODO: implement assert (verification) logic

            string result1 = "Pass";
        }

        #region Given

        [Given(@"the user is on unregistered vehicle permit registration page")]
        public void GivenTheUserIsOnUnregisteredVehiclePermitRegistrationPage()
        {
            //string result1 = "Pass";
            _unRegisteredVehiclePermit.NavigateToUrl();
        }


        #endregion
    }
}
