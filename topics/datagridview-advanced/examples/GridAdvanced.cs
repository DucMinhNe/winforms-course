using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace HelloForms;

public class Account
{
    public string Name { get; set; } = "";
    public decimal Balance { get; set; }
    public bool IsActive { get; set; }
}

public class GridAdvanced : Form
{
    public GridAdvanced()
    {
        Text = "Grid (advanced)";
        ClientSize = new Size(480, 320);

        var grid = new DataGridView
        {
            Dock = DockStyle.Fill,
            AutoGenerateColumns = false,           // we define columns ourselves
            AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
        };

        grid.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Name", DataPropertyName = "Name" });
        grid.Columns.Add(new DataGridViewTextBoxColumn
        {
            HeaderText = "Balance",
            DataPropertyName = "Balance",
            DefaultCellStyle = { Format = "C", Alignment = DataGridViewContentAlignment.MiddleRight },
        });
        grid.Columns.Add(new DataGridViewCheckBoxColumn { HeaderText = "Active", DataPropertyName = "IsActive" });

        // Per-cell formatting: red text for negative balances.
        grid.CellFormatting += (s, e) =>
        {
            if (grid.Columns[e.ColumnIndex].DataPropertyName == "Balance"
                && e.Value is decimal d && d < 0)
            {
                e.CellStyle!.ForeColor = Color.Red;
            }
        };

        grid.DataSource = new List<Account>
        {
            new() { Name = "Alice", Balance = 1200.50m, IsActive = true },
            new() { Name = "Bao", Balance = -45.00m, IsActive = false },
        };

        Controls.Add(grid);
    }
}
