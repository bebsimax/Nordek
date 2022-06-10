using System;
using System.ComponentModel;

namespace Nordek.Models;

public class Verb : IEditableObject, INotifyPropertyChanged
{
    struct VerbData
    {
        internal Int64 ID;
        internal string Infinitiv;
        internal string Presens;
        internal string Preteritum;
        internal string PreteritumPerfektum;
        internal string Translation;
        internal bool Active;
        internal bool Regular;

        public VerbData(Int64 ID, string Infinitiv, string Presens, string Preteritum, string PreteritumPerfektum,
            bool Active, bool Regular)
        {
            this.ID = ID;
            this.Infinitiv = Infinitiv;
            this.Presens = Presens;
            this.Preteritum = Preteritum;
            this.PreteritumPerfektum = PreteritumPerfektum;
            this.Translation = new string("");
            this.Active = Active;
            this.Regular = Regular;
        }

        public VerbData(Int64 ID, string Infinitiv, string Presens, string Preteritum, string PreteritumPerfektum,
            string Translation, bool Active, bool Regular)
        {
            this.ID = ID;
            this.Infinitiv = Infinitiv;
            this.Presens = Presens;
            this.Preteritum = Preteritum;
            this.PreteritumPerfektum = PreteritumPerfektum;
            this.Translation = Translation;
            this.Active = Active;
            this.Regular = Regular;
        }
    }
    private VerbData backupData;
    private VerbData verbData;
    private bool inTxn = false;
    public bool New { get; set; } = false;
    public bool edited { get; set; } = false;

    public Verb(Int64 ID, string Infinitiv, string Presens, string Preteritum, string PreteritumPerfektum, bool Active,
        bool Regular)
    {
        verbData = new VerbData(ID, Infinitiv, Presens, Preteritum, PreteritumPerfektum, Active, Regular);
        New = false;
    }
    
    
    public Verb(Int64 ID, string Infinitiv, string Presens, string Preteritum, string PreteritumPerfektum, string Translation, bool Active,
        bool Regular)
    {
        verbData = new VerbData(ID, Infinitiv, Presens, Preteritum, PreteritumPerfektum, Translation, Active, Regular);
        New = false;
    }

    public Verb()
    {
        verbData = new VerbData();
    }
    
    public void BeginEdit()
    {
        if (!inTxn)
        {
            backupData = verbData;
            inTxn = true;
        }
    }

    public void CancelEdit()
    {
        if (inTxn)
        {
            verbData = backupData;
            inTxn = false;
        }
    }

    public void EndEdit()
    {
        if (inTxn)
        {
            backupData = new VerbData();
            inTxn = false;
            edited = true;
        }
    }
    
    public Verb(Int64 ID)
    {
        this.ID = ID;
        New = true;
    }
    public Int64 ID
    {
        get
        {
            return this.verbData.ID;
        }
        set
        {
            verbData.ID = value;
        }
    }
    public string Infinitiv
    {
        get => verbData.Infinitiv;
        set
        {
            if (value != verbData.Infinitiv)
            {
                verbData.Infinitiv = value;
                NotifyPropertyChanged(nameof(Infinitiv));
            }
            
        }
    }
    
    public string Presens
    {
        get => verbData.Presens;
        set
        {
            if (value != verbData.Presens)
            {
                verbData.Presens = value;
                NotifyPropertyChanged(nameof(Presens));
            }
            
        }
    }
    
    public string Preteritum
    {
        get => verbData.Preteritum;
        set
        {
            if (value != verbData.Preteritum)
            {
                verbData.Preteritum = value;
                NotifyPropertyChanged(nameof(Preteritum));
            }
        }
    }
    
    public string PreteritumPerfektum
    {
        get => verbData.PreteritumPerfektum;
        set
        {
            if (value != verbData.PreteritumPerfektum)
            {
                verbData.PreteritumPerfektum = value;
                NotifyPropertyChanged(nameof(PreteritumPerfektum));
            }
            
        }
    }
    public string Translation
    {
        get => verbData.Translation;
        set
        {
            if (value != verbData.Translation)
            {
                verbData.Translation = value;
                NotifyPropertyChanged(nameof(Translation));
            }
            
        }
    }
    
    public bool Active
    {
        get => verbData.Active;
        set
        {
            if (value != verbData.Active)
            {
                verbData.Active = value;
                NotifyPropertyChanged(nameof(Active));
            }
            
        }
    }
    
    public bool Regular
    {
        get => verbData.Regular;
        set
        {
            if (value != verbData.Regular)
            {
                verbData.Regular = value;
                NotifyPropertyChanged(nameof(Regular));
            }
            
        }
    }
    
    public event PropertyChangedEventHandler? PropertyChanged;
    
    private void NotifyPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}