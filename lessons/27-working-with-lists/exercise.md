# Exercise — Lesson 27

1. Create `Todo { Title, Done }` and a `BindingList<Todo>`.
2. Bind it to a `DataGridView` through a `BindingSource`.
3. **Add**: a textbox + button that calls `bs.Add(new Todo { Title = ... })` —
   confirm the grid updates with no manual refresh.
4. **Remove**: a button calling `bs.RemoveCurrent()` on the selected row.
5. Swap the `BindingList<Todo>` for a plain `List<Todo>` and observe that
   Add/Remove no longer refresh the grid — that's *why* `BindingList` exists.

**Done when:** adding/removing items updates the grid automatically with
`BindingList`, and you can explain why a plain `List` doesn't.
