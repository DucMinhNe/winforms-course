# Lesson 01: Setting up .NET & WinForms

Install the SDK and create your first Windows Forms project.

## What you'll learn

- WinForms is **Windows-only** and runs on the **.NET 6/7 SDK** (or the older
  .NET Framework). Check with `dotnet --version`.
- The visual designer ships with **Visual Studio 2022**. VS Code + the CLI work
  too, but you edit the designer code by hand.
- Create a project from the terminal:
  ```bash
  dotnet new winforms -n HelloForms
  cd HelloForms
  dotnet run
  ```
- A blank window appears — that's a running WinForms app.

## Example

See `examples/Program.cs` — the entry point the template generates.

## Exercise

1. `dotnet new winforms -n HelloForms` and `dotnet run`.
2. Confirm an empty window opens and closes cleanly.
3. Print your SDK version with `dotnet --version` and note it's 6.x or 7.x.
