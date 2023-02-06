# Lesson 02: Project structure

Know which file does what before you start dragging controls.

## What you'll learn

A `dotnet new winforms` project contains:

- **`Program.cs`** — the entry point. `Main()` calls `Application.Run(form)`.
- **`Form1.cs`** — *your* code for the form: event handlers, logic.
- **`Form1.Designer.cs`** — **generated** code. `InitializeComponent()` builds
  the controls. The designer rewrites this; don't hand-edit it.
- **`Form1.resx`** — resources for the form (icons, localized strings,
  embedded images).
- **`HelloForms.csproj`** — the project file: target framework
  (`net7.0-windows`), `<UseWindowsForms>true</UseWindowsForms>`, NuGet refs.

## The partial-class trick

`Form1.cs` and `Form1.Designer.cs` are **two halves of the same `partial
class`**. That's how the designer keeps generated layout code separate from
your hand-written logic — both compile into one `Form1` type.

## Example

See `examples/structure.txt`.

## Exercise

1. Open a fresh project and locate all five items above.
2. Open `Form1.Designer.cs` and read `InitializeComponent()` — every property
   you set in the designer shows up here as code.
3. Open `.csproj` and find the target framework and `UseWindowsForms`.
