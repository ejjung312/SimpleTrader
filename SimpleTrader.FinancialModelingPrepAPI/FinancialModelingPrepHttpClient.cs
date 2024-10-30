using Newtonsoft.Json;

namespace SimpleTrader.FinancialModelingPrepAPI
{
    public class FinancialModelingPrepHttpClient : HttpClient
    {
        public FinancialModelingPrepHttpClient()
        {
            this.BaseAddress = new Uri("https://financialmodelingprep.com/api/v3");
        }

        public async Task<T> GetAsync<T>(string uri)
        {
            //HttpResponseMessage response = await GetAsync($"{uri}?apikey=OdRiKITrL4KfPyAQ0frGMGFi9F2sNWQ4");
            HttpResponseMessage response = await GetAsync(uri);
            string jsonResponse = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<T>(jsonResponse);
        }
    }
}
