using IMS.Integration.Tests.Services;
using System.Net.Http;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using Xunit;

namespace IMS.Integration.Tests.Steps.Controllers
{
    [Binding]
    public class CategorySteps
    {
        private readonly ScenarioContext context;
        public CategorySteps(ScenarioContext scenarioContext)
        {
            context = scenarioContext;
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
            this.context.Set(response, "response");
        }


        [Then("a (.*) http status should be returned")]
        public void ThenAHttpStatusShouldBeReturned(int expectedStatusCode)
        {
            var response = this.context.Get<HttpResponseMessage>("response");
            Assert.Equal(expectedStatusCode, (int)response.StatusCode);
        }
    }
}
