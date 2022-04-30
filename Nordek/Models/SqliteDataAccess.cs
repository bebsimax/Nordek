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
    public static List<Noun> LoadNouns()
    {
        using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
        {
            var output = cnn.Query<Noun>("SELECT * FROM Nouns;", new DynamicParameters());
            return output.ToList();
        }
    }

    public static void CreateNoun(Noun noun)
    {
        using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
        {
            var cmd = cnn.CreateCommand();
            cmd.CommandText = @"INSERT INTO Nouns (ArtikkelID, EntallU, EntallB, FlertallU, FlertallB, Regular) VALUES 
            (@ArtikkelID, @EntallU, @EntallB, @FlertallU, @FlertallB, @Regular);";
            AddParameter(cmd, "@ArtikkelID", noun.ArtikkelID);
            AddParameter(cmd, "@EntallU", noun.EntallU);
            AddParameter(cmd, "@EntallB", noun.EntallB);
            AddParameter(cmd, "@FlertallU", noun.FlertallU);
            AddParameter(cmd, "@FlertallB", noun.FlertallB);
            AddParameter(cmd, "@Regular", noun.Regular);
            cmd.Prepare();

            cmd.ExecuteNonQuery();
        }
    }
    
    public static void GetNoun(Noun noun)
    {
        using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
        {
            var cmd = cnn.CreateCommand();
            cmd.CommandText = @"INSERT INTO Nouns (ArtikkelID, EntallU, EntallB, FlertallU, FlertallB, Regular) VALUES 
            (@ArtikkelID, @EntallU, @EntallB, @FlertallU, @FlertallB, @Regular);";
            AddParameter(cmd, "@ArtikkelID", noun.ArtikkelID);
            AddParameter(cmd, "@EntallU", noun.EntallU);
            AddParameter(cmd, "@EntallB", noun.EntallB);
            AddParameter(cmd, "@FlertallU", noun.FlertallU);
            AddParameter(cmd, "@FlertallB", noun.FlertallB);
            AddParameter(cmd, "@Regular", noun.Regular);
            cmd.Prepare();

            cmd.ExecuteNonQuery();
        }
    }
    

    public static List<User> LoadUsers()
    {
        using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
        {
            var output = cnn.Query<User>("SELECT * FROM Users;", new DynamicParameters());
            return output.ToList();
        }
    }

    public static void CreateUser(User user)
    {
        using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
        {
            var cmd = cnn.CreateCommand();
            cmd.CommandText = "INSERT INTO Users (login) VALUES (@login);";
            AddParameter(cmd, "@login", user.login);
            cmd.Prepare();

            cmd.ExecuteNonQuery();
        }
    }

    public static List<User> GetUserByID(int id)
    {
        using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
        {
            var cmd = cnn.CreateCommand();
            cmd.CommandText = "SELECT * FROM Nouns WHERE id=@id;";
            AddParameter(cmd, "@id", id);
            cmd.Prepare();

            var rdr = cmd.ExecuteReader();
            List<User> users = new List<User>();
            while (rdr.Read())
            {
                var u = new User(rdr.GetInt32(0), rdr.GetString(1));
                users.Add(u);
            }

            return users;
        }
    }
    public static int UpdateUser(User user)
    {
        using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
        {
            var cmd = cnn.CreateCommand();
            cmd.CommandText = "UPDATE Users SET login=@login WHERE id=@id;";
            AddParameter(cmd, "@login", user.login);
            AddParameter(cmd, "@id", user.id);
            cmd.Prepare();

            return cmd.ExecuteNonQuery();
        }
    }
    public static int DeleteUser(User user)
    {
        using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
        {
            var cmd = cnn.CreateCommand();
            cmd.CommandText = "DELETE FROM Users  WHERE id=@id;";
            AddParameter(cmd, "@id", user.id);
            cmd.Prepare();

            return cmd.ExecuteNonQuery();
        }
    }
    public static int WipeActiveUser()
    {
        using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
        {
            var cmd = cnn.CreateCommand();
            cmd.CommandText = "DELETE FROM Active_User";
            cmd.Prepare();

            return cmd.ExecuteNonQuery();
        }
    }
    public static void SetActiveUser(User user)
    {
        WipeActiveUser();
        using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
        {
            var cmd = cnn.CreateCommand();
            cmd.CommandText = "INSERT INTO Active_User (ID) VALUES (@id)";
            AddParameter(cmd, "@id", user.id);
            cmd.Prepare();

            cmd.ExecuteNonQuery();
        }
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
}