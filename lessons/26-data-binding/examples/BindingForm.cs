using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace HelloForms;

public class Customer
{
    public string Name { get; set; } = "";
    public string Email { get; set; } = "";
}

public class BindingForm : Form
{
    public BindingForm()
    {
        Text = "Data binding";
        ClientSize = new Size(500, 340);

        var customers = new List<Customer>
        {
            new() { Name = "Alice", Email = "alice@example.com" },
            new() { Name = "Bao",   Email = "bao@example.com" },
        };

        // BindingSource sits between the data and the controls.
        var bs = new BindingSource { DataSource = customers };

        var grid = new DataGridView
        {
            Dock = DockStyle.Top,
            Height = 160,
            DataSource = bs,                 // complex binding to the list
            AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
            SelectionMode = DataGridViewSelectionMode.FullRowSelect,
        };

        var txtName = new TextBox { Location = new Point(80, 180), Width = 200 };
        var txtEmail = new TextBox { Location = new Point(80, 215), Width = 200 };
        // Simple binding to the CURRENT item of the BindingSource
        txtName.DataBindings.Add("Text", bs, nameof(Customer.Name));
        txtEmail.DataBindings.Add("Text", bs, nameof(Customer.Email));

        var prev = new Button { Text = "◀ Prev", Location = new Point(80, 255) };
        var next = new Button { Text = "Next ▶", Location = new Point(180, 255) };
        prev.Click += (s, e) => bs.MovePrevious();
        next.Click += (s, e) => bs.MoveNext();

        Controls.AddRange(new Control[]
        {
            grid,
            new Label { Text = "Name:", Location = new Point(20, 183), AutoSize = true },
            txtName,
            new Label { Text = "Email:", Location = new Point(20, 218), AutoSize = true },
            txtEmail,
            prev, next,
        });
    }
}
