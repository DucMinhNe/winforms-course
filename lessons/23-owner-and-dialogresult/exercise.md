# Exercise — Lesson 23

1. Build `ConfirmDialog(string message)`. Add **Save** and **Cancel** buttons
   and set their `DialogResult` to `OK`/`Cancel` — do **not** call `Close()`.
2. Set `AcceptButton`/`CancelButton` so **Enter** = Save and **Esc** = Cancel.
3. Open it with `ShowDialog(this)`; confirm it centres on the parent
   (`CenterParent`) and has no taskbar entry.
4. Open it once with `ShowDialog()` (no owner) and note it can't centre on the
   parent.

**Done when:** the buttons close the dialog via `DialogResult` alone, Enter/Esc
work, and ownership controls centring/taskbar behaviour.
