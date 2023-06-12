# Exercise — Control lifecycle

1. Subscribe to `Load`, `Shown`, `Activated`, `Deactivate`, `FormClosing`,
   `FormClosed` and `Debug.WriteLine` each. Run, click away and back, then close
   — read the order in the Output window.
2. Move data-loading work into `Load` (not the constructor) and confirm it still
   works.
3. In `FormClosing`, if a textbox is non-empty, prompt "Discard changes?" and
   set `e.Cancel = true` when the user says No.

**Done when:** you can state which event fires once vs many times, and your
unsaved-changes guard blocks the close.
