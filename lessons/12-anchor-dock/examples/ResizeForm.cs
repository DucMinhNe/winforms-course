using System.Drawing;
using System.Windows.Forms;

namespace HelloForms;

public class ResizeForm : Form
{
    public ResizeForm()
    {
        Text = "Resize me!";
        ClientSize = new Size(420, 300);
        MinimumSize = new Size(300, 200);

        // Search box stretches horizontally with the window
        var txtSearch = new TextBox
        {
            Location = new Point(12, 12),
            Width = ClientSize.Width - 24,
            Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right,
            PlaceholderText = "Search...",
        };

        // Content area fills the middle (docked Fill in its own panel)
        var content = new Panel
        {
            Location = new Point(12, 44),
            Size = new Size(ClientSize.Width - 24, ClientSize.Height - 92),
            Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right,
            BorderStyle = BorderStyle.FixedSingle,
        };
        content.Controls.Add(new ListBox { Dock = DockStyle.Fill });

        // Buttons hug the bottom-right corner
        var btnCancel = new Button { Text = "Cancel", Anchor = AnchorStyles.Bottom | AnchorStyles.Right };
        btnCancel.Location = new Point(ClientSize.Width - 92, ClientSize.Height - 36);
        var btnOk = new Button { Text = "OK", Anchor = AnchorStyles.Bottom | AnchorStyles.Right };
        btnOk.Location = new Point(ClientSize.Width - 184, ClientSize.Height - 36);

        Controls.AddRange(new Control[] { txtSearch, content, btnOk, btnCancel });
    }
}
