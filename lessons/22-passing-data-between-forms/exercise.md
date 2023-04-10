# Exercise — Lesson 22

1. Build `EditForm(string initialName)` that pre-fills a textbox from the
   constructor argument.
2. Add `public string EnteredName { get; private set; }`; set it and
   `DialogResult = DialogResult.OK` when OK is clicked.
3. From the main form:
   ```csharp
   using var dlg = new EditForm(currentName);
   if (dlg.ShowDialog(this) == DialogResult.OK)
       lbl.Text = dlg.EnteredName;
   ```
4. (Bonus) Pass an object (e.g. a `Customer`) in and return an edited copy out.

**Done when:** data flows in via the constructor and back out via a property —
without the parent touching the child's controls directly.
