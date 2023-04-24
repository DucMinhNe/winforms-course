# Lesson 28: ADO.NET connections

Talk to a real database with the classic .NET data API.

## What you'll learn

- The ADO.NET objects: `SqlConnection` (open a connection),
  `SqlCommand` (a query), `SqlParameter` (safe inputs),
  `ExecuteReader` (rows), `ExecuteScalar` (one value), `ExecuteNonQuery`
  (insert/update/delete row count).
- **Always** dispose connections — use `using`. Connection pooling means
  open-late, close-early is cheap.
- **Always** parameterise. String-concatenating user input is a SQL-injection
  hole.
- For SQLite use `Microsoft.Data.Sqlite`; for SQL Server
  `Microsoft.Data.SqlClient`. Same shape, different namespace.

```csharp
using var conn = new SqlConnection(connectionString);
conn.Open();

using var cmd = new SqlCommand("SELECT Name FROM Products WHERE Price > @min", conn);
cmd.Parameters.AddWithValue("@min", 100);

using var reader = cmd.ExecuteReader();
while (reader.Read())
    Console.WriteLine(reader.GetString(0));
```

## Example

See `examples/Db.cs`.

## Exercise

1. Add a SQLite connection string (a local `app.db`).
2. Create a `products` table if it doesn't exist (`ExecuteNonQuery`).
3. Insert a row using **parameters** (never string concatenation).
4. Read all rows with a reader into a `List<Product>` and bind it to a grid.
