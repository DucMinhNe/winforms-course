# Topic: Async on the UI thread

The one threading rule in WinForms, and how `async`/`await` respects it.

## The rule

**Only the UI thread may touch a control.** Reading `textBox.Text` or setting
`label.Text` from another thread throws `InvalidOperationException`
("Cross-thread operation not valid") — or worse, corrupts state in release.

## Why await "just works"

WinForms installs a `SynchronizationContext` that posts continuations back to
the UI thread via the message pump. So after `await`, you're **back on the UI
thread** automatically:

```csharp
private async void Button_Click(object sender, EventArgs e)
{
    var data = await Task.Run(() => HeavyWork());  // runs on a thread-pool thread
    grid.DataSource = data;                         // safely back on the UI thread
}
```

- `Task.Run(...)` pushes CPU work off the UI thread.
- I/O (HttpClient, file, DB) exposes truly async methods (`GetStringAsync`,
  `ReadAsync`) — `await` those directly; no `Task.Run` needed.
- `async void` is acceptable **only** for event handlers; everything else
  returns `Task` so callers can await and catch exceptions.

## When you're on a background thread: Invoke

Code inside `Task.Run`, a raw `Thread`, or a `System.Timers.Timer` callback is
**not** on the UI thread. Marshal back:

```csharp
void SetStatus(string text)
{
    if (label.InvokeRequired) label.Invoke(() => label.Text = text);
    else label.Text = text;
}
```

## Gotchas

- Don't `.Result` / `.Wait()` a task on the UI thread — it deadlocks (the
  continuation needs the UI thread you're blocking).
- Exceptions in `async void` handlers go to `Application.ThreadException`
  (see [global-error-handling](../global-error-handling/)).

## Example

See `examples/AsyncPatterns.cs`.

## Exercise

1. An `async` handler that `await Task.Run(...)`s CPU work and updates a label
   before/after — confirm no freeze.
2. From a raw `Thread`, update a label via `Invoke`; remove `Invoke` and observe
   the cross-thread exception.
