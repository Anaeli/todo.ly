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

    public async Task<T> GetAsync<T>(string url)
    {
        var request = CreateRequest(url: url);
        var res = await client.GetAsync<T>(request);
        return res!;
    }

    public async Task<T> DeleteAsync<T>(string url)
    {
        var request = CreateRequest(url: url);
        var res = await client.DeleteAsync<T>(request);
        return res!;
    }
}
