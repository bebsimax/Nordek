using Nordek.Models;
using Nordek.Services;
using Nordek.ViewModels;

namespace Nordek.Commands;

public class RepeatMediumNounsCommand : CommandBase
{
    private readonly ParameterNavigationService<Nouns, RepeatNounsViewModel> _navigationService;
    private RepeatViewModel _viewmodel;

    public RepeatMediumNounsCommand(RepeatViewModel viewmodel, ParameterNavigationService<Nouns, RepeatNounsViewModel> navigationService)
    {
        _navigationService = navigationService;
        _viewmodel = viewmodel;
    }
    
    public override void Execute(object parameter)
    {
        if (_viewmodel.ObjectsToRepeat.nounsDict[Globals.medium.difficulty].nouns.Count == 0)
        {
            return;
        }
        
        
        _navigationService.Navigate(_viewmodel.ObjectsToRepeat.nounsDict[Globals.medium.difficulty]);
    }
}