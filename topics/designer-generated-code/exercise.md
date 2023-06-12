# Exercise — Designer-generated code

1. In a designer form, add a `TextBox` and a `Button`. Open `Form1.Designer.cs`
   and find: the private fields, the property lines, the `Click` wiring, and the
   `Controls.Add` calls.
2. Change the button text in the **Properties window** and watch exactly one
   line change in the generated file.
3. Set the form's `Localizable = true`, switch `Language` to another culture,
   and change a label's text — see culture-specific entries land in the `.resx`.
4. Recreate the same form **in code only** (no designer) and compare how it
   reads in git.

**Done when:** you can trace every designer action to generated code and explain
why you shouldn't hand-edit `InitializeComponent()`.
