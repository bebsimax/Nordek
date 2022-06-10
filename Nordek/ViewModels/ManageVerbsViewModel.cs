using System.Collections.Generic;
using System.Windows.Input;
using Nordek.Commands;
using Nordek.Models;
using Nordek.Services;
using Nordek.Stores;

namespace Nordek.ViewModels;

public class ManageVerbsViewModel : ViewModelBase
{
    public ICommand NavigateManagementCommand { get; }
    public ICommand NavigateHomeCommand { get; }
    public List<Verb> Verbs { get; set; }
    public ICommand SaveVerbsChangesToDbCommand { get;}
    public List<Language> Languages { get; }
    
    public ManageVerbsViewModel(NavigationStore navigationStore)
    {
        NavigateManagementCommand = new NavigateCommand<ManagementViewModel>(new NavigationService<ManagementViewModel>(
            navigationStore, () => new ManagementViewModel(navigationStore)));
        NavigateHomeCommand = 
            new NavigateCommand<HomeViewModel>(new NavigationService<HomeViewModel>(
                navigationStore, () => new HomeViewModel(navigationStore)));
        Verbs = SqliteDataAccess.LoadVerbs();

        SaveVerbsChangesToDbCommand = new SaveVerbsChangesToDbCommand(this);
        Languages = SqliteDataAccess.GetLanguages();
    }
}