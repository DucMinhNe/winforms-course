# Lesson 26: Data binding

Connect controls to data so they update each other automatically.

## What you'll learn

- **Simple binding** — bind one control property to one data property:
  ```csharp
  txtName.DataBindings.Add("Text", customer, nameof(Customer.Name));
  ```
  Edits in the textbox flow back to the object (and vice-versa).
- **BindingSource** — a middleman between your data and controls. Bind controls
  to the `BindingSource`, set its `DataSource` to your list/object. It tracks
  the *current* item and exposes navigation (`MoveNext`, `Position`).
- **Complex binding** — list controls (`DataGridView`, `ComboBox`, `ListBox`)
  bind their whole `DataSource` to a collection.
- Two-way binding needs the data object to raise change notifications
  (`INotifyPropertyChanged`) for the UI to refresh when code changes a value —
  covered in the data-binding-deep topic.

```csharp
var bs = new BindingSource { DataSource = customers };
grid.DataSource = bs;                                   // grid shows the list
txtName.DataBindings.Add("Text", bs, "Name");           // textbox shows current row
// moving the grid selection updates the textbox automatically
```

## Example

See `examples/BindingForm.cs`.

## Exercise

1. A `Customer` class with `Name` and `Email`.
2. A `BindingSource` over a `List<Customer>`; bind a `DataGridView` to it.
3. Bind two textboxes to the BindingSource's `Name`/`Email` — selecting a grid
   row fills the textboxes; editing a textbox updates the row.
4. Add Next/Previous buttons calling `bs.MoveNext()` / `bs.MovePrevious()`.
