using System.Windows.Navigation;
using Nordek.Models;
using Nordek.Services;
using Nordek.Stores;
using Nordek.ViewModels;

namespace Nordek.Commands;

public class EditUserCommand : CommandBase
{
    private readonly AccountViewModel _viewModel;

    public EditUserCommand(AccountViewModel viewModel)
    {
        _viewModel = viewModel;
    }

    public override void Execute(object parameter)
    {
        var newLogin = _viewModel.NewLogin;
        if (newLogin == null)
        {
            return;
        }

        var user = Globals.ActiveUser;
        user.login = newLogin;

        SqliteDataAccess.UpdateUser(user);
        
    }
}