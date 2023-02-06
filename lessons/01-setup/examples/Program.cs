namespace HelloForms;

static class Program
{
    // [STAThread] is REQUIRED for WinForms — the UI runs on a
    // single-threaded apartment so COM components (clipboard, dialogs) work.
    [STAThread]
    static void Main()
    {
        // .NET 6/7 helper: sets high-DPI mode, default font, visual styles.
        ApplicationConfiguration.Initialize();

        // Show the main form and start the message loop.
        Application.Run(new MainForm());
    }
}
