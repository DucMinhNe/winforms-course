# Topic: Designer-generated code

Demystifying `*.Designer.cs`, `InitializeComponent()`, and `.resx`.

## The partial class

A form is split across two files of one `partial class`:
- **`Form1.cs`** — your logic.
- **`Form1.Designer.cs`** — generated layout: a private field per control and
  one big `InitializeComponent()` that news them up, sets properties, wires
  events, and adds them to `Controls`.

When you drag a control or change a property, the designer **rewrites**
`InitializeComponent()`. That's why hand-editing it is risky — your edits can be
clobbered or can confuse the designer into not loading.

## InitializeComponent anatomy

```csharp
private void InitializeComponent()
{
    this.button1 = new System.Windows.Forms.Button();
    this.SuspendLayout();                 // pause layout while we configure
    // button1
    this.button1.Location = new System.Drawing.Point(12, 12);
    this.button1.Click += new System.EventHandler(this.button1_Click);
    // Form1
    this.Controls.Add(this.button1);
    this.ResumeLayout(false);             // resume + relayout once
}
```

`SuspendLayout`/`ResumeLayout` batch changes so the form lays out once, not per
property.

## .resx files

`Form1.resx` stores form resources: the icon, embedded images, and — when you
set `Localizable = true` — per-culture strings and positions (see
[resources-localization](../resources-localization/)).

## Practical guidance

- Edit properties via the designer or in your own code (`Load`), not by hand in
  the generated file.
- Code-only forms (no designer) are perfectly valid and diff better in git —
  many teams prefer them for dynamic UIs.

## Example

See `examples/Annotated.Designer.cs`.

## Exercise

1. Add 2 controls in the designer; open the `.Designer.cs` and map each
   designer action to its generated line.
2. Set `Localizable = true` on the form and change a control's text per culture;
   watch entries appear in the `.resx`.
