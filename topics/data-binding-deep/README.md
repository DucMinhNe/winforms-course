# Topic: Data binding, deeper

Make the UI react when your *data* changes — not just when the user types.

## The missing piece: INotifyPropertyChanged

Simple binding (Lesson 26) updates the object when the user edits a control. The
reverse — control refreshing when *code* changes a property — only works if the
data object **raises change notifications** by implementing
`INotifyPropertyChanged`.

```csharp
public class Customer : INotifyPropertyChanged
{
    private string _name = "";
    public string Name
    {
        get => _name;
        set { if (_name != value) { _name = value; OnChanged(); } }
    }

    public event PropertyChangedEventHandler? PropertyChanged;
    private void OnChanged([CallerMemberName] string? p = null)
        => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(p));
}
```

Now `customer.Name = "X"` in code instantly updates a bound textbox.

## Lists that notify

For a bound grid/list to refresh on add/remove **and** on item-property
changes, use `BindingList<T>` of items that implement
`INotifyPropertyChanged`. `BindingSource` sits in the middle and exposes
`Current`, `Position`, and `ResetBindings()`.

## Format & Parse

Transform values between data and display with the binding's `Format`
(data→control) and `Parse` (control→data) events — e.g. show a `decimal` as
currency, store a trimmed string.

```csharp
var b = txtPrice.DataBindings.Add("Text", product, nameof(Product.Price));
b.Format += (s, e) => e.Value = ((decimal)e.Value!).ToString("C");
```

## Example

See `examples/Customer.cs`.

## Exercise

1. Make a `Customer : INotifyPropertyChanged` with `Name`/`Email`.
2. Bind a textbox to `Name`; add a button that sets `customer.Name` in code and
   confirm the textbox updates (proves notification works).
3. Add a `Format`/`Parse` pair to display a number as currency.
