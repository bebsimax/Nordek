using System;
using System.Windows.Input;
using Nordek.Commands;
using Nordek.Models;
using Nordek.Services;
using Nordek.Stores;

namespace Nordek.ViewModels;

public class RepeatVerbsViewModel : ViewModelBase
{
    public Verbs Verbs { get; set; }
    public Verb v { get; set; }
    public string Placeholder { get; set; } = "#########";
    public string Translation { get; set; }
    
    public ICommand NavigateRepeatCommand { get; }
    public ICommand ShowVerbsCommand { get; }
    public ICommand SaveHardVerbRepeatCommand { get; }
    public ICommand SaveMediumVerbRepeatCommand { get; }
    public ICommand SaveEasyVerbRepeatCommand { get; }
    public ICommand SaveTrivialVerbRepeatCommand { get; }
    
    private string infinitiv;
    public string Infinitiv
    {
        get { return infinitiv; }
        set
        {
            infinitiv = value;
            OnPropertyChanged();
        }
    }
    
    private string presens;
    public string Presens
    {
        get { return presens; }
        set
        {
            presens = value;
            OnPropertyChanged();
        }
    }
    
    private string preteritum;
    public string Preteritum
    {
        get { return preteritum; }
        set
        {
            preteritum = value;
            OnPropertyChanged();
        }
    }
    
    private string preteritumPerfektum;
    public string PreteritumPerfektum
    {
        get { return preteritumPerfektum; }
        set
        {
            preteritumPerfektum = value;
            OnPropertyChanged();
        }
    }
    
    public RepeatVerbsViewModel(Verbs verbs, NavigationStore navigationStore)
    {
        Verbs = verbs;
        v = PopRandomVerb();
        Translation = v.Translation;
        ShowPlaceholder();
        
        
        NavigateRepeatCommand = new NavigateCommand<RepeatViewModel>(new NavigationService<RepeatViewModel>(
            navigationStore, () => new RepeatViewModel(navigationStore)));
        SaveHardVerbRepeatCommand = new SaveHardVerbRepeatCommand(
            new NavigationService<RepeatViewModel>(navigationStore,
                () => new RepeatViewModel(navigationStore)), this);
        SaveMediumVerbRepeatCommand = new SaveMediumVerbRepeatCommand(
            new NavigationService<RepeatViewModel>(navigationStore,
                () => new RepeatViewModel(navigationStore)), this);
        SaveEasyVerbRepeatCommand = new SaveEasyVerbRepeatCommand(
            new NavigationService<RepeatViewModel>(navigationStore,
                () => new RepeatViewModel(navigationStore)), this);
        SaveTrivialVerbRepeatCommand = new SaveTrivialVerbRepeatCommand(
            new NavigationService<RepeatViewModel>(navigationStore,
                () => new RepeatViewModel(navigationStore)), this);
        ShowVerbsCommand = new ShowVerbsCommand(this);
    }

    

    public Verb PopRandomVerb()
    {
        int l = Verbs.verbs.Count;
        Random random = new Random();
        int index = random.Next(l);
        Verb n = Verbs.verbs[index];
        Verbs.verbs.RemoveAt(index);
        SetVerbCountLeft();
        return n;
    }

    private void SetVerbCountLeft()
    {
        VerbCountLeft = Verbs.verbs.Count.ToString();
    }

    private string verbCountLeft;
    public string VerbCountLeft
    {
        get { return verbCountLeft; }
        set
        {
            verbCountLeft = value;
            OnPropertyChanged();
        }
    }

    public void ShowPlaceholder()
    {
        Infinitiv = Placeholder;
        Presens = Placeholder;
        Preteritum = Placeholder;
        PreteritumPerfektum = Placeholder;
    }
}