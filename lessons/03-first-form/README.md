# Lesson 03: Your first form

Build a window in code so you understand what the designer generates.

## What you'll learn

- A form is a class that inherits `System.Windows.Forms.Form`.
- Set properties in the constructor: `Text` (title), `Size`, `StartPosition`.
- Add a control: create it, set its properties, add it to `Controls`.
- `Application.Run(new MainForm())` shows it and pumps messages until it closes.

```csharp
public class MainForm : Form
{
    public MainForm()
    {
        Text = "My First Form";
        Size = new Size(400, 250);
        StartPosition = FormStartPosition.CenterScreen;

        var label = new Label { Text = "Hello, WinForms!", AutoSize = true, Location = new Point(20, 20) };
        Controls.Add(label);
    }
}
```

Doing it by hand once makes the designer's `InitializeComponent()` obvious —
it's just this code, generated.

## Example

See `examples/MainForm.cs` and `examples/Program.cs`.

## Exercise

1. Create `MainForm : Form` entirely in code (no designer).
2. Set the title, size 500×300, and centre it on screen.
3. Add a `Label` and a `Button`; position them with `Location`.
4. Run it.
