using RestSharp;
using RestSharp.Authenticators;
using System.Threading.Tasks;
using Models;

namespace Core;

public class RestHelper
{
    RestClient client;

    public RestHelper(string uri)
    {
        client = new RestClient(uri);
    }

    private RestRequest CreateRequest(string url)
    {
        return new RestRequest(url);
    }

    public void AddDefaultHeader(string Key, string value)
    {
        client.AddDefaultHeader(Key, value);
    }

    public RestResponse Get(string url)
    {
        var request = CreateRequest(url: url);
        var res = client.Get(request);
        return res!;
    }

    public async Task<T> GetAsync<T>(string url)
    {
        var request = CreateRequest(url: url);
        var res = await client.GetAsync<T>(request);
        return res!;
    }

    public RestResponse Post(string url)
    {
        // var request = CreateRequest(url: url);
        var request = new RestRequest(url, Method.Post);

        var param = new UserPayloadModel(null, "test@gmail.com", "password", "joaco", null, null, null, null, null, null, null, null, null);
        // request.AddHeader("Content-type", "application/json");
        request.AddJsonBody(param);
        
        var res = client.Execute(request);
        return res!;
    }

    // public async Task<T> PostAsync<T>(string url, UserPayloadModel payload)
    // {
    //     var request = CreateRequest(url: url);
    //     var res = await client.PostJsonAsync<UserPayloadModel, T>(url, payload);
    //     return res!;
    // }

    public async Task<T> DeleteAsync<T>(string url)
    {
        var request = CreateRequest(url: url);
        var res = await client.DeleteAsync<T>(request);
        return res!;
    }

}
