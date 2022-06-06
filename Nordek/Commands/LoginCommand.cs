using System.Windows.Navigation;
using Nordek.Models;
using Nordek.Services;
using Nordek.Stores;
using Nordek.ViewModels;

namespace Nordek.Commands;

public class LoginCommand : CommandBase
{
    
    private readonly LoginViewModel _viewModel;
    private readonly NavigationService<HomeViewModel> _navigationService;
    
    public LoginCommand(LoginViewModel viewModel, NavigationService<HomeViewModel> navigationService)
    {
        _viewModel = viewModel;
        _navigationService = navigationService;
    }

    public override void Execute(object parameter)
    {
        var user = _viewModel.SelectedUser;
        if (user == null)
        {
            return;
        }

        var remember = _viewModel.RememberMe;
        if (remember)
        {
            SqliteDataAccess.SetActiveUser(user);
        }
        Globals.ActiveUser = user;
        _navigationService.Navigate();
    }
}