using System;
using Nordek.Stores;
using Nordek.ViewModels;

namespace Nordek.Services;

public class NavigationService<TViewModel>
    where TViewModel : ViewModelBase
{
    public NavigationService(NavigationStore navigationStore, Func<TViewModel> createViewModel)
    {
        _navigationStore = navigationStore;
        _createViewModel = createViewModel;
    }

    private NavigationStore _navigationStore;
    private readonly Func<TViewModel> _createViewModel;

    public void Navigate()
    {
        _navigationStore.CurrentViewModel = _createViewModel();
    }
}