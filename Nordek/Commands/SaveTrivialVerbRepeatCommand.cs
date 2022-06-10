using Nordek.Models;
using Nordek.Services;
using Nordek.ViewModels;

namespace Nordek.Commands;

public class SaveTrivialVerbRepeatCommand : CommandBase
{
    private readonly NavigationService<RepeatViewModel> _navigationService;
    private RepeatVerbsViewModel _viewmodel;

    public SaveTrivialVerbRepeatCommand(NavigationService<RepeatViewModel> navigationService,
        RepeatVerbsViewModel viewmodel)
    {
        _navigationService = navigationService;
        _viewmodel = viewmodel;
    }
    
    public override void Execute(object parameter)
    {
        SqliteDataAccess.AddVerbRepeat(_viewmodel.v, Globals.trivial.difficulty);
        if (_viewmodel.Verbs.verbs.Count == 0)
        {
            _navigationService.Navigate();
        }
        
        _viewmodel.ShowPlaceholder();
        _viewmodel.v = _viewmodel.PopRandomVerb();
        _viewmodel.Translation = _viewmodel.v.Translation;
    }
}