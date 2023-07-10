# Topic: DataGridView, advanced

Custom columns, formatting, and handling big data.

## Define columns explicitly

Turn off `AutoGenerateColumns` and add typed columns to control order, headers,
widths, and types:

- `DataGridViewTextBoxColumn`, `DataGridViewCheckBoxColumn`,
  `DataGridViewComboBoxColumn`, `DataGridViewButtonColumn`,
  `DataGridViewImageColumn`, `DataGridViewLinkColumn`.
- Set `DataPropertyName` to bind a column to a property.

```csharp
grid.AutoGenerateColumns = false;
grid.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Name", DataPropertyName = "Name" });
grid.Columns.Add(new DataGridViewCheckBoxColumn { HeaderText = "Active", DataPropertyName = "IsActive" });
```

## Formatting

- `CellFormatting` — change displayed text/color per cell without touching data
  (e.g. red negatives, currency).
- Column `DefaultCellStyle.Format = "C"` for simple number/date formats.

```csharp
grid.CellFormatting += (s, e) =>
{
    if (grid.Columns[e.ColumnIndex].DataPropertyName == "Balance" && e.Value is decimal d && d < 0)
        e.CellStyle.ForeColor = Color.Red;
};
```

## Virtual mode for huge data

Binding a million-row list is slow. **Virtual mode** (`VirtualMode = true`)
makes the grid ask you for cell values on demand via `CellValueNeeded`, so you
keep data in your own store and render only what's visible.

## Other essentials

- `EditingControlShowing` to customise the editor.
- `DataError` to handle bad input gracefully (default shows a dialog).
- `CellClick` / `CellContentClick` for button/link columns.

## Example

See `examples/GridAdvanced.cs`.

## Exercise

1. Build a grid with explicit columns (text + checkbox), `AutoGenerateColumns =
   false`, bound to a list.
2. Use `CellFormatting` to color negative balances red and show them as
   currency.
3. (Stretch) Switch to `VirtualMode` over a `List<T>` of 100k rows and serve
   `CellValueNeeded`.
