using Newtonsoft.Json;

namespace SimpleTrader.FinancialModelingPrepAPI
{
    public class FinancialModelingPrepHttpClient : HttpClient
    {
        private readonly string apiKey;

        public FinancialModelingPrepHttpClient(string apiKey)
        {
            this.BaseAddress = new Uri("https://financialmodelingprep.com/api/v3");
            this.apiKey = apiKey;
        }

        public async Task<T> GetAsync<T>(string uri)
        {
            HttpResponseMessage response = await GetAsync($"{uri}?apikey={apiKey}");
            //HttpResponseMessage response = await GetAsync(uri);
            string jsonResponse = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<T>(jsonResponse);
        }
    }
}
