# Exercise — Dependency injection

1. `dotnet add package Microsoft.Extensions.DependencyInjection`.
2. In `Program.Main`, build a `ServiceCollection`:
   - `AddSingleton<IClock, SystemClock>()`
   - `AddTransient<MainForm>()`
3. Give `MainForm` a constructor `MainForm(IClock clock)`; use `clock.Now` in
   the title. Resolve it with `provider.GetRequiredService<MainForm>()` and
   `Application.Run(...)` it.
4. (Bonus) Register `EditForm` + a `Func<EditForm>` factory; open the child form
   via the factory so it, too, is container-built.

**Done when:** no form `new`s its own services — the container injects them, and
you can swap `IClock` for a fake in a test.
