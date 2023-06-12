# Exercise — Async on the UI thread

1. Write an `async` button handler that sets a label to "Working...", `await`s
   `Task.Run(() => /* tight loop */)`, then sets "Done". Drag the window during
   it — no freeze.
2. Add an I/O button that `await Http.GetStringAsync(url)` directly (no
   `Task.Run`) and shows the byte count.
3. Start a raw `Thread` that updates the label via `label.Invoke(...)`. Then
   remove the `Invoke` and watch the **cross-thread** exception; restore it.
4. (Trap) Try `Task.Run(...).Result` in the handler and observe the deadlock —
   then fix it with `await`.

**Done when:** async work never freezes the UI, background updates use `Invoke`,
and you've seen why `.Result` on the UI thread deadlocks.
