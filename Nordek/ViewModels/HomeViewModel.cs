using System.Windows.Input;
using Nordek.Commands;
using Nordek.Models;
using Nordek.Services;
using Nordek.Stores;

namespace Nordek.ViewModels;

public class HomeViewModel : ViewModelBase
{
    public string WelcomeMessage => "Welcome to my application.";
    public ICommand LogoutCommand { get; }
    public ICommand NavigateAccountCommand { get; }
    public ICommand NavigateSearchCommand { get; }
    public ICommand NavigateManagementCommand { get; }
    public ICommand NavigateRepeatCommand { get; }

    public HomeViewModel(NavigationStore navigationStore)
    {

        NavigateAccountCommand = new NavigateCommand<AccountViewModel>(new NavigationService<AccountViewModel>(
                navigationStore, () => new AccountViewModel(navigationStore)));
        
        NavigateSearchCommand = new NavigateCommand<SearchViewModel>(new NavigationService<SearchViewModel>(
            navigationStore, () => new SearchViewModel(navigationStore)));
        
        LogoutCommand = new LogoutCommand(new NavigationService<LoginViewModel>(
            navigationStore, () => new LoginViewModel(navigationStore)));
        
        NavigateManagementCommand = new NavigateCommand<ManagementViewModel>(new NavigationService<ManagementViewModel>(
            navigationStore, () => new ManagementViewModel(navigationStore)));
        
        NavigateRepeatCommand = new NavigateCommand<RepeatViewModel>(new NavigationService<RepeatViewModel>(
            navigationStore, () => new RepeatViewModel(navigationStore)));
    }
}