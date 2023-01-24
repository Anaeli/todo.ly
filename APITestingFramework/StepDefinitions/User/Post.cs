using System.Text.Json;
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

[Then(@"the API should return a ""(.*)"" status code and a ""(.*)"" error message indicating missing fields")]
public void ThentheAPIshouldreturnastatuscodeandaerrormessageindicatingmissingfields(string statusCode,string errorMessage)
        {
            RestResponse response = (RestResponse)_scenarioContext["Response"];

            Assert.True(response.IsSuccessful);
            Assert.Equal(statusCode, response.StatusCode.ToString());
            var res = JsonSerializer.Deserialize<ErrorResponseModel>(response.Content!);
            Assert.IsType<ErrorResponseModel>(res);
            Assert.Equal(errorMessage, res!.ErrorMessage);
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

[Then(@"the API should return a ""(.*)"" status code and a ""(.*)"" error message indicating invalid data")]
public void ThentheAPIshouldreturnastatuscodeandaerrormessageindicatinginvaliddata(string statusCode,string errorMessage)
        {
            RestResponse response = (RestResponse)_scenarioContext["Response"];

            Assert.True(response.IsSuccessful);
            Assert.Equal(statusCode, response.StatusCode.ToString());
            var res = JsonSerializer.Deserialize<ErrorResponseModel>(response.Content!);
            Assert.IsType<ErrorResponseModel>(res);
            Assert.Equal(errorMessage, res!.ErrorMessage);
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

[Then(@"the API should return a ""(.*)"" status code and a ""(.*)"" error message indicating the email already exists")]
public void ThentheAPIshouldreturnastatuscodeandaerrormessageindicatingtheemailalreadyexists(string statusCode,string errorMessage)
        {
            RestResponse response = (RestResponse)_scenarioContext["Response"];

            Assert.True(response.IsSuccessful);
            Assert.Equal(statusCode, response.StatusCode.ToString());
            var res = JsonSerializer.Deserialize<ErrorResponseModel>(response.Content!);
            Assert.IsType<ErrorResponseModel>(res);
            Assert.Equal(errorMessage, res!.ErrorMessage);
            Assert.Equal(201, res!.ErrorCode);
        }
    }
}
