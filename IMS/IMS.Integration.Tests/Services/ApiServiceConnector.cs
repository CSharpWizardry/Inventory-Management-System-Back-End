using System.Net.Http;
using System.Threading.Tasks;

namespace IMS.Integration.Tests.Services
{
    public class ApiServiceConnector
    {
        private static HttpClient _client { get; }
        private const string baseUrl = "http://localhost:5000/";
        private static ApiServiceConnector _instance;
        
        private ApiServiceConnector() { }
        public static ApiServiceConnector Instance{
            get {
                if (_instance is null)
                    _instance = new ApiServiceConnector();
                return _instance;
            } }
        static ApiServiceConnector()
        {
            _client = new HttpClient();
        }

        public async Task<HttpResponseMessage> GetFromApiAsync(string route)
        {
            return await _client.GetAsync(baseUrl + route);
        }

    }
}
