using System.Diagnostics;
using System.Windows.Forms;

namespace HelloForms;

public class RawMessages : Form
{
    private const int WM_LBUTTONDOWN = 0x0201;

    // WndProc receives every Windows message dispatched by the pump.
    protected override void WndProc(ref Message m)
    {
        if (m.Msg == WM_LBUTTONDOWN)
            Debug.WriteLine($"Left button down at lParam={m.LParam}");

        base.WndProc(ref m);   // let the default handling run (raises Click, etc.)
    }
}

// The pump (simplified) is what Application.Run does:
//   while (GetMessage(out msg))   // blocks until a message arrives
//   {
//       TranslateMessage(msg);
//       DispatchMessage(msg);     // → the target window's WndProc
//   }
//
// Blocking a Click handler stalls THIS loop → "Not Responding".
