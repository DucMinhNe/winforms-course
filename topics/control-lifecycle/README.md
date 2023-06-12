# Topic: Control lifecycle

The order things happen — and where to put your code.

## Form lifecycle events (in order)

1. **Constructor** — `InitializeComponent()` builds controls. Do minimal work;
   controls exist but the window isn't shown and handles may not be created.
2. **`Load`** — fires once before the form first displays. The classic place to
   populate data, restore settings, set initial state.
3. **`Shown`** — fires once after the form is first visible. Use for things that
   need the window actually on screen (focus tricks, showing a child dialog
   immediately).
4. **`Activated` / `Deactivate`** — gain/lose focus (can fire many times).
5. **`FormClosing`** — about to close; `e.Cancel = true` vetoes it (prompt to
   save). `e.CloseReason` tells you why.
6. **`FormClosed`** — closed; final cleanup.
7. **`Dispose`** — releases unmanaged resources.

## Don'ts

- Don't do heavy work in the **constructor** — it runs before `Load` and errors
  there are confusing.
- Don't assume control `Handle`s exist until the form is loaded/shown
  (`IsHandleCreated`).
- `Load` runs **once**; if you need to refresh on every show (a reused
  modeless form), use `VisibleChanged` or `Activated`.

## Example

See `examples/LifecycleForm.cs`.

## Exercise

1. Log each event (`Constructor`, `Load`, `Shown`, `Activated`, `FormClosing`,
   `FormClosed`) and observe the order.
2. In `FormClosing`, if a textbox has unsaved text, prompt and set
   `e.Cancel = true` on "No".
