# Exercise — Progress & cancellation

1. Add a `ProgressBar`, a Start and a Cancel button.
2. On Start: create a `Progress<int>` on the UI thread (its callback sets
   `bar.Value`), then `await Task.Run(...)` a 0→100 loop that `Report`s each step.
3. On Cancel: call `_cts.Cancel()`. The worker checks
   `token.ThrowIfCancellationRequested()` each iteration.
4. Catch `OperationCanceledException` → "Cancelled"; otherwise "Completed".
   Re-enable Start and dispose the CTS in a `finally`.

**Done when:** the bar fills smoothly, Cancel stops it promptly with a
"Cancelled" status, and the buttons reset correctly either way.
