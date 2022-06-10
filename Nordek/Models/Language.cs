using System;

namespace Nordek.Models;

public class Language
{
    public Int64 ID { get; set; }
    public string Lang { get; set; }
    public Language(Int64 ID, string Lang)
    {
        this.ID = ID;
        this.Lang = Lang;
    }

    public override string ToString()
    {
        return this.Lang;
    }
}