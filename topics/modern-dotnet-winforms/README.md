# Topic: Modern .NET WinForms

WinForms on .NET 6/7 is not the .NET Framework WinForms of 2010.

## Why it still matters

WinForms is actively maintained on modern .NET. You keep the productive
designer + mature control set, but gain the modern runtime, C# language
features, NuGet, single-file publish, and better performance.

## SDK-style project

The `.csproj` is tiny compared to old `packages.config` projects:

```xml
<Project Sdk="Microsoft.NET.Sdk">
  <PropertyGroup>
    <OutputType>WinExe</OutputType>
    <TargetFramework>net7.0-windows</TargetFramework>
    <UseWindowsForms>true</UseWindowsForms>
    <Nullable>enable</Nullable>
    <ImplicitUsings>enable</ImplicitUsings>
  </PropertyGroup>
</Project>
```

## Language features you should use

- **Nullable reference types** (`<Nullable>enable</Nullable>`) — the compiler
  flags possible `null`s; mark event handlers `object? sender`.
- **File-scoped namespaces**, **target-typed `new`** (`Button btn = new()`),
  **collection expressions**, **records**, **pattern matching** (great for
  `sender is Button b`), **switch expressions**.
- **`ApplicationConfiguration.Initialize()`** replaces the old three-line
  visual-styles/DPI boilerplate (it's source-generated from csproj settings).
- **`async`/`await`** instead of `BackgroundWorker`.

## Migrating from .NET Framework

- Use the **.NET Upgrade Assistant** to convert the project.
- Most WinForms code ports as-is; watch for removed/changed APIs, `app.config`
  → `appsettings`/runtimeconfig, and third-party controls that need .NET-Core
  versions.

## Example

See `examples/modern.csproj`.

## Exercise

1. Inspect a `dotnet new winforms` `.csproj`; confirm `Nullable` and
   `ImplicitUsings` are enabled.
2. Refactor an older-style form to use target-typed `new`, file-scoped
   namespace, and `object? sender` handlers; fix any nullable warnings.
3. Replace a `BackgroundWorker` with `async`/`await`.
