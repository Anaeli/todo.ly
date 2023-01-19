using TechTalk.SpecFlow;

namespace todo.ly.Steps
{
    [Binding]
    public sealed class DeleteProjectByIDStepDefinitions
    {
        private readonly ScenarioContext _scenarioContext;

        public DeleteProjectByIDStepDefinitions(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [Given("the user has a valid project ID")]
        public void Giventheusershouldre()
        {
            _scenarioContext.Pending();
        }

        [When("the user sends a DELETE request to the (.*) endpoint")]
        public void WhentheusersendsaDELETErequesttotheendpoint(string args1)
        {
            _scenarioContext.Pending();
        }

        [Then("the project should be removed from the list of projects")]
        public void Thentheprojectshouldberemovedfromthelistofprojects()
        {
            _scenarioContext.Pending();
        }

        [Then("the user should receive a response with the removed project's information")]
        public void Andtheusershouldreceivearesponsewiththeremovedprojectsinformation()
        {
            _scenarioContext.Pending();
        }

    }
}