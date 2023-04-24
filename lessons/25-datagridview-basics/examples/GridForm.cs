using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace HelloForms;

public record Product(int Id, string Name, decimal Price);

public class GridForm : Form
{
    public GridForm()
    {
        Text = "Products";
        ClientSize = new Size(480, 320);

        var grid = new DataGridView
        {
            Dock = DockStyle.Fill,
            ReadOnly = true,
            AllowUserToAddRows = false,
            SelectionMode = DataGridViewSelectionMode.FullRowSelect,
            AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
            MultiSelect = false,
        };

        var products = new List<Product>
        {
            new(1, "Keyboard", 29.99m),
            new(2, "Mouse", 14.50m),
            new(3, "Monitor", 199.00m),
        };
        grid.DataSource = products;   // columns auto-generated from properties

        var status = new Label { Dock = DockStyle.Bottom, Height = 24, TextAlign = ContentAlignment.MiddleLeft };
        grid.SelectionChanged += (s, e) =>
        {
            if (grid.CurrentRow?.DataBoundItem is Product p)
                status.Text = $"  Selected: {p.Name} ({p.Price:C})";
        };

        Controls.Add(grid);
        Controls.Add(status);
    }
}
