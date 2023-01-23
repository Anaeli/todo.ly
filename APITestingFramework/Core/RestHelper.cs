using RestSharp;
using RestSharp.Authenticators;
using System.Threading.Tasks;
using Models;
using System.Text.Json;
using RestSharp.Serializers.Json;

namespace Core;

public class RestHelper
{
    RestClient client;

    public RestHelper(string uri)
    {
        client = new RestClient(uri);
    }

    public void AddDefaultHeader(string Key, string value)
    {
        client.AddDefaultHeader(Key, value);
    }

    public RestResponse Get(string url)
    {
        var request = new RestRequest(url, Method.Get);
        var res = client.Execute(request);
        return res!;
    }

    public RestResponse Post<T>(string url, T body)
    {
        var request = new RestRequest(url, Method.Post);

        var bodyString = JsonSerializer.Serialize<T>(body);
        request.AddParameter("application/json", bodyString, ParameterType.RequestBody);

        var res = client.Post(request);
        return res;
    }

    public RestResponse Delete(string url)
    {
        var request = new RestRequest(url, Method.Delete);
        var res = client.Execute(request);
        return res!;
    }
}