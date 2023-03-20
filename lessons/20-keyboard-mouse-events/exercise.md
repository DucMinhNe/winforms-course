# Exercise — Lesson 20

1. Make a textbox accept **digits only** by setting `e.Handled = true` for
   non-digit, non-control characters in `KeyPress`.
2. Set `KeyPreview = true` and handle `KeyDown` so **Ctrl+S** shows a "Saved"
   message and `e.SuppressKeyPress = true` stops the beep.
3. Add a `Panel` whose `MouseMove` updates a label with `e.X`, `e.Y`.
4. (Bonus) On `MouseWheel`, change the panel's background lightness using
   `e.Delta`.

**Done when:** the textbox rejects letters, Ctrl+S works form-wide, and the
panel reports live mouse coordinates.
