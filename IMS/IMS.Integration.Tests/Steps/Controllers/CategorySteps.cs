using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using Xunit;

namespace IMS.Integration.Tests.Steps.Controllers
{
    [Binding]
    public class CategorySteps
    {
        private readonly ScenarioContext _scenarioContext;
        private HttpClient _client { get; set; }

        public CategorySteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            _client = new HttpClient();
        }

        [Given(@"a request must be made")]
        public void GivenARequestMustBeMade()
        {
            //informative only
        }

        [When(@"the request is made to the endpoint")]
        public async Task WhenTheRequestIsMadeToTheEndpoint()
        {
            var response = await _client.GetAsync("http://localhost:8080/WeatherForecast");
            this._scenarioContext.Set(response, "response");
        }


        [Then(@"a (.*) http status should be returned")]
        public void ThenAHttpStatusShouldBeReturned(int statusCode)
        {
            var response = this._scenarioContext.Get<HttpResponseMessage>("response");
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }
    }
}
