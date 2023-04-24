using System.Collections.Generic;
using Microsoft.Data.Sqlite;   // NuGet: Microsoft.Data.Sqlite

namespace HelloForms;

// A tiny data-access helper using ADO.NET against SQLite.
public class Db
{
    private const string ConnStr = "Data Source=app.db";

    public void EnsureSchema()
    {
        using var conn = new SqliteConnection(ConnStr);
        conn.Open();
        using var cmd = conn.CreateCommand();
        cmd.CommandText = """
            CREATE TABLE IF NOT EXISTS products (
                Id    INTEGER PRIMARY KEY AUTOINCREMENT,
                Name  TEXT NOT NULL,
                Price REAL NOT NULL
            );
            """;
        cmd.ExecuteNonQuery();
    }

    public int Insert(string name, decimal price)
    {
        using var conn = new SqliteConnection(ConnStr);
        conn.Open();
        using var cmd = conn.CreateCommand();
        cmd.CommandText = "INSERT INTO products (Name, Price) VALUES (@name, @price)";
        cmd.Parameters.AddWithValue("@name", name);     // PARAMETERISED — no injection
        cmd.Parameters.AddWithValue("@price", price);
        return cmd.ExecuteNonQuery();                    // rows affected
    }

    public List<Product> GetAll()
    {
        var list = new List<Product>();
        using var conn = new SqliteConnection(ConnStr);
        conn.Open();
        using var cmd = conn.CreateCommand();
        cmd.CommandText = "SELECT Id, Name, Price FROM products ORDER BY Name";
        using var reader = cmd.ExecuteReader();
        while (reader.Read())
            list.Add(new Product(reader.GetInt32(0), reader.GetString(1), (decimal)reader.GetDouble(2)));
        return list;
    }
}
