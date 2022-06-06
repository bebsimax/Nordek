using System.Collections.Generic;
using Nordek.Models;
using Nordek.ViewModels;

namespace Nordek.Commands;

public class SaveNounsChangesToDb : CommandBase
{
    private readonly ManageNounsViewModel _viewModel;

    public SaveNounsChangesToDb(ManageNounsViewModel viewmodel)
    {
        _viewModel = viewmodel;
    }
    
    public override void Execute(object parameter)
    {
        foreach (var noun in _viewModel.Nouns)
        {
            if (noun.New)
            {
                var res = SqliteDataAccess.CreateNoun(noun);
                noun.New = false;
            }
            
            if (noun.edited)
            {
                var res = SqliteDataAccess.UpdateNoun(noun);
                noun.edited = false;
            }
        }

        foreach (var id in Globals.NounsIDsToDelete)
        {
            var res = SqliteDataAccess.DeleteNoun(id);
        }

        Globals.NounsIDsToDelete = new List<long>();

        _viewModel.UpdateView();
    }
}