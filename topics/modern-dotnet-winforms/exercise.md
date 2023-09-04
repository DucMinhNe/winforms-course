# Exercise — Modern .NET WinForms

1. Open a `dotnet new winforms` project. Confirm the SDK-style `.csproj` and
   enable `<Nullable>enable</Nullable>` + `<ImplicitUsings>enable</ImplicitUsings>`
   if not already.
2. Modernise a form:
   - file-scoped namespace,
   - target-typed `new` (`Button btn = new() { ... }`),
   - `object? sender` in handlers,
   - a `switch` expression or `sender is Button b` pattern.
   Fix any nullable warnings the compiler raises.
3. Replace a `BackgroundWorker` somewhere with `async`/`await` + `Task.Run`.

**Done when:** the project builds clean with nullable enabled and uses modern
C# idioms throughout.
