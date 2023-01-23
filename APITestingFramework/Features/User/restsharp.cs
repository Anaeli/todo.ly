using System.Collections.Generic;
using RestSharp;
using RestSharp.Authenticators;

public record User(int Id, string Email, string FullName);
public record Error(string ErrorMessage, int ErrorCode);

public class UserTest
{
    [Fact]
    public void TestName()
    {
        // var client = new RestClient("https://todo.ly/api");
        // // {
        // //     Authenticator = new HttpBasicAuthenticator("jgioffre@gmail.com", "Password")
        // // };

        // client.AddDefaultHeader("Authorization", "Basic amdpb2ZmcmVAaG90bWFpbC5jb206UGFzc3dvcmQ=");

        // var request = new RestRequest("user.json");
        // var response = client.Get(request);
        // System.Console.WriteLine(response.Content);
        // Assert.True(response.IsSuccessful);
        // System.Console.WriteLine(response.StatusCode);
        // var response1 = client.Get<User>(request);
        // System.Console.WriteLine(response1);
    }
}

