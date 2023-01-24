using System;
using System.Text.Json;
using Core;
using Features.GeneralSteps;
using Models;
using RestSharp;
using TechTalk.SpecFlow;

namespace Features.User.Put
{
    [Binding]
    [Scope(Feature = "User Update")]
    public class PutStepDefinitions : CommonSteps
    {
        private readonly ScenarioContext _scenarioContext;
        private readonly RestHelper client = new RestHelper("https://todo.ly/api");

        public PutStepDefinitions(ScenarioContext scenarioContext) : base(scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [When(@"the user submits a PUT request to the API endpoint with a valid JSON or XML payload")]
        public void WhentheusersubmitsaPUTrequesttotheAPIendpointwithavalidJSONorXMLpayload()
        {
            string url = "user/0.json";
            UserPayloadModel body = new UserPayloadModel(
                null,
                "newPassword",
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
            _scenarioContext["Response"] = client.Put<UserPayloadModel>(url, body);
        }

        [Then(@"the API should return a (.*) status code and the user should be updated in the database")]
        public void ThentheAPIshouldreturnastatuscodeandtheusershouldbeupdatedinthedatabase(string statusCode)
        {
            RestResponse response = (RestResponse)_scenarioContext["Response"];
            Assert.True(response.IsSuccessful);
            Assert.Equal(statusCode, response.StatusCode.ToString());
            var user = JsonSerializer.Deserialize<UserPayloadModel>(response.Content!);
            Assert.IsType<UserPayloadModel>(user);
            // Assert.Equal("newPassword", user?.Password);
        }

[When(@"the user submits a PUT request to the API endpoint with an invalid ""(.*)"" user email")]
public void WhentheusersubmitsaPUTrequesttotheAPIendpointwithaninvaliduseremail(string email)
        {
            string url = "user/0.json";
            client.AddDefaultHeader("Authorization", "Basic aW52YWxpZEBlbWFpbC5jb206UGFzc3dvcmQ=");
            client.AddDefaultHeader("Accept", "*/*");

            UserPayloadModel body = new UserPayloadModel(
                null,
                "newPassword",
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
            _scenarioContext["Response"] = client.Put<UserPayloadModel>(url, body);
        }

        [Then(@"the API should return a (.*) status code and an error message indicating that the user was not found")]
        public void ThentheAPIshouldreturnastatuscodeandanerrormessageindicatingthattheuserwasnotfound(string statusCode)
        {
            RestResponse response = (RestResponse)_scenarioContext["Response"];

            Assert.True(response.IsSuccessful);
            Assert.Equal(statusCode, response.StatusCode.ToString());

            var error = JsonSerializer.Deserialize<ErrorResponseModel>(response.Content!);
            Assert.IsType<ErrorResponseModel>(error);
            Assert.Equal("Account doesn't exist", error!.ErrorMessage);
            Assert.Equal(105, error!.ErrorCode);
        }

        [When(@"the user submits a PUT request to the API endpoint")]
        public void WhentheusersubmitsaPUTrequesttotheAPIendpoint()
        {
            string url = "user/0.json";

            _scenarioContext["Response"] = client.Put<UserPayloadModel>(url, body: null!);
        }

        [Then(@"the API should return a (.*) status code and an error message indicating that the user is not authorized to access the resource.")]
        public void ThentheAPIshouldreturnastatuscodeandanerrormessageindicatingthattheuserisnotauthorizedtoaccesstheresource(string statusCode)
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
