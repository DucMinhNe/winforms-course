# Lesson 31: Timers

Run code repeatedly on the UI thread — clocks, polling, animations.

## What you'll learn

- Use **`System.Windows.Forms.Timer`** in WinForms. Its `Tick` event fires on
  the **UI thread**, so you can touch controls safely.
- Props: `Interval` (milliseconds), `Enabled` (or `Start()` / `Stop()`).
- Don't confuse it with `System.Timers.Timer` / `System.Threading.Timer` —
  those fire on background threads and need `Invoke` to update the UI (see the
  async lesson).
- Keep `Tick` handlers fast; for slow work, do it async (next lesson), not in a
  timer tick.
- **Dispose** the timer (or stop it) when the form closes.

```csharp
var timer = new System.Windows.Forms.Timer { Interval = 1000 };
timer.Tick += (s, e) => lblClock.Text = DateTime.Now.ToLongTimeString();
timer.Start();
```

## Example

See `examples/ClockForm.cs`.

## Exercise

1. A clock label updated every second by a `Forms.Timer`.
2. Start/Stop buttons that toggle the timer.
3. A countdown from 10 to 0 (a second timer or a counter) that shows "Done!" and
   stops at zero.
