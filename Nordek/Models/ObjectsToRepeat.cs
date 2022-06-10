using System;
using System.Collections.Generic;

namespace Nordek.Models;

public class ObjectsToRepeat
{
    public Dictionary<string, Nouns> nounsDict;
    public Dictionary<string, Verbs> verbsDict;

    public ObjectsToRepeat()
    {
        
        nounsDict = new Dictionary<string, Nouns>()
        {
            {Globals.trivial.difficulty, SqliteDataAccess.GetNounsToRepeat(Globals.trivial.difficulty)},
            {Globals.easy.difficulty, SqliteDataAccess.GetNounsToRepeat(Globals.easy.difficulty)},
            {Globals.medium.difficulty, SqliteDataAccess.GetNounsToRepeat(Globals.medium.difficulty)},
            {Globals.hard.difficulty, SqliteDataAccess.GetNounsToRepeat(Globals.hard.difficulty)},
            {Globals.New.difficulty, SqliteDataAccess.GetNewNounsToRepeat()},
        };

        verbsDict = new Dictionary<string, Verbs>()
        {
            {Globals.trivial.difficulty, SqliteDataAccess.GetVerbsToRepeat(Globals.trivial.difficulty)},
            {Globals.easy.difficulty, SqliteDataAccess.GetVerbsToRepeat(Globals.easy.difficulty)},
            {Globals.medium.difficulty, SqliteDataAccess.GetVerbsToRepeat(Globals.medium.difficulty)},
            {Globals.hard.difficulty, SqliteDataAccess.GetVerbsToRepeat(Globals.hard.difficulty)},
            {Globals.New.difficulty, SqliteDataAccess.GetNewVerbsToRepeat()},
        };
    }
}