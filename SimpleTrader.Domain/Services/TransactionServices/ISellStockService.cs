using SimpleTrader.Domain.Models;

namespace SimpleTrader.Domain.Services.TransactionServices
{
    public interface ISellStockService
    {
        Task<Account> SellStock(Account seller, string symbol, int shares);
    }
}
