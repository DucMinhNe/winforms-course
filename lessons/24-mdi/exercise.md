# Exercise — Lesson 24

1. Make a parent form with `IsMdiContainer = true` and a `MenuStrip` with a
   **Window** menu.
2. **Window ▸ New** opens a child form (`MdiParent = this`) titled
   "Document N", containing a multiline textbox.
3. Add **Cascade**, **Tile Horizontal**, **Tile Vertical** items calling
   `LayoutMdi(...)`.
4. Set `menu.MdiWindowListItem = windowMenu` so open documents auto-list in the
   menu, and switching between them works.

**Done when:** you can spawn several child documents, arrange them, and jump
between them from the Window menu.
