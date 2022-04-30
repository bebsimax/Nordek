using Nordek.Stores;
using Nordek.ViewModels;

namespace Nordek.Commands;

public class LoginCommand : CommandBase
{
    private readonly LoginViewModel _viewModel;
    private readonly NavigationStore _navigationStore;
    
    public LoginCommand(LoginViewModel viewModel, NavigationStore navigationStore)
    {
        _viewModel = viewModel;
        _navigationStore = navigationStore;
    }

    public override void Execute(object parameter)
    {
        _navigationStore.CurrentViewModel = new HomeViewModel(_navigationStore);
    }
}