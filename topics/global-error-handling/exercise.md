# Exercise — Global error handling

1. Before `Application.Run`, set
   `Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException)`
   and wire `Application.ThreadException` to (a) log the exception to a file and
   (b) show a friendly dialog.
2. Add a button whose handler does `throw new InvalidOperationException("boom")`.
   Click it — the app should survive, log, and show your dialog (not crash).
3. Also wire `AppDomain.CurrentDomain.UnhandledException` and
   `TaskScheduler.UnobservedTaskException` to the same logger.
4. Make sure the logger itself never throws (wrap it in try/catch).

**Done when:** an unexpected UI-thread exception is logged and shown gracefully
instead of crashing the app.
