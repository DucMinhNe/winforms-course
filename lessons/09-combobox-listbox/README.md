# Lesson 09: ComboBox & ListBox

Let the user pick from a list.

## What you'll learn

- **ComboBox** — a dropdown. `DropDownStyle`:
  - `DropDown` (default) — editable text + list,
  - `DropDownList` — pick-only (no typing),
  - `Simple` — always-open list.
- **ListBox** — an always-visible list; `SelectionMode` can be `One` or
  `MultiExtended` (Ctrl/Shift multi-select).
- Add items: `Items.Add(...)`, `Items.AddRange(...)`, or bind with
  `DataSource`.
- Read selection: `SelectedItem`, `SelectedIndex` (-1 = none),
  `SelectedItems` (ListBox multi).
- React with `SelectedIndexChanged`.
- Bind objects and show a property via `DisplayMember` / `ValueMember`.

```csharp
cmb.DropDownStyle = ComboBoxStyle.DropDownList;
cmb.Items.AddRange(new[] { "Vietnam", "Singapore", "Japan" });
cmb.SelectedIndexChanged += (s, e) => lbl.Text = $"Picked: {cmb.SelectedItem}";
```

## Example

See `examples/PickerForm.cs`.

## Exercise

1. A `DropDownList` ComboBox of 4 countries; show the choice in a label.
2. A multi-select `ListBox` of hobbies; a button that lists the selected ones.
3. Bind the ComboBox to a `List<Country>` object with `DisplayMember = "Name"`.
