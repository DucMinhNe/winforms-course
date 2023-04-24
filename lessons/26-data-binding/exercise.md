# Exercise — Lesson 26

1. Create a `Customer { Name, Email }` class and a `List<Customer>`.
2. Wrap it in a `BindingSource` and bind a `DataGridView` to it.
3. Add two textboxes; bind their `Text` to the BindingSource's `Name` and
   `Email`:
   ```csharp
   txtName.DataBindings.Add("Text", bs, nameof(Customer.Name));
   ```
4. Add **Prev/Next** buttons calling `bs.MovePrevious()` / `bs.MoveNext()`.

Observe: selecting a grid row fills the textboxes; editing a textbox and moving
off updates the grid row — all without manual wiring.

**Done when:** grid selection and the textboxes stay in sync through the
`BindingSource`.
