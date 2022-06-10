using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Nordek.Models;

namespace Nordek.Views;

public partial class ManageVerbsView : UserControl
{
    public ManageVerbsView()
    {
        InitializeComponent();
    }
    private void VerbsDataGrid_OnAddingNewItem(object? sender, AddingNewItemEventArgs e)
    {
        int id = SqliteDataAccess.GetNextVerbID();
        e.NewItem = new Verb(id);
    }

    private void VerbsDataGrid_OnPreviewKeyDown(object sender, KeyEventArgs e)
    {
        var grid = (DataGrid) sender;
        if (Key.Delete == e.Key)
        {
            foreach (var row in grid.SelectedItems)
            {
                var v = (Verb) row;
                Globals.VerbsIDsToDelete.Add(v.ID);
            }
        }
    }

    private void ButtonAddTranslation_OnClick(object sender, RoutedEventArgs e)
    {
        var translation = this.tbTranslation.Text;
        if (translation == "")
        {
            this.tbMsg.Text = "Please enter translation";
            return;
        }

        int id;
        var verbID = this.tbVerbid.Text;
        try
        {
            id = Int32.Parse(verbID);
        }
        catch (FormatException)
        {
            this.tbMsg.Text = "ID must be an integer";
            return;
        }

        if (cbLanguage.SelectedItem is null)
        {
            this.tbMsg.Text = "Please select language";
            return;
        }
        var lang = (Language)this.cbLanguage.SelectionBoxItem;

        var n = SqliteDataAccess.GetVerbById(id);
        if (n.Count==0)
        {
            this.tbMsg.Text = @"Verb with this ID does not exist";
            return;
        }

        var t = SqliteDataAccess.CheckTranslation(lang.ID, translation);
        if (t is null)
        {
            SqliteDataAccess.CreateTranslation(lang.ID, translation);
        }

        var result = SqliteDataAccess.AddVerbTranslation(lang.ID, translation, id);
        if (result == 1)
        {
            this.tbMsg.Text = @"Translation added!";
        }
        else
        {
            this.tbMsg.Text = @"This Verb already has that translation!!";
        }
    }
}