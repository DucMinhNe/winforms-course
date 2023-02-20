using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace HelloForms;

public class PickerForm : Form
{
    public PickerForm()
    {
        Text = "Pickers";
        ClientSize = new Size(360, 280);

        // ComboBox — pick-only dropdown
        var cmb = new ComboBox
        {
            Location = new Point(20, 20),
            Width = 200,
            DropDownStyle = ComboBoxStyle.DropDownList,
        };
        cmb.Items.AddRange(new[] { "Vietnam", "Singapore", "Japan", "Korea" });
        cmb.SelectedIndex = 0;

        var lblCountry = new Label { Location = new Point(240, 24), AutoSize = true };
        cmb.SelectedIndexChanged += (s, e) => lblCountry.Text = cmb.SelectedItem?.ToString();
        lblCountry.Text = cmb.SelectedItem?.ToString();

        // ListBox — multi-select
        var list = new ListBox
        {
            Location = new Point(20, 60),
            Size = new Size(200, 120),
            SelectionMode = SelectionMode.MultiExtended,
        };
        list.Items.AddRange(new[] { "Reading", "Coding", "Gaming", "Cooking", "Hiking" });

        var btnShow = new Button { Text = "Show selected", Location = new Point(20, 195) };
        var lblHobbies = new Label { Location = new Point(20, 230), AutoSize = true };
        btnShow.Click += (s, e) =>
            lblHobbies.Text = string.Join(", ", list.SelectedItems.Cast<string>());

        Controls.AddRange(new Control[] { cmb, lblCountry, list, btnShow, lblHobbies });
    }
}
