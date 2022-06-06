using Nordek.Models;
using Nordek.Services;
using Nordek.ViewModels;

namespace Nordek.Commands;

public class LogoutCommand : CommandBase
{
    
    private readonly NavigationService<LoginViewModel> _navigationService;

    public LogoutCommand(NavigationService<LoginViewModel> navigationService)
    {
        _navigationService = navigationService;
    }

    public override void Execute(object parameter)
    {
        Globals.ActiveUser = null;
        SqliteDataAccess.WipeActiveUser();
        _navigationService.Navigate();
    }
}