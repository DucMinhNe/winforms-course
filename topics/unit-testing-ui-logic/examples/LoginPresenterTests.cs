using System;
using Xunit;

namespace HelloForms.Tests;

// Fakes implement the same interfaces the presenter depends on — no WinForms.
internal class FakeAuth : IAuthService
{
    private readonly bool _valid;
    public FakeAuth(bool valid) => _valid = valid;
    public bool Validate(string user, string pass) => _valid;
}

internal class FakeLoginView : ILoginView
{
    public string Username { get; set; } = "";
    public string Password { get; set; } = "";
    public event EventHandler? LoginClicked;

    public bool SuccessShown { get; private set; }
    public string? LastError { get; private set; }

    public void ShowSuccess() => SuccessShown = true;
    public void ShowError(string message) => LastError = message;

    public void RaiseLogin() => LoginClicked?.Invoke(this, EventArgs.Empty);
}

public class LoginPresenterTests
{
    [Fact]
    public void Valid_credentials_show_success()
    {
        var view = new FakeLoginView { Username = "alice", Password = "secret" };
        _ = new LoginPresenter(view, new FakeAuth(valid: true));

        view.RaiseLogin();

        Assert.True(view.SuccessShown);
        Assert.Null(view.LastError);
    }

    [Fact]
    public void Invalid_credentials_show_error()
    {
        var view = new FakeLoginView { Username = "bob", Password = "wrong" };
        _ = new LoginPresenter(view, new FakeAuth(valid: false));

        view.RaiseLogin();

        Assert.False(view.SuccessShown);
        Assert.Equal("Invalid credentials", view.LastError);
    }
}
