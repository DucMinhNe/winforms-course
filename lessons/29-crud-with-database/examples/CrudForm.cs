using System.Drawing;
using System.Windows.Forms;

namespace HelloForms;

// Assumes a Db class with EnsureSchema/GetAll/Insert/Update/Delete (Lesson 28 + 2 methods).
public class CrudForm : Form
{
    private readonly Db _db = new();
    private readonly BindingSource _bs = new();
    private readonly DataGridView _grid = new()
    {
        Dock = DockStyle.Fill,
        AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
        SelectionMode = DataGridViewSelectionMode.FullRowSelect,
        ReadOnly = true,
    };
    private readonly TextBox _name = new() { PlaceholderText = "Name", Width = 160 };
    private readonly NumericUpDown _price = new() { Maximum = 100000, DecimalPlaces = 2, Width = 100 };

    public CrudForm()
    {
        Text = "Products CRUD";
        ClientSize = new Size(560, 360);
        _db.EnsureSchema();

        _grid.DataSource = _bs;

        var bar = new FlowLayoutPanel { Dock = DockStyle.Bottom, AutoSize = true };
        bar.Controls.Add(_name);
        bar.Controls.Add(_price);
        bar.Controls.Add(MakeBtn("Add", Add));
        bar.Controls.Add(MakeBtn("Update", Update));
        bar.Controls.Add(MakeBtn("Delete", Delete));

        _grid.SelectionChanged += (s, e) =>
        {
            if (_bs.Current is Product p) { _name.Text = p.Name; _price.Value = p.Price; }
        };

        Controls.Add(_grid);
        Controls.Add(bar);
        Refresh();
    }

    private Button MakeBtn(string t, System.Action a)
    {
        var b = new Button { Text = t, AutoSize = true, Margin = new Padding(4) };
        b.Click += (s, e) => a();
        return b;
    }

    private void Refresh() => _bs.DataSource = _db.GetAll();

    private void Add()
    {
        _db.Insert(_name.Text.Trim(), _price.Value);
        Refresh();
    }

    private void Update()
    {
        if (_bs.Current is not Product p) return;
        _db.Update(p.Id, _name.Text.Trim(), _price.Value);
        Refresh();
    }

    private void Delete()
    {
        if (_bs.Current is not Product p) return;
        if (MessageBox.Show(this, $"Delete {p.Name}?", "Confirm",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes) return;
        _db.Delete(p.Id);
        Refresh();
    }
}
