using System.Drawing;
using System.Windows.Forms;

namespace HelloForms;

public class ConfirmForm : Form
{
    public ConfirmForm()
    {
        Text = "MessageBox demo";
        ClientSize = new Size(300, 140);

        var btnDelete = new Button { Text = "Delete", Location = new Point(20, 20) };
        var status = new Label { Location = new Point(20, 90), AutoSize = true };

        btnDelete.Click += (s, e) =>
        {
            var result = MessageBox.Show(
                this,                                   // owner → centred on this form
                "Delete this file? This cannot be undone.",
                "Confirm delete",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning,
                MessageBoxDefaultButton.Button2);       // default to "No"

            status.Text = result == DialogResult.Yes ? "Deleted." : "Cancelled.";
        };

        // Confirm before closing
        FormClosing += (s, e) =>
        {
            var r = MessageBox.Show(this, "Quit the app?", "Confirm",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (r == DialogResult.No) e.Cancel = true;   // veto the close
        };

        Controls.Add(btnDelete);
        Controls.Add(status);
    }
}
