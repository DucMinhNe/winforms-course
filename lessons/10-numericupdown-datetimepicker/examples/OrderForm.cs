using System;
using System.Drawing;
using System.Windows.Forms;

namespace HelloForms;

public class OrderForm : Form
{
    private const decimal UnitPrice = 19.99m;

    public OrderForm()
    {
        Text = "Order";
        ClientSize = new Size(340, 200);

        var qty = new NumericUpDown
        {
            Location = new Point(20, 20),
            Minimum = 1,
            Maximum = 99,
            Value = 1,
        };
        var lblTotal = new Label { Location = new Point(160, 24), AutoSize = true };
        void UpdateTotal(object? s, EventArgs e) => lblTotal.Text = (qty.Value * UnitPrice).ToString("C");
        qty.ValueChanged += UpdateTotal;
        UpdateTotal(null, EventArgs.Empty);

        var when = new DateTimePicker
        {
            Location = new Point(20, 70),
            Width = 200,
            Format = DateTimePickerFormat.Custom,
            CustomFormat = "yyyy-MM-dd",
            MinDate = DateTime.Today,
        };
        var lblDays = new Label { Location = new Point(20, 110), AutoSize = true };
        when.ValueChanged += (s, e) =>
            lblDays.Text = $"{(when.Value.Date - DateTime.Today).Days} day(s) from now";

        Controls.AddRange(new Control[] { qty, lblTotal, when, lblDays });
    }
}
