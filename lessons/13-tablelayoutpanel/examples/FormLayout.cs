using System.Windows.Forms;
using System.Drawing;

namespace HelloForms;

public class FormLayout : Form
{
    public FormLayout()
    {
        Text = "Contact";
        ClientSize = new Size(420, 320);

        var t = new TableLayoutPanel
        {
            Dock = DockStyle.Fill,
            Padding = new Padding(12),
            ColumnCount = 2,
            RowCount = 4,
        };
        // Columns: fixed label column + flexible input column
        t.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 90));
        t.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100));
        // Rows: two auto rows, one flexible (message), one auto (buttons)
        t.RowStyles.Add(new RowStyle(SizeType.AutoSize));
        t.RowStyles.Add(new RowStyle(SizeType.AutoSize));
        t.RowStyles.Add(new RowStyle(SizeType.Percent, 100));
        t.RowStyles.Add(new RowStyle(SizeType.AutoSize));

        t.Controls.Add(new Label { Text = "Name:", Anchor = AnchorStyles.Left, AutoSize = true }, 0, 0);
        t.Controls.Add(new TextBox { Dock = DockStyle.Fill }, 1, 0);

        t.Controls.Add(new Label { Text = "Email:", Anchor = AnchorStyles.Left, AutoSize = true }, 0, 1);
        t.Controls.Add(new TextBox { Dock = DockStyle.Fill }, 1, 1);

        t.Controls.Add(new Label { Text = "Message:", Anchor = AnchorStyles.Left | AnchorStyles.Top, AutoSize = true }, 0, 2);
        t.Controls.Add(new TextBox { Dock = DockStyle.Fill, Multiline = true }, 1, 2);

        var ok = new Button { Text = "Send", Anchor = AnchorStyles.Right, Width = 100 };
        t.Controls.Add(ok, 1, 3);

        Controls.Add(t);
    }
}
