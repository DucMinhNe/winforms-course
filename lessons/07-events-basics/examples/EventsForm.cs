using System;
using System.Drawing;
using System.Windows.Forms;

namespace HelloForms;

public class EventsForm : Form
{
    private readonly TextBox _display = new() { Location = new Point(20, 20), Width = 240, ReadOnly = true };
    private readonly Label _count = new() { Location = new Point(20, 110), AutoSize = true };

    public EventsForm()
    {
        Text = "Events";
        ClientSize = new Size(300, 160);
        Controls.Add(_display);
        Controls.Add(_count);

        // Three buttons sharing ONE handler — disambiguated via sender
        var x = 20;
        foreach (var digit in new[] { "1", "2", "3" })
        {
            var btn = new Button { Text = digit, Location = new Point(x, 60), Width = 60 };
            btn.Click += Digit_Click;     // method-group attach
            Controls.Add(btn);
            x += 70;
        }

        // Live character count
        _display.TextChanged += (sender, e) => _count.Text = $"{_display.Text.Length} chars";
    }

    private void Digit_Click(object? sender, EventArgs e)
    {
        var btn = (Button)sender!;        // which button fired it?
        _display.Text += btn.Text;
    }
}
