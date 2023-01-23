using System;
using TechTalk.SpecFlow;
using Core;
using Models;
using RestSharp;
	
namespace Features.User.Post
{

[Binding]
public class PostStepDefinitions
{
    private readonly ScenarioContext _scenarioContext;
    private RestHelper client = new RestHelper("https://todo.ly/api");
    RestResponse response;

    public PostStepDefinitions(ScenarioContext scenarioContext)
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

[When(@"the user submits a POST request to the API endpoint with a valid JSON or XML payload")]
public async void WhentheusersubmitsaPOSTrequesttotheAPIendpointwithavalidJSONorXMLpayload()
{
    var url = "user.json";

    var user = new UserPayloadModelRequest("joaquasdin@email.com", "Joaco", "password");
    
    response = client.Post(url);
    System.Console.WriteLine(response.IsSuccessful);
    System.Console.WriteLine(response.StatusCode);
    System.Console.WriteLine(response.Content);
}

[Then(@"the API should return a (.*) status code and the new user should be added to the database")]
public void ThentheAPIshouldreturnastatuscodeandthenewusershouldbeaddedtothedatabase(int args1)
{
	string skere = ""; 
}


[When(@"the user submits a POST request to the API endpoint with a JSON or XML payload that is missing required fields")]
public void WhentheusersubmitsaPOSTrequesttotheAPIendpointwithaJSONorXMLpayloadthatismissingrequiredfields()
{
	string skere = ""; 
}

[Then(@"the API should return a (.*) status code and an error message indicating that the required fields are missing")]
public void ThentheAPIshouldreturnastatuscodeandanerrormessageindicatingthattherequiredfieldsaremissing(int args1)
{
	string skere = ""; 
}


[When(@"the user submits a POST request to the API endpoint with a JSON or XML payload that has invalid data")]
public void WhentheusersubmitsaPOSTrequesttotheAPIendpointwithaJSONorXMLpayloadthathasinvaliddata()
{
	string skere = ""; 
}

[Then(@"the API should return a (.*) status code and an error message indicating that the data is invalid")]
public void ThentheAPIshouldreturnastatuscodeandanerrormessageindicatingthatthedataisinvalid(int args1)
{
	string skere = ""; 
}


[When(@"the user submits a POST request to the API endpoint with a JSON or XML payload that has an email previously used to create an account")]
public void WhentheusersubmitsaPOSTrequesttotheAPIendpointwithaJSONorXMLpayloadthathasanemailpreviouslyusedtocreateanaccount()
{
	string skere = ""; 
}

[Then(@"the API should return a (.*) status code and an error message indicating that an account with the email provided already exists")]
public void ThentheAPIshouldreturnastatuscodeandanerrormessageindicatingthatanaccountwiththeemailprovidedalreadyexists(int args1)
{
	string skere = ""; 
}

		}
	}
