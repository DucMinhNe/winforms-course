# Exercise — Lesson 32

1. Add an `async` button handler that:
   - disables the button and sets a label to "Working...",
   - `await`s `Task.Run(() => Thread.Sleep(3000))` (or `Task.Delay(3000)`),
   - sets the label to "Done!" and re-enables the button.
   While it runs, **drag the window** — confirm it doesn't freeze.
2. Add a second button that does the same slow work on a **raw `Thread`** and
   updates the label via `status.Invoke(...)`. Remove the `Invoke` and watch it
   throw a cross-thread exception (then put it back).

**Done when:** the async version never freezes the UI, and you understand why
the raw-thread version needs `Control.Invoke`.
