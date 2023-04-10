# Lesson 21: Opening forms — Show vs ShowDialog

Most apps have more than one window. Two ways to open them.

## What you'll learn

- **`Show()`** — opens a **modeless** window. Returns immediately; both windows
  stay usable. Good for tool windows, document windows.
- **`ShowDialog()`** — opens a **modal** window. **Blocks** the caller until the
  dialog closes, and disables the rest of the app meanwhile. Returns a
  `DialogResult`. Good for forms that must be answered before continuing
  (settings, "add item", login).
- Always `new` the form to open it: `var f = new SettingsForm(); f.Show();`.
- Dispose modal dialogs with `using`:
  ```csharp
  using var dlg = new SettingsForm();
  if (dlg.ShowDialog(this) == DialogResult.OK) { /* apply */ }
  ```
  (A modeless `Show()` form disposes itself when closed; don't `using` it.)

## Example

See `examples/MainForm.cs` and `examples/ChildForm.cs`.

## Exercise

1. A main form with two buttons: "Open modeless" (`Show`) and "Open dialog"
   (`ShowDialog`).
2. With the modeless window open, confirm the main form is still clickable.
3. With the dialog open, confirm the main form is **blocked** until you close it.
