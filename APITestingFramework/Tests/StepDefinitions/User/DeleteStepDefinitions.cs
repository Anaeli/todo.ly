using System;
using System.Text.Json;
using Core;
using Features.GeneralSteps;
using Models;
using RestSharp;
using TechTalk.SpecFlow;

namespace Features.User.Delete
{
    [Binding]
    [Scope(Feature = "User Deletion")]
    public class DeleteStepDefinitions : CommonSteps
    {
        private readonly ScenarioContext _scenarioContext;

        public DeleteStepDefinitions(ScenarioContext scenarioContext) : base(scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [When(@"the user submits a DELETE request to the API endpoint")]
        public void WhentheusersubmitsaDELETErequesttotheAPIendpoint()
        {
            string url = "user/0.json";
            Client.AddDefaultHeader("Authorization", _scenarioContext["Authorization"].ToString()!);
            Client.AddDefaultHeader("Accept", "*/*");
            _scenarioContext["Response"] = Client.Delete(url);
        }

        [Then(
            @"the API should return a (.*) status code and the user should be removed from the database"
        )]
        public void ThentheAPIshouldreturnastatuscodeandtheusershouldberemovedfromthedatabase(
            string statusCode
        )
        {
            RestResponse response = (RestResponse)_scenarioContext["Response"];

            Assert.True(response.IsSuccessful);
            Assert.Equal(statusCode, response.StatusCode.ToString());
            var user = JsonSerializer.Deserialize<UserPayloadModel>(response.Content!);
            Assert.IsType<UserPayloadModel>(user);
        }

        [Then(@"the API should return a ""(.*)"" status code and a ""(.*)"" error message indicating that the user is not authorized to access the resource.")]
        public void ThentheAPIshouldreturnastatuscodeandaerrormessageindicatingthattheuserisnotauthorizedtoaccesstheresource(string statusCode, string errorMessage)
        {
            RestResponse response = (RestResponse)_scenarioContext["Response"];

            Assert.True(response.IsSuccessful);
            Assert.Equal(statusCode, response.StatusCode.ToString());
            var res = JsonSerializer.Deserialize<ErrorResponseModel>(response.Content!);
            Assert.IsType<ErrorResponseModel>(res);
            Assert.Equal(errorMessage, res!.ErrorMessage);
            Assert.Equal(102, res!.ErrorCode);
        }
    }
}
