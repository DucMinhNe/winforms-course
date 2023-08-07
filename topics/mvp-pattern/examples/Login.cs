using System;
using System.Drawing;
using System.Windows.Forms;

namespace HelloForms;

// --- Contracts (no WinForms types) ---
public interface IAuthService { bool Validate(string user, string pass); }

public interface ILoginView
{
    string Username { get; }
    string Password { get; }
    event EventHandler LoginClicked;
    void ShowError(string message);
    void ShowSuccess();
}

// --- Presenter: pure logic, testable with a fake view ---
public class LoginPresenter
{
    private readonly ILoginView _view;
    private readonly IAuthService _auth;

    public LoginPresenter(ILoginView view, IAuthService auth)
    {
        _view = view;
        _auth = auth;
        _view.LoginClicked += (s, e) => HandleLogin();
    }

    private void HandleLogin()
    {
        if (_auth.Validate(_view.Username, _view.Password)) _view.ShowSuccess();
        else _view.ShowError("Invalid credentials");
    }
}

// --- The Form just implements the view interface (thin) ---
public class LoginForm : Form, ILoginView
{
    private readonly TextBox _user = new() { Location = new(100, 20), Width = 160 };
    private readonly TextBox _pass = new() { Location = new(100, 55), Width = 160, UseSystemPasswordChar = true };

    public LoginForm()
    {
        Text = "Login";
        ClientSize = new Size(300, 140);
        var btn = new Button { Text = "Log in", Location = new(100, 90) };
        btn.Click += (s, e) => LoginClicked?.Invoke(this, EventArgs.Empty);
        Controls.AddRange(new Control[]
        {
            new Label { Text = "User:", Location = new(20, 23), AutoSize = true }, _user,
            new Label { Text = "Pass:", Location = new(20, 58), AutoSize = true }, _pass, btn,
        });
    }

    public string Username => _user.Text;
    public string Password => _pass.Text;
    public event EventHandler? LoginClicked;
    public void ShowError(string message) => MessageBox.Show(this, message, "Error");
    public void ShowSuccess() => MessageBox.Show(this, "Welcome!");
}

// Wire-up:  var form = new LoginForm();
//           var presenter = new LoginPresenter(form, new RealAuthService());
//           Application.Run(form);
