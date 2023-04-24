# Exercise — Lesson 29

1. Extend the Lesson 28 `Db` class with:
   ```csharp
   public int Update(int id, string name, decimal price) { /* UPDATE ... WHERE Id=@id */ }
   public int Delete(int id) { /* DELETE ... WHERE Id=@id */ }
   ```
   (parameterised, of course).
2. Build the CRUD form (see example): grid + Name/Price inputs + Add/Update/
   Delete buttons.
3. Selecting a grid row fills the inputs; **Update** writes those edits;
   **Delete** confirms via `MessageBox` first.
4. Call `Refresh()` (re-read `GetAll()`) after every write.

**Done when:** create/read/update/delete all work, the grid always matches the
DB, and data survives restarting the app.
