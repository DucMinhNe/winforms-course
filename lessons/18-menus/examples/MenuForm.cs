using System.Drawing;
using System.Windows.Forms;

namespace HelloForms;

public class MenuForm : Form
{
    private readonly TextBox _editor = new() { Dock = DockStyle.Fill, Multiline = true };

    public MenuForm()
    {
        Text = "Menus";
        ClientSize = new Size(480, 320);

        var menu = new MenuStrip();

        // File menu
        var file = new ToolStripMenuItem("&File");
        file.DropDownItems.Add(new ToolStripMenuItem("&New", null, (s, e) => _editor.Clear())
            { ShortcutKeys = Keys.Control | Keys.N });
        file.DropDownItems.Add(new ToolStripMenuItem("&Open...", null, (s, e) => { /* open */ })
            { ShortcutKeys = Keys.Control | Keys.O });
        file.DropDownItems.Add(new ToolStripSeparator());
        file.DropDownItems.Add(new ToolStripMenuItem("E&xit", null, (s, e) => Close()));

        // View menu with a checkable item
        var view = new ToolStripMenuItem("&View");
        var wrap = new ToolStripMenuItem("&Word wrap") { CheckOnClick = true, Checked = true };
        wrap.Click += (s, e) => _editor.WordWrap = wrap.Checked;
        view.DropDownItems.Add(wrap);

        menu.Items.AddRange(new ToolStripItem[] { file, view });

        // Right-click context menu on the editor
        var ctx = new ContextMenuStrip();
        ctx.Items.Add("Cut", null, (s, e) => _editor.Cut());
        ctx.Items.Add("Copy", null, (s, e) => _editor.Copy());
        ctx.Items.Add("Paste", null, (s, e) => _editor.Paste());
        _editor.ContextMenuStrip = ctx;

        // Order: add editor first (Fill), then menu, then set MainMenuStrip
        Controls.Add(_editor);
        Controls.Add(menu);
        MainMenuStrip = menu;
    }
}
