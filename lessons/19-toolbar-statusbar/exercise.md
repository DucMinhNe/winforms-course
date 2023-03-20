# Exercise — Lesson 19

1. Add a `ToolStrip` with **New / Open / Save** `ToolStripButton`s
   (`DisplayStyle = Text`). Each click sets a status label to "<name> clicked".
2. Add a `StatusStrip` with:
   - a left `ToolStripStatusLabel` (`Spring = true`) showing "Ready",
   - a right label showing the editor's `TextLength`, updated on `TextChanged`.
3. Confirm both bars dock correctly above/below the `Fill`ed editor.

**Done when:** toolbar clicks update the status, and the character count tracks
the text live on the right side of the status bar.
