using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace HelloForms;

public class DialogsForm : Form
{
    private readonly TextBox _editor = new()
    {
        Dock = DockStyle.Fill,
        Multiline = true,
        ScrollBars = ScrollBars.Both,
    };

    public DialogsForm()
    {
        Text = "Mini editor";
        ClientSize = new Size(500, 360);

        var bar = new FlowLayoutPanel { Dock = DockStyle.Top, AutoSize = true };
        bar.Controls.Add(MakeButton("Open", Open));
        bar.Controls.Add(MakeButton("Save", Save));
        bar.Controls.Add(MakeButton("Color", PickColor));
        bar.Controls.Add(MakeButton("Font", PickFont));

        Controls.Add(_editor);
        Controls.Add(bar);
    }

    private static Button MakeButton(string text, System.Action onClick)
    {
        var b = new Button { Text = text, AutoSize = true, Margin = new Padding(4) };
        b.Click += (s, e) => onClick();
        return b;
    }

    private void Open()
    {
        using var dlg = new OpenFileDialog { Filter = "Text files|*.txt|All files|*.*" };
        if (dlg.ShowDialog(this) == DialogResult.OK)
            _editor.Text = File.ReadAllText(dlg.FileName);
    }

    private void Save()
    {
        using var dlg = new SaveFileDialog { Filter = "Text files|*.txt", DefaultExt = "txt" };
        if (dlg.ShowDialog(this) == DialogResult.OK)
            File.WriteAllText(dlg.FileName, _editor.Text);
    }

    private void PickColor()
    {
        using var dlg = new ColorDialog { Color = _editor.BackColor };
        if (dlg.ShowDialog(this) == DialogResult.OK)
            _editor.BackColor = dlg.Color;
    }

    private void PickFont()
    {
        using var dlg = new FontDialog { Font = _editor.Font };
        if (dlg.ShowDialog(this) == DialogResult.OK)
            _editor.Font = dlg.Font;
    }
}
