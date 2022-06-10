using Nordek.Models;
using Nordek.Services;
using Nordek.ViewModels;

namespace Nordek.Commands;

public class RepeatAllVerbsCommand : CommandBase
{
    private readonly ParameterNavigationService<Verbs, RepeatVerbsViewModel> _navigationService;
    private RepeatViewModel _viewmodel;

    public RepeatAllVerbsCommand(RepeatViewModel viewmodel, ParameterNavigationService<Verbs, RepeatVerbsViewModel> navigationService)
    {
        _navigationService = navigationService;
        _viewmodel = viewmodel;
    }
    
    public override void Execute(object parameter)
    {
        Verbs verbs = new Verbs();
        if (_viewmodel.ObjectsToRepeat.verbsDict[Globals.hard.difficulty].verbs.Count != 0)
        {
            verbs.verbs.AddRange(_viewmodel.ObjectsToRepeat.verbsDict[Globals.hard.difficulty].verbs);
        }
        
        if (_viewmodel.ObjectsToRepeat.verbsDict[Globals.medium.difficulty].verbs.Count != 0)
        {
            verbs.verbs.AddRange(_viewmodel.ObjectsToRepeat.verbsDict[Globals.medium.difficulty].verbs);
        }
        
        if (_viewmodel.ObjectsToRepeat.verbsDict[Globals.easy.difficulty].verbs.Count != 0)
        {
            verbs.verbs.AddRange(_viewmodel.ObjectsToRepeat.verbsDict[Globals.easy.difficulty].verbs);
        }
        
        if (_viewmodel.ObjectsToRepeat.verbsDict[Globals.trivial.difficulty].verbs.Count != 0)
        {
            verbs.verbs.AddRange(_viewmodel.ObjectsToRepeat.verbsDict[Globals.trivial.difficulty].verbs);
        }
        
        if (_viewmodel.ObjectsToRepeat.verbsDict[Globals.New.difficulty].verbs.Count != 0)
        {
            verbs.verbs.AddRange(_viewmodel.ObjectsToRepeat.verbsDict[Globals.New.difficulty].verbs);
        }

        if (verbs.verbs.Count == 0)
        {
            return;
        }
        
        _navigationService.Navigate(verbs);
    }
}