# Topic: Keyboard shortcuts & mnemonics

Make your app fast for keyboard users.

## Mnemonics (Alt-access keys)

Put `&` before a letter in a control's `Text` to make Alt+letter activate it:
`&File` → Alt+F, a button `&Save` → Alt+S. For a label + textbox, the label's
mnemonic moves focus to the **next** control in tab order — so place the label
right before its input.

## Menu/tool shortcuts

`ToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.S;` shows "Ctrl+S" and
fires the item from anywhere. Great for standard actions.

## Form-wide keys without a menu

Two options:

1. **`KeyPreview = true`** + `KeyDown` — the form sees keys before the focused
   control:
   ```csharp
   KeyPreview = true;
   KeyDown += (s, e) => { if (e.Control && e.KeyCode == Keys.F) { OpenFind(); e.SuppressKeyPress = true; } };
   ```
2. **Override `ProcessCmdKey`** — intercepts keys even ones controls would
   normally swallow (arrows, Tab); return `true` to mark handled:
   ```csharp
   protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
   {
       if (keyData == (Keys.Control | Keys.S)) { Save(); return true; }
       return base.ProcessCmdKey(ref msg, keyData);
   }
   ```

## AcceptButton / CancelButton

Wire **Enter** and **Esc** to default buttons on a form/dialog (Lesson 05) —
the simplest, most expected shortcut.

## Example

See `examples/Shortcuts.cs`.

## Exercise

1. A menu with `Ctrl+S` (Save) and `Ctrl+O` (Open) via `ShortcutKeys`.
2. Mnemonics on two buttons (`&Save`, `&Cancel`) — test Alt+S / Alt+C.
3. Override `ProcessCmdKey` so `Ctrl+F` opens a find box from anywhere, even
   while a textbox has focus.
