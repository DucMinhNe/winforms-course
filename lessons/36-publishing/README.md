# Lesson 36: Publishing your app

Turn your project into something you can hand to a user.

## What you'll learn

- **`dotnet publish`** builds a distributable. Key options:
  - `-c Release` — optimised build.
  - `-r win-x64` — target runtime.
  - **Self-contained** (`--self-contained true`) bundles the .NET runtime, so
    users don't need .NET installed (bigger output). **Framework-dependent**
    (default) is small but needs the runtime present.
  - **Single file** (`-p:PublishSingleFile=true`) packs everything into one
    `.exe`.
  - **Trimming** (`-p:PublishTrimmed=true`) drops unused code to shrink it
    (test carefully — reflection can break).
- Visual Studio: **Build ▸ Publish** wizard wraps the same options, and can
  produce a **ClickOnce** installer with auto-update.
- Set the app icon (`<ApplicationIcon>` in the `.csproj`) and version
  (`<Version>`).

```bash
dotnet publish -c Release -r win-x64 --self-contained true \
  -p:PublishSingleFile=true
# → bin/Release/net7.0-windows/win-x64/publish/HelloForms.exe
```

## Example

See `examples/publish-commands.txt`.

## Exercise

1. Publish your app **framework-dependent** and note the output size.
2. Publish it **self-contained + single-file** for `win-x64` and run the single
   `.exe` on a machine path without your project.
3. Set an `<ApplicationIcon>` and `<Version>` in the `.csproj` and confirm the
   exe shows them.

**Done when:** you have a runnable `.exe` and understand the trade-off between
self-contained (portable, large) and framework-dependent (small, needs .NET).
