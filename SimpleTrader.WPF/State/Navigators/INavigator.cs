﻿using SimpleTrader.WPF.ViewModels;
using System.Windows.Input;

namespace SimpleTrader.WPF.State.Navigators
{
    public enum ViewType
    {
        Login,
        Home,
        Portfolio,
        Buy
    }

    public interface INavigator
    {
        ViewModelBase CurrentViewModel { get; set; }
    }
}
