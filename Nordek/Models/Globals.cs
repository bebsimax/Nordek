using System;
using System.Collections.Generic;

namespace Nordek.Models;

static class Globals
{
    public static User? ActiveUser { get; set; }

    public static ObjectInDB[] TypesPresentInDB { get; set; } = new ObjectInDB[1]
    {
        new ObjectInDB("Noun"),
    };

    public static List<Int64> NounsIDsToDelete { get; set; } = new List<Int64>();
}
