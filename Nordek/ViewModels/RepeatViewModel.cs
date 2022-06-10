using System.Windows.Input;
using Nordek.Commands;
using Nordek.Models;
using Nordek.Services;
using Nordek.Stores;

namespace Nordek.ViewModels;

public class RepeatViewModel : ViewModelBase
{
    public ICommand NavigateHomeCommand { get; }
    public ICommand RepeatHardNounsCommand { get; }
    public ICommand RepeatMediumNounsCommand { get; }
    public ICommand RepeatEasyNounsCommand { get; }
    public ICommand RepeatTrivialNounsCommand { get; }
    public ICommand RepeatAllNounsCommand { get; }
    public ICommand RepeatNewNounsCommand { get; }
    public ICommand RepeatHardVerbsCommand { get; }
    public ICommand RepeatMediumVerbsCommand { get; }
    public ICommand RepeatEasyVerbsCommand { get; }
    public ICommand RepeatTrivialVerbsCommand { get; }
    public ICommand RepeatAllVerbsCommand { get; }
    public ICommand RepeatNewVerbsCommand { get; }
    public ObjectsToRepeat ObjectsToRepeat { get; set; }
    
    private int hardNounToRepeatCount;
    public int HardNounToRepeatCount {
        get { return hardNounToRepeatCount; }
        set
        {
            hardNounToRepeatCount = value;
            OnPropertyChanged();
        }
    }
    
    private int mediumNounToRepeatCount;
    public int MediumNounToRepeatCount {
        get { return mediumNounToRepeatCount; }
        set
        {
            mediumNounToRepeatCount = value;
            OnPropertyChanged();
        }
    }
    
    private int easyNounToRepeatCount;
    public int EasyNounToRepeatCount {
        get { return easyNounToRepeatCount; }
        set
        {
            easyNounToRepeatCount = value;
            OnPropertyChanged();
        }
    }
    
    private int trivialNounToRepeatCount;
    public int TrivialNounToRepeatCount {
        get { return trivialNounToRepeatCount; }
        set
        {
            trivialNounToRepeatCount = value;
            OnPropertyChanged();
        }
    }

    private int newNounToRepeatCount;
    public int NewNounToRepeatCount {
        get { return newNounToRepeatCount; }
        set
        {
            newNounToRepeatCount = value;
            OnPropertyChanged();
        }
    }
    
    private int hardVerbToRepeatCount;
    public int HardVerbToRepeatCount {
        get { return hardVerbToRepeatCount; }
        set
        {
            hardVerbToRepeatCount = value;
            OnPropertyChanged();
        }
    }
    
    private int mediumVerbToRepeatCount;
    public int MediumVerbToRepeatCount {
        get { return mediumVerbToRepeatCount; }
        set
        {
            mediumVerbToRepeatCount = value;
            OnPropertyChanged();
        }
    }
    
    private int easyVerbToRepeatCount;
    public int EasyVerbToRepeatCount {
        get { return easyVerbToRepeatCount; }
        set
        {
            easyVerbToRepeatCount = value;
            OnPropertyChanged();
        }
    }
    
    private int trivialVerbToRepeatCount;
    public int TrivialVerbToRepeatCount {
        get { return trivialVerbToRepeatCount; }
        set
        {
            trivialVerbToRepeatCount = value;
            OnPropertyChanged();
        }
    }

    private int newVerbToRepeatCount;
    public int NewVerbToRepeatCount {
        get { return newVerbToRepeatCount; }
        set
        {
            newVerbToRepeatCount = value;
            OnPropertyChanged();
        }
    }
    
    
    
    public RepeatViewModel(NavigationStore navigationStore)
    {
        ParameterNavigationService<Nouns, RepeatNounsViewModel> navigationNounsService =
            new ParameterNavigationService<Nouns, RepeatNounsViewModel>(navigationStore,
                (parameter) => new RepeatNounsViewModel(parameter, navigationStore));
        ObjectsToRepeat = new ObjectsToRepeat();
        setCountsToRepeat();
        NavigateHomeCommand = 
            new NavigateCommand<HomeViewModel>(new NavigationService<HomeViewModel>(
                navigationStore, () => new HomeViewModel(navigationStore)));
        RepeatHardNounsCommand =
            new RepeatHardNounsCommand(this, navigationNounsService);
        RepeatMediumNounsCommand = new RepeatMediumNounsCommand(this, navigationNounsService);
        RepeatEasyNounsCommand =  new RepeatEasyNounsCommand(this, navigationNounsService);
        RepeatTrivialNounsCommand =  new RepeatTrivialNounsCommand(this, navigationNounsService);
        RepeatAllNounsCommand = new RepeatAllNounsCommand(this, navigationNounsService);
        RepeatNewNounsCommand = new RepeatNewNounsCommand(this, navigationNounsService);
        
        ParameterNavigationService<Verbs, RepeatVerbsViewModel> navigationVerbsService =
            new ParameterNavigationService<Verbs, RepeatVerbsViewModel>(navigationStore,
                (parameter) => new RepeatVerbsViewModel(parameter, navigationStore));
        RepeatHardVerbsCommand =
            new RepeatHardVerbsCommand(this, navigationVerbsService);
        RepeatMediumVerbsCommand = new RepeatMediumVerbsCommand(this, navigationVerbsService);
        RepeatEasyVerbsCommand =  new RepeatEasyVerbsCommand(this, navigationVerbsService);
        RepeatTrivialVerbsCommand =  new RepeatTrivialVerbsCommand(this, navigationVerbsService);
        RepeatAllVerbsCommand = new RepeatAllVerbsCommand(this, navigationVerbsService);
        RepeatNewVerbsCommand = new RepeatNewVerbsCommand(this, navigationVerbsService);
    }

    private void setCountsToRepeat()
    {
        hardNounToRepeatCount = ObjectsToRepeat.nounsDict[Globals.hard.difficulty].nouns.Count;
        mediumNounToRepeatCount = ObjectsToRepeat.nounsDict[Globals.medium.difficulty].nouns.Count;
        easyNounToRepeatCount = ObjectsToRepeat.nounsDict[Globals.easy.difficulty].nouns.Count;
        trivialNounToRepeatCount = ObjectsToRepeat.nounsDict[Globals.trivial.difficulty].nouns.Count;
        newNounToRepeatCount =  ObjectsToRepeat.nounsDict[Globals.New.difficulty].nouns.Count;
        
        hardVerbToRepeatCount = ObjectsToRepeat.verbsDict[Globals.hard.difficulty].verbs.Count;
        mediumVerbToRepeatCount = ObjectsToRepeat.verbsDict[Globals.medium.difficulty].verbs.Count;
        easyVerbToRepeatCount = ObjectsToRepeat.verbsDict[Globals.easy.difficulty].verbs.Count;
        trivialVerbToRepeatCount = ObjectsToRepeat.verbsDict[Globals.trivial.difficulty].verbs.Count;
        newVerbToRepeatCount = ObjectsToRepeat.verbsDict[Globals.New.difficulty].verbs.Count;
    }
}