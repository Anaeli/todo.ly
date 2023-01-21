using System;
using TechTalk.SpecFlow;
using Core;
using Models;

namespace Features.User.Delete
{
    [Binding]
    public class DeleteStepDefinitions
    {
        private readonly ScenarioContext _scenarioContext;
        private RestHelper client = new RestHelper("https://todo.ly/api");
        private ITestOutputHelper _output;

        public DeleteStepDefinitions(ScenarioContext scenarioContext, ITestOutputHelper output)
        {
            _scenarioContext = scenarioContext;
            _output = output;
        }

        [Given(@"the user is authenticated")]
        public void Giventheuserisauthenticated()
        {
            var credentialsKey = "Authorization";
            var credentialsValue = "Basic amdpb2ZmcmVAaG90bWFpbC5jb206UGFzc3dvcmQ=";
            client.AddDefaultHeader(credentialsKey, credentialsValue);
        }

        [When(@"the user submits a DELETE request to the API endpoint")]
        public async void WhentheusersubmitsaDELETErequesttotheAPIendpoint()
        {
            var url = "user/0.json";
            UserPayloadModel res = await client.DeleteAsync<UserPayloadModel>(url: url);
            Console.WriteLine(res.Id);
            _output.WriteLine(res.Id.ToString());
        }

        [Then(
            @"the API should return a (.*) status code and the user should be removed from the database"
        )]
        public void ThentheAPIshouldreturnastatuscodeandtheusershouldberemovedfromthedatabase(
            int args1
        )
        {
            string skere = "";
        }

        [Given(@"the user is not authenticated")]
        public void Giventheuserisnotauthenticated()
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
