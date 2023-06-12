# Exercise — Memory & disposal

1. In an `OnPaint`/`Paint` handler, allocate a `Pen` and `Brush` with `using`
   and draw a filled rectangle. Confirm you do **not** dispose `e.Graphics`.
2. Cache a `Font` as a field; use it every paint; dispose it in the form's
   `Dispose(bool)`.
3. Subscribe the form to a `static` event. Without unsubscribing, the form
   leaks (the static event roots it). Add
   `FormClosed += (s,e) => Service.Event -= Handler;` and confirm it's collected
   (a finalizer `Debug.WriteLine` or a memory profiler proves it).

**Done when:** GDI objects are scoped with `using`, the cached font is disposed
with the form, and the event leak is fixed by unsubscribing.
