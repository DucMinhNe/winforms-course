using System;
using System.Drawing;
using System.Windows.Forms;

namespace HelloForms;

public class DisposalDemo : Form
{
    // Long-lived resource: create once, dispose with the form.
    private readonly Font _titleFont = new("Segoe UI", 16f, FontStyle.Bold);

    public DisposalDemo()
    {
        Text = "Disposal";
        ClientSize = new Size(320, 200);
        DoubleBuffered = true;

        // Example of a leak-prone subscription + its fix:
        AppEvents.Tick += OnTick;
        FormClosed += (s, e) => AppEvents.Tick -= OnTick;   // unsubscribe!
    }

    private void OnTick(object? sender, EventArgs e) { /* ... */ }

    protected override void OnPaint(PaintEventArgs e)
    {
        base.OnPaint(e);

        // Short-lived GDI objects → using, disposed immediately.
        using var pen = new Pen(Color.SteelBlue, 3);
        using var brush = new SolidBrush(Color.FromArgb(40, Color.SteelBlue));
        e.Graphics.FillRectangle(brush, 20, 60, 280, 100);
        e.Graphics.DrawRectangle(pen, 20, 60, 280, 100);

        // Reuse the cached long-lived font (do NOT dispose e.Graphics).
        e.Graphics.DrawString("Disposal demo", _titleFont, Brushes.Black, 20, 20);
    }

    protected override void Dispose(bool disposing)
    {
        if (disposing) _titleFont.Dispose();   // free the field we own
        base.Dispose(disposing);
    }
}

// A stand-in long-lived publisher
static class AppEvents { public static event EventHandler? Tick; }
