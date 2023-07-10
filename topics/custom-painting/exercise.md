# Exercise — Custom-painted controls

1. Build `RatingControl : Control` that paints 5 shapes in `OnPaint`; filled for
   `i < Value`, empty otherwise. Enable the double-buffer/userpaint styles via
   `SetStyle(...)`.
2. Expose `int Value` (0–5); call `Invalidate()` in its setter so it repaints.
3. Handle `OnMouseDown` to set `Value` from `e.X`, and raise a `ValueChanged`
   event.
4. Put two rating controls on a form, subscribe to `ValueChanged`, and show both
   values in a label.

**Done when:** clicking the control sets the rating, it repaints cleanly, and
the host reads the value through the property/event.
