namespace SimpleTrader.WPF.ViewModels.Factories
{
    public class PortfolioVidwModelFactory : ISimpleTraderViewModelFactory<PortfolioViewModel>
    {
        public PortfolioViewModel CreateViewModel()
        {
            return new PortfolioViewModel();
        }
    }
}
