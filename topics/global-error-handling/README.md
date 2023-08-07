# Topic: Global error handling

Catch the exceptions you forgot to catch — and fail gracefully.

## Two global hooks

Unhandled exceptions can come from the UI thread or background threads. Wire
both **before** `Application.Run`:

```csharp
[STAThread]
static void Main()
{
    Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);

    // Exceptions on the UI thread (most WinForms code, incl. async void handlers)
    Application.ThreadException += (s, e) =>
        ShowAndLog(e.Exception);

    // Exceptions on non-UI threads / truly unhandled (process is usually doomed)
    AppDomain.CurrentDomain.UnhandledException += (s, e) =>
        Log((Exception)e.ExceptionObject);

    // Faulted Tasks nobody awaited
    TaskScheduler.UnobservedTaskException += (s, e) => { Log(e.Exception); e.SetObserved(); };

    ApplicationConfiguration.Initialize();
    Application.Run(new MainForm());
}
```

## Behaviour

- `ThreadException` keeps the app **alive** — show a friendly dialog, log
  details, let the user continue. This is your safety net for unexpected UI
  errors.
- `AppDomain.UnhandledException` usually means the process is ending — log, then
  let it crash (you can't reliably recover).
- Still `try/catch` where you can do something specific; the global handler is
  the *last* resort, not an excuse to skip local handling.

## Logging

Write to a file or a logging library (Serilog/NLog) with the stack trace and
context. A "Something went wrong" dialog with a hidden details/copy button beats
a raw stack trace in the user's face.

## Example

See `examples/GlobalErrors.cs`.

## Exercise

1. Wire `Application.ThreadException` to show a friendly dialog and append the
   exception to a log file.
2. Throw from a button handler — confirm the app survives and logs it.
3. Add `AppDomain.CurrentDomain.UnhandledException` and
   `TaskScheduler.UnobservedTaskException` handlers that log.
