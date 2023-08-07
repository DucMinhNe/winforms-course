using System;
using System.Windows.Forms;
using Microsoft.Extensions.DependencyInjection;

namespace HelloForms;

public interface IClock { DateTime Now { get; } }
public class SystemClock : IClock { public DateTime Now => DateTime.Now; }

static class Program
{
    [STAThread]
    static void Main()
    {
        ApplicationConfiguration.Initialize();

        var services = new ServiceCollection();
        services.AddSingleton<IClock, SystemClock>();   // one instance app-wide
        services.AddTransient<MainForm>();              // new form each resolve
        // A factory so child forms also get DI:
        services.AddTransient<Func<EditForm>>(sp => () => sp.GetRequiredService<EditForm>());
        services.AddTransient<EditForm>();

        using var provider = services.BuildServiceProvider();
        Application.Run(provider.GetRequiredService<MainForm>());
    }
}

public class MainForm : Form
{
    private readonly IClock _clock;
    private readonly Func<EditForm> _editFactory;

    // Dependencies arrive via the constructor — no `new`, fully testable.
    public MainForm(IClock clock, Func<EditForm> editFactory)
    {
        _clock = clock;
        _editFactory = editFactory;

        Text = $"Started at {_clock.Now:T}";
        var open = new Button { Text = "Open editor" };
        open.Click += (s, e) => { using var f = _editFactory(); f.ShowDialog(this); };
        Controls.Add(open);
    }
}

public class EditForm : Form { /* also constructed by the container */ }
