using System;
using System.Text.Json;
using Core;
// using Features.GeneralSteps;
using Models;
using RestSharp;
using TechTalk.SpecFlow;

namespace Features.Project.Delete
{
    [Binding]
    [Scope(Feature = "Delete a project by ID")]
    public class DeleteProjectStepDefinitions
    {
        private readonly ScenarioContext _scenarioContext;
        private readonly RestHelper client = new RestHelper("https://todo.ly/api");
        private string ApiUrl = "";
        public DeleteProjectStepDefinitions(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [Given("the user has a valid project ID (.*)")]
        public void Thentheusershouldre(long id)
        {
            ApiUrl = $"projects/{id}.json";
            client.AddDefaultHeader("Authorization", "Basic VmFsZXJpYS5Hb256YWxlc0BqYWxhLnVuaXZlcnNpdHk6MTIzNA==");
            client.AddDefaultHeader("Accept", "*/*");

            _scenarioContext["Response"] = client.Get(ApiUrl);
            var response = (RestResponse)_scenarioContext["Response"];
            Assert.True(response.IsSuccessful);
            Console.WriteLine(response.Content);
            // var Project = JsonSerializer.Deserialize<ProjectRecord>(response.Content!.ToString());
            // Assert.Equal(Project!.Id, 9);
        }

        [When("the user sends a DELETE request to the API endpoint")]
        public void WhentheusersendsaDELETErequesttotheendpoint()
        {
            // _scenarioContext["Response"] = client.Delete(ApiUrl);
            // var response = (RestResponse)_scenarioContext["Response"];
            // Assert.True(response.IsSuccessful);
        }

        [Then("the project should be removed from the list of projects")]
        public void Thentheprojectshouldberemovedfromthelistofprojects()
        {
            // _scenarioContext["Response"] = client.Get(ApiUrl);
            // var response = (RestResponse)_scenarioContext["Response"];
            // Console.WriteLine(response);
            // Assert.Empty(response.Content);
        }

        [Given("the user has an invalid project ID (.*)")]
        public void GiventheuserhasaninvalidprojectID(long id)
        {
            ApiUrl = $"projects/{id}.json";
            client.AddDefaultHeader("Authorization", "Basic VmFsZXJpYS5Hb256YWxlc0BqYWxhLnVuaXZlcnNpdHk6MTIzNA==");
            client.AddDefaultHeader("Accept", "*/*");

        }

        [When("the user sends a DELETE request for the non-existent project to the API endpoint and return a (.*) status code with the message: (.*)")]
        public void WhentheusersendsaDELETErequestforthenonexistentprojecttotheAPIendpoint(int expectedErrorCode, string expectedErrorMessage)
        {
            _scenarioContext["Response"] = client.Get(ApiUrl);
            var response = (RestResponse)_scenarioContext["Response"];
            ErrorResponseModel? project = JsonSerializer.Deserialize<ErrorResponseModel>(response.Content!);
            Assert.Equal(project!.ErrorCode, expectedErrorCode);
            Assert.Equal(project!.ErrorMessage, expectedErrorMessage);
        }

        [Then("the API should return a (.*) status code and an error message indicating (.*) to access the resource")]
        public void ThentheAPIshouldreturna401statuscodeandanerrormessageindicatingthattheuserisnotauthorizedtoaccesstheresource(int expectedErrorCode, string expectedErrorMessage)
        {
            _scenarioContext["Response"] = client.Delete(ApiUrl);
            var response = (RestResponse)_scenarioContext["Response"];
            ErrorResponseModel? project = JsonSerializer.Deserialize<ErrorResponseModel>(response.Content!);
            Assert.Equal(project!.ErrorCode, expectedErrorCode);
            Assert.Equal(project!.ErrorMessage, expectedErrorMessage);
        }
    }
}
