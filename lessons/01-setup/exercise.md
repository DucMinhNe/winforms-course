# Exercise — Lesson 01

1. Create and run a project:
   ```bash
   dotnet new winforms -n HelloForms
   cd HelloForms
   dotnet run
   ```
2. Open `Program.cs` and find the three pieces: `[STAThread]`,
   `ApplicationConfiguration.Initialize()`, and `Application.Run(...)`.
3. Change the window title: in `Form1` set `this.Text = "Hello!";` (or via the
   designer's `Text` property) and re-run.

**Done when:** a window titled "Hello!" opens, and you can point to the line
that starts the message loop.
