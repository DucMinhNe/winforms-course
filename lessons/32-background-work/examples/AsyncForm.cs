using System;
using System.Drawing;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HelloForms;

public class AsyncForm : Form
{
    public AsyncForm()
    {
        Text = "Async";
        ClientSize = new Size(320, 180);

        var status = new Label { Location = new Point(20, 20), AutoSize = true };
        var btn = new Button { Text = "Do slow work", Location = new Point(20, 60) };
        var btnThread = new Button { Text = "Raw thread + Invoke", Location = new Point(20, 100), Width = 180 };

        // Modern: async/await keeps the UI responsive, resumes on the UI thread.
        btn.Click += async (sender, e) =>
        {
            btn.Enabled = false;
            status.Text = "Working...";
            await Task.Run(() => Thread.Sleep(3000));   // slow work OFF the UI thread
            status.Text = "Done!";                       // back ON the UI thread
            btn.Enabled = true;
        };

        // Old-school: a background thread MUST marshal UI updates with Invoke.
        btnThread.Click += (sender, e) =>
        {
            new Thread(() =>
            {
                Thread.Sleep(2000);
                if (status.InvokeRequired)
                    status.Invoke(() => status.Text = "Updated from a thread");
                else
                    status.Text = "Updated from a thread";
            }) { IsBackground = true }.Start();
        };

        Controls.AddRange(new Control[] { status, btn, btnThread });
    }
}
