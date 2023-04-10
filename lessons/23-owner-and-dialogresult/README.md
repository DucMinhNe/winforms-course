# Lesson 23: Owner & DialogResult

The mechanics that make dialogs behave correctly.

## What you'll learn

- **DialogResult** is how a modal dialog reports its outcome:
  - Give a button a `DialogResult` (e.g. `DialogResult.OK`) and clicking it
    **auto-closes** the dialog and makes `ShowDialog()` return that value — no
    `Close()` call needed.
  - Or set `this.DialogResult = ...` in code to close programmatically.
  - `AcceptButton` / `CancelButton` map **Enter**/**Esc** to buttons.
- **Owner** — pass the parent to `ShowDialog(this)` / `Show(this)`. Benefits:
  the dialog centres on the parent (`CenterParent`), stays on top of it,
  minimises with it, and doesn't get a separate taskbar entry.
- A dialog closed with a `DialogResult` is **not disposed** automatically, so
  you can still read its properties — that's why you wrap it in `using`.

```csharp
// In the dialog:
btnSave.DialogResult = DialogResult.OK;   // click → closes, returns OK

// In the parent:
using var dlg = new MyDialog();
if (dlg.ShowDialog(this) == DialogResult.OK) { var x = dlg.Value; }
```

## Example

See `examples/ConfirmDialog.cs`.

## Exercise

1. A dialog with Save/Cancel buttons whose `DialogResult` is `OK`/`Cancel` —
   no `Close()` calls.
2. Wire `AcceptButton`/`CancelButton` so Enter/Esc work.
3. Open it with `ShowDialog(this)` and confirm it centres on the parent; then
   open it with no owner and note the difference.
