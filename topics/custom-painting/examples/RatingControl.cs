using System;
using System.Drawing;
using System.Windows.Forms;

namespace HelloForms;

// A self-drawing 0–5 rating control.
public class RatingControl : Control
{
    private const int Star = 30;
    private int _value;

    public event EventHandler? ValueChanged;

    public int Value
    {
        get => _value;
        set
        {
            value = Math.Clamp(value, 0, 5);
            if (_value == value) return;
            _value = value;
            Invalidate();                       // trigger repaint
            ValueChanged?.Invoke(this, EventArgs.Empty);
        }
    }

    public RatingControl()
    {
        // Flicker-free, redraw on resize, we own all painting.
        SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint
               | ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw, true);
        Size = new Size(Star * 5, Star);
        Cursor = Cursors.Hand;
    }

    protected override void OnPaint(PaintEventArgs e)
    {
        for (int i = 0; i < 5; i++)
        {
            var brush = i < _value ? Brushes.Gold : Brushes.Gainsboro;
            e.Graphics.FillEllipse(brush, i * Star + 2, 2, Star - 6, Height - 6);
        }
    }

    protected override void OnMouseDown(MouseEventArgs e)
    {
        base.OnMouseDown(e);
        Value = Math.Clamp(e.X / Star + 1, 0, 5);   // click sets the rating
    }
}
