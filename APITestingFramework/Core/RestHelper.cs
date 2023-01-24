﻿using System.Text.Json;
using RestSharp;

namespace Core;

public class RestHelper
{
    private readonly RestClient client;

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
        RestRequest request = new RestRequest(url, Method.Get);
        RestResponse res = client.Execute(request);
        return res!;
    }

    public RestResponse Post<T>(string url, T body)
    {
        RestRequest request = new RestRequest(url, Method.Post);

        string bodyString = JsonSerializer.Serialize<T>(body);
        request.AddParameter("application/json", bodyString, ParameterType.RequestBody);

        RestResponse res = client.Post(request);
        return res;
    }

    public RestResponse Delete(string url)
    {
        RestRequest request = new RestRequest(url, Method.Delete);
        RestResponse res = client.Execute(request);
        return res!;
    }

    public RestResponse Put<T>(string url, T body)
    {
        RestRequest request = new RestRequest(url, Method.Put);

        string bodyString = JsonSerializer.Serialize<T>(body);
        request.AddParameter("application/json", bodyString, ParameterType.RequestBody);

        RestResponse res = client.Put(request);
        return res;
    }
}
