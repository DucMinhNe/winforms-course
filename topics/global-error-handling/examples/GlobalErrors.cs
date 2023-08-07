using System;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HelloForms;

static class GlobalErrors
{
    private static readonly string LogPath =
        Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
                     "WinFormsCourse", "errors.log");

    [STAThread]
    static void Main()
    {
        Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);

        // UI-thread exceptions (incl. async void handlers) — app stays alive.
        Application.ThreadException += (s, e) =>
        {
            Log(e.Exception);
            MessageBox.Show("Something went wrong. The error has been logged.",
                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        };

        // Non-UI / fatal — log, then the process typically ends.
        AppDomain.CurrentDomain.UnhandledException += (s, e) => Log(e.ExceptionObject as Exception);

        // Faulted tasks that were never awaited.
        TaskScheduler.UnobservedTaskException += (s, e) => { Log(e.Exception); e.SetObserved(); };

        ApplicationConfiguration.Initialize();
        Application.Run(new MainForm());
    }

    private static void Log(Exception? ex)
    {
        if (ex is null) return;
        try
        {
            Directory.CreateDirectory(Path.GetDirectoryName(LogPath)!);
            File.AppendAllText(LogPath, $"[error] {ex}{Environment.NewLine}{Environment.NewLine}");
        }
        catch { /* never throw from the logger */ }
    }
}
