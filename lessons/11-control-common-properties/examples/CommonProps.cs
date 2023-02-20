using System;
using System.Drawing;
using System.Windows.Forms;

namespace HelloForms;

public class CommonProps : Form
{
    public CommonProps()
    {
        Text = "Common properties";
        ClientSize = new Size(360, 220);

        var lbl = new Label { Location = new Point(20, 150), AutoSize = true, Font = new Font("Segoe UI", 12f) };

        // Generate buttons in a loop; stash data in Tag; share one handler.
        for (int i = 1; i <= 5; i++)
        {
            var btn = new Button
            {
                Name = $"btn{i}",
                Text = $"#{i}",
                Tag = i,                               // arbitrary data on the control
                Location = new Point(20 + (i - 1) * 64, 20),
                Width = 56,
                TabIndex = i,                          // keyboard order
            };
            btn.Click += (sender, e) =>
            {
                var n = (int)((Button)sender!).Tag!;   // read it back
                lbl.Text = $"You clicked button {n}";
            };
            Controls.Add(btn);
        }

        // Toggle Enabled + Visible of another control
        var target = new TextBox { Location = new Point(20, 80), Width = 200, Text = "toggle me" };
        var toggle = new Button { Text = "Toggle", Location = new Point(240, 78) };
        toggle.Click += (s, e) =>
        {
            target.Enabled = !target.Enabled;
            // target.Visible = !target.Visible;   // or hide entirely
        };

        Controls.Add(target);
        Controls.Add(toggle);
        Controls.Add(lbl);
    }
}
