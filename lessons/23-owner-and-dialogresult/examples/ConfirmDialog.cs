using System.Drawing;
using System.Windows.Forms;

namespace HelloForms;

public class ConfirmDialog : Form
{
    public ConfirmDialog(string message)
    {
        Text = "Confirm";
        ClientSize = new Size(280, 120);
        FormBorderStyle = FormBorderStyle.FixedDialog;
        MaximizeBox = MinimizeBox = false;
        StartPosition = FormStartPosition.CenterParent;   // needs an owner
        ShowInTaskbar = false;

        Controls.Add(new Label { Text = message, Location = new Point(20, 20), AutoSize = true });

        // Setting DialogResult on a button makes it close the dialog and
        // return that value from ShowDialog() — no Close() needed.
        var ok = new Button { Text = "Save", DialogResult = DialogResult.OK, Location = new Point(40, 60) };
        var cancel = new Button { Text = "Cancel", DialogResult = DialogResult.Cancel, Location = new Point(150, 60) };

        Controls.Add(ok);
        Controls.Add(cancel);
        AcceptButton = ok;       // Enter = Save
        CancelButton = cancel;   // Esc  = Cancel
    }
}

// Parent:
//   using var dlg = new ConfirmDialog("Save your changes?");
//   if (dlg.ShowDialog(this) == DialogResult.OK) { /* save */ }
