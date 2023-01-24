using System.Text.Json;
using Features.GeneralSteps;
using Models;
using RestSharp;
using TechTalk.SpecFlow;
using RestSharp.Authenticators;
using System.Collections.Generic;

namespace Features.Item.Get
{
    [Binding]
    [Scope(Feature = "Retrieve all items")]
    public class GetItemsStepDefinitions : CommonSteps
    {
        private readonly ScenarioContext _scenarioContext;
        private readonly string url = "projects/4053023/items.json";

        public GetItemsStepDefinitions(ScenarioContext scenarioContext)
            : base(scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [When(
            @"the user makes a GET request to the API endpoint to retrieve the items of a valid project ID"
        )]
        public void WhentheusermakesaGETrequesttotheAPIendpointtoretrievetheitemsofavalidprojectID()
        {
            var username = _scenarioContext["username"].ToString();
            var password = _scenarioContext["password"].ToString();
            Client.AddDefaultHeader("Accept", "*/*");
            Client.AddAuthenticator(username: username!, password: password!);

            _scenarioContext["Response"] = Client.Get(url);

        }

        [Then(
            @"the API should return an (.*) status code and the list of items on the project"
        )]
        public void ThentheAPIshouldreturnanstatuscodeandthelistofitemsontheproject(
            string statusCode
        )
        {
            RestResponse response = (RestResponse)_scenarioContext["Response"];
            System.Console.WriteLine(response.Content!);
            Assert.Equal(statusCode, response.StatusCode.ToString());
            var items = JsonSerializer.Deserialize<List<ItemsPayloadModel>>(response.Content!);
            Assert.IsType<ItemsPayloadModel>(items);
        }

        // [When(
        //     @"the user makes a GET request to the API endpoint to retrieve the done items of a valid project ID"
        // )]
        // public void WhentheusermakesaGETrequesttotheAPIendpointtoretrievethedoneitemsofavalidprojectID()
        // {
        //     Client.AddDefaultHeader("Authorization", _scenarioContext["Authorization"].ToString()!);
        //     Client.AddDefaultHeader("Accept", "*/*");

        //     _scenarioContext["Response"] = Client.Get(url);
        // }

        // [Then(
        //     @"the API should return an ""(.*)"" status code and the list of done items on the project`"
        // )]
        // public void ThentheAPIshouldreturnanstatuscodeandthelistofdoneitemsontheproject(
        //     string statusCode
        // )
        // {
        //     RestResponse response = (RestResponse)_scenarioContext["Response"];
        //     Assert.True(response.IsSuccessful);
        //     Assert.Equal(statusCode, response.StatusCode.ToString());
        //     var items = JsonSerializer.Deserialize<ItemsPayloadModel>(response.Content!);
        //     Assert.IsType<ItemsPayloadModel>(items);
        // }
    }
}
