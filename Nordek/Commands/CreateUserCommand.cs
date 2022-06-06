using Nordek.Models;
using Nordek.ViewModels;

namespace Nordek.Commands;

public class CreateUserCommand : CommandBase
{
    private readonly CreateUserViewModel _viewModel;
    
    public CreateUserCommand(CreateUserViewModel viewModel)
    {
        _viewModel = viewModel;
    }
    
    public override void Execute(object parameter)
    {
        var login = _viewModel.LoginInput;
        if (login.Equals(""))
        {
            return;
        }
        User u = new User(login);
        var result = SqliteDataAccess.CreateUser(u);
        if (result == null)
        {
            _viewModel.QueryResult = "Created User " + u.login;
        }
        else
        {
            _viewModel.QueryResult = "Error:" + result;
        }
    }
}