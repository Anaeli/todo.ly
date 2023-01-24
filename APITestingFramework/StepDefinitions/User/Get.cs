using System;
using System.Text.Json;
using Core;
using Features.GeneralSteps;
using Models;
using RestSharp;
using TechTalk.SpecFlow;

namespace Features.User.Get
{
    [Binding]
    [Scope(Feature = "Retrieve an existing user")]
    public class GetStepDefinitions : CommonSteps
    {
        private readonly ScenarioContext _scenarioContext;
        private readonly RestHelper client = new RestHelper("https://todo.ly/api");

        public GetStepDefinitions(ScenarioContext scenarioContext) : base(scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [When(@"the user submits a GET request to the API endpoint with a valid user ID")]
        public void WhentheusersubmitsaGETrequesttotheAPIendpointwithavaliduserID()
        {
            string url = "user.json";
            client.AddDefaultHeader("Authorization", _scenarioContext["Authorization"].ToString()!);
            client.AddDefaultHeader("Accept", "*/*");

            _scenarioContext["Response"] = client.Get(url);
        }

        [Then(@"the API should return a (.*) status code and the requested user in JSON format")]
        public void ThentheAPIshouldreturnastatuscodeandtherequesteduserinJSONformat(string statusCode)
        {

            RestResponse response = (RestResponse)_scenarioContext["Response"];

            Assert.True(response.IsSuccessful);
            Assert.Equal(statusCode, response.StatusCode.ToString());

            var user = JsonSerializer.Deserialize<UserPayloadModel>(response.Content!);
            Assert.IsType<UserPayloadModel>(user);
        }

        [When(
            @"the user submits a GET request to the API endpoint with an invalid user email in the URL"
        )]
        public void WhentheusersubmitsaGETrequesttotheAPIendpointwithaninvaliduserIDintheURL()
        {
            string url = "user.json";
            client.AddDefaultHeader("Authorization", "Basic aW52YWxpZEBlbWFpbC5jb206UGFzc3dvcmQ=");
            client.AddDefaultHeader("Accept", "*/*");

            _scenarioContext["Response"] = client.Get(url);
        }

        [Then(
            @"the API should return a (.*) status code and an error message indicating that the user was not found"
        )]
        public void ThentheAPIshouldreturnastatuscodeandanerrormessageindicatingthattheuserwasnotfound(
            string statusCode
        )
        {
            RestResponse response = (RestResponse)_scenarioContext["Response"];

            Assert.True(response.IsSuccessful);
            Assert.Equal(statusCode, response.StatusCode.ToString());

            var error = JsonSerializer.Deserialize<ErrorResponseModel>(response.Content!);
            Assert.IsType<ErrorResponseModel>(error);
            Assert.Equal("Account doesn't exist", error!.ErrorMessage);
            Assert.Equal(105, error!.ErrorCode);
        }

        [When(@"the user submits a GET request to the API endpoint")]
        public void WhentheusersubmitsaGETrequesttotheAPIendpoint()
        {
            string url = "user.json";
            client.AddDefaultHeader("Accept", "*/*");

            _scenarioContext["Response"] = client.Get(url);
        }

        [Then(
            @"the API should return a (.*) status code and an error message indicating that the user is not authorized to access the resource."
        )]
        public void ThentheAPIshouldreturnastatuscodeandanerrormessageindicatingthattheuserisnotauthorizedtoaccesstheresource(
            string statusCode
        )
        {
            RestResponse response = (RestResponse)_scenarioContext["Response"];

            Assert.True(response.IsSuccessful);
            Assert.Equal(statusCode, response.StatusCode.ToString());

            var error = JsonSerializer.Deserialize<ErrorResponseModel>(response.Content!);
            Assert.IsType<ErrorResponseModel>(error);
            Assert.Equal("Not Authenticated", error!.ErrorMessage);
            Assert.Equal(102, error!.ErrorCode);
        }
    }
}
