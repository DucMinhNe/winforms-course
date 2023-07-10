# Topic: Custom-painted controls

Build a control that draws itself — a gauge, a sparkline, a rating star.

## Subclass and override OnPaint

Inherit a control (often `Control` for a blank canvas) and paint in `OnPaint`.
Expose properties; call `Invalidate()` in their setters so the control repaints
when state changes.

```csharp
public class RatingControl : Control
{
    private int _value;
    public int Value
    {
        get => _value;
        set { _value = Math.Clamp(value, 0, 5); Invalidate(); }   // repaint on change
    }

    public RatingControl()
    {
        SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint
               | ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw, true);
        Size = new Size(150, 30);
    }

    protected override void OnPaint(PaintEventArgs e)
    {
        for (int i = 0; i < 5; i++)
            e.Graphics.FillRectangle(i < _value ? Brushes.Gold : Brushes.LightGray,
                i * 30, 0, 26, Height);
    }
}
```

## Make it interactive

Override `OnMouseDown` to set `Value` from `e.X`, and `OnMouseMove` for hover.
`ResizeRedraw` repaints on resize; `OptimizedDoubleBuffer` removes flicker.

## Owner-drawing built-in controls

You don't always need a new control — many support owner draw:
`ListBox.DrawMode = OwnerDrawFixed` + `DrawItem`, `ComboBox` `DrawItem`,
`TabControl` `DrawItem`, custom `DataGridView` cell painting. Same idea: handle
the draw event and render yourself.

## Example

See `examples/RatingControl.cs`.

## Exercise

1. Build a `RatingControl : Control` that draws 5 stars/blocks and exposes an
   `int Value` (0–5) that repaints via `Invalidate()`.
2. Set `Value` from a mouse click (`OnMouseDown`, map `e.X` to a star index).
3. Drop two of them on a form and read their values.
