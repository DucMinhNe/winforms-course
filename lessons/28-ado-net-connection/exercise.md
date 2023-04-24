# Exercise — Lesson 28

1. Add the package: `dotnet add package Microsoft.Data.Sqlite`.
2. Write a `Db` helper (see example) with `EnsureSchema()`, `Insert(name,
   price)`, and `GetAll()`.
3. On form load, call `EnsureSchema()`, insert a couple of products with
   **parameters**, then bind `GetAll()` to a `DataGridView`.
4. Prove parameterisation matters: try inserting a name like `O'Brien` — it
   works because you used `@name`, not string concatenation.

**Done when:** rows persist to `app.db` across runs, and reads show up in the
grid. Every query uses parameters.
