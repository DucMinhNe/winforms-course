using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace HelloForms;

public class DrawingForm : Form
{
    private Color _fill = Color.SteelBlue;

    public DrawingForm()
    {
        Text = "GDI+";
        ClientSize = new Size(320, 240);
        DoubleBuffered = true;          // kill flicker

        var btn = new Button { Text = "Recolor", Dock = DockStyle.Bottom };
        btn.Click += (s, e) =>
        {
            _fill = _fill == Color.SteelBlue ? Color.IndianRed : Color.SteelBlue;
            Invalidate();               // request a repaint — do NOT draw here
        };
        Controls.Add(btn);
    }

    protected override void OnPaint(PaintEventArgs e)
    {
        base.OnPaint(e);
        var g = e.Graphics;
        g.SmoothingMode = SmoothingMode.AntiAlias;

        var rect = new Rectangle(30, 30, 240, 120);
        using var brush = new LinearGradientBrush(rect, _fill, Color.White, 45f);
        using var pen = new Pen(Color.FromArgb(180, _fill), 3);
        using var font = new Font("Segoe UI", 18f, FontStyle.Bold);

        g.FillRectangle(brush, rect);
        g.DrawRectangle(pen, rect);

        var text = "GDI+ drawing";
        var size = g.MeasureString(text, font);
        g.DrawString(text, font, Brushes.Black,
            rect.X + (rect.Width - size.Width) / 2,
            rect.Y + (rect.Height - size.Height) / 2);
        // Note: e.Graphics is NOT disposed — we don't own it.
    }
}
