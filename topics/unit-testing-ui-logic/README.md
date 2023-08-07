# Topic: Unit-testing UI logic

You can't easily click a button in a test — so move the logic where you can test
it.

## The principle

WinForms controls are hard to test (they need a message loop, a window). The
fix isn't a UI-automation tool; it's **architecture**: keep forms thin and put
logic in presenters/services that take interfaces. Then test those with no UI.

## Test a presenter with a fake view

Using the MVP setup from [mvp-pattern](../mvp-pattern/):

```csharp
// A hand-written fake view — no WinForms involved.
class FakeLoginView : ILoginView
{
    public string Username { get; set; } = "";
    public string Password { get; set; } = "";
    public event EventHandler? LoginClicked;
    public bool SuccessShown, ErrorShown;
    public void ShowSuccess() => SuccessShown = true;
    public void ShowError(string m) => ErrorShown = true;
    public void RaiseLogin() => LoginClicked?.Invoke(this, EventArgs.Empty);
}

[Fact]
public void Valid_credentials_show_success()
{
    var view = new FakeLoginView { Username = "a", Password = "p" };
    var auth = new FakeAuth(valid: true);
    _ = new LoginPresenter(view, auth);

    view.RaiseLogin();

    Assert.True(view.SuccessShown);
    Assert.False(view.ErrorShown);
}
```

## Setup

`dotnet new xunit` (or NUnit/MSTest) in a separate test project that references
the app. Mock services by hand or with Moq. Tests run on CI with no display —
because no real form is created.

## Rules of thumb

- Logic in a presenter/service = testable; logic in `button1_Click` = not.
- Depend on interfaces (`IAuthService`, `IClock`, `IFileStore`) so tests can
  substitute fakes.
- Keep `async void` handlers to a one-liner that calls a testable `Task`
  method.

## Example

See `examples/LoginPresenterTests.cs`.

## Exercise

1. Add an xUnit test project referencing your app.
2. Write a `FakeLoginView` and a `FakeAuthService`.
3. Test that valid creds call `ShowSuccess` and invalid creds call `ShowError`
   — with no form instantiated.
