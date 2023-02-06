# Exercise — Lesson 03

Build a form **in code** (delete the designer file or start from a class):

```csharp
public class MainForm : Form
{
    public MainForm()
    {
        Text = "Greeter";
        Size = new Size(500, 300);
        StartPosition = FormStartPosition.CenterScreen;

        var name = new TextBox { Location = new Point(20, 20), Width = 200 };
        var greet = new Button { Text = "Greet", Location = new Point(20, 60) };
        var output = new Label { AutoSize = true, Location = new Point(20, 100) };

        greet.Click += (s, e) => output.Text = $"Hello, {name.Text}!";

        Controls.AddRange(new Control[] { name, greet, output });
    }
}
```

Wire `Program.cs` to `Application.Run(new MainForm())` and run.

**Done when:** typing a name and clicking **Greet** updates the label, and you
built the whole window without the designer.
