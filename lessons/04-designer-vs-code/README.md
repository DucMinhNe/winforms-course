# Lesson 04: The designer vs code

Two ways to build a UI — and why they're really the same thing.

## What you'll learn

- The **Visual Designer** (VS 2022) lets you drag controls onto a form. Behind
  the scenes it writes C# into `Form1.Designer.cs`'s `InitializeComponent()`.
- The **Properties window** (F4) sets control properties; each change becomes a
  line in the designer file.
- The **Events tab** (the lightning bolt) generates an empty handler in
  `Form1.cs` and wires it up in the designer file.
- **Golden rule:** edit `Form1.cs` (your logic) freely; let the designer own
  `Form1.Designer.cs`. Hand-editing the generated file can corrupt the
  designer view.

## When to use which

- **Designer**: fast for static layouts, pixel nudging, exploring controls.
- **Code**: dynamic UIs (controls created in a loop), version-control-friendly
  diffs, anything the designer can't express.

Most real apps mix both: lay out the shell in the designer, build dynamic bits
in code.

## Example

See `examples/MainForm.Designer.cs` — a typical generated file, annotated.

## Exercise

1. In the designer, drop a `Button` and set its `Text` and `(Name)`.
2. Open `Form1.Designer.cs` and find the exact lines the designer wrote.
3. Double-click the button to generate a `Click` handler; see it appear in
   `Form1.cs` and get wired in the designer file.
