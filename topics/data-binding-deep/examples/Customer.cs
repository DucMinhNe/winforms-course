using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace HelloForms;

// Implements INotifyPropertyChanged so bound controls refresh when CODE
// changes a property (not only when the user edits the control).
public class Customer : INotifyPropertyChanged
{
    private string _name = "";
    private decimal _balance;

    public string Name
    {
        get => _name;
        set => Set(ref _name, value);
    }

    public decimal Balance
    {
        get => _balance;
        set => Set(ref _balance, value);
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    private void Set<T>(ref T field, T value, [CallerMemberName] string? name = null)
    {
        if (Equals(field, value)) return;
        field = value;
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}

// Binding with Format/Parse to show Balance as currency:
//   var b = txtBalance.DataBindings.Add("Text", customer, nameof(Customer.Balance));
//   b.Format += (s, e) => e.Value = ((decimal)e.Value!).ToString("C");
//   b.Parse  += (s, e) => e.Value = decimal.Parse(((string)e.Value!).Trim('$', ' ', ','));
