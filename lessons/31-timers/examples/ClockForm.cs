using System;
using System.Drawing;
using System.Windows.Forms;

namespace HelloForms;

public class ClockForm : Form
{
    // Forms.Timer ticks on the UI thread — safe to update controls directly.
    private readonly System.Windows.Forms.Timer _timer = new() { Interval = 1000 };
    private int _countdown = 10;

    public ClockForm()
    {
        Text = "Clock";
        ClientSize = new Size(280, 160);

        var clock = new Label { Location = new Point(20, 20), AutoSize = true, Font = new Font("Consolas", 16f) };
        var count = new Label { Location = new Point(20, 70), AutoSize = true };
        var toggle = new Button { Text = "Stop", Location = new Point(20, 110) };

        _timer.Tick += (s, e) =>
        {
            clock.Text = DateTime.Now.ToLongTimeString();
            if (_countdown > 0) count.Text = $"Countdown: {--_countdown}";
            else count.Text = "Done!";
        };
        _timer.Start();

        toggle.Click += (s, e) =>
        {
            _timer.Enabled = !_timer.Enabled;
            toggle.Text = _timer.Enabled ? "Stop" : "Start";
        };

        // Clean up the timer with the form
        FormClosed += (s, e) => _timer.Dispose();

        Controls.AddRange(new Control[] { clock, count, toggle });
    }
}
