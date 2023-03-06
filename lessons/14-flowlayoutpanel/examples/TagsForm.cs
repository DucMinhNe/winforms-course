using System.Drawing;
using System.Windows.Forms;

namespace HelloForms;

public class TagsForm : Form
{
    public TagsForm()
    {
        Text = "Tags";
        ClientSize = new Size(380, 260);

        var input = new TextBox { Dock = DockStyle.Top, PlaceholderText = "New tag, then Add" };
        var add = new Button { Text = "Add", Dock = DockStyle.Top };

        var flow = new FlowLayoutPanel
        {
            Dock = DockStyle.Fill,
            FlowDirection = FlowDirection.LeftToRight,
            WrapContents = true,        // tags re-flow to the next line on resize
            AutoScroll = true,
            Padding = new Padding(6),
        };

        add.Click += (s, e) =>
        {
            var text = input.Text.Trim();
            if (text.Length == 0) return;

            var tag = new Button { Text = text + "  ✕", AutoSize = true, Margin = new Padding(4) };
            tag.Click += (s2, e2) => flow.Controls.Remove(tag);   // click a tag to remove it
            flow.Controls.Add(tag);
            input.Clear();
            input.Focus();
        };

        // Order matters: docked-Top controls claim the top first, Fill takes the rest.
        Controls.Add(flow);
        Controls.Add(add);
        Controls.Add(input);
        AcceptButton = add;
    }
}
