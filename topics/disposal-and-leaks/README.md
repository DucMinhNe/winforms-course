# Topic: Memory & disposal

WinForms wraps native resources — leak them and your app bloats or crashes.

## What needs disposing

Anything holding an OS handle implements `IDisposable`: `Font`, `Brush`, `Pen`,
`Bitmap`, `Graphics`, `Image`, plus components like `Timer`. The GC eventually
collects them, but the **native handle** isn't freed until `Dispose()` runs —
so leaks show up as GDI/handle exhaustion, not just managed memory.

## Rules

- **`using`** for short-lived GDI objects:
  ```csharp
  using var pen = new Pen(Color.Red, 2);
  e.Graphics.DrawRectangle(pen, rect);
  ```
- **Don't dispose** the `Graphics` from a `Paint` event's `e.Graphics` — you
  don't own it.
- Controls added to a `Controls` collection are disposed with their parent
  form. Controls you create but **don't** add (or `Remove` without disposing)
  must be disposed yourself.
- Cache long-lived objects (a `Font` reused every paint) as fields and dispose
  them in the form's `Dispose`, rather than allocating per paint.

## The #1 leak: forgotten event handlers

If a long-lived object subscribes to a short-lived one's event (or vice-versa),
the subscription keeps it alive. Detach with `-=` when done, or use weak events.

```csharp
// leak: the static/long-lived publisher keeps `this` form alive forever
SomeService.DataChanged += OnDataChanged;
// fix: unsubscribe on close
FormClosed += (s, e) => SomeService.DataChanged -= OnDataChanged;
```

## Example

See `examples/DisposalDemo.cs`.

## Exercise

1. In a `Paint` handler, allocate a `Brush`/`Pen` with `using` and draw.
2. Subscribe the form to a static event; confirm (via a finalizer log or a
   memory profiler) the form isn't collected until you `-=` it on `FormClosed`.
3. Create a `Font` once as a field; dispose it in the form's `Dispose`.
