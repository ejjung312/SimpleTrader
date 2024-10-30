using SimpleTrader.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleTrader.WPF.ViewModels.Factories
{
    public class MajorIndexListingVIewModelFactory : ISimpleTraderViewModelFactory<MajorIndexListingViewModel>
    {
        private IMajorIndexService _majorIndexService;

        public MajorIndexListingVIewModelFactory(IMajorIndexService majorIndexService)
        {
            _majorIndexService = majorIndexService;
        }

        public MajorIndexListingViewModel CreateViewModel()
        {
            return MajorIndexListingViewModel.LoadMajorIndexViewModel(_majorIndexService);
        }
    }
}
