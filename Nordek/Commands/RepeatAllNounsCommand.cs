using System.Linq;
using Nordek.Models;
using Nordek.Services;
using Nordek.ViewModels;

namespace Nordek.Commands;

public class RepeatAllNounsCommand : CommandBase
{
    private readonly ParameterNavigationService<Nouns, RepeatNounsViewModel> _navigationService;
    private RepeatViewModel _viewmodel;

    public RepeatAllNounsCommand(RepeatViewModel viewmodel, ParameterNavigationService<Nouns, RepeatNounsViewModel> navigationService)
    {
        _navigationService = navigationService;
        _viewmodel = viewmodel;
    }
    
    public override void Execute(object parameter)
    {
        Nouns nouns = new Nouns();
        if (_viewmodel.ObjectsToRepeat.nounsDict[Globals.hard.difficulty].nouns.Count != 0)
        {
            nouns.nouns.AddRange(_viewmodel.ObjectsToRepeat.nounsDict[Globals.hard.difficulty].nouns);
        }
        
        if (_viewmodel.ObjectsToRepeat.nounsDict[Globals.medium.difficulty].nouns.Count != 0)
        {
            nouns.nouns.AddRange(_viewmodel.ObjectsToRepeat.nounsDict[Globals.medium.difficulty].nouns);
        }
        
        if (_viewmodel.ObjectsToRepeat.nounsDict[Globals.easy.difficulty].nouns.Count != 0)
        {
            nouns.nouns.AddRange(_viewmodel.ObjectsToRepeat.nounsDict[Globals.easy.difficulty].nouns);
        }
        
        if (_viewmodel.ObjectsToRepeat.nounsDict[Globals.trivial.difficulty].nouns.Count != 0)
        {
            nouns.nouns.AddRange(_viewmodel.ObjectsToRepeat.nounsDict[Globals.trivial.difficulty].nouns);
        }
        
        if (_viewmodel.ObjectsToRepeat.nounsDict[Globals.New.difficulty].nouns.Count != 0)
        {
            nouns.nouns.AddRange(_viewmodel.ObjectsToRepeat.nounsDict[Globals.New.difficulty].nouns);
        }

        if (nouns.nouns.Count == 0)
        {
            return;
        }
        
        _navigationService.Navigate(nouns);
    }
}