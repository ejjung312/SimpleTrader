﻿using SimpleTrader.Domain.Services;
using SimpleTrader.Domain.Services.TransactionServices;
using SimpleTrader.WPF.Commands;
using SimpleTrader.WPF.State.Accounts;
using System.Windows.Input;

namespace SimpleTrader.WPF.ViewModels
{
    public class BuyViewModel : ViewModelBase
    {
		private string _symbol;
		public string Symbol
		{
			get
			{
				return _symbol;
			}
			set
			{
				_symbol = value;
				OnPropertyChanged(nameof(Symbol));
			}
		}

		private string _searchResultSymbol = string.Empty;
		public string SearchResultSymbol
        {
			get
			{
				return _searchResultSymbol;
			}
			set
			{
				_searchResultSymbol = value;
				OnPropertyChanged(nameof(SearchResultSymbol));
				OnPropertyChanged(nameof(TotalPrice));
			}
		}

		private double _stockPrice;
		public double StockPrice
		{
			get
			{
				return _stockPrice;
			}
			set
			{
				_stockPrice = value;
				OnPropertyChanged(nameof(StockPrice));
				OnPropertyChanged(nameof(TotalPrice));
			}
		}

		private int _sharesToBuy;
		public int SharesToBuy
        {
			get
			{
				return _sharesToBuy;
			}
			set
			{
				_sharesToBuy = value;
				OnPropertyChanged(nameof(SharesToBuy));
				OnPropertyChanged(nameof(TotalPrice));
			}
		}

		public double TotalPrice
		{
			get
			{
				return SharesToBuy * StockPrice;
			}
		}

		public ICommand SearchSymbolCommand { get; set; }
		public ICommand BuyStockCommand { get; set; }

        public BuyViewModel(IStockPriceService stockPriceService, IBuyStockService buyStockService, IAccountStore accountStore)
        {
            SearchSymbolCommand = new SearchSymbolCommand(this, stockPriceService);
            BuyStockCommand = new BuyStockCommand(this, buyStockService, accountStore);
        }
    }
}
