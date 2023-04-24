using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace HelloForms;

public class Todo
{
    public string Title { get; set; } = "";
    public bool Done { get; set; }
}

public class TodoForm : Form
{
    // BindingList notifies bound controls on Add/Remove → grid auto-updates.
    private readonly BindingList<Todo> _todos = new();

    public TodoForm()
    {
        Text = "Todos";
        ClientSize = new Size(460, 320);

        var bs = new BindingSource { DataSource = _todos };
        var grid = new DataGridView
        {
            Dock = DockStyle.Fill,
            DataSource = bs,
            AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
            SelectionMode = DataGridViewSelectionMode.FullRowSelect,
        };

        var input = new TextBox { Dock = DockStyle.Top, PlaceholderText = "New todo" };
        var bar = new FlowLayoutPanel { Dock = DockStyle.Top, AutoSize = true };
        var add = new Button { Text = "Add" };
        var remove = new Button { Text = "Remove selected" };
        bar.Controls.Add(add);
        bar.Controls.Add(remove);

        add.Click += (s, e) =>
        {
            if (input.Text.Trim().Length == 0) return;
            bs.Add(new Todo { Title = input.Text.Trim() });   // grid updates instantly
            input.Clear();
        };
        remove.Click += (s, e) => { if (bs.Current != null) bs.RemoveCurrent(); };

        Controls.Add(grid);
        Controls.Add(bar);
        Controls.Add(input);
        AcceptButton = add;
    }
}
