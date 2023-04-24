# Lesson 29: CRUD with a database

Wire the grid and a form together into Create-Read-Update-Delete.

## What you'll learn

Put the pieces from the last lessons together:

- **Read**: load rows into a `BindingList<T>`, bind via `BindingSource` to a
  `DataGridView`.
- **Create**: an "Add" form/inputs → `INSERT` → add to the binding list (or
  reload).
- **Update**: edit the selected row (in-grid or in a detail form) → `UPDATE`
  by id.
- **Delete**: confirm with a `MessageBox`, `DELETE` by id, remove from the list.
- Keep data access in a repository/`Db` class; keep the form about UI. Reload
  from the DB after writes (simplest), or update the in-memory list to match.

```csharp
private void Refresh() => _bs.DataSource = _db.GetAll();   // re-read after a write

private void Delete()
{
    if (_bs.Current is not Product p) return;
    if (MessageBox.Show($"Delete {p.Name}?", "Confirm", MessageBoxButtons.YesNo) != DialogResult.Yes) return;
    _db.Delete(p.Id);
    Refresh();
}
```

## Example

See `examples/CrudForm.cs`.

## Exercise

1. Using the `Db` helper from Lesson 28 (add `Update(id, name, price)` and
   `Delete(id)`), build a form with a grid + Name/Price inputs.
2. **Add** inserts and refreshes; **Update** writes the selected row's edits;
   **Delete** confirms then removes.
3. Reload the grid from the DB after each write so it always reflects the
   database.

**Done when:** all four operations work end-to-end and survive an app restart.
