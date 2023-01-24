using TechTalk.SpecFlow;
using DotNetEnv;
using System;

namespace Features.GeneralSteps
{
    public class CommonSteps
    {
        private readonly ScenarioContext _scenarioContext;

        public CommonSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [Given(@"the user is authenticated")]
        public void Giventheuserisauthenticated()
        {
            _scenarioContext["Authorization"] = "Basic amdpb2ZmcmVAaG90bWFpbC5jb206UGFzc3dvcmQ=";
            // DotNetEnv.Env.Load();
            // _scenarioContext["Authorization"] = Environment.GetEnvironmentVariable("AUTHORIZATION");
        }


        [Given(@"the user is not authenticated")]
        public void Giventheuserinotsauthenticated()
        {
            _scenarioContext["Authorization"] = "";
        }
    }
}
