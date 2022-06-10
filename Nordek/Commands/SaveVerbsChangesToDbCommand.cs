using System.Collections.Generic;
using Nordek.Models;
using Nordek.ViewModels;

namespace Nordek.Commands;

public class SaveVerbsChangesToDbCommand : CommandBase
{
    private readonly ManageVerbsViewModel _viewModel;

    public SaveVerbsChangesToDbCommand(ManageVerbsViewModel viewmodel)
    {
        _viewModel = viewmodel;
    }
    
    public override void Execute(object parameter)
    {
        foreach (var verb in _viewModel.Verbs)
        {
            if (verb.New)
            {
                var res = SqliteDataAccess.CreateVerb(verb);
                verb.New = false;
                continue;
            }
            
            if (verb.edited)
            {
                var res = SqliteDataAccess.UpdateVerb(verb);
                verb.edited = false;
            }
        }

        foreach (var id in Globals.VerbsIDsToDelete)
        {
            var res = SqliteDataAccess.DeleteVerb(id);
        }

        Globals.VerbsIDsToDelete = new List<long>();
    }
}