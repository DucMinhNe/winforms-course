# Exercise — Keyboard shortcuts & mnemonics

1. Build a `MenuStrip` with **Save** (`Ctrl+S`) and **Open** (`Ctrl+O`) using
   `ShortcutKeys`.
2. Add `&Save` and `&Cancel` buttons; verify Alt+S and Alt+C trigger them.
3. Override `ProcessCmdKey` so `Ctrl+F` opens a "find" action from anywhere —
   confirm it fires even while a `TextBox` has focus (where a plain `KeyDown`
   on the form might not).
4. (Bonus) Add a label `&Name:` directly before a textbox; pressing Alt+N
   focuses the textbox.

**Done when:** menu shortcuts, button mnemonics, and the `ProcessCmdKey`
override all work as expected.
