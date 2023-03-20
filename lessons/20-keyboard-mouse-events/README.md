# Lesson 20: Keyboard & mouse events

React to keys and pointer actions.

## What you'll learn

**Keyboard** (on the focused control, or the form if `KeyPreview = true`):
- `KeyDown` / `KeyUp` — physical keys, with `KeyEventArgs`: `e.KeyCode`,
  `e.Control`, `e.Shift`, `e.Alt`. Set `e.SuppressKeyPress = true` to swallow it.
- `KeyPress` — character input, with `KeyPressEventArgs.KeyChar` (good for
  filtering input, e.g. digits only).

**Mouse**:
- `MouseDown` / `MouseUp` / `MouseMove` — `MouseEventArgs`: `e.Button`,
  `e.Location`, `e.X/Y`, `e.Clicks`, `e.Delta` (wheel).
- `MouseEnter` / `MouseLeave` / `MouseWheel` / `MouseDoubleClick`.

```csharp
// Digits-only textbox
txt.KeyPress += (s, e) =>
{
    if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
        e.Handled = true;   // reject the character
};

// Ctrl+S anywhere on the form
KeyPreview = true;
KeyDown += (s, e) => { if (e.Control && e.KeyCode == Keys.S) { Save(); e.SuppressKeyPress = true; } };
```

## Example

See `examples/InputForm.cs`.

## Exercise

1. A textbox that only accepts digits (filter in `KeyPress`).
2. `KeyPreview` + a `KeyDown` handler so `Ctrl+S` triggers a "Saved" message
   from anywhere on the form.
3. A panel that shows the live mouse coordinates in its `MouseMove` handler.
