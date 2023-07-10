# Exercise — Binding validation (IDataErrorInfo)

1. Implement `IDataErrorInfo` on a `Customer` with rules for `Name` (required),
   `Email` (contains `@`), and `Age` (0–120).
2. In the form:
   ```csharp
   var bs = new BindingSource { DataSource = new Customer() };
   errorProvider.DataSource = bs;
   txtName.DataBindings.Add("Text", bs, nameof(Customer.Name),
       false, DataSourceUpdateMode.OnPropertyChanged);
   // ...same for Email, Age
   ```
3. Type invalid values and confirm the ⚠ icons show/clear live — with **zero**
   `Validating` handlers.

**Done when:** validation lives entirely on the model and the UI reflects it
automatically through the `ErrorProvider`.
