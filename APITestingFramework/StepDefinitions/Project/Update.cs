using System;
using TechTalk.SpecFlow;

namespace StepDefinitions.Project.Update
{
    [Binding]
    public class StepDefinitionsUpdate
    {
        private readonly ScenarioContext _scenarioContext;

        public StepDefinitionsUpdate(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [Given("the user is authenticated in (.*) to update the projects")]
        public void Giventheuserisauthenticatedinpagetoupdatetheprojects(string s)
        {
            // _scenarioContext.Pending();
        }

        [When("the user sends a PUT request to the (.*) endpoint")]
        public void WhentheusersendsaPUTrequesttothehttpstodolyapiprojectsidjsonendpoint(string Id)
        {
            // _scenarioContext.Pending();
        }

        [Then("includes the updated project content, items count, icon, item type, parent id, collapsed, and item order in the request body")]
        public void Thenincludestheupdatedprojectcontentitemscounticonitemtypeparentidcollapsedanditemorderintherequestbody()
        {
            // _scenarioContext.Pending();
        }

        [Then("the project's information should be updated in the projects")]
        public void Thentheprojectsinformationshouldbeupdatedintheprojects()
        {
            // _scenarioContext.Pending();
        }

        [Then("the user should receive a response with the updated project's information")]
        public void Thentheusershouldreceivea()
        {
            // _scenarioContext.Pending();
        }

    }
}