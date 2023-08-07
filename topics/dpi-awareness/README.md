# Topic: High-DPI awareness

Make your app crisp on 4K and scaled displays instead of blurry.

## The problem

On a 150%/200%-scaled monitor, a DPI-unaware app is **bitmap-stretched** by
Windows — blurry text, fuzzy controls. DPI-aware apps render at native
resolution and stay sharp.

## Declare awareness (.NET 6/7)

`ApplicationConfiguration.Initialize()` (the template's `Program.cs`) sets
`HighDpiMode` for you. To control it, configure in the `.csproj` or
`app.manifest`:

```xml
<!-- runtimeconfig / csproj -->
<PropertyGroup>
  <ApplicationHighDpiMode>PerMonitorV2</ApplicationHighDpiMode>
</PropertyGroup>
```

`PerMonitorV2` is the modern best mode: the app rescales correctly when dragged
between monitors of different scaling.

## Build scalable layouts

DPI awareness only helps if your layout scales. Avoid hard-coded pixel
positions; rely on:
- **TableLayoutPanel / FlowLayoutPanel / Anchor / Dock** (lessons 12–15),
- `AutoScaleMode = Dpi` (or `Font`) on forms,
- `AutoSize` where possible,
- vector/SVG or multiple-resolution images instead of one fixed bitmap.

## Gotchas

- A pixel-perfect designer layout can break at 150% — test at multiple scales.
- Custom GDI+ drawing should scale by the current DPI
  (`e.Graphics.DpiX / 96f`) or work in logical units.
- `Per-monitor` requires handling `DpiChanged` if you do custom layout math.

## Example

See `examples/dpi-config.txt`.

## Exercise

1. Confirm your app uses `PerMonitorV2` (via `ApplicationConfiguration` or the
   csproj setting).
2. Build a form using `TableLayoutPanel` + `AutoScaleMode = Dpi` and view it on
   a 150% display (or change Windows scaling) — text should stay sharp and
   layout intact.
3. In a custom-drawn control, scale sizes by `DeviceDpi / 96f` and verify it
   looks right when scaled.
