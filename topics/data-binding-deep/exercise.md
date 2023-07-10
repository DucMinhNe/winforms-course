# Exercise — Data binding, deeper

1. Implement `Customer : INotifyPropertyChanged` with `Name` and `Balance`
   (raise `PropertyChanged` in the setters).
2. Bind a textbox to `Name`. Add a "Randomize" button that sets `customer.Name`
   **in code** — the textbox should update without you touching it.
3. Bind another textbox to `Balance` and add a `Format` handler to show it as
   currency (`ToString("C")`) and a `Parse` handler to read it back.
4. Put a few customers in a `BindingList<Customer>` bound to a grid; change one
   customer's `Balance` in code and watch the grid cell update.

**Done when:** code-driven property changes flow to the UI, and money displays
formatted while storing a clean `decimal`.
