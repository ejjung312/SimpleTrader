using SimpleTrader.WPF.State.Assets;
using System.Collections.ObjectModel;

namespace SimpleTrader.WPF.ViewModels
{
    public class AssetSummaryViewModel : ViewModelBase
    {
        private readonly AssetStore _assetStore;

        private readonly ObservableCollection<AssetViewModel> _topAssets;

        public double AccountBalance => _assetStore.AccountBalance;
        public IEnumerable<AssetViewModel> TopAssets => _topAssets;

        public AssetSummaryViewModel(AssetStore assetStore)
        {
            _assetStore = assetStore;

            _topAssets = new ObservableCollection<AssetViewModel>();

            _assetStore.StateChanged += AssetStore_StateChanged;

            ResetAsset();
        }

        private void AssetStore_StateChanged()
        {
            OnPropertyChanged(nameof(AccountBalance));
            ResetAsset();
        }

        private void ResetAsset()
        {
            IEnumerable<AssetViewModel> assetViewModels = _assetStore.AssetTransactions
                .GroupBy(t => t.Asset.Symbol)
                .Select(g => new AssetViewModel(g.Key, g.Sum(a => a.IsPurchase ? a.Shares : -a.Shares)))
                .Where(a => a.Shares > 0)
                .OrderByDescending(a => a.Shares)
                .Take(3);

            _topAssets.Clear();
            foreach (AssetViewModel viewModel in assetViewModels)
            {
                _topAssets.Add(viewModel);
            }
        }
    }
}
