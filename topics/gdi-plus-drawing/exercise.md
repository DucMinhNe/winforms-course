# Exercise — GDI+ drawing

1. Make a form with `DoubleBuffered = true`. In `OnPaint`, set
   `SmoothingMode.AntiAlias` and draw a gradient-filled rectangle
   (`LinearGradientBrush`) with an outline `Pen` and a centered string
   (`MeasureString` to center it).
2. Add a button that toggles a color field and calls `Invalidate()` — confirm
   the drawing updates and there's no flicker.
3. Verify every `Pen`/`Brush`/`Font` you create uses `using`, and you never
   dispose `e.Graphics`.

**Done when:** the custom graphics render smoothly, recolor on demand, and don't
flicker.
