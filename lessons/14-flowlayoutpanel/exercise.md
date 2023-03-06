# Exercise — Lesson 14

1. Build a tag editor: a docked-`Top` textbox + "Add" button, and a `Fill`ed
   `FlowLayoutPanel` (`WrapContents = true`).
2. "Add" creates a `Button` (AutoSize, small `Margin`) in the flow.
3. Clicking a tag removes it with `flow.Controls.Remove(tag)`.
4. Resize the window — confirm the tags wrap to new rows automatically.

**Done when:** you can add/remove tags and they re-flow on resize with no manual
positioning.
