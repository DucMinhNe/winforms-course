# Exercise — Settings, deeper

1. In the Settings designer add: a **User** setting `Theme` (string) and an
   **Application** setting `Channel` (string). Confirm you can assign `Theme` at
   runtime but `Channel` is read-only.
2. Implement the upgrade pattern: a `HasUpgraded` (bool, user) setting that
   gates a one-time `Properties.Settings.Default.Upgrade()` on startup, then
   sets `HasUpgraded = true` and saves. Bump `<Version>` and confirm settings
   carry forward.
3. (Bonus) Add `appsettings.json` with an `Api:BaseUrl`, read it via
   `Microsoft.Extensions.Configuration`, and show it on the form.

**Done when:** user prefs persist and survive a version bump via `Upgrade()`,
and you can explain user vs application scope.
