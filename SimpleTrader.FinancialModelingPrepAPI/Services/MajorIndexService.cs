using Newtonsoft.Json;
using SimpleTrader.Domain.Models;
using SimpleTrader.Domain.Services;

namespace SimpleTrader.FinancialModelingPrepAPI.Services
{
    public class MajorIndexService : IMajorIndexService
    {
        public async Task<MajorIndex> GetMajorIndex(MajorIndexType indexType)
        {
            using(HttpClient client = new HttpClient())
            {
                //string uri = "https://financialmodelingprep.com/api/v3/" + GetUriSuffix(indexType);
                string uri = "https://financialmodelingprep.com/api/v3/profile/AAPL";

                HttpResponseMessage response = await client.GetAsync($"{uri}?apikey=OdRiKITrL4KfPyAQ0frGMGFi9F2sNWQ4");
                string jsonResponse = await response.Content.ReadAsStringAsync();

                //MajorIndex majorIndex = JsonConvert.DeserializeObject<MajorIndex>(jsonResponse);
                List<MajorIndex> temp = JsonConvert.DeserializeObject<List<MajorIndex>>(jsonResponse);
                MajorIndex majorIndex = temp[0];
                majorIndex.Type = indexType;
                return majorIndex;
            }
        }

        private string GetUriSuffix(MajorIndexType indexType)
        {
            switch (indexType)
            {
                case MajorIndexType.DowJones:
                    return ".DJI";
                case MajorIndexType.Nasdaq:
                    return ".IXIC";
                case MajorIndexType.SP500:
                    return ".INX";
                default:
                    return ".DJI";
            }
        }
    }
}
