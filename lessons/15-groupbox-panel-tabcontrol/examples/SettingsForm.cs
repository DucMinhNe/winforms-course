using System.Drawing;
using System.Windows.Forms;

namespace HelloForms;

public class SettingsForm : Form
{
    public SettingsForm()
    {
        Text = "Settings";
        ClientSize = new Size(420, 300);

        var tabs = new TabControl { Dock = DockStyle.Fill };

        // --- Tab 1: General ---
        var general = new TabPage("General");
        var appearance = new GroupBox { Text = "Appearance", Location = new Point(12, 12), Size = new Size(360, 90) };
        appearance.Controls.Add(new CheckBox { Text = "Dark mode", Location = new Point(15, 25), AutoSize = true });
        appearance.Controls.Add(new CheckBox { Text = "Compact layout", Location = new Point(15, 50), AutoSize = true });
        general.Controls.Add(appearance);

        // --- Tab 2: Account ---
        var account = new TabPage("Account");
        account.Controls.Add(new Label { Text = "Display name:", Location = new Point(12, 18), AutoSize = true });
        account.Controls.Add(new TextBox { Location = new Point(110, 14), Width = 200 });

        tabs.TabPages.AddRange(new[] { general, account });

        var status = new Label { Dock = DockStyle.Bottom, Height = 24, TextAlign = ContentAlignment.MiddleLeft };
        tabs.SelectedIndexChanged += (s, e) => status.Text = $"  Tab: {tabs.SelectedTab?.Text}";
        status.Text = $"  Tab: {tabs.SelectedTab?.Text}";

        Controls.Add(tabs);
        Controls.Add(status);
    }
}
