using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using Dapper;

namespace Nordek.Models;

public class SqliteDataAccess
{
    public static List<Noun> LoadNouns()
    {
        using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
        {
            var output = cnn.Query<Noun>("select EntallU, EntallB, FlertallB, FlertallU from Nouns", new DynamicParameters());
            return output.ToList();
        }
    }

    private static string LoadConnectionString(string id = "Default")
    {
        return ConfigurationManager.ConnectionStrings[id].ConnectionString;
    }
}