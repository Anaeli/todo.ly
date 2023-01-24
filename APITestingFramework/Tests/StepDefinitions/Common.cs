﻿using System;
using Core;
using DotNetEnv;
using TechTalk.SpecFlow;

namespace Features.GeneralSteps
{
    public class CommonSteps
    {
        private readonly ScenarioContext _scenarioContext;
        public readonly RestHelper Client = new RestHelper("https://todo.ly/api");

        public CommonSteps(ScenarioContext scenarioContext)
        {
            DotNetEnv.Env.TraversePath().Load();
            _scenarioContext = scenarioContext;
        }

        [Given(@"the user is authenticated")]
        public void Giventheuserisauthenticated()
        {
            _scenarioContext["Authorization"] = System.Environment.GetEnvironmentVariable(
                "AUTHORIZATION"
            );
        }

        [Given(@"the user is not authenticated")]
        public void Giventheuserinotsauthenticated()
        {
            _scenarioContext["Authorization"] = "";
        }
    }
}
