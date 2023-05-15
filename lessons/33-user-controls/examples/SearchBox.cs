using System;
using System.Drawing;
using System.Windows.Forms;

namespace HelloForms;

// A reusable search bar: a TextBox + Button exposed via a clean API.
public class SearchBox : UserControl
{
    private readonly TextBox _input = new() { Location = new Point(0, 1), Width = 180, PlaceholderText = "Search..." };
    private readonly Button _go = new() { Text = "Go", Location = new Point(186, 0), Width = 50 };

    // Public API — consumers use these, NOT the inner controls.
    public string Query
    {
        get => _input.Text;
        set => _input.Text = value;
    }

    public event EventHandler? Search;

    public SearchBox()
    {
        Height = 28;
        Width = 240;
        Controls.Add(_input);
        Controls.Add(_go);

        _go.Click += (s, e) => OnSearch();
        _input.KeyDown += (s, e) =>
        {
            if (e.KeyCode == Keys.Enter) { OnSearch(); e.SuppressKeyPress = true; }
        };
    }

    protected virtual void OnSearch() => Search?.Invoke(this, EventArgs.Empty);
}

// Parent usage:
//   var box = new SearchBox { Location = new Point(20, 20) };
//   box.Search += (s, e) => DoSearch(((SearchBox)s!).Query);
//   Controls.Add(box);
