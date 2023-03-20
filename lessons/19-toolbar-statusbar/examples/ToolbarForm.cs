using System.Drawing;
using System.Windows.Forms;

namespace HelloForms;

public class ToolbarForm : Form
{
    private readonly TextBox _editor = new() { Dock = DockStyle.Fill, Multiline = true };
    private readonly ToolStripStatusLabel _info = new() { Spring = true, TextAlign = ContentAlignment.MiddleLeft };
    private readonly ToolStripStatusLabel _count = new();

    public ToolbarForm()
    {
        Text = "Toolbar & status";
        ClientSize = new Size(480, 320);

        // Toolbar
        var tool = new ToolStrip();
        foreach (var name in new[] { "New", "Open", "Save" })
        {
            var btn = new ToolStripButton(name) { DisplayStyle = ToolStripItemDisplayStyle.Text };
            btn.Click += (s, e) => _info.Text = $"{name} clicked";
            tool.Items.Add(btn);
        }

        // Status bar: stretchy label on the left, count on the right
        var status = new StatusStrip();
        status.Items.Add(_info);
        status.Items.Add(_count);
        _info.Text = "Ready";

        _editor.TextChanged += (s, e) => _count.Text = $"{_editor.TextLength} chars";
        _count.Text = "0 chars";

        // Fill content first, then docked bars
        Controls.Add(_editor);
        Controls.Add(tool);     // docks Top
        Controls.Add(status);   // docks Bottom
    }
}
