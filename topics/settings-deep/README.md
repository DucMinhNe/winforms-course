# Topic: Settings, deeper

Where settings live, the two scopes, and modern alternatives.

## User vs Application scope

The designer-managed `Properties.Settings` has two scopes:

- **User** — per-user, **read/write at runtime**, persisted to a per-user file.
  Use for preferences: window bounds, theme, recent files, last folder.
- **Application** — **read-only at runtime**, shared defaults compiled into
  `App.config`. Use for things like an API base URL that's fixed per build.

```csharp
Properties.Settings.Default.Theme = "Dark";   // user scope only
Properties.Settings.Default.Save();            // persist to disk
```

## Where the file actually is

User settings are written to a `user.config` under
`%LocalAppData%\<Company>\<App>_<hash>\<version>\`. The version is in the path,
so **upgrading your app starts fresh** unless you call
`Properties.Settings.Default.Upgrade()` once after a version bump (a common
first-run pattern).

## Modern alternative: appsettings.json

For read-only/structured config, `Microsoft.Extensions.Configuration` +
`appsettings.json` (bound to a POCO) is the modern .NET approach and pairs with
DI:

```csharp
var config = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json", optional: true)
    .Build();
var apiUrl = config["Api:BaseUrl"];
```

For *writable* user prefs, the Settings system (or your own JSON file via the
files lesson) is simpler than rolling config writes by hand.

## Rules of thumb

- User prefs → `Settings` (user scope) or a JSON file in `%AppData%`.
- Fixed config/secrets → `appsettings.json` / environment (never hard-code
  secrets).
- Handle the version-upgrade reset with `Upgrade()` on first run after an
  update.

## Example

See `examples/settings-notes.txt`.

## Exercise

1. Add a **user**-scope setting and a **read-only application** setting; confirm
   only the user one is writable at runtime.
2. Implement the first-run `Upgrade()` pattern (a bool `HasUpgraded` user
   setting gating a one-time `Upgrade()`).
3. (Bonus) Load a read-only value from `appsettings.json` with
   `Microsoft.Extensions.Configuration`.
