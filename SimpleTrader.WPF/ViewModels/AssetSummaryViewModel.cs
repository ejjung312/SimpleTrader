﻿using SimpleTrader.WPF.State.Assets;

namespace SimpleTrader.WPF.ViewModels
{
    public class AssetSummaryViewModel : ViewModelBase
    {
        private readonly AssetStore _assetStore;

        public double AccountBalance => _assetStore.AccountBalance;
        public AssetListingViewModel AssetListingViewModel { get; }

        public AssetSummaryViewModel(AssetStore assetStore)
        {
            _assetStore = assetStore;

            AssetListingViewModel = new AssetListingViewModel(assetStore, assets => assets.Take(3));

            _assetStore.StateChanged += AssetStore_StateChanged;
        }

        private void AssetStore_StateChanged()
        {
            OnPropertyChanged(nameof(AccountBalance));
        }

        public override void Dispose()
        {
            _assetStore.StateChanged -= AssetStore_StateChanged;
            AssetListingViewModel.Dispose();

            base.Dispose();
        }
    }
}
