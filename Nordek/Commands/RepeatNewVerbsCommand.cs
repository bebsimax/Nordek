using Nordek.Models;
using Nordek.Services;
using Nordek.ViewModels;

namespace Nordek.Commands;

public class RepeatNewVerbsCommand : CommandBase
{
    private readonly ParameterNavigationService<Verbs, RepeatVerbsViewModel> _navigationService;
    private RepeatViewModel _viewmodel;

    public RepeatNewVerbsCommand(RepeatViewModel viewmodel, ParameterNavigationService<Verbs, RepeatVerbsViewModel> navigationService)
    {
        _navigationService = navigationService;
        _viewmodel = viewmodel;
    }
    
    public override void Execute(object parameter)
    {
        if (_viewmodel.ObjectsToRepeat.verbsDict[Globals.New.difficulty].verbs.Count == 0)
        {
            return;
        }
        
        _navigationService.Navigate(_viewmodel.ObjectsToRepeat.verbsDict[Globals.New.difficulty]);
    }
}