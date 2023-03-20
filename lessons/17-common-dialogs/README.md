# Lesson 17: Common dialogs

The built-in OS dialogs for files, folders, colors, and fonts.

## What you'll learn

The pattern is always the same: create the dialog, configure it, call
`ShowDialog()`, and act if it returns `DialogResult.OK`.

- **OpenFileDialog** — pick a file (or many with `Multiselect = true`). Set
  `Filter`, read `FileName` / `FileNames`.
- **SaveFileDialog** — choose a save path. Set `Filter`, `DefaultExt`; read
  `FileName`.
- **FolderBrowserDialog** — pick a directory; read `SelectedPath`.
- **ColorDialog** — pick a color; read `Color`.
- **FontDialog** — pick a font; read `Font`.

```csharp
using var dlg = new OpenFileDialog { Filter = "Text|*.txt|All|*.*" };
if (dlg.ShowDialog(this) == DialogResult.OK)
{
    var text = File.ReadAllText(dlg.FileName);
}
```

`using var` disposes the dialog automatically. The `Filter` format is
`Description|pattern|Description|pattern`.

## Example

See `examples/DialogsForm.cs`.

## Exercise

1. **Open** a `.txt` file and load its contents into a multiline textbox.
2. **Save** the textbox contents to a chosen path (`File.WriteAllText`).
3. A **Color** button that opens `ColorDialog` and sets the textbox
   `BackColor`.
4. A **Font** button that opens `FontDialog` and sets the textbox `Font`.
