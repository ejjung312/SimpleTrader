using Newtonsoft.Json;
using SimpleTrader.FinancialModelingPrepAPI.Models;

namespace SimpleTrader.FinancialModelingPrepAPI
{
    public class FinancialModelingPrepHttpClient : HttpClient
    {
        private readonly HttpClient _client;
        private readonly string _apiKey;

        public FinancialModelingPrepHttpClient(HttpClient client, FinancialModelingPrepAPIKey apiKey)
        {
            this.BaseAddress = new Uri("https://financialmodelingprep.com/api/v3");
            _client = client;
            _apiKey = apiKey.Key;
        }

        public async Task<T> GetAsync<T>(string uri)
        {
            HttpResponseMessage response = await _client.GetAsync($"{uri}?apikey={_apiKey}");
            //HttpResponseMessage response = await GetAsync(uri);
            string jsonResponse = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<T>(jsonResponse);
        }
    }
}
