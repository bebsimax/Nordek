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

    private int allNounsCount;

    public int AllNounsCount
    {
        get { return allNounsCount; }
        set
        {
            allNounsCount = value;
            OnPropertyChanged();
        }
    }
    
    private int activeNounsCount;

    public int ActiveNounsCount
    {
        get { return activeNounsCount; }
        set
        {
            activeNounsCount = value;
            OnPropertyChanged();
        }
    }
    
    private int learnedNounsCount;
    public int LearnedNounsCount
    {
        get { return learnedNounsCount; }
        set
        {
            learnedNounsCount = value;
            OnPropertyChanged();
        }
    }
    
    private string nounsProgressPercentage;
    public string NounsProgressPercentage
    {
        get { return nounsProgressPercentage; }
        set
        {
            nounsProgressPercentage = value;
            OnPropertyChanged();
        }
    }
    
    private int nounsRepeatsCount;
    public int NounsRepeatsCount
    {
        get { return nounsRepeatsCount; }
        set
        {
            nounsRepeatsCount = value;
            OnPropertyChanged();
        }
    }
    
    private int allVerbsCount;
    public int AllVerbsCount
    {
        get { return allVerbsCount; }
        set
        {
            allVerbsCount = value;
            OnPropertyChanged();
        }
    }
    
    private int activeVerbsCount;
    public int ActiveVerbsCount
    {
        get { return activeVerbsCount; }
        set
        {
            activeVerbsCount = value;
            OnPropertyChanged();
        }
    }
    
    private int learnedVerbsCount;
    public int LearnedVerbsCount
    {
        get { return learnedVerbsCount; }
        set
        {
            learnedVerbsCount = value;
            OnPropertyChanged();
        }
    }
    
    private string verbsProgressPercentage;
    public string VerbsProgressPercentage
    {
        get { return verbsProgressPercentage; }
        set
        {
            verbsProgressPercentage = value;
            OnPropertyChanged();
        }
    }
    
    
    private int verbsRepeatsCount;
    public int VerbsRepeatsCount
    {
        get { return verbsRepeatsCount; }
        set
        {
            verbsRepeatsCount = value;
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
        
        AllNounsCount = SqliteDataAccess.GetNounsCount();
        ActiveNounsCount = SqliteDataAccess.GetActiveNounsCount();
        LearnedNounsCount = SqliteDataAccess.GetLearnedNounsCount();
        NounsProgressPercentage = ((LearnedNounsCount* 100) / AllNounsCount).ToString() + "%";
        NounsRepeatsCount = SqliteDataAccess.GetNounsRepeatCount();

        AllVerbsCount = SqliteDataAccess.GetVerbsCount();
        ActiveVerbsCount = SqliteDataAccess.GetActiveVerbsCount();
        LearnedVerbsCount = SqliteDataAccess.GetLearnedVerbsCount();
        VerbsProgressPercentage = ((LearnedVerbsCount * 100) / AllVerbsCount ).ToString() + "%";
        VerbsRepeatsCount = SqliteDataAccess.GetVerbsRepeatCount();
    }
    
    
}