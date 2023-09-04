using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace HelloForms;

// Modern source-generated P/Invoke (.NET 7+). Class must be `partial`.
internal static partial class Native
{
    [LibraryImport("user32.dll")]
    [return: MarshalAs(UnmanagedType.Bool)]
    internal static partial bool FlashWindow(IntPtr hWnd, [MarshalAs(UnmanagedType.Bool)] bool bInvert);

    [LibraryImport("user32.dll")]
    internal static partial int GetSystemMetrics(int nIndex);

    internal const int SM_CXSCREEN = 0;
    internal const int SM_CYSCREEN = 1;
}

public class InteropForm : Form
{
    public InteropForm()
    {
        Text = "P/Invoke";
        ClientSize = new System.Drawing.Size(320, 160);

        var flash = new Button { Text = "Flash taskbar", Location = new(20, 20) };
        flash.Click += (s, e) => Native.FlashWindow(Handle, true);   // Handle = native HWND

        var size = new Button { Text = "Screen size", Location = new(20, 60) };
        var lbl = new Label { Location = new(20, 100), AutoSize = true };
        size.Click += (s, e) =>
            lbl.Text = $"{Native.GetSystemMetrics(Native.SM_CXSCREEN)} x {Native.GetSystemMetrics(Native.SM_CYSCREEN)}";

        Controls.AddRange(new Control[] { flash, size, lbl });
    }
}
