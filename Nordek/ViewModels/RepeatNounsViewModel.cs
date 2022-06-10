using System;
using System.Windows.Input;
using Nordek.Commands;
using Nordek.Models;
using Nordek.Services;
using Nordek.Stores;

namespace Nordek.ViewModels;

public class RepeatNounsViewModel : ViewModelBase
{
    private string artikkel;
    public string Artikkel
    {
        get { return artikkel; }
        set
        {
            artikkel = value;
            OnPropertyChanged();
        }
    }
    
    private string entallU;
    public string EntallU
    {
        get { return entallU; }
        set
        {
            entallU = value;
            OnPropertyChanged();
        }
    }
    
    private string entallB;
    public string EntallB
    {
        get { return entallB; }
        set
        {
            entallB = value;
            OnPropertyChanged();
        }
    }
    
    private string flertallU;
    public string FlertallU
    {
        get { return flertallU; }
        set
        {
            flertallU = value;
            OnPropertyChanged();
        }
    }
    
    private string flertallB;
    public string FlertallB
    {
        get { return flertallB; }
        set
        {
            flertallB = value;
            OnPropertyChanged();
        }
    }
    private string translation;
    public string Translation
    {
        get { return translation; }
        set
        {
            translation = value;
            OnPropertyChanged();
        }
    }

    private string nounCountLeft;
    public string NounCountLeft
    {
        get { return nounCountLeft; }
        set
        {
            nounCountLeft = value;
            OnPropertyChanged();
        }
    }
    
    public Nouns Nouns { get; set; }
    public Noun n { get; set; }
    public string Placeholder { get; set; } = "#########";
    
    public ICommand NavigateRepeatCommand { get; }
    public ICommand ShowNounsCommand { get; }
    public ICommand SaveHardNounRepeatCommand { get; }
    public ICommand SaveMediumNounRepeatCommand { get; }
    public ICommand SaveEasyNounRepeatCommand { get; }
    public ICommand SaveTrivialNounRepeatCommand { get; }

    public RepeatNounsViewModel(Nouns nouns, NavigationStore navigationStore)
    {
        Nouns = nouns;
        n = PopRandomNoun();
        Translation = n.Translation;
        ShowPlaceholder();
        
        
        NavigateRepeatCommand = new NavigateCommand<RepeatViewModel>(new NavigationService<RepeatViewModel>(
            navigationStore, () => new RepeatViewModel(navigationStore)));
        SaveHardNounRepeatCommand = new SaveHardNounRepeatCommand(
            new NavigationService<RepeatViewModel>(navigationStore,
                () => new RepeatViewModel(navigationStore)), this);
        SaveMediumNounRepeatCommand = new SaveMediumNounRepeatCommand(
            new NavigationService<RepeatViewModel>(navigationStore,
                () => new RepeatViewModel(navigationStore)), this);
        SaveEasyNounRepeatCommand = new SaveEasyNounRepeatCommand(
            new NavigationService<RepeatViewModel>(navigationStore,
                () => new RepeatViewModel(navigationStore)), this);
        SaveTrivialNounRepeatCommand = new SaveTrivialNounRepeatCommand(
            new NavigationService<RepeatViewModel>(navigationStore,
                () => new RepeatViewModel(navigationStore)), this);
        ShowNounsCommand = new ShowNounsCommand(this);
    }

    public Noun PopRandomNoun()
    {
        int l = Nouns.nouns.Count;
        Random random = new Random();
        int index = random.Next(l);
        Noun n = Nouns.nouns[index];
        Nouns.nouns.RemoveAt(index);
        SetNounCountLeft();
        return n;
    }

    private void SetNounCountLeft()
    {
        NounCountLeft = Nouns.nouns.Count.ToString();
    }

    public void ShowPlaceholder()
    {
        Artikkel = Placeholder;
        EntallU = Placeholder;
        EntallB = Placeholder;
        FlertallU = Placeholder;
        FlertallB = Placeholder;
    }
}