using SimpleTrader.Domain.Models;
using SimpleTrader.Domain.Services;

namespace SimpleTrader.FinancialModelingPrepAPI.Services
{
    public class MajorIndexService : IMajorIndexService
    {
        private readonly FinancialModelingPrepHttpClientFactory _httpClientFactory;

        public MajorIndexService(FinancialModelingPrepHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<MajorIndex> GetMajorIndex(MajorIndexType indexType)
        {
            using(FinancialModelingPrepHttpClient client = _httpClientFactory.CreateHttpClient())
            {
                //string uri = "/profile/AAPL";
                string uri = client.BaseAddress + "/profile/AAPL";

                List<MajorIndex> temp = await client.GetAsync<List<MajorIndex>>(uri);
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
                    throw new Exception("MajorIndexType does not have a suffix defined.");
            }
        }
    }
}
