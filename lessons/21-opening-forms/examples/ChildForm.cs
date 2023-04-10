using System.Drawing;
using System.Windows.Forms;

namespace HelloForms;

public class ChildForm : Form
{
    public ChildForm()
    {
        Text = "Child";
        ClientSize = new Size(240, 120);
        StartPosition = FormStartPosition.CenterParent;

        // Buttons with a DialogResult auto-close a modal dialog and return it.
        var ok = new Button { Text = "OK", DialogResult = DialogResult.OK, Location = new Point(30, 40) };
        var cancel = new Button { Text = "Cancel", DialogResult = DialogResult.Cancel, Location = new Point(130, 40) };

        Controls.Add(ok);
        Controls.Add(cancel);
        AcceptButton = ok;
        CancelButton = cancel;
    }
}
