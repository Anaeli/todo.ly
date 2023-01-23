using TechTalk.SpecFlow;

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

            System.Console.WriteLine("IS ");
            System.Console.WriteLine(_scenarioContext.ScenarioInfo.Title);
            System.Console.WriteLine("");
        }

        [Given(@"the user is not authenticated")]
        public void Giventheuserinotsauthenticated()
        {
            _scenarioContext["Authorization"] = "";
            System.Console.WriteLine("NOT ");
            System.Console.WriteLine(_scenarioContext.ScenarioInfo.Title);
            System.Console.WriteLine("");
        }
    }
}
