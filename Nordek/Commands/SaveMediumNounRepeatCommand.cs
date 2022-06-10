using Nordek.Models;
using Nordek.Services;
using Nordek.ViewModels;

namespace Nordek.Commands;

public class SaveMediumNounRepeatCommand : CommandBase
{
    private readonly NavigationService<RepeatViewModel> _navigationService;
    private RepeatNounsViewModel _viewmodel;

    public SaveMediumNounRepeatCommand(NavigationService<RepeatViewModel> navigationService,
        RepeatNounsViewModel viewmodel)
    {
        _navigationService = navigationService;
        _viewmodel = viewmodel;
    }
    
    public override void Execute(object parameter)
    {
        SqliteDataAccess.AddNounRepeat(_viewmodel.n, Globals.medium.difficulty);
        if (_viewmodel.Nouns.nouns.Count == 0)
        {
            _navigationService.Navigate();
        }
        
        _viewmodel.ShowPlaceholder();
        _viewmodel.n = _viewmodel.PopRandomNoun();
        _viewmodel.Translation = _viewmodel.n.Translation;
    }
}