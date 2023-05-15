using System;
using System.Drawing;
using System.Windows.Forms;

namespace HelloForms;

public class SignupForm : Form
{
    private readonly ErrorProvider _errors = new();
    private readonly TextBox _name = new() { Location = new Point(100, 20), Width = 200 };
    private readonly TextBox _email = new() { Location = new Point(100, 55), Width = 200 };

    public SignupForm()
    {
        Text = "Sign up";
        ClientSize = new Size(360, 160);

        _name.Validating += (s, e) =>
        {
            if (string.IsNullOrWhiteSpace(_name.Text))
            {
                _errors.SetError(_name, "Name is required");
                e.Cancel = true;
            }
            else _errors.SetError(_name, "");
        };

        _email.Validating += (s, e) =>
        {
            if (!_email.Text.Contains('@'))
            {
                _errors.SetError(_email, "Enter a valid email");
                e.Cancel = true;
            }
            else _errors.SetError(_email, "");
        };

        var submit = new Button { Text = "Submit", Location = new Point(100, 100) };
        submit.Click += (s, e) =>
        {
            if (ValidateChildren())                  // runs every Validating handler
                MessageBox.Show(this, $"Welcome, {_name.Text}!");
        };

        Controls.AddRange(new Control[]
        {
            new Label { Text = "Name:", Location = new Point(20, 23), AutoSize = true }, _name,
            new Label { Text = "Email:", Location = new Point(20, 58), AutoSize = true }, _email,
            submit,
        });
    }
}
