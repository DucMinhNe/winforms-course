# Exercise — High-DPI awareness

1. Ensure the app runs in `PerMonitorV2` (via `ApplicationConfiguration` or
   `Application.SetHighDpiMode(...)` / csproj).
2. Build a form whose layout uses `TableLayoutPanel`/`Anchor`/`Dock` and set
   `AutoScaleMode = AutoScaleMode.Dpi`.
3. Change Windows display scaling to 150% (or move the window to a scaled
   monitor) and confirm text is sharp and nothing clips.
4. In a custom-drawn control, multiply sizes by `DeviceDpi / 96f` and verify it
   scales.

**Done when:** the app is crisp (not stretched-blurry) at 100%, 150%, and 200%,
and the layout holds.
