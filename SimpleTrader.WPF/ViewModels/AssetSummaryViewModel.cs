using SimpleTrader.WPF.State.Assets;
using System.Collections.ObjectModel;

namespace SimpleTrader.WPF.ViewModels
{
    public class AssetSummaryViewModel : ViewModelBase
    {
        private readonly AssetStore _assetStore;

        private readonly ObservableCollection<AssetViewModel> _assets;

        public double AccountBalance => _assetStore.AccountBalance;
        public IEnumerable<AssetViewModel> Assets => _assets;

        public AssetSummaryViewModel(AssetStore assetStore)
        {
            _assetStore = assetStore;

            _assets = new ObservableCollection<AssetViewModel>();

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
                .Where(a => a.Shares > 0);

            _assets.Clear();
            foreach (AssetViewModel viewModel in assetViewModels)
            {
                _assets.Add(viewModel);
            }
        }
    }
}
