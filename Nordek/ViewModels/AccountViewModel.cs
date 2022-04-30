using System.Windows.Input;
using Nordek.Commands;
using Nordek.Stores;

namespace Nordek.ViewModels;

public class AccountViewModel : ViewModelBase
{
    public string Name => "SingletonSean";

    public ICommand NavigateHomeCommand { get; }

    public AccountViewModel(NavigationStore navigationStore)
    {
        NavigateHomeCommand = new NavigateCommand<HomeViewModel>(navigationStore, () => new HomeViewModel(navigationStore));
    }
}