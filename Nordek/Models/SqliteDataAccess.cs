using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using Dapper;
using Nordek.Commands;

namespace Nordek.Models;

public class SqliteDataAccess
{
    private static IDbConnection conn;

    public static void SetupConnection()
    {
        conn = new SQLiteConnection(LoadConnectionString());
        conn.Open();
    }
    public static List<Noun> LoadNouns()
    {
        var sql = "SELECT * FROM Nouns";
        return conn.Query<Noun>(sql, new DynamicParameters()).ToList();
    }

    public static int GetNounsCount()
    {
        var sql = "SELECT COUNT(*) FROM Nouns";
        return conn.ExecuteScalar<int>(sql, new DynamicParameters());
    }

    public static int CreateNoun(Noun noun)
    {
        var dictionary = new Dictionary<string, object>
        {
            {"@ID", noun.ID},
            {"@Artikkel", noun.Artikkel},
            {"@EntallU", noun.EntallU},
            {"@EntallB", noun.EntallB},
            {"@FlertallB", noun.FlertallB},
            {"@FlertallU", noun.FlertallU},
            {"@Active", noun.Active},
            {"@Regular", noun.Regular},
        };
        var sql = @"INSERT INTO Nouns (ID, Artikkel, EntallU, EntallB, FlertallU, FlertallB, Regular) VALUES 
            (@ID, @Artikkel, @EntallU, @EntallB, @FlertallU, @FlertallB, @Regular)";
        return conn.Execute(sql, dictionary);
    }
    
    public static List<Noun> GetNounById(int id)
    {
        var sql = "SELECT * FROM Nouns WHERE id=@id";
        return conn.Query<Noun>(sql, new { id }).ToList();
    }

    public static int ActivateNouns(int number)
    {
        var dictionary = new Dictionary<string, object>
        {
            {"@number", number},
        };
        var sql = "UPDATE Nouns SET Active=true WHERE id IN (SELECT id FROM Nouns WHERE Active=false LIMIT @number)";
        return conn.Execute(sql, dictionary);
    }

    public static int DeleteNoun(Int64 id)
    {
        var dictionary = new Dictionary<string, object>
        {
            {"@ID", id},
        };
        var sql = "DELETE FROM Nouns WHERE id=@ID";
        return conn.Execute(sql, dictionary);
    }
    

    public static List<User> LoadUsers()
    {
        return conn.Query<User>("SELECT * FROM Users;", new DynamicParameters()).ToList();
    }
    
    public static string? CreateUser(User user)
    {
        
        var cmd = conn.CreateCommand();
        cmd.CommandText = "INSERT INTO Users (login) VALUES (@login);";
        AddParameter(cmd, "@login", user.login);
        cmd.Prepare();
        try
        {
            cmd.ExecuteNonQuery();
        }
        catch (SQLiteException ex)
        {
            return ex.Message;
        }

        return null;
    }

    public static List<User> GetUserById(int id)
    {
        return conn.Query<User>("SELECT * FROM Users WHERE id=@id;", new { id }).ToList();
    }
    public static int UpdateUser(User user)
    {
        var cmd = conn.CreateCommand();
        cmd.CommandText = "UPDATE Users SET login=@login WHERE id=@id;";
        AddParameter(cmd, "@login", user.login);
        AddParameter(cmd, "@id", user.id);
        cmd.Prepare();
        return cmd.ExecuteNonQuery();
    }
    public static int DeleteUser(User user)
    {
        var cmd = conn.CreateCommand();
        cmd.CommandText = "DELETE FROM Users  WHERE id=@id;";
        AddParameter(cmd, "@id", user.id);
        cmd.Prepare();
        return cmd.ExecuteNonQuery();
    }

    public static List<Noun?> SearchNouns(String phrase)
    {
        var searchCondidtion = phrase + "%";
        return conn.Query<Noun?>("SELECT * FROM Nouns WHERE EntallU LIKE @searchCondidtion", param: new { searchCondidtion }).ToList();
    }

    public static int UpdateNoun(Noun noun)
    {
        var dictionary = new Dictionary<string, object>
        {
            {"@ID", noun.ID},
            {"@Artikkel", noun.Artikkel},
            {"@EntallU", noun.EntallU},
            {"@EntallB", noun.EntallB},
            {"@FlertallB", noun.FlertallB},
            {"@FlertallU", noun.FlertallU},
            {"@Active", noun.Active},
            {"@Regular", noun.Regular},
        };
        var sql = @"UPDATE Nouns 
        SET 
            Artikkel=@Artikkel,
            EntallU=@EntallU,
            EntallB=@EntallB,
            FlertallB=@FlertallB,
            FlertallU=@FlertallU,
            Active=@Active,
            Regular=@Regular
        WHERE
            ID=@ID
        ";
        return conn.Execute(sql, dictionary);
    }

    public static int GetNextNounID()
    {
        var sql = "SELECT MAX(id)+1 FROM Nouns";
        return conn.ExecuteScalar<int>(sql);
    }
    
    public static List<User?> GetActiveUser()
    {
        return conn.Query<User>("SELECT Users.ID, Users.login FROM Users JOIN Active_User AU on Users.ID = AU.ID;", new DynamicParameters()).ToList();
    }

    public static int GetActiveNounsCount()
    {
        var sql = "SELECT COUNT(*) FROM Nouns WHERE Active=true";
        return conn.ExecuteScalar<int>(sql);
    }
    public static int WipeActiveUser()
    {
        var cmd = conn.CreateCommand();
        cmd.CommandText = "DELETE FROM Active_User";
        cmd.Prepare();
        return cmd.ExecuteNonQuery();
    }
    public static void SetActiveUser(User user)
    {
        WipeActiveUser();
        var cmd = conn.CreateCommand();
        cmd.CommandText = "INSERT INTO Active_User (ID) VALUES (@id)";
        AddParameter(cmd, "@id", user.id);
        cmd.Prepare();
        cmd.ExecuteNonQuery();
    }
    public static void AddParameter (IDbCommand command, string name, object value)
    {
        var parameter = command.CreateParameter();
        parameter.ParameterName = name;
        parameter.Value = value;
        command.Parameters.Add(parameter);
    }
    
    private static string LoadConnectionString(string id = "Default")
    {
        return ConfigurationManager.ConnectionStrings[id].ConnectionString;
    }

    public static Nouns GetNounsToRepeat(string difficulty)
    {
        var dictionary = new Dictionary<string, object>
        {
            {"@difficulty", difficulty},
            {"@id", Globals.ActiveUser.id}
        };
        var sql = @"
SELECT * FROM
    (
    SELECT N.*, T.Translation FROM Nouns N
        JOIN Nouns_Translations NT ON N.ID = NT.NounID
        JOIN Translations T on NT.TranslationID = T.ID
        JOIN Languages L on T.LangID = L.ID
    WHERE
        L.Lang='english'
        AND N.Active
        AND N.ID IN (
            SELECT NR.NounID as ID FROM Nouns_Repetitions NR
                JOIN Difficulties D ON NR.DifficultyID=D.ID
            GROUP BY NounID
            HAVING
                D.Difficulty=@difficulty AND DateRepeated =MAX(DateRepeated) AND NR.UserID=@id
                AND JULIANDAY(DATE())-JULIANDAY(MAX(DateRepeated))>
                    (SELECT DaysToRepeat FROM Difficulties WHERE Difficulty=@difficulty)
            )
    ORDER BY random()
    )
GROUP BY ID";
        var q = conn.Query<Noun>(sql, dictionary).ToList();
        return new Nouns(q);
    }

    public static int AddNounRepeat(Noun n, string difficulty)
    {
        var dictionary = new Dictionary<string, object>
        {
            {"@difficulty", difficulty},
            {"@UserID", Globals.ActiveUser.id},
            {"@NounID", n.ID}
        };
        var sql = @"
INSERT INTO Nouns_Repetitions (NounID, UserID, DifficultyID, DateRepeated) VALUES 
    (@NounID, @UserID, (SELECT ID FROM Difficulties WHERE Difficulty=@Difficulty), DATE())";
        return conn.Execute(sql, dictionary);
    }

    public static List<Language> GetLanguages()
    {
        var sql = @"SELECT * FROM Languages";
        return conn.Query<Language>(sql).ToList();
    }

    public static int? CheckTranslation(long langId, string translation)
    {
        var dictionary = new Dictionary<string, object>
        {
            {"@translation", translation},
            {"@LangID", langId}
        };
        var sql = @"SELECT id FROM Translations WHERE LangID=@LangID AND Translation=@translation";
        return conn.ExecuteScalar<int?>(sql, dictionary);
    }

    public static int CreateTranslation(long langId, string translation)
    {
        var dictionary = new Dictionary<string, object>
        {
            {"@translation", translation},
            {"@LangID", langId}
        };
        var sql = @"INSERT INTO Translations (LangID, Translation) VALUES (@LangID,@Translation)";
        return conn.Execute(sql, dictionary);
    }

    public static int AddNounTranslation(long langId, string translation, int id)
    {
        var dictionary = new Dictionary<string, object>
        {
            {"@translation", translation},
            {"@LangID", langId},
            {"@NounID", id}
        };
        var sql =
            @"INSERT INTO Nouns_Translations (NounID, TranslationID) VALUES (@NounID, (SELECT ID FROM Translations WHERE LangID=@LangID AND Translation=@translation))";
        int result;
        try
        {
            result = conn.Execute(sql, dictionary);
        }
        catch (SQLiteException ex)
        {
            return 0;
        }

        return result;
    }

    public static Verbs GetVerbsToRepeat(string difficulty)
    {
        var dictionary = new Dictionary<string, object>
        {
            {"@difficulty", difficulty},
            {"@id", Globals.ActiveUser.id}
        };
        var sql = @"
SELECT * FROM
    (
    SELECT V.*, T.Translation FROM Verbs V
        JOIN Verbs_Translations VT ON V.ID = VT.VerbID
        JOIN Translations T on VT.TranslationID = T.ID
        JOIN Languages L on T.LangID = L.ID
    WHERE
        L.Lang='english'
        AND V.Active
        AND V.ID IN (
            SELECT VR.VerbID as ID FROM Verbs_Repetitions VR
                JOIN Difficulties D ON VR.DifficultyID=D.ID
            GROUP BY VerbID
            HAVING
                D.Difficulty=@difficulty AND DateRepeated =MAX(DateRepeated) AND VR.UserID=@id
                AND JULIANDAY(DATE())-JULIANDAY(MAX(DateRepeated))>
                    (SELECT DaysToRepeat FROM Difficulties WHERE Difficulty=@difficulty)
            )
    ORDER BY random()
    )
GROUP BY ID";
        var q = conn.Query<Verb>(sql, dictionary).ToList();
        return new Verbs(q);
    }

    public static int GetNextVerbID()
    {
        var sql = "SELECT MAX(id)+1 FROM Verbs";
        return conn.ExecuteScalar<int>(sql);
    }

    public static List<Verb> GetVerbById(int id)
    {
        var sql = "SELECT * FROM Verbs WHERE id=@id";
        return conn.Query<Verb>(sql, new { id }).ToList();
    }

    public static int AddVerbTranslation(long langId, string translation, int id)
    {
        var dictionary = new Dictionary<string, object>
        {
            {"@translation", translation},
            {"@LangID", langId},
            {"@VerbID", id}
        };
        var sql =
            @"INSERT INTO Verbs_Translations (VerbID, TranslationID) VALUES (@VerbID, (SELECT ID FROM Translations WHERE LangID=@LangID AND Translation=@translation))";
        int result;
        try
        {
            result = conn.Execute(sql, dictionary);
        }
        catch (SQLiteException ex)
        {
            return 0;
        }

        return result;
    }

    public static List<Verb> LoadVerbs()
    {
        var sql = "SELECT * FROM Verbs";
        return conn.Query<Verb>(sql, new DynamicParameters()).ToList();
    }

    public static int CreateVerb(Verb verb)
    {
        var dictionary = new Dictionary<string, object>
        {
            {"@ID", verb.ID},
            {"@Infinitiv", verb.Infinitiv},
            {"@Presens", verb.Presens},
            {"@Preteritum", verb.Preteritum},
            {"@PreteritumPerfektum", verb.PreteritumPerfektum},
            {"@Active", verb.Active},
            {"@Regular", verb.Regular},
        };
        var sql = @"INSERT INTO Verbs (ID, Infinitiv, Presens, Preteritum, PreteritumPerfektum, Active, Regular) VALUES 
            (@ID, @Infinitiv, @Presens, @Preteritum, @PreteritumPerfektum, @Active, @Regular)";
        return conn.Execute(sql, dictionary);
    }

    public static int UpdateVerb(Verb verb)
    {
        var dictionary = new Dictionary<string, object>
        {
            {"@ID", verb.ID},
            {"@Infinitiv", verb.Infinitiv},
            {"@Presens", verb.Presens},
            {"@Preteritum", verb.Preteritum},
            {"@PreteritumPerfektum", verb.PreteritumPerfektum},
            {"@Active", verb.Active},
            {"@Regular", verb.Regular},
        };
        var sql = @"UPDATE Verbs SET
                Infinitiv=@Infinitiv,
                 Presens=@Presens,
                 Preteritum=@Preteritum,
                 PreteritumPerfektum=@PreteritumPerfektum,
                 Active=@Active,
                 Regular=@Regular WHERE ID=@ID";
        return conn.Execute(sql, dictionary);
    }

    public static int DeleteVerb(long id)
    {
        var dictionary = new Dictionary<string, object>
        {
            {"@ID", id},
        };
        var sql = @"DELETE FROM Verbs WHERE ID=@ID";
        return conn.Execute(sql, dictionary);
    }

    public static int AddVerbRepeat(Verb v, string difficulty)
    {
        var dictionary = new Dictionary<string, object>
        {
            {"@difficulty", difficulty},
            {"@UserID", Globals.ActiveUser.id},
            {"@VerbID", v.ID}
        };
        var sql = @"
INSERT INTO Verbs_Repetitions (VerbID, UserID, DifficultyID, DateRepeated) VALUES 
    (@VerbID, @UserID, (SELECT ID FROM Difficulties WHERE Difficulty=@Difficulty), DATE())";
        return conn.Execute(sql, dictionary);
    }

    public static Nouns GetNewNounsToRepeat()
    {
        var dictionary = new Dictionary<string, object>
        {
            {"@ID", Globals.ActiveUser.id}
        };
        var sql = @"
SELECT * FROM
    (
        SELECT N.*, T.Translation FROM Nouns N
        JOIN Nouns_Translations NT ON N.ID = NT.NounID
        JOIN Translations T on NT.TranslationID = T.ID
        JOIN Languages L on T.LangID = L.ID
        WHERE
            L.Lang='english'
            AND N.Active
            AND N.ID IN 
            (
              SELECT DISTINCT Nouns.ID FROM Nouns
              LEFT JOIN Nouns_Repetitions NR ON Nouns.ID = NR.NounID
                WHERE NR.ID IS NULL
            )
        ORDER BY random()
    )
GROUP BY ID
";
        return new Nouns(conn.Query<Noun>(sql, dictionary).ToList());
    }

    public static Verbs GetNewVerbsToRepeat()
    {
        var dictionary = new Dictionary<string, object>
        {
            {"@ID", Globals.ActiveUser.id}
        };
        var sql = @"
SELECT * FROM
    (
    SELECT V.*, T.Translation FROM Verbs V
        JOIN Verbs_Translations VT ON V.ID = VT.VerbID
        JOIN Translations T on VT.TranslationID = T.ID
        JOIN Languages L on T.LangID = L.ID
    WHERE
        L.Lang='english'
        AND V.Active
        AND V.ID IN (
            SELECT DISTINCT VerbS.ID FROM Verbs
              LEFT JOIN Verbs_Repetitions VR ON Verbs.ID = VR.VerbID
                WHERE VR.ID IS NULL
            )
    ORDER BY random()
    )
GROUP BY ID";
        return new Verbs(conn.Query<Verb>(sql, dictionary).ToList());
    }

    public static int GetVerbsCount()
    {
        var sql = @"SELECT COUNT(*) FROM Verbs";
        return conn.ExecuteScalar<int>(sql, new DynamicParameters());
    }

    public static int GetActiveVerbsCount()
    {
        var sql = @"SELECT COUNT(*) FROM Verbs WHERE Active=true";
        return conn.ExecuteScalar<int>(sql, new DynamicParameters());
    }

    public static int GetNounsRepeatCount()
    {
        var dictionary = new Dictionary<string, object>
        {
            {"@ID", Globals.ActiveUser.id}
        };
        var sql = @"SELECT COUNT(*) FROM Nouns_Repetitions WHERE UserID=@ID";
        return conn.ExecuteScalar<int>(sql, dictionary);
    }

    public static int GetVerbsRepeatCount()
    {
        var dictionary = new Dictionary<string, object>
        {
            {"@ID", Globals.ActiveUser.id}
        };
        var sql = @"SELECT COUNT(*) FROM Verbs_Repetitions WHERE UserID=@ID";
        return conn.ExecuteScalar<int>(sql, dictionary);
    }

    public static int GetLearnedNounsCount()
    {
        var dictionary = new Dictionary<string, object>
        {
            {"@ID", Globals.ActiveUser.id}
        };
        var sql = @"
SELECT COUNT(*) FROM (
    SELECT N.ID FROM Nouns N
    JOIN Nouns_Repetitions NR on N.ID = NR.NounID
    GROUP BY N.ID
    HAVING 
            NR.UserID=@ID 
            AND NR.DifficultyID=
                (SELECT ID FROM Difficulties ORDER BY Value ASC LIMIT 1)
            AND DateRepeated=MAX(DateRepeated))";
        return conn.ExecuteScalar<int>(sql, dictionary);
    }

    public static int GetLearnedVerbsCount()
    {
        var dictionary = new Dictionary<string, object>
        {
            {"@ID", Globals.ActiveUser.id}
        };
        var sql = @"
SELECT COUNT(*) FROM (
    SELECT V.ID FROM Verbs V
    JOIN Verbs_Repetitions VR on V.ID = VR.VerbID
    GROUP BY V.ID
    HAVING 
            VR.UserID=@ID 
            AND VR.DifficultyID=
                (SELECT ID FROM Difficulties ORDER BY Value ASC LIMIT 1)
            AND DateRepeated=MAX(DateRepeated))";
        return conn.ExecuteScalar<int>(sql, dictionary);
    }
}