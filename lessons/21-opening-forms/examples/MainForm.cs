using System.Drawing;
using System.Windows.Forms;

namespace HelloForms;

public class MainForm : Form
{
    public MainForm()
    {
        Text = "Main";
        ClientSize = new Size(300, 160);

        var btnModeless = new Button { Text = "Open modeless (Show)", Location = new Point(20, 20), Width = 200 };
        btnModeless.Click += (s, e) =>
        {
            var child = new ChildForm();
            child.Show(this);   // returns immediately; both windows usable
        };

        var btnModal = new Button { Text = "Open dialog (ShowDialog)", Location = new Point(20, 60), Width = 200 };
        var lbl = new Label { Location = new Point(20, 110), AutoSize = true };
        btnModal.Click += (s, e) =>
        {
            using var dlg = new ChildForm();           // dispose when done
            var result = dlg.ShowDialog(this);          // BLOCKS until closed
            lbl.Text = $"Dialog returned: {result}";
        };

        Controls.AddRange(new Control[] { btnModeless, btnModal, lbl });
    }
}
