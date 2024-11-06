using Newtonsoft.Json;
using SimpleTrader.Domain.Exceptions;
using SimpleTrader.Domain.Services;
using SimpleTrader.FinancialModelingPrepAPI.Results;

namespace SimpleTrader.FinancialModelingPrepAPI.Services
{
    public class StockPriceService : IStockPriceService
    {
        private readonly FinancialModelingPrepHttpClient _client;

        public StockPriceService(FinancialModelingPrepHttpClient client)
        {
            _client = client;
        }

        public async Task<double> GetPrice(string symbol)
        {
            string uri = _client.BaseAddress + "/profile/" + symbol;

            List<StockPriceResult> temp = await _client.GetAsync<List<StockPriceResult>>(uri);
            StockPriceResult stockPriceResult = temp[0];

            if (stockPriceResult.Price == 0)
            {
                throw new InvalidSymbolException(symbol);
            }

            return stockPriceResult.Price;
        }
    }
}
