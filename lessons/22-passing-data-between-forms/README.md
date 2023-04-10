# Lesson 22: Passing data between forms

Get data **into** a form and results **back out**.

## What you'll learn

Three clean patterns (avoid making controls `public` or using global state):

1. **Constructor injection** — pass data in when you create the form.
   ```csharp
   var dlg = new EditForm(customer);   // give it what it needs
   ```
2. **Public properties** — expose results to read after a modal dialog closes.
   ```csharp
   using var dlg = new EditForm(customer);
   if (dlg.ShowDialog(this) == DialogResult.OK)
       var updated = dlg.Result;       // read the answer back
   ```
3. **Events / callbacks** — for modeless forms that report changes back to the
   parent as they happen.
   ```csharp
   child.ValueChanged += (s, value) => UpdateMainView(value);
   ```

**Don't** reach into another form's controls (`other.textBox1.Text`). Expose a
property or raise an event — it keeps forms decoupled and testable.

## Example

See `examples/EditForm.cs`.

## Exercise

1. `EditForm` takes a `string initialName` in its constructor and pre-fills a
   textbox.
2. It exposes a `public string EnteredName { get; private set; }` set when OK is
   clicked.
3. The main form opens it modally, reads `EnteredName` on `DialogResult.OK`, and
   shows it.
