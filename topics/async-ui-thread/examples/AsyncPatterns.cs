using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HelloForms;

public class AsyncPatterns : Form
{
    private readonly Label _status = new() { AutoSize = true, Location = new(20, 20) };
    private static readonly HttpClient Http = new();

    public AsyncPatterns()
    {
        var cpuBtn = new Button { Text = "CPU work", Location = new(20, 60) };
        var ioBtn = new Button { Text = "Download", Location = new(120, 60) };
        var threadBtn = new Button { Text = "Raw thread", Location = new(230, 60) };

        // CPU-bound → offload with Task.Run, resume on UI thread after await.
        cpuBtn.Click += async (s, e) =>
        {
            _status.Text = "Crunching...";
            int sum = await Task.Run(() => { int t = 0; for (int i = 0; i < 100_000_000; i++) t += i % 7; return t; });
            _status.Text = $"Done: {sum}";        // back on UI thread
        };

        // I/O-bound → await the async API directly (no Task.Run).
        ioBtn.Click += async (s, e) =>
        {
            _status.Text = "Downloading...";
            string html = await Http.GetStringAsync("https://example.com");
            _status.Text = $"Got {html.Length} chars";
        };

        // Background thread → must marshal UI updates with Invoke.
        threadBtn.Click += (s, e) =>
        {
            new Thread(() =>
            {
                Thread.Sleep(1500);
                SetStatus("Updated from background thread");
            }) { IsBackground = true }.Start();
        };

        Controls.AddRange(new Control[] { _status, cpuBtn, ioBtn, threadBtn });
    }

    private void SetStatus(string text)
    {
        if (_status.InvokeRequired) _status.Invoke(() => _status.Text = text);
        else _status.Text = text;
    }
}
