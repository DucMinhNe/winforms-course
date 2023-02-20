# Lesson 06: Label, TextBox & Button

The three controls every form starts with.

## What you'll learn

- **Label** — read-only text. Key props: `Text`, `AutoSize`, `Font`,
  `ForeColor`, `TextAlign`.
- **TextBox** — single-line input (set `Multiline = true` for many lines). Key
  props: `Text`, `PlaceholderText`, `MaxLength`, `ReadOnly`,
  `PasswordChar`/`UseSystemPasswordChar`.
- **Button** — clickable. The `Click` event is where the action happens; `Text`
  is the caption.
- Read input with `textBox.Text`; write output with `label.Text = ...`.

```csharp
btnGreet.Click += (s, e) =>
{
    lblOutput.Text = string.IsNullOrWhiteSpace(txtName.Text)
        ? "Please enter a name."
        : $"Hello, {txtName.Text}!";
};
```

## Example

See `examples/MainForm.cs` — a tiny greeter.

## Exercise

1. Lay out a `Label` "Name:", a `TextBox`, and a `Button` "Greet".
2. On click, show `Hello, <name>!` in an output label.
3. If the textbox is empty, show a prompt instead.
4. Add a password `TextBox` with `UseSystemPasswordChar = true` and observe the
   masking.
