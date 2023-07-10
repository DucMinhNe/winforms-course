# Topic: GDI+ drawing

Draw your own graphics with the `Graphics` API.

## Where to draw: the Paint event

Override `OnPaint` (or handle `Paint`) and use `e.Graphics`. **Never** cache or
dispose `e.Graphics` — you don't own it. Windows calls Paint whenever the
control needs redrawing; call `Invalidate()` to request a repaint.

```csharp
protected override void OnPaint(PaintEventArgs e)
{
    base.OnPaint(e);
    var g = e.Graphics;
    g.SmoothingMode = SmoothingMode.AntiAlias;

    using var pen = new Pen(Color.SteelBlue, 3);
    using var brush = new SolidBrush(Color.FromArgb(60, Color.SteelBlue));
    g.FillEllipse(brush, 20, 20, 120, 80);
    g.DrawEllipse(pen, 20, 20, 120, 80);
    g.DrawString("GDI+", Font, Brushes.Black, 30, 50);
}
```

## The toolbox

- **Pen** (outlines), **Brush** (fills: `SolidBrush`, `LinearGradientBrush`,
  `TextureBrush`), **Font** + `DrawString`, `Color`.
- Shapes: `DrawLine`, `DrawRectangle`/`FillRectangle`, `DrawEllipse`,
  `DrawPolygon`, `DrawArc`, `DrawPath` (with `GraphicsPath`), `DrawImage`.
- `SmoothingMode.AntiAlias` for smooth curves; `TextRenderingHint` for text.

## Flicker → double buffering

Custom drawing flickers without buffering. Set `DoubleBuffered = true` on the
form/control (or the `OptimizedDoubleBuffer` control style). This draws to an
off-screen buffer then blits it once.

## Invalidate to animate/update

Don't draw outside Paint. To change what's shown, update your state and call
`Invalidate()` (optionally a rectangle) to trigger a repaint.

## Example

See `examples/DrawingForm.cs`.

## Exercise

1. A form (`DoubleBuffered = true`) that in `OnPaint` draws an anti-aliased
   filled rounded rect with a gradient brush and a centered string.
2. A button that changes a color field and calls `Invalidate()` to redraw.
3. Confirm GDI objects are scoped with `using` and `e.Graphics` is never
   disposed.
