using System.Drawing;
using System.Windows.Forms;

namespace HelloForms;

// A typical fixed-size dialog configured purely via form properties.
public class DialogForm : Form
{
    public DialogForm()
    {
        var btnSave = new Button { Text = "Save", Location = new Point(60, 80), DialogResult = DialogResult.OK };
        var btnCancel = new Button { Text = "Cancel", Location = new Point(160, 80), DialogResult = DialogResult.Cancel };

        // ---- Form properties ----
        Text = "Settings";
        ClientSize = new Size(300, 130);
        FormBorderStyle = FormBorderStyle.FixedDialog;  // can't resize
        MaximizeBox = false;
        MinimizeBox = false;
        StartPosition = FormStartPosition.CenterParent;
        ShowInTaskbar = false;

        AcceptButton = btnSave;    // Enter key triggers Save
        CancelButton = btnCancel;  // Esc key triggers Cancel

        Controls.Add(btnSave);
        Controls.Add(btnCancel);
    }
}

// Shown with:  using var dlg = new DialogForm();
//              if (dlg.ShowDialog(this) == DialogResult.OK) { /* saved */ }
