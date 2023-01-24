using System;
using TechTalk.SpecFlow;
using System.Text.Json;
using Core;
// using Features.GeneralSteps;
using Models;
using RestSharp;

namespace Features.Project.Delete
{
    [Binding]
    [Scope(Feature = "Delete a project by ID")]
    public class DeleteProjectStepDefinitions
    {
        private readonly ScenarioContext _scenarioContext;
        private readonly RestHelper client = new RestHelper("https://todo.ly/api");
        private ProjectPayloadModel? Project;
        String url = "";
        public DeleteProjectStepDefinitions(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [Given("the user has a valid project ID (.*)")]
        public void Thentheusershouldre(long Id)
        {
            url = $"projects/{Id}.json";
            client.AddDefaultHeader("Authorization", "Basic VmFsZXJpYS5Hb256YWxlc0BqYWxhLnVuaXZlcnNpdHk6MTIzNA==");
            client.AddDefaultHeader("Accept", "*/*");

            _scenarioContext["Response"] = client.Get(url);
            var response = (RestResponse)_scenarioContext["Response"];
            Assert.True(response.IsSuccessful);
            Project = JsonSerializer.Deserialize<ProjectPayloadModel>(response.Content!);
            Assert.Equal(Project!.Id, Id);
        }

        [When("the user sends a DELETE request to the API endpoint")]
        public void WhentheusersendsaDELETErequesttotheendpoint()
        {
            _scenarioContext["Response"] = client.Delete(url);
            var response = (RestResponse)_scenarioContext["Response"];
            Assert.True(response.IsSuccessful);
        }

        [Then("the project should be removed from the list of projects")]
        public void Thentheprojectshouldberemovedfromthelistofprojects()
        {
             _scenarioContext["Response"] = client.Get(url);
            var response = (RestResponse)_scenarioContext["Response"];
            Console.WriteLine(response);
            Assert.Empty(response.Content);
        }
    }
}