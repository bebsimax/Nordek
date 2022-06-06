using System.Collections.Generic;
using System.Windows.Input;
using Nordek.Commands;
using Nordek.Models;
using Nordek.Services;
using Nordek.Stores;

namespace Nordek.ViewModels;

public class SearchViewModel : ViewModelBase
{
    public ICommand NavigateHomeCommand { get; }
    public ObjectInDB[] ObjectTypes { get; set; }

    public List<Noun> nouns { get; set; }

    public SearchViewModel(NavigationStore navigationStore)
    {
        NavigateHomeCommand = 
            new NavigateCommand<HomeViewModel>(new NavigationService<HomeViewModel>(
                navigationStore, () => new HomeViewModel(navigationStore)));

        ObjectTypes = Globals.TypesPresentInDB;
    }
}