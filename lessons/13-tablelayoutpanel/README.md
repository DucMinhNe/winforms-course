# Lesson 13: TableLayoutPanel

A grid that lays out controls in rows and columns — like CSS grid for WinForms.

## What you'll learn

- `TableLayoutPanel` arranges children in a cell grid. Set `ColumnCount` /
  `RowCount`, then define how each track sizes via `ColumnStyles` / `RowStyles`:
  - `SizeType.Absolute` — fixed pixels.
  - `SizeType.Percent` — share of the remaining space.
  - `SizeType.AutoSize` — fit the content.
- Place a control: `table.Controls.Add(ctrl, col, row)`. Span cells with
  `SetColumnSpan` / `SetRowSpan`.
- `Dock = DockStyle.Fill` the table so the grid follows the form, and dock each
  child `Fill` so it fills its cell.
- This is how you build clean, resizable forms without pixel-pushing.

```csharp
var t = new TableLayoutPanel { Dock = DockStyle.Fill, ColumnCount = 2, RowCount = 2 };
t.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 90));   // label column
t.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100));   // input column
t.Controls.Add(new Label { Text = "Name:" }, 0, 0);
t.Controls.Add(new TextBox { Dock = DockStyle.Fill }, 1, 0);
```

## Example

See `examples/FormLayout.cs`.

## Exercise

1. Build a 2-column form: labels in column 0 (Absolute 90px), inputs in column 1
   (Percent 100), for Name / Email / Message.
2. Make the Message row `Percent` so a multiline textbox grows with the window.
3. Add an OK button spanning both columns in the last row.
