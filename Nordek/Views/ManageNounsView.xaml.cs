using System.Windows.Controls;
using System.Windows.Input;
using Nordek.Models;

namespace Nordek.Views;

public partial class ManageNounsView : UserControl
{
    public ManageNounsView()
    {
        InitializeComponent();
    }

    private void NounsDataGrid_OnAddingNewItem(object? sender, AddingNewItemEventArgs e)
    {
        int id = SqliteDataAccess.GetNextNounID();
        e.NewItem = new Noun(id);
    }

    private void NounsDataGrid_OnPreviewKeyDown(object sender, KeyEventArgs e)
    {
        var grid = (DataGrid) sender;
        if (Key.Delete == e.Key)
        {
            foreach (var row in grid.SelectedItems)
            {
                var n = (Noun) row;
                Globals.NounsIDsToDelete.Add(n.ID);
            }
        }
    }
}