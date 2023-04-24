# Exercise — Lesson 25

1. Define `record Product(int Id, string Name, decimal Price);`.
2. Bind a `List<Product>` to a `DataGridView` (Dock `Fill`). Set it read-only,
   `AllowUserToAddRows = false`, `SelectionMode = FullRowSelect`,
   `AutoSizeColumnsMode = Fill`.
3. On `SelectionChanged`, cast `grid.CurrentRow.DataBoundItem` to `Product` and
   show its name + price in a status label.
4. (Bonus) Hide the `Id` column with `grid.Columns["Id"].Visible = false;` after
   binding.

**Done when:** the grid lists products and selecting a row updates the status
with the bound object's data.
