using System;
using TechTalk.SpecFlow;
using Core;
using Models;
using RestSharp;
using System.Text.Json;
using Features.GeneralSteps;

namespace Features.User.Post
{
    [Binding]
    [Scope(Feature = "User Creation")]
    public class PostStepDefinitions : CommonSteps
    {
        private readonly ScenarioContext _scenarioContext;
        private RestHelper client = new RestHelper("https://todo.ly/api");
        RestResponse response;

        public PostStepDefinitions(ScenarioContext scenarioContext) : base(scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        // [Given(@"the user is not authenticated")]
        // public void Giventheuserisnotauthenticated()
        // {
        //     var credentialsKey = "Authorization";
        //     var credentialsValue = "Basic amdpb2ZmcmVAaG90bWFpbC5jb206UGFzc3dvcmQ=";
        //     client.AddDefaultHeader(credentialsKey, credentialsValue);
        // }

        [When(
            @"the user submits a POST request to the API endpoint with a valid JSON or XML payload"
        )]
        public void WhentheusersubmitsaPOSTrequesttotheAPIendpointwithavalidJSONorXMLpayload()
        {
            var url = "user.json";
            var body = new UserPayloadModel(
                "molinazjd@gmail.com",
                "password",
                "joaco",
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
            response = client.Post<UserPayloadModel>(url, body);
        }

        [Then(
            @"the API should return a (.*) status code and the new user should be added to the database"
        )]
        public void ThentheAPIshouldreturnastatuscodeandthenewusershouldbeaddedtothedatabase(
            int args1
        )
        {
            Assert.True(response.IsSuccessful);
            Assert.Equal(response.StatusCode.ToString(), "OK");

            var user = JsonSerializer.Deserialize<UserPayloadModel>(response.Content!);
            Assert.IsType<UserPayloadModel>(user);
        }

        [When(
            @"the user submits a POST request to the API endpoint with a JSON or XML payload that is missing required fields"
        )]
        public void WhentheusersubmitsaPOSTrequesttotheAPIendpointwithaJSONorXMLpayloadthatismissingrequiredfields()
        {
            string skere = "";
        }

        [Then(
            @"the API should return a (.*) status code and an error message indicating that the required fields are missing"
        )]
        public void ThentheAPIshouldreturnastatuscodeandanerrormessageindicatingthattherequiredfieldsaremissing(
            int args1
        )
        {
            string skere = "";
        }

        [When(
            @"the user submits a POST request to the API endpoint with a JSON or XML payload that has invalid data"
        )]
        public void WhentheusersubmitsaPOSTrequesttotheAPIendpointwithaJSONorXMLpayloadthathasinvaliddata()
        {
            string skere = "";
        }

        [Then(
            @"the API should return a (.*) status code and an error message indicating that the data is invalid"
        )]
        public void ThentheAPIshouldreturnastatuscodeandanerrormessageindicatingthatthedataisinvalid(
            int args1
        )
        {
            string skere = "";
        }

        [When(
            @"the user submits a POST request to the API endpoint with a JSON or XML payload that has an email previously used to create an account"
        )]
        public void WhentheusersubmitsaPOSTrequesttotheAPIendpointwithaJSONorXMLpayloadthathasanemailpreviouslyusedtocreateanaccount()
        {
            string skere = "";
        }

        [Then(
            @"the API should return a (.*) status code and an error message indicating that an account with the email provided already exists"
        )]
        public void ThentheAPIshouldreturnastatuscodeandanerrormessageindicatingthatanaccountwiththeemailprovidedalreadyexists(
            int args1
        )
        {
            string skere = "";
        }
    }
}
