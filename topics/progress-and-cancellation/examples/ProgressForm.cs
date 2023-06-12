using System;
using System.Drawing;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HelloForms;

public class ProgressForm : Form
{
    private readonly ProgressBar _bar = new() { Location = new(20, 20), Width = 300 };
    private readonly Label _status = new() { Location = new(20, 55), AutoSize = true };
    private readonly Button _start = new() { Text = "Start", Location = new(20, 90) };
    private readonly Button _cancel = new() { Text = "Cancel", Location = new(110, 90), Enabled = false };
    private CancellationTokenSource? _cts;

    public ProgressForm()
    {
        Text = "Progress & cancel";
        ClientSize = new Size(360, 150);

        _start.Click += async (s, e) => await RunAsync();
        _cancel.Click += (s, e) => _cts?.Cancel();

        Controls.AddRange(new Control[] { _bar, _status, _start, _cancel });
    }

    private async Task RunAsync()
    {
        _start.Enabled = false; _cancel.Enabled = true;
        _cts = new CancellationTokenSource();
        var token = _cts.Token;

        // Created on the UI thread → Report() posts back here.
        var progress = new Progress<int>(p => _bar.Value = p);

        try
        {
            await Task.Run(() =>
            {
                for (int i = 0; i <= 100; i++)
                {
                    token.ThrowIfCancellationRequested();
                    Thread.Sleep(30);                       // simulate work
                    ((IProgress<int>)progress).Report(i);
                }
            }, token);
            _status.Text = "Completed";
        }
        catch (OperationCanceledException)
        {
            _status.Text = "Cancelled";
        }
        finally
        {
            _start.Enabled = true; _cancel.Enabled = false;
            _cts.Dispose(); _cts = null;
        }
    }
}
