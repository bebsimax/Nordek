using System.Windows.Input;
using Nordek.Commands;
using Nordek.Models;
using Nordek.Services;
using Nordek.Stores;

namespace Nordek.ViewModels;

public class AccountViewModel : ViewModelBase
{
    private string welcomeMsg;
    public string WelcomeMsg
    {
        get { return welcomeMsg; }
        set
        {
            welcomeMsg = "Hello " + value + "!";
            OnPropertyChanged();
        }
    }
    
    private string currentUserLogin;

    public string CurrentUserLogin
    {
        get { return currentUserLogin; }
        set
        {
            currentUserLogin = value;
            WelcomeMsg = currentUserLogin;
            OnPropertyChanged();
        }
    }

    
    public string NewLogin { get; set; }
    public ICommand NavigateHomeCommand { get; }
    public ICommand EditUserCommand { get; }
    public ICommand DeleteUserCommand { get; }
    
    public AccountViewModel(NavigationStore navigationStore)
    {
        CurrentUserLogin = Globals.ActiveUser.login;
        NavigateHomeCommand = 
            new NavigateCommand<HomeViewModel>(new NavigationService<HomeViewModel>(
                navigationStore, () => new HomeViewModel(navigationStore)));
        EditUserCommand = new EditUserCommand(this);
    }
    
    
}