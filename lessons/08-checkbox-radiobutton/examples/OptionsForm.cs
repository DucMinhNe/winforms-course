using System;
using System.Drawing;
using System.Windows.Forms;

namespace HelloForms;

public class OptionsForm : Form
{
    public OptionsForm()
    {
        Text = "Options";
        ClientSize = new Size(320, 240);

        var chkAgree = new CheckBox { Text = "I agree to the terms", Location = new Point(20, 20), AutoSize = true };
        var btnNext = new Button { Text = "Continue", Location = new Point(20, 50), Enabled = false };
        chkAgree.CheckedChanged += (s, e) => btnNext.Enabled = chkAgree.Checked;

        // RadioButtons grouped by their container → mutually exclusive
        var group = new GroupBox { Text = "Size", Location = new Point(20, 90), Size = new Size(180, 110) };
        var rbS = new RadioButton { Text = "Small",  Location = new Point(15, 25), AutoSize = true };
        var rbM = new RadioButton { Text = "Medium", Location = new Point(15, 50), AutoSize = true, Checked = true };
        var rbL = new RadioButton { Text = "Large",  Location = new Point(15, 75), AutoSize = true };
        group.Controls.AddRange(new Control[] { rbS, rbM, rbL });

        var lblChoice = new Label { Location = new Point(210, 120), AutoSize = true };
        void Update(object? s, EventArgs e)
        {
            lblChoice.Text = rbS.Checked ? "S" : rbL.Checked ? "L" : "M";
        }
        rbS.CheckedChanged += Update;
        rbM.CheckedChanged += Update;
        rbL.CheckedChanged += Update;
        Update(null, EventArgs.Empty);

        Controls.AddRange(new Control[] { chkAgree, btnNext, group, lblChoice });
    }
}
