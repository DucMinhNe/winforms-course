# Lesson 25: DataGridView basics

The grid control for showing and editing tabular data.

## What you'll learn

- The fastest way to fill it: set `DataSource` to a list of objects — columns
  are auto-generated from public properties.
  ```csharp
  grid.DataSource = new List<Product> { ... };
  ```
- Useful properties: `AutoGenerateColumns`, `ReadOnly`,
  `SelectionMode = FullRowSelect`, `AllowUserToAddRows`,
  `AutoSizeColumnsMode = Fill`, `MultiSelect`.
- Read the selection: `grid.CurrentRow`, `grid.SelectedRows`, and
  `grid.CurrentRow.DataBoundItem` (the underlying object).
- Events: `SelectionChanged`, `CellClick`, `CellValueChanged`,
  `CellFormatting`.
- For live add/remove to reflect in the grid, bind a `BindingList<T>` (next
  lessons), not a plain `List<T>`.

## Example

See `examples/GridForm.cs`.

## Exercise

1. Define `record Product(int Id, string Name, decimal Price);`.
2. Bind a `List<Product>` to a `DataGridView` (Dock Fill,
   `AutoSizeColumnsMode = Fill`, `SelectionMode = FullRowSelect`, read-only).
3. Show the selected product's name in a label via `SelectionChanged` using
   `CurrentRow.DataBoundItem`.
