using System.Drawing;
using System.Windows.Forms;

namespace HelloForms;

public class EditForm : Form
{
    private readonly TextBox _name;

    // Result exposed as a property — the parent reads it after OK.
    public string EnteredName { get; private set; } = "";

    // Data passed IN via the constructor.
    public EditForm(string initialName)
    {
        Text = "Edit name";
        ClientSize = new Size(260, 120);
        StartPosition = FormStartPosition.CenterParent;

        _name = new TextBox { Location = new Point(20, 20), Width = 220, Text = initialName };

        var ok = new Button { Text = "OK", Location = new Point(60, 60) };
        ok.Click += (s, e) =>
        {
            EnteredName = _name.Text.Trim();    // capture the result
            DialogResult = DialogResult.OK;     // closes the modal dialog
        };

        Controls.Add(_name);
        Controls.Add(ok);
        AcceptButton = ok;
    }
}

// Parent usage:
//   using var dlg = new EditForm("Marcus");
//   if (dlg.ShowDialog(this) == DialogResult.OK)
//       lbl.Text = dlg.EnteredName;
