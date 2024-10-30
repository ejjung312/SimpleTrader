using Newtonsoft.Json;
using SimpleTrader.Domain.Exceptions;
using SimpleTrader.Domain.Services;
using SimpleTrader.FinancialModelingPrepAPI.Results;

namespace SimpleTrader.FinancialModelingPrepAPI.Services
{
    public class StockPriceService : IStockPriceService
    {
        public async Task<double> GetPrice(string symbol)
        {
            using (FinancialModelingPrepHttpClient client = new FinancialModelingPrepHttpClient())
            {
                string uri = client.BaseAddress + "/profile/" + symbol + "?apikey=OdRiKITrL4KfPyAQ0frGMGFi9F2sNWQ4";

                List<StockPriceResult> temp = await client.GetAsync<List<StockPriceResult>>(uri);
                StockPriceResult stockPriceResult = temp[0];

                if (stockPriceResult.Price == 0)
                {
                    throw new InvalidSymbolException(symbol);
                }

                return stockPriceResult.Price;
            }
        }
    }
}
