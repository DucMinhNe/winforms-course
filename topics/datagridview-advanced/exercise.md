# Exercise — DataGridView, advanced

1. Set `AutoGenerateColumns = false` and add explicit columns: a text column for
   Name, a text column for Balance (`DefaultCellStyle.Format = "C"`,
   right-aligned), and a `DataGridViewCheckBoxColumn` for IsActive.
2. Bind a `List<Account>` and confirm columns appear in your order with your
   headers.
3. Add a `CellFormatting` handler that paints negative balances red.
4. (Stretch) Recreate the grid in `VirtualMode = true` over a `List<Account>` of
   100,000 rows; serve cells in `CellValueNeeded` and confirm it stays fast.

**Done when:** the grid shows typed, formatted columns and highlights negatives
— and you understand when virtual mode is worth it.
