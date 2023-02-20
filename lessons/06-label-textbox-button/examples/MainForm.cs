using System;
using System.Drawing;
using System.Windows.Forms;

namespace HelloForms;

public class MainForm : Form
{
    public MainForm()
    {
        Text = "Greeter";
        ClientSize = new Size(360, 180);

        var lblName = new Label { Text = "Name:", Location = new Point(20, 24), AutoSize = true };
        var txtName = new TextBox { Location = new Point(80, 20), Width = 240, PlaceholderText = "Type your name" };
        var btnGreet = new Button { Text = "Greet", Location = new Point(80, 60), Width = 100 };
        var lblOutput = new Label { Location = new Point(20, 110), AutoSize = true, Font = new Font("Segoe UI", 12f) };

        btnGreet.Click += (sender, e) =>
        {
            lblOutput.Text = string.IsNullOrWhiteSpace(txtName.Text)
                ? "Please enter a name."
                : $"Hello, {txtName.Text}!";
        };

        Controls.AddRange(new Control[] { lblName, txtName, btnGreet, lblOutput });
        AcceptButton = btnGreet;   // Enter also greets
    }
}
