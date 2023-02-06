using System.Drawing;
using System.Windows.Forms;

namespace HelloForms;

// A form built entirely in code — this is what the designer generates for you.
public class MainForm : Form
{
    public MainForm()
    {
        // Form properties
        Text = "My First Form";
        Size = new Size(400, 250);
        StartPosition = FormStartPosition.CenterScreen;

        // A label
        var label = new Label
        {
            Text = "Hello, WinForms!",
            AutoSize = true,
            Location = new Point(20, 20),
            Font = new Font("Segoe UI", 12f),
        };

        // A button
        var button = new Button
        {
            Text = "Click me",
            Location = new Point(20, 60),
            Width = 120,
        };
        button.Click += (sender, e) => label.Text = "You clicked the button!";

        // Add controls to the form's control collection
        Controls.Add(label);
        Controls.Add(button);
    }
}
