# Topic: The MVP pattern

Separate UI from logic so you can test the logic without a window.

## Why

Code-behind that mixes UI and business rules can only be tested by clicking.
**Model-View-Presenter** extracts the logic into a **Presenter** that talks to
the **View** through an interface — so you can unit-test the Presenter with a
fake view, no WinForms required.

## The pieces

- **View interface** (`ILoginView`) — exposes what the presenter needs:
  properties for inputs, methods to show results, events for user actions.
- **The Form implements the View interface** — thin: it forwards events and
  renders what it's told.
- **Presenter** — holds a reference to `IView`, subscribes to its events, runs
  logic, calls back into the view. No WinForms types inside.

```csharp
public interface ILoginView
{
    string Username { get; }
    string Password { get; }
    event EventHandler LoginClicked;
    void ShowError(string message);
    void ShowSuccess();
}

public class LoginPresenter
{
    private readonly ILoginView _view;
    private readonly IAuthService _auth;

    public LoginPresenter(ILoginView view, IAuthService auth)
    {
        _view = view; _auth = auth;
        _view.LoginClicked += (s, e) => HandleLogin();
    }

    private void HandleLogin()
    {
        if (_auth.Validate(_view.Username, _view.Password)) _view.ShowSuccess();
        else _view.ShowError("Invalid credentials");
    }
}
```

## Payoff

The presenter is plain C# — unit-test it with a stub `ILoginView` and a fake
`IAuthService`. The form stays dumb. Pairs naturally with
[dependency-injection](../dependency-injection/) and
[unit-testing-ui-logic](../unit-testing-ui-logic/).

## Example

See `examples/Login.cs`.

## Exercise

1. Define `ILoginView` (Username, Password, `LoginClicked`, `ShowError`,
   `ShowSuccess`).
2. Implement it on a `LoginForm`.
3. Write `LoginPresenter` that validates via an `IAuthService` and calls back.
4. (Next topic) unit-test the presenter with a fake view — no form needed.
