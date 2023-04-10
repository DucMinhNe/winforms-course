# Exercise — Lesson 21

1. Build a main form with two buttons:
   - **Open modeless** → `new ChildForm().Show(this);`
   - **Open dialog** → `using var dlg = new ChildForm(); var r = dlg.ShowDialog(this);`
2. Give `ChildForm` OK/Cancel buttons with `DialogResult` set, so the dialog
   closes and returns a result.
3. Show the returned `DialogResult` in a label on the main form.
4. Observe the difference: the modeless window leaves the main form usable; the
   dialog blocks it.

**Done when:** you can clearly demonstrate modal vs modeless behaviour and read
the dialog's result.
