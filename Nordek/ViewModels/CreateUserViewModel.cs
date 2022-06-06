using System.Windows.Input;
using Nordek.Commands;
using Nordek.Services;
using Nordek.Stores;

namespace Nordek.ViewModels;

public class CreateUserViewModel : ViewModelBase
{
    private NavigationStore _navigationStore;
    private string loginInput;
    private string queryResult;

    public string LoginInput
    {
        get { return loginInput; }
        set
        {
            loginInput = value;
            OnPropertyChanged();
        }
    }
    
    public string QueryResult
    {
        get { return queryResult; }
        set
        {
            queryResult = value;
            OnPropertyChanged();
        }
    }

    public ICommand NavigateLoginCommand { get; }
    public ICommand CreateUserCommand { get; }

    public CreateUserViewModel(NavigationStore navigationStore)
    {
        _navigationStore = navigationStore;
        NavigateLoginCommand = 
            new NavigateCommand<LoginViewModel>(new NavigationService<LoginViewModel>(
                navigationStore, () => new LoginViewModel(navigationStore)));
        CreateUserCommand = new CreateUserCommand(this);
    }
    
    
}