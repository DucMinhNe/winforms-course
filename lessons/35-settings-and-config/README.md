# Lesson 35: Settings & configuration

Remember user preferences between runs.

## What you'll learn

- **Application Settings** (`Properties.Settings`): a designer-managed store with
  two scopes:
  - **User** — per-user, **writable at runtime** (window size, theme, last
    folder). Saved to a per-user file.
  - **Application** — read-only at runtime (defaults baked in).
- Read/write user settings, then persist:
  ```csharp
  Properties.Settings.Default.LastName = txtName.Text;
  Properties.Settings.Default.Save();          // write to disk
  ```
- A common pattern: restore window bounds on `Load`, save them on
  `FormClosing`.
- For app-wide read-only config, `appsettings.json` +
  `Microsoft.Extensions.Configuration` is the modern alternative; classic apps
  use `app.config`'s `<appSettings>` via `ConfigurationManager.AppSettings`.

## Example

See `examples/SettingsUsage.cs`.

## Exercise

1. Add a user setting `UserName` (string) and `WindowSize` (Size) in the
   project Settings designer.
2. On `Load`, restore them (pre-fill a textbox, set the form size).
3. On `FormClosing`, save the current values with
   `Properties.Settings.Default.Save()`.
4. Restart and confirm the name and window size are remembered.
