using System.Windows.Input;
using Nordek.Commands;
using Nordek.Services;
using Nordek.Stores;

namespace Nordek.ViewModels;

public class RepeatViewModel : ViewModelBase
{
    public ICommand NavigateHomeCommand { get; }
    public ICommand RepeatCommand { get; }
    public RepeatViewModel(NavigationStore navigationStore)
    {
        NavigateHomeCommand = 
            new NavigateCommand<HomeViewModel>(new NavigationService<HomeViewModel>(
                navigationStore, () => new HomeViewModel(navigationStore)));
    }
}