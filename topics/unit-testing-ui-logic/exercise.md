# Exercise — Unit-testing UI logic

1. Create an xUnit test project and reference your app project:
   ```bash
   dotnet new xunit -n HelloForms.Tests
   dotnet add HelloForms.Tests reference HelloForms.csproj
   ```
2. Write a `FakeLoginView : ILoginView` that records `ShowSuccess`/`ShowError`
   calls and can `RaiseLogin()`. Write a `FakeAuth : IAuthService`.
3. Test both paths: valid creds → `SuccessShown` true; invalid → the right error
   message. Construct the presenter, call `RaiseLogin()`, assert.
4. Run `dotnet test` — it passes with **no form created** and works on headless
   CI.

**Done when:** your presenter's behaviour is verified by tests that never touch
a real WinForms control.
