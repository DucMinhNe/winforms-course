using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace HelloForms;

public class LifecycleForm : Form
{
    public LifecycleForm()
    {
        Debug.WriteLine("1. Constructor");

        Load += (s, e) => Debug.WriteLine("2. Load (once, before first show)");
        Shown += (s, e) => Debug.WriteLine("3. Shown (once, after visible)");
        Activated += (s, e) => Debug.WriteLine("Activated");
        Deactivate += (s, e) => Debug.WriteLine("Deactivate");

        FormClosing += (s, e) =>
        {
            Debug.WriteLine($"FormClosing (reason: {e.CloseReason})");
            // Veto example: confirm before closing
            if (MessageBox.Show("Close the form?", "Confirm", MessageBoxButtons.YesNo) == DialogResult.No)
                e.Cancel = true;
        };
        FormClosed += (s, e) => Debug.WriteLine("FormClosed");
    }

    protected override void Dispose(bool disposing)
    {
        Debug.WriteLine("Dispose");
        base.Dispose(disposing);
    }
}
