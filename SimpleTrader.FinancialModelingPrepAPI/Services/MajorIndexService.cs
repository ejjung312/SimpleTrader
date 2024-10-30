using Newtonsoft.Json;
using SimpleTrader.Domain.Models;
using SimpleTrader.Domain.Services;
using SimpleTrader.FinancialModelingPrepAPI.Results;

namespace SimpleTrader.FinancialModelingPrepAPI.Services
{
    public class MajorIndexService : IMajorIndexService
    {
        public async Task<MajorIndex> GetMajorIndex(MajorIndexType indexType)
        {
            using(FinancialModelingPrepHttpClient client = new FinancialModelingPrepHttpClient())
            {
                //string uri = "/profile/AAPL";
                string uri = client.BaseAddress + "/profile/AAPL?apikey=OdRiKITrL4KfPyAQ0frGMGFi9F2sNWQ4";

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
