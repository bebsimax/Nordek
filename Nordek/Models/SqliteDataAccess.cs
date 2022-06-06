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
        var sql = @"INSERT INTO Nouns (Artikkel, EntallU, EntallB, FlertallU, FlertallB, Regular) VALUES 
            (@Artikkel, @EntallU, @EntallB, @FlertallU, @FlertallB, @Regular)";
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

    public static int GetActiveNounsNumber()
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
/*
    public static Nouns GetHardNounsToRepeat()
    {
        var sql = @"SELECT * FROM Nouns WHERE ID IN (
SELECT NR.NounID as ID FROM Nouns_Repetitions NR 
JOIN Difficulties D ON NR.DifficultyID=D.ID
GROUP BY NounID
HAVING D.Difficulty='hard' AND DateRepeated =MAX(DateRepeated))";
        
    }

*/
}