using System;
using System.Text.Json;
using Core;
using Features.GeneralSteps;
using Models;
using RestSharp;
using TechTalk.SpecFlow;

namespace Features.User.Post
{
    [Binding]
    [Scope(Feature = "User Creation")]
    public class PostStepDefinitions : CommonSteps
    {
        private readonly ScenarioContext _scenarioContext;
        private readonly RestHelper client = new RestHelper("https://todo.ly/api");

        public PostStepDefinitions(ScenarioContext scenarioContext) : base(scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [When(
            @"the user submits a POST request to the API endpoint with a valid JSON or XML payload"
        )]
        public void WhentheusersubmitsaPOSTrequesttotheAPIendpointwithavalidJSONorXMLpayload()
        {
            string url = "user.json";
            UserPayloadModel body = new UserPayloadModel(
                "molinazjd@gmail.com",
                "password",
                "fullname",
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
            _scenarioContext["Response"] = client.Post<UserPayloadModel>(url, body);
        }

        [Then(
            @"the API should return a (.*) status code and the new user should be added to the database"
        )]
        public void ThentheAPIshouldreturnastatuscodeandthenewusershouldbeaddedtothedatabase(
            string statusCode
        )
        {
            RestResponse response = (RestResponse)_scenarioContext["Response"];
            Assert.True(response.IsSuccessful);
            Assert.Equal(statusCode, response.StatusCode.ToString());
            var user = JsonSerializer.Deserialize<UserPayloadModel>(response.Content!);
            Assert.IsType<UserPayloadModel>(user);
        }

        [When(
            @"the user submits a POST request to the API endpoint with a JSON or XML payload that is missing required fields"
        )]
        public void WhentheusersubmitsaPOSTrequesttotheAPIendpointwithaJSONorXMLpayloadthatismissingrequiredfields()
        {
            string url = "user.json";
            UserPayloadModel body = new UserPayloadModel(
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
            _scenarioContext["Response"] = client.Post<UserPayloadModel>(url, body);
        }

        [Then(
            @"the API should return a (.*) status code and an error message indicating that the required fields are missing"
        )]
        public void ThentheAPIshouldreturnastatuscodeandanerrormessageindicatingthattherequiredfieldsaremissing(
            string statusCode
        )
        {
            RestResponse response = (RestResponse)_scenarioContext["Response"];

            Assert.True(response.IsSuccessful);
            Assert.Equal(statusCode, response.StatusCode.ToString());
            var res = JsonSerializer.Deserialize<ErrorResponseModel>(response.Content!);
            Assert.IsType<ErrorResponseModel>(res);
            Assert.Equal("Invalid Email Address", res!.ErrorMessage);
            Assert.Equal(307, res!.ErrorCode);
        }

        [When(
            @"the user submits a POST request to the API endpoint with a JSON or XML payload that has invalid data"
        )]
        public void WhentheusersubmitsaPOSTrequesttotheAPIendpointwithaJSONorXMLpayloadthathasinvaliddata()
        {
            string url = "user.json";
            UserPayloadModel body = new UserPayloadModel(
                "",
                "password",
                "fullname",
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
            _scenarioContext["Response"] = client.Post<UserPayloadModel>(url, body);
        }

        [Then(
            @"the API should return a (.*) status code and an error message indicating that the data is invalid"
        )]
        public void ThentheAPIshouldreturnastatuscodeandanerrormessageindicatingthatthedataisinvalid(
            string statusCode
        )
        {
            RestResponse response = (RestResponse)_scenarioContext["Response"];

            Assert.True(response.IsSuccessful);
            Assert.Equal(statusCode, response.StatusCode.ToString());
            var res = JsonSerializer.Deserialize<ErrorResponseModel>(response.Content!);
            Assert.IsType<ErrorResponseModel>(res);
            Assert.Equal("Invalid Email Address", res!.ErrorMessage);
            Assert.Equal(307, res!.ErrorCode);
        }

        [When(
            @"the user submits a POST request to the API endpoint with a JSON or XML payload that has an email previously used to create an account"
        )]
        public void WhentheusersubmitsaPOSTrequesttotheAPIendpointwithaJSONorXMLpayloadthathasanemailpreviouslyusedtocreateanaccount()
        {
            string url = "user.json";
            UserPayloadModel body = new UserPayloadModel(
                "test@gmail.com",
                "password",
                "fullname",
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
            _scenarioContext["Response"] = client.Post<UserPayloadModel>(url, body);
        }

        [Then(
            @"the API should return a (.*) status code and an error message indicating that an account with the email provided already exists"
        )]
        public void ThentheAPIshouldreturnastatuscodeandanerrormessageindicatingthatanaccountwiththeemailprovidedalreadyexists(
            string statusCode
        )
        {
            RestResponse response = (RestResponse)_scenarioContext["Response"];

            Assert.True(response.IsSuccessful);
            Assert.Equal(statusCode, response.StatusCode.ToString());
            var res = JsonSerializer.Deserialize<ErrorResponseModel>(response.Content!);
            Assert.IsType<ErrorResponseModel>(res);
            Assert.Equal("Account with this email address already exists", res!.ErrorMessage);
            Assert.Equal(201, res!.ErrorCode);
        }
    }
}
