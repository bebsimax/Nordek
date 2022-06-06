using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Input;
using Nordek.Commands;
using Nordek.Models;
using Nordek.Services;
using Nordek.Stores;

namespace Nordek.ViewModels;

public class ManageNounsViewModel : ViewModelBase
{
    public ICommand NavigateManagementCommand { get; }
    public ICommand NavigateHomeCommand { get; }
    public List<Noun> Nouns { get; set; }
    public ICommand SaveNounsChangesToDb { get;}
    
    public ManageNounsViewModel(NavigationStore navigationStore)
    {
        NavigateManagementCommand = new NavigateCommand<ManagementViewModel>(new NavigationService<ManagementViewModel>(
            navigationStore, () => new ManagementViewModel(navigationStore)));
        NavigateHomeCommand = 
            new NavigateCommand<HomeViewModel>(new NavigationService<HomeViewModel>(
                navigationStore, () => new HomeViewModel(navigationStore)));
        Nouns = SqliteDataAccess.LoadNouns();

        SaveNounsChangesToDb = new SaveNounsChangesToDb(this);

    }

    public void UpdateView()
    {
        Nouns = SqliteDataAccess.LoadNouns();
    }
    
}