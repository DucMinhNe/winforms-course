# Lesson 05: Form properties

The settings that control how a window looks and behaves.

## What you'll learn

- **Identity / title**: `Text` (titlebar), `Icon`.
- **Size & position**: `Size` / `ClientSize`, `StartPosition`
  (`CenterScreen`, `Manual`, …), `Location`, `MinimumSize` / `MaximumSize`.
- **Border & chrome**: `FormBorderStyle` (`Sizable`, `FixedDialog`,
  `FixedSingle`, `None`), `MaximizeBox`, `MinimizeBox`, `ControlBox`.
- **State**: `WindowState` (`Normal`, `Maximized`, `Minimized`), `TopMost`,
  `Opacity`, `ShowInTaskbar`.
- **Behaviour**: `AcceptButton` (Enter triggers it), `CancelButton` (Esc),
  `KeyPreview` (form sees key events before controls).

```csharp
Text = "Settings";
FormBorderStyle = FormBorderStyle.FixedDialog;
MaximizeBox = false;
StartPosition = FormStartPosition.CenterParent;
AcceptButton = btnSave;   // Enter = Save
CancelButton = btnCancel; // Esc  = Cancel
```

## Example

See `examples/DialogForm.cs`.

## Exercise

1. Make a fixed-size dialog: `FormBorderStyle.FixedDialog`, no maximize button,
   centred on its parent.
2. Set `AcceptButton`/`CancelButton` so Enter and Esc work.
3. Try `TopMost = true` and `Opacity = 0.9` and observe the effect.
