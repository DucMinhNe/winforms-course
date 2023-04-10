using System.Drawing;
using System.Windows.Forms;

namespace HelloForms;

public class MdiParentForm : Form
{
    private int _count;

    public MdiParentForm()
    {
        Text = "MDI demo";
        ClientSize = new Size(640, 420);
        IsMdiContainer = true;               // the grey MDI work area

        var menu = new MenuStrip();
        var window = new ToolStripMenuItem("&Window");

        window.DropDownItems.Add(new ToolStripMenuItem("&New", null, (s, e) =>
        {
            var doc = new Form
            {
                MdiParent = this,            // host it inside this form
                Text = $"Document {++_count}",
                ClientSize = new Size(300, 200),
            };
            doc.Controls.Add(new TextBox { Dock = DockStyle.Fill, Multiline = true });
            doc.Show();
        }));
        window.DropDownItems.Add(new ToolStripSeparator());
        window.DropDownItems.Add(new ToolStripMenuItem("&Cascade", null, (s, e) => LayoutMdi(MdiLayout.Cascade)));
        window.DropDownItems.Add(new ToolStripMenuItem("Tile &Horizontal", null, (s, e) => LayoutMdi(MdiLayout.TileHorizontal)));
        window.DropDownItems.Add(new ToolStripMenuItem("Tile &Vertical", null, (s, e) => LayoutMdi(MdiLayout.TileVertical)));

        menu.Items.Add(window);
        menu.MdiWindowListItem = window;     // auto-list open child windows here

        Controls.Add(menu);
        MainMenuStrip = menu;
    }
}
