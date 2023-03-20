# Exercise — Lesson 18

1. Add a `MenuStrip` with a **File** menu: **New**, **Open** (`Ctrl+O` via
   `ShortcutKeys`), a separator, and **Exit** (calls `Close()`).
2. Add a **View** menu with a checkable **Word wrap** item (`CheckOnClick`) that
   toggles the editor's `WordWrap`.
3. Give the editor a `ContextMenuStrip` with **Cut / Copy / Paste** wired to
   `_editor.Cut()/Copy()/Paste()`.
4. Use `&` access keys (e.g. `&File`) and confirm Alt+F opens the menu.

**Done when:** the menu works (including the shortcut and the checkable toggle)
and right-clicking the editor shows the context menu.
