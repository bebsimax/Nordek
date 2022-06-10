using Nordek.Models;
using Nordek.Services;
using Nordek.ViewModels;

namespace Nordek.Commands;

public class SaveTrivialNounRepeatCommand : CommandBase
{
    private readonly NavigationService<RepeatViewModel> _navigationService;
    private RepeatNounsViewModel _viewmodel;

    public SaveTrivialNounRepeatCommand(NavigationService<RepeatViewModel> navigationService,
        RepeatNounsViewModel viewmodel)
    {
        _navigationService = navigationService;
        _viewmodel = viewmodel;
    }
    
    public override void Execute(object parameter)
    {
        SqliteDataAccess.AddNounRepeat(_viewmodel.n, Globals.trivial.difficulty);
        if (_viewmodel.Nouns.nouns.Count == 0)
        {
            _navigationService.Navigate();
        }
        
        _viewmodel.ShowPlaceholder();
        _viewmodel.n = _viewmodel.PopRandomNoun();
        _viewmodel.Translation = _viewmodel.n.Translation;
    }
}