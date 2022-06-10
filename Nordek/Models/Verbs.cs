using System.Collections.Generic;

namespace Nordek.Models;

public class Verbs : List<Verb>
{
    public List<Verb> verbs { get; set; }
    
    public Verbs(List<Verb> v)
    {
        verbs = new List<Verb>();
        foreach (var verb in v)
        {
            verbs.Add(verb);
        }
    }
    
    public Verbs()
    {
        verbs = new List<Verb>();
    }
}