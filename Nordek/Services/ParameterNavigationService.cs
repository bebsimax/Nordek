using System;
using Nordek.Stores;
using Nordek.ViewModels;

namespace Nordek.Services;

public class ParameterNavigationService<TParameter, TViewModel>
where TViewModel : ViewModelBase
{
    private readonly NavigationStore _navigationStore;
    private readonly Func<TParameter, TViewModel> _createViewModel;

    public ParameterNavigationService(NavigationStore navigationStore, Func<TParameter, TViewModel> func)
    {
        _navigationStore = navigationStore;
        _createViewModel = func;
    }

    public void Navigate(TParameter parameter)
    {
        _navigationStore.CurrentViewModel = _createViewModel(parameter);
    }
}