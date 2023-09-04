using System.Windows.Forms;

namespace HelloForms;

public class Shortcuts : Form
{
    public Shortcuts()
    {
        Text = "Shortcuts";
        ClientSize = new System.Drawing.Size(360, 220);

        var menu = new MenuStrip();
        var file = new ToolStripMenuItem("&File");   // Alt+F mnemonic
        file.DropDownItems.Add(new ToolStripMenuItem("&Save", null, (s, e) => Save())
            { ShortcutKeys = Keys.Control | Keys.S });   // Ctrl+S
        file.DropDownItems.Add(new ToolStripMenuItem("&Open", null, (s, e) => { })
            { ShortcutKeys = Keys.Control | Keys.O });
        menu.Items.Add(file);

        // Mnemonic buttons
        var save = new Button { Text = "&Save", Location = new(20, 40) };   // Alt+S
        var cancel = new Button { Text = "&Cancel", Location = new(120, 40) };

        Controls.Add(menu);
        Controls.Add(save);
        Controls.Add(cancel);
        MainMenuStrip = menu;
    }

    private void Save() => MessageBox.Show(this, "Saved!");

    // Intercept keys app-wide — even ones a focused control would eat.
    protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
    {
        if (keyData == (Keys.Control | Keys.F))
        {
            MessageBox.Show(this, "Find box would open here.");
            return true;   // handled — stop further processing
        }
        return base.ProcessCmdKey(ref msg, keyData);
    }
}
