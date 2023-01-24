using System;
using System.Text.Json;
using Core;
// using Features.GeneralSteps;
using Models;
using RestSharp;
using TechTalk.SpecFlow;

namespace StepDefinitions.Project.Update
{
    [Binding]
    [Scope(Feature = "Update a Project by ID")]
    public class StepDefinitionsUpdate
    {
        private readonly ScenarioContext _scenarioContext;
        private readonly RestHelper client = new RestHelper("https://todo.ly/api");
        private readonly ProjectObject? Project;
        private string ApiUrl = "";

        public StepDefinitionsUpdate(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [Given("the user is authenticated")]
        public void Giventheuserisauthenticatedinpagetoupdatetheprojects()
        {
            //COMMON
        }

        [When("the user sends a PUT request for the project with ID (.*) to the API endpoint")]
        public void WhentheusersendsaPUTrequesttothehttpstodolyapiprojectsidjsonendpoint(long id)
        {
            ApiUrl = $"projects/{id}.json";
            client.AddDefaultHeader("Authorization", "Basic VmFsZXJpYS5Hb256YWxlc0BqYWxhLnVuaXZlcnNpdHk6MTIzNA==");
            client.AddDefaultHeader("Accept", "*/*");

            ProjectRecord body = new ProjectRecord(
                Id: null,
                Content: "proj",
                ItemsCount: null,
                null,
                null,
                null,
                null,
                null,
                null,
                null,
                null,
                null,
                null,
                null,
                null,
                null,
                null,
                null
            );
            // _scenarioContext["Response"] = client.Get(ApiUrl);
            _scenarioContext["Response"] = client.Put<ProjectRecord>(ApiUrl, body);
            var response = (RestResponse)_scenarioContext["Response"];
            Assert.Equal(response.Content, "x");
            // ProjectPayloadModel? project = JsonSerializer.Deserialize<ProjectPayloadModel>(response.Content!);

            // _scenarioContext["Response"] = client.Put<ProjectPayloadModel>(ApiUrl, body);
            // var response = (RestResponse)_scenarioContext["Response"];
            // Assert.Equal(project!.Content , "d");
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
