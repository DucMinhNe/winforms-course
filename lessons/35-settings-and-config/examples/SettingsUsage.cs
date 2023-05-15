using System.Drawing;
using System.Windows.Forms;

namespace HelloForms;

// Demonstrates persisting user settings across runs.
// (Define UserName:string and WindowSize:Size in the Settings designer first.)
public class SettingsUsage : Form
{
    private readonly TextBox _name = new() { Location = new Point(20, 20), Width = 200 };

    public SettingsUsage()
    {
        Text = "Settings";
        var settings = Properties.Settings.Default;

        Load += (s, e) =>
        {
            // Restore saved values (with sensible fallbacks)
            _name.Text = settings.UserName;
            if (settings.WindowSize != Size.Empty)
                Size = settings.WindowSize;
            else
                ClientSize = new Size(320, 160);
        };

        FormClosing += (s, e) =>
        {
            // Capture current values and persist them
            settings.UserName = _name.Text;
            settings.WindowSize = Size;
            settings.Save();                 // writes the user.config file
        };

        Controls.Add(new Label { Text = "Name:", Location = new Point(20, 0), AutoSize = true });
        Controls.Add(_name);
    }
}

// Classic read-only app config:
//   var apiUrl = System.Configuration.ConfigurationManager.AppSettings["ApiUrl"];
