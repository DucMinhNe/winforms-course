# Topic: Dependency injection

Wire your forms and services with `Microsoft.Extensions.DependencyInjection`.

## Why

`new`-ing services inside a form hard-wires dependencies and blocks testing. A
DI container builds the object graph for you and hands forms their dependencies
through the constructor.

## Setup (.NET 6/7 WinForms)

```bash
dotnet add package Microsoft.Extensions.DependencyInjection
```

```csharp
static class Program
{
    [STAThread]
    static void Main()
    {
        ApplicationConfiguration.Initialize();

        var services = new ServiceCollection();
        services.AddSingleton<IAuthService, RealAuthService>();
        services.AddTransient<MainForm>();           // forms can be injected too
        using var provider = services.BuildServiceProvider();

        Application.Run(provider.GetRequiredService<MainForm>());
    }
}
```

```csharp
public partial class MainForm : Form
{
    private readonly IAuthService _auth;
    public MainForm(IAuthService auth)   // injected by the container
    {
        InitializeComponent();
        _auth = auth;
    }
}
```

## Lifetimes

- **Singleton** — one instance for the app (config, caches, a logger).
- **Transient** — a new instance every resolve (most forms, lightweight
  services).
- **Scoped** — per-scope; less common in desktop, useful around a unit of work.

## Opening child forms with DI

Inject a factory (`Func<EditForm>` or `IServiceProvider`) so child forms get
their dependencies too, instead of `new`-ing them and losing injection.

## Example

See `examples/Program.cs`.

## Exercise

1. Add the DI package; register an `IClock`/`IAuthService` and your `MainForm`.
2. Inject the service into `MainForm` via its constructor; use it in an action.
3. Resolve and run `MainForm` from the provider in `Program.Main`.
4. (Bonus) Inject a `Func<EditForm>` factory and use it to open a child form.
