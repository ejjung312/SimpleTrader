namespace SimpleTrader.Domain.Models
{
    public class Account : DomainObject
    {
        public User AccountHolder { get; set; }
        public double Balance { get; set; }
        //public ICollection<AssetTransaction> AssetTransactions { get; set; }

        private ICollection<AssetTransaction> _assetTransactions;
        public ICollection<AssetTransaction> AssetTransactions
        {
            get => _assetTransactions ??= new List<AssetTransaction>();
            set => _assetTransactions = value;
        }
    }
}
