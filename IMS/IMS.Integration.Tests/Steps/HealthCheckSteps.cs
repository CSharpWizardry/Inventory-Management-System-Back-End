using IMS.Integration.Tests.Services;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using Xunit;

namespace IMS.Integration.Tests.Steps
{
    [Binding]
    public class HealthCheckSteps
    {
        private readonly ScenarioContext context;
        private const string healthCheckEndpoint = "health";

        public HealthCheckSteps(ScenarioContext context)
        {
            this.context = context;
        }

        [When("a health-check is made")]
        public async Task WhenAHealth_CheckIsMade()
        {
            var response = await ApiServiceConnector.Instance.GetFromRouteAsync(healthCheckEndpoint);
            this.context.Set(response, "response");
        }

        [Then("the response contains the value '(.*)'")]
        public async Task ThenTheResponseContainsTheValue(string expectedValue)
        {
            var response = this.context.Get<HttpResponseMessage>("response");
            var contentBody = await response.Content.ReadAsStringAsync();
            Assert.Contains(expectedValue, contentBody);
        }


    }
}
