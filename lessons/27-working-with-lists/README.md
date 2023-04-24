# Lesson 27: Working with lists

Make the UI update automatically when your collection changes.

## What you'll learn

- A plain `List<T>` bound to a grid does **not** refresh when you add/remove
  items — the grid never hears about it.
- **`BindingList<T>`** raises change notifications, so a bound
  `DataGridView`/`ListBox` updates the moment you `Add`/`Remove`/`Insert`.
- Bind through a `BindingSource` for the cleanest setup; call
  `bindingSource.Add(item)` / `.RemoveCurrent()` and the grid follows.
- For per-item edits to refresh too, the item class should implement
  `INotifyPropertyChanged` (see the data-binding-deep topic).
- `BindingSource.ResetBindings(false)` forces a refresh if you ever mutate
  outside the notification system.

```csharp
var items = new BindingList<Todo>();
var bs = new BindingSource { DataSource = items };
grid.DataSource = bs;
bs.Add(new Todo { Title = "New" });   // grid updates instantly
```

## Example

See `examples/TodoForm.cs`.

## Exercise

1. A `Todo { Title, Done }` class and a `BindingList<Todo>` shown in a grid.
2. A textbox + **Add** button that appends a new Todo — the grid updates with
   no manual refresh.
3. A **Remove** button that deletes the selected row via `bs.RemoveCurrent()`.
