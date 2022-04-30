using System.Windows.Input;
using Nordek.Commands;
using Nordek.Stores;

namespace Nordek.ViewModels;

public class LoginViewModel : ViewModelBase
{
    private NavigationStore _navigationStore;
    public ICommand LoginCommand { get; }

    public LoginViewModel(NavigationStore navigationStore)
    {
        _navigationStore = navigationStore;
        LoginCommand = new LoginCommand(this, _navigationStore);
    }
}