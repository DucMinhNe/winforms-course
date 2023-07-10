using System.ComponentModel;

namespace HelloForms;

// Validation rules live on the model. An ErrorProvider bound to a
// BindingSource over this object surfaces them automatically.
public class Customer : IDataErrorInfo
{
    public string Name { get; set; } = "";
    public string Email { get; set; } = "";
    public int Age { get; set; }

    // Per-property error message ("" means valid).
    public string this[string columnName] => columnName switch
    {
        nameof(Name)  => string.IsNullOrWhiteSpace(Name) ? "Name is required" : "",
        nameof(Email) => Email.Contains('@') ? "" : "Enter a valid email address",
        nameof(Age)   => Age is < 0 or > 120 ? "Age must be 0–120" : "",
        _ => "",
    };

    // Object-level error (rarely needed).
    public string Error => "";
}

// Wiring (in the form):
//   var bs = new BindingSource { DataSource = customer };
//   errorProvider.DataSource = bs;
//   txtName.DataBindings.Add("Text", bs, nameof(Customer.Name),
//       false, DataSourceUpdateMode.OnPropertyChanged);
