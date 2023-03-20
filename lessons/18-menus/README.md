# Lesson 18: Menus

Top menu bars and right-click context menus.

## What you'll learn

- **MenuStrip** — the bar across the top. Add it and set the form's `MainMenuStrip`.
  Build a tree of `ToolStripMenuItem`s (File ▸ New / Open / Exit).
- Each item has a `Click` event, an optional `ShortcutKeys`
  (e.g. `Keys.Control | Keys.S`), and can show a checkmark (`Checked`,
  `CheckOnClick`).
- `ToolStripSeparator` draws a divider between groups.
- **ContextMenuStrip** — a right-click menu. Assign it to any control's
  `ContextMenuStrip` property; it pops up automatically on right-click.
- The designer builds these visually, but knowing the code makes dynamic menus
  (recent files, etc.) easy.

```csharp
var file = new ToolStripMenuItem("&File");
var open = new ToolStripMenuItem("&Open", null, OnOpen) { ShortcutKeys = Keys.Control | Keys.O };
file.DropDownItems.Add(open);
menu.Items.Add(file);
```

(`&` before a letter makes it an Alt-access key — Alt+F opens File.)

## Example

See `examples/MenuForm.cs`.

## Exercise

1. A `MenuStrip` with **File ▸ New / Open / — / Exit**, where Open has
   `Ctrl+O` and Exit closes the form.
2. A **View ▸ Word wrap** checkable item that toggles a textbox's `WordWrap`.
3. A `ContextMenuStrip` on the textbox with **Cut / Copy / Paste**.
