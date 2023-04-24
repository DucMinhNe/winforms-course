# Lesson 30: Reading & writing files

Persist data without a database — text, and JSON.

## What you'll learn

- **Text**: `File.ReadAllText(path)` / `File.WriteAllText(path, text)`;
  line-based with `File.ReadAllLines` / `WriteAllLines` /
  `AppendAllText`.
- **JSON** (the modern default for app data): `System.Text.Json`.
  ```csharp
  string json = JsonSerializer.Serialize(todos, new JsonSerializerOptions { WriteIndented = true });
  File.WriteAllText(path, json);

  var loaded = JsonSerializer.Deserialize<List<Todo>>(File.ReadAllText(path)) ?? new();
  ```
- Pick a sane location for user data:
  `Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)` →
  `%AppData%\YourApp\data.json`. Don't write next to the .exe (Program Files is
  read-only).
- Wrap file IO in `try/catch (IOException / UnauthorizedAccessException)` — the
  disk can always say no.

## Example

See `examples/Storage.cs`.

## Exercise

1. A JSON `Storage` helper: `Save(List<Todo>)` and `Load()` to a file under
   `%AppData%\WinFormsCourse\todos.json`.
2. Load on startup into a `BindingList<Todo>`; save on `FormClosing`.
3. Add/remove todos in the UI, restart the app, and confirm they persist.
4. Wrap reads/writes in `try/catch` and show a friendly message on failure.
