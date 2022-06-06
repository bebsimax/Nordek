using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Input;
using Nordek.Commands;
using Nordek.Models;
using Nordek.Services;
using Nordek.Stores;

namespace Nordek.ViewModels;

public class LoginViewModel : ViewModelBase
{
    private NavigationStore _navigationStore;
    public ICommand NavigateCreateUserCommand { get; }
    public ICommand LoginCommand { get;}
    public bool RememberMe { get; set; }
    public List<User> Users { get; set; }
    private User _selectedUser;

    public User SelectedUser
    {
        get { return _selectedUser; }
        set
        {
            _selectedUser = value;
            OnPropertyChanged();
        }
    }
    public LoginViewModel(NavigationStore navigationStore)
    {
        _navigationStore = navigationStore;
        NavigateCreateUserCommand = 
            new NavigateCommand<CreateUserViewModel>(new NavigationService<CreateUserViewModel>(
                navigationStore, () => new CreateUserViewModel(navigationStore)));

        this.LoginCommand =
            new LoginCommand(this, new NavigationService<HomeViewModel>(
                navigationStore, () => new HomeViewModel(navigationStore)));

        Users = SqliteDataAccess.LoadUsers();
    }
}