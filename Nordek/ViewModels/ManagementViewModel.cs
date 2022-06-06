using System.Windows.Input;
using Nordek.Commands;
using Nordek.Services;
using Nordek.Stores;

namespace Nordek.ViewModels;

public class ManagementViewModel : ViewModelBase
{
    private NavigationStore _navigationStore;
    
    public ICommand NavigateHomeCommand { get; }
    public ICommand NavigateManageNounsCommand { get; }
    public ManagementViewModel(NavigationStore navigationStore)
    {
        _navigationStore = navigationStore;
        NavigateHomeCommand = 
            new NavigateCommand<HomeViewModel>(new NavigationService<HomeViewModel>(
                navigationStore, () => new HomeViewModel(navigationStore)));
        NavigateManageNounsCommand = 
            new NavigateCommand<ManageNounsViewModel>(new NavigationService<ManageNounsViewModel>(
                navigationStore, () => new ManageNounsViewModel(navigationStore)));
    }
}