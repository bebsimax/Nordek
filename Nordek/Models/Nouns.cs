using System.Collections;
using System.Collections.Generic;

namespace Nordek.Models;

public class Nouns : List<Noun>
{
    public List<Noun> nouns { get; set; }

    public Nouns(List<Noun> n)
    {
        nouns = new List<Noun>();
        foreach (var noun in n)
        {
            nouns.Add(noun);
        }
    }
    
    public Nouns()
    {
        nouns = new List<Noun>();
    }
}