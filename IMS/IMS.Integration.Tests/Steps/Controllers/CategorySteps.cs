using IMS.Integration.Tests.Services;
using System;
using System.Collections.Generic;
using System.IO;
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
        public CategorySteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [Given("a request must be made")]
        public void GivenARequestMustBeMade()
        {
            //informative only
        }
        [When("the request is made to the '(.*)' endpoint")]
        public async Task WhenTheRequestIsMadeToTheEndpoint(string endpoint)
        {
            var response = await ApiServiceConnector.Instance.GetFromApiAsync(endpoint);
            this._scenarioContext.Set(response, "response");
        }


        [Then("a (.*) http status should be returned")]
        public void ThenAHttpStatusShouldBeReturned(int expectedStatusCode)
        {
            var response = this._scenarioContext.Get<HttpResponseMessage>("response");
            Assert.Equal(expectedStatusCode, (int)response.StatusCode);
        }
    }
}
