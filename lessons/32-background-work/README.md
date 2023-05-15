# Lesson 32: Background work & async

Keep the UI responsive while doing slow work.

## What you'll learn

- The UI runs on **one thread**. Block it (a long loop, a slow network call) and
  the window freezes — no repaint, no clicks.
- **The modern way: `async`/`await`.** Make the event handler `async`, `await`
  the slow work; the UI thread is freed while it runs and resumes automatically
  afterwards.
  ```csharp
  private async void btnLoad_Click(object sender, EventArgs e)
  {
      btnLoad.Enabled = false;
      var data = await Task.Run(() => SlowFetch());   // off the UI thread
      grid.DataSource = data;                          // back on the UI thread
      btnLoad.Enabled = true;
  }
  ```
- **The rule:** you may only touch controls from the UI thread. After `await`,
  you're already back on it. But from a raw background thread you must marshal
  back with `Control.Invoke`:
  ```csharp
  if (label.InvokeRequired) label.Invoke(() => label.Text = "done");
  else label.Text = "done";
  ```
- The classic **`BackgroundWorker`** (DoWork / ProgressChanged / RunWorker
  Completed) predates async/await; you'll see it in older code, but prefer
  async today.

## Example

See `examples/AsyncForm.cs`.

## Exercise

1. A button whose handler is `async` and `await`s `Task.Delay(3000)` (simulated
   work); disable it during, re-enable after — confirm the window stays
   draggable.
2. Show "Working..." then "Done" without freezing.
3. (Bonus) Start a raw `Thread` that updates a label via `Control.Invoke` and
   observe the difference.
