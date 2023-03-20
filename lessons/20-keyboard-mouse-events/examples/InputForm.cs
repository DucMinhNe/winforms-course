using System;
using System.Drawing;
using System.Windows.Forms;

namespace HelloForms;

public class InputForm : Form
{
    public InputForm()
    {
        Text = "Keyboard & mouse";
        ClientSize = new Size(360, 240);
        KeyPreview = true;   // form sees keys before the focused control

        // Digits-only textbox
        var digits = new TextBox { Location = new Point(20, 20), Width = 200, PlaceholderText = "digits only" };
        digits.KeyPress += (s, e) =>
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                e.Handled = true;     // reject non-digits
        };

        // Live mouse coordinates over a panel
        var pad = new Panel
        {
            Location = new Point(20, 60),
            Size = new Size(320, 120),
            BorderStyle = BorderStyle.FixedSingle,
            BackColor = Color.WhiteSmoke,
        };
        var coords = new Label { Location = new Point(8, 8), AutoSize = true, Parent = pad };
        pad.MouseMove += (s, e) => coords.Text = $"X={e.X}, Y={e.Y}";

        // Ctrl+S from anywhere
        KeyDown += (s, e) =>
        {
            if (e.Control && e.KeyCode == Keys.S)
            {
                MessageBox.Show(this, "Saved!");
                e.SuppressKeyPress = true;   // don't beep / pass it on
            }
        };

        Controls.Add(digits);
        Controls.Add(pad);
    }
}
