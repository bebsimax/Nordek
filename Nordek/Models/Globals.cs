using System;
using System.Collections.Generic;

namespace Nordek.Models;

static class Globals
{
    public static User? ActiveUser { get; set; }
    public static Difficulty hard = new Difficulty("hard");
    public static Difficulty medium = new Difficulty("medium");
    public static Difficulty easy = new Difficulty("easy");
    public static Difficulty trivial = new Difficulty("trivial");
    public static Difficulty New = new Difficulty("new");

    public static ObjectInDB[] TypesPresentInDB { get; set; } = new ObjectInDB[1]
    {
        new ObjectInDB("Noun"),
    };

    public static List<Int64> NounsIDsToDelete { get; set; } = new List<Int64>();
    public static List<Int64> VerbsIDsToDelete { get; set; } = new List<Int64>();
}
