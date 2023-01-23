using System;
using TechTalk.SpecFlow;
using Core;
using Models;
using RestSharp;
using System.Text.Json;
using Features.GeneralSteps;

namespace Features.User.Get
{
    [Binding]
    [Scope(Feature = "Retrieve an existing user")]
    public class GetStepDefinitions : CommonSteps
    {
        private readonly ScenarioContext _scenarioContext;
        private RestHelper client = new RestHelper("https://todo.ly/api");
        RestResponse response;

        public GetStepDefinitions(ScenarioContext scenarioContext) : base(scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [When(@"the user submits a GET request to the API endpoint with a valid user ID")]
        public void WhentheusersubmitsaGETrequesttotheAPIendpointwithavaliduserID()
        {
            var url = "user.json";
            client.AddDefaultHeader("Authorization", _scenarioContext["Authorization"].ToString()!);
            client.AddDefaultHeader("Accept", "*/*");

            response = client.Get(url);
        }

        [Then(@"the API should return a (.*) status code and the requested user in JSON format")]
        public void ThentheAPIshouldreturnastatuscodeandtherequesteduserinJSONformat(int args1)
        {
            Assert.True(response.IsSuccessful);
            Assert.Equal(response.StatusCode.ToString(), "OK");

            var user = JsonSerializer.Deserialize<UserPayloadModel>(response.Content!);
            Assert.IsType<UserPayloadModel>(user);
        }

        [When(
            @"the user submits a GET request to the API endpoint with an invalid user ID in the URL"
        )]
        public void WhentheusersubmitsaGETrequesttotheAPIendpointwithaninvaliduserIDintheURL()
        {
            client.AddDefaultHeader("Authorization", _scenarioContext["Authorization"].ToString()!);
            string skere = "";
        }

        [Then(
            @"the API should return a (.*) status code and an error message indicating that the user was not found"
        )]
        public void ThentheAPIshouldreturnastatuscodeandanerrormessageindicatingthattheuserwasnotfound(
            int args1
        )
        {
            string skere = "";
        }

        [When(@"the user submits a GET request to the API endpoint")]
        public void WhentheusersubmitsaGETrequesttotheAPIendpoint()
        {
            string skere = "";
        }

        [Then(
            @"the API should return a (.*) status code and an error message indicating that the user is not authorized to access the resource."
        )]
        public void ThentheAPIshouldreturnastatuscodeandanerrormessageindicatingthattheuserisnotauthorizedtoaccesstheresource(
            int args1
        )
        {
            string skere = "";
        }
    }
}
