# Topic: Progress & cancellation

Show a progress bar and let the user stop a long operation.

## Reporting progress with IProgress<T>

`IProgress<T>.Report(...)` marshals the callback to the thread that **created**
the `Progress<T>` — create it on the UI thread and you can update controls
directly inside the callback.

```csharp
var progress = new Progress<int>(percent => progressBar.Value = percent);  // UI thread
await Task.Run(() =>
{
    for (int i = 0; i <= 100; i++)
    {
        DoChunk(i);
        ((IProgress<int>)progress).Report(i);   // posts back to the UI thread
    }
});
```

## Cancellation with CancellationToken

Pass a token into the work; the work checks it and throws
`OperationCanceledException` when cancelled.

```csharp
private CancellationTokenSource? _cts;

private async void Start_Click(object sender, EventArgs e)
{
    _cts = new CancellationTokenSource();
    try
    {
        await Task.Run(() => Work(_cts.Token), _cts.Token);
        status.Text = "Completed";
    }
    catch (OperationCanceledException)
    {
        status.Text = "Cancelled";
    }
}

private void Cancel_Click(object sender, EventArgs e) => _cts?.Cancel();

void Work(CancellationToken ct)
{
    for (int i = 0; i < 100; i++) { ct.ThrowIfCancellationRequested(); /* ... */ }
}
```

## Tips

- Disable Start / enable Cancel while running; reset in a `finally`.
- Dispose the `CancellationTokenSource` after use.
- For determinate work use `ProgressBar.Value`; for unknown duration use
  `Style = Marquee`.

## Example

See `examples/ProgressForm.cs`.

## Exercise

1. A progress bar driven by `Progress<int>` from a `Task.Run` loop.
2. Start/Cancel buttons with a `CancellationTokenSource`; the worker calls
   `ThrowIfCancellationRequested()`.
3. Show "Completed" or "Cancelled"; re-enable Start in a `finally`.
