using System.Windows.Input;
using Nordek.Commands;
using Nordek.Stores;

namespace Nordek.ViewModels;

public class HomeViewModel : ViewModelBase
{
    public string WelcomeMessage => "Welcome to my application.";

    public ICommand NavigateAccountCommand { get; }

    public HomeViewModel(NavigationStore navigationStore)
    {
        NavigateAccountCommand =
            new NavigateCommand<AccountViewModel>(navigationStore, () => new AccountViewModel(navigationStore));
    }
}