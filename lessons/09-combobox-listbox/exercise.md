# Exercise — Lesson 09

1. Add a `DropDownList` `ComboBox` of 4 countries. Show the selection in a label
   via `SelectedIndexChanged`.
2. Add a `MultiExtended` `ListBox` of hobbies and a button that joins the
   `SelectedItems` into a label (`string.Join(", ", list.SelectedItems.Cast<string>())`).
3. Define `record Country(string Name, string Code);`, build a
   `List<Country>`, set it as the ComboBox `DataSource` with
   `DisplayMember = "Name"`, and read the chosen `Country` from `SelectedItem`.

**Done when:** the combo shows country names (not type names) via
`DisplayMember`, and multi-select hobbies print correctly.
