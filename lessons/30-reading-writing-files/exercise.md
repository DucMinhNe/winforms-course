# Exercise — Lesson 30

1. Build a `Storage` helper that serialises a `List<Todo>` to JSON under
   `%AppData%\WinFormsCourse\todos.json` (see example).
2. In a Todo form: `Load()` on startup into a `BindingList<Todo>`; `Save(...)`
   in the `FormClosing` handler.
3. Add/remove a few todos, close the app, reopen it — they should still be
   there.
4. Wrap the IO in `try/catch` and show a `MessageBox` if saving fails (e.g.
   simulate by making the file read-only).

**Done when:** todos persist across runs as indented JSON in `%AppData%`, and IO
errors are handled gracefully rather than crashing.
