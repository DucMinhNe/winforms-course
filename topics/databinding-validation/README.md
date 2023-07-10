# Topic: Binding validation (IDataErrorInfo)

Put validation rules on the data, not scattered across event handlers.

## IDataErrorInfo

Implement `IDataErrorInfo` on your model to expose per-property error strings.
Bound controls (with an `ErrorProvider` pointed at the `BindingSource`) then
show errors **automatically** — no per-control `Validating` code.

```csharp
public class Customer : IDataErrorInfo
{
    public string Name { get; set; } = "";
    public string Email { get; set; } = "";

    public string this[string column] => column switch
    {
        nameof(Name)  => string.IsNullOrWhiteSpace(Name) ? "Name is required" : "",
        nameof(Email) => Email.Contains('@') ? "" : "Enter a valid email",
        _ => "",
    };

    public string Error => "";   // object-level error (rarely used)
}
```

## Wire it up

```csharp
var bs = new BindingSource { DataSource = customer };
errorProvider.DataSource = bs;     // the provider reads IDataErrorInfo
txtName.DataBindings.Add("Text", bs, nameof(Customer.Name),
    false, DataSourceUpdateMode.OnPropertyChanged);
```

With `OnPropertyChanged`, the model updates as the user types and the
`ErrorProvider` shows/clears the ⚠ live.

## When to use which

- **IDataErrorInfo** — rules belong to the domain object; reusable across forms;
  testable without UI. Preferred for real apps.
- **Validating event + ErrorProvider** (Lesson 34) — quick, form-local checks.
- **INotifyDataErrorInfo** — the async/multi-error successor; heavier, more
  common in WPF/MAUI but available here too.

## Example

See `examples/Customer.cs`.

## Exercise

1. Implement `IDataErrorInfo` on a `Customer` with rules for `Name` and `Email`.
2. Bind two textboxes through a `BindingSource`; set `errorProvider.DataSource =
   bs` and bind with `DataSourceUpdateMode.OnPropertyChanged`.
3. Type bad values and watch the ⚠ icons appear/disappear with **no per-control
   validation code**.
