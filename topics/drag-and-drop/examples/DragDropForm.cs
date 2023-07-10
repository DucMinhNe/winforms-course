using System.Drawing;
using System.Windows.Forms;

namespace HelloForms;

public class DragDropForm : Form
{
    public DragDropForm()
    {
        Text = "Drag & drop";
        ClientSize = new Size(420, 260);

        var source = new ListBox { Location = new(20, 20), Size = new(170, 180) };
        source.Items.AddRange(new[] { "Apple", "Banana", "Cherry" });

        var target = new ListBox { Location = new(220, 20), Size = new(170, 180), AllowDrop = true };

        // Start the drag from the source
        source.MouseDown += (s, e) =>
        {
            if (source.SelectedItem is string item)
                source.DoDragDrop(item, DragDropEffects.Copy);
        };

        // Allow text drops AND file drops; set the cursor effect
        target.DragEnter += (s, e) =>
        {
            e.Effect = (e.Data!.GetDataPresent(DataFormats.Text) ||
                        e.Data.GetDataPresent(DataFormats.FileDrop))
                ? DragDropEffects.Copy
                : DragDropEffects.None;
        };

        target.DragDrop += (s, e) =>
        {
            if (e.Data!.GetDataPresent(DataFormats.FileDrop))
                target.Items.AddRange((string[])e.Data.GetData(DataFormats.FileDrop)!);
            else if (e.Data.GetDataPresent(DataFormats.Text))
                target.Items.Add((string)e.Data.GetData(DataFormats.Text)!);
        };

        Controls.Add(source);
        Controls.Add(target);
    }
}
