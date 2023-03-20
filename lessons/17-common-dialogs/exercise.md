# Exercise — Lesson 17

Build a tiny text editor:

1. A `Multiline` textbox filling the form.
2. **Open** — `OpenFileDialog` (filter `Text files|*.txt`), load with
   `File.ReadAllText(dlg.FileName)`.
3. **Save** — `SaveFileDialog`, write with `File.WriteAllText(...)`.
4. **Color** — `ColorDialog` → set `BackColor`.
5. **Font** — `FontDialog` → set `Font`.

Use `using var dlg = ...` and only act when `ShowDialog(this) == DialogResult.OK`.

**Done when:** you can open a file, edit, save it, and restyle the editor with
the OS color/font pickers.
