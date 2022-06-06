using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using Nordek.Models;

namespace Nordek.Views;

public partial class SearchView : UserControl
{
    public SearchView()
    {
        InitializeComponent();
        ICollectionView cvNouns = CollectionViewSource.GetDefaultView(nounSearchGrid);
        Nouns nouns = (Nouns) this.Resources["nouns"];
        foreach (var n in SqliteDataAccess.LoadNouns())
        {
            nouns.Add(n);
        }
    }
    

    private void CbActiveFilter_OnChecked(object sender, RoutedEventArgs e)
    {
        CollectionViewSource.GetDefaultView(nounSearchGrid.ItemsSource).Refresh();
    }

    private void CbActiveFilter_OnUnchecked(object sender, RoutedEventArgs e)
    {
        
    }
    
    

    private void Selector_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        CollectionViewSource.GetDefaultView(nounSearchGrid.ItemsSource).Refresh();
    }

    private void TbSearch_OnKeyDown(object sender, KeyEventArgs e)
    {
        if (e.Key == Key.Return)
        {
            CollectionViewSource.GetDefaultView(nounSearchGrid.ItemsSource).Refresh();
        }
    }

    private void TbSearch_OnTextChanged(object sender, TextChangedEventArgs e)
    {
        CollectionViewSource.GetDefaultView(nounSearchGrid.ItemsSource).Refresh();
    }
    
    private void CollectionViewSource_Filter(object sender, FilterEventArgs e)
    {
        if (e.Item is Noun n)
        {
            e.Accepted = false;
            string? active, regular, phrase;
            bool activeResult = false, regularResult = false, phraseResult = false;
            if (cbActive.SelectedItem is not null)
            {
                ComboBoxItem cbi = (ComboBoxItem) cbActive.SelectedItem;
                active = cbi.Content.ToString();
                if (active == "All")
                {
                    active = null;
                }

                if (active is null)
                {
                    activeResult = true;
                } else
                {
                    activeResult = false;
                    if (active == "Active" && n.Active)
                    {
                        activeResult = true;
                    }

                    if (active == "Non Active" && !n.Active)
                    {
                        activeResult = true;
                    }
                }
            }

            if (cbRegular.SelectedItem is not null)
            {
                ComboBoxItem cbi = (ComboBoxItem) cbRegular.SelectedItem;
                regular = cbi.Content.ToString();
                if (regular == "All")
                {
                    regular = null;
                }

                if (regular is null)
                {
                    regularResult = true;
                }
                else
                {
                    regularResult = false;
                    if (regular == "Regular" && n.Regular)
                    {
                        regularResult = true;
                    }

                    if (regular == "Irregular" && !n.Regular)
                    {
                        regularResult = true;
                    }
                }
            }

            phrase = tbSearch.Text;
            if (phrase == "")
            {
                phraseResult = true;
            }
            else
            {
                phraseResult = PhraseInNoun(phrase, n);
            }

            e.Accepted = phraseResult && activeResult && regularResult;
        }
    }

    private bool PhraseInNoun(string phase, Noun n)
    {
        return n.EntallU.Contains(phase);
    }
    
}