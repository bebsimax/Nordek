using System;
using System.Collections;
using System.ComponentModel;
using System.DirectoryServices.ActiveDirectory;
using System.Runtime.CompilerServices;

namespace Nordek.Models;

public class Noun : IEditableObject, INotifyPropertyChanged
{
    struct NounData
    {
        public NounData(Int64 ID, string Artikkel, string EntallU, string EntallB, string FlertallU, string FlertallB, bool Active, bool Regular)
        {
            this.ID = ID;
            this.Artikkel = Artikkel;
            this.EntallU = EntallU;
            this.EntallB = EntallB;
            this.FlertallU = FlertallU;
            this.FlertallB = FlertallB;
            this.Active = Active;
            this.Regular = Regular;
        }
        
        /* Entall - singular, Flertall - plural
     Ubestemt - unspecified, Bestemt - specified */
        internal Int64 ID;
        internal string Artikkel;
        internal string EntallU;
        internal string EntallB;
        internal string FlertallU;
        internal string FlertallB;
        internal bool Active;
        internal bool Regular;
    }
    
    private NounData backupData;
    private NounData nounData;
    private bool inTxn = false;
    public bool New { get; set; } = false;
    public bool edited { get; set; } = false;
    

    public Noun(Int64 ID, string Artikkel, string EntallU, string EntallB, string FlertallU, string FlertallB,
        bool Active, bool Regular)
    {
        nounData = new NounData(ID, Artikkel, EntallU, EntallB, FlertallU, FlertallB, Active, Regular);
        New = false;
    }
    
    public Noun()
    {
        nounData = new NounData();
    }

    public Noun(Int64 ID)
    {
        this.ID = ID;
        New = true;
    }
    

    public void BeginEdit()
    {
        if (!inTxn)
        {
            backupData = nounData;
            inTxn = true;
        }
    }

    public void CancelEdit()
    {
        if (inTxn)
        {
            nounData = backupData;
            inTxn = false;
        }
    }

    public void EndEdit()
    {
        if (inTxn)
        {
            backupData = new NounData();
            inTxn = false;
            edited = true;
        }
    }
    public Int64 ID
    {
        get
        {
            return this.nounData.ID;
        }
        set
        {
            nounData.ID = value;
        }
    }

    public string Artikkel
    {
        get => nounData.Artikkel;
        set
        {
            if (value != nounData.Artikkel)
            {
                nounData.Artikkel = value;
                NotifyPropertyChanged(nameof(Artikkel));
            }
            
        }
    }
    
    public string EntallU
    {
        get => nounData.EntallU;
        set
        {
            if (value != nounData.EntallU)
            {
                nounData.EntallU = value;
                NotifyPropertyChanged(nameof(EntallU));
            }
            
        }
    }
    
    public string EntallB
    {
        get => nounData.EntallB;
        set
        {
            if (value != nounData.EntallB)
            {
                nounData.EntallB = value;
                NotifyPropertyChanged(nameof(EntallB));
            }
        }
    }
    
    public string FlertallU
    {
        get => nounData.FlertallU;
        set
        {
            if (value != nounData.FlertallU)
            {
                nounData.FlertallU = value;
                NotifyPropertyChanged(nameof(FlertallU));
            }
            
        }
    }
    
    public string FlertallB
    {
        get => nounData.FlertallB;
        set
        {
            if (value != nounData.FlertallB)
            {
                nounData.FlertallB = value;
                NotifyPropertyChanged(nameof(FlertallB));
            }
            
        }
    }
    
    public bool Active
    {
        get => nounData.Active;
        set
        {
            if (value != nounData.Active)
            {
                nounData.Active = value;
                NotifyPropertyChanged(nameof(Active));
            }
            
        }
    }
    
    public bool Regular
    {
        get => nounData.Regular;
        set
        {
            if (value != nounData.Regular)
            {
                nounData.Regular = value;
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