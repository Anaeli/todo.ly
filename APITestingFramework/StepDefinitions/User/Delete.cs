using System;
using TechTalk.SpecFlow;
using Core;
using RestSharp;
using Features.GeneralSteps;

namespace Features.User.Delete
{
    [Binding]
    [Scope(Feature = "User Deletion")]
    public class DeleteStepDefinitions : CommonSteps
    {
        private readonly ScenarioContext _scenarioContext;
        private RestHelper client = new RestHelper("https://todo.ly/api");
        RestResponse response;

        public DeleteStepDefinitions(ScenarioContext scenarioContext) : base(scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [When(@"the user submits a DELETE request to the API endpoint")]
        public void WhentheusersubmitsaDELETErequesttotheAPIendpoint()
        {
            var url = "user/0.json";

            client.AddDefaultHeader("Authorization", _scenarioContext["Authorization"].ToString()!);
            client.AddDefaultHeader("Accept", "*/*");
            response = client.Delete(url);
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
