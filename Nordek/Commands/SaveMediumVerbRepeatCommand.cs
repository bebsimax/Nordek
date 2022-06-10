using Nordek.Models;
using Nordek.Services;
using Nordek.ViewModels;

namespace Nordek.Commands;

public class SaveMediumVerbRepeatCommand : CommandBase
{
    private readonly NavigationService<RepeatViewModel> _navigationService;
    private RepeatVerbsViewModel _viewmodel;

    public SaveMediumVerbRepeatCommand(NavigationService<RepeatViewModel> navigationService,
        RepeatVerbsViewModel viewmodel)
    {
        _navigationService = navigationService;
        _viewmodel = viewmodel;
    }
    
    public override void Execute(object parameter)
    {
        SqliteDataAccess.AddVerbRepeat(_viewmodel.v, Globals.medium.difficulty);
        if (_viewmodel.Verbs.verbs.Count == 0)
        {
            _navigationService.Navigate();
        }
        
        _viewmodel.ShowPlaceholder();
        _viewmodel.v = _viewmodel.PopRandomVerb();
        _viewmodel.Translation = _viewmodel.v.Translation;
    }
}