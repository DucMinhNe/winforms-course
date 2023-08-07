# Exercise — The MVP pattern

1. Define `ILoginView` with `Username`, `Password`, a `LoginClicked` event, and
   `ShowError`/`ShowSuccess` methods.
2. Implement it on a `LoginForm` (the form only forwards the click event and
   renders results).
3. Write `LoginPresenter(ILoginView view, IAuthService auth)` that handles
   `LoginClicked`, validates, and calls back into the view.
4. Wire them in `Program.cs`: create the form, the service, the presenter, then
   `Application.Run(form)`.

**Done when:** the presenter contains the logic and references only interfaces —
ready to unit-test in the next topic.
