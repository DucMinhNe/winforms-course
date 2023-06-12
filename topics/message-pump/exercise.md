# Exercise — The message pump

1. Override `WndProc(ref Message m)` on a form and `Debug.WriteLine(m.Msg)`.
   Run, move the mouse, click — watch the message flood in the Output window.
   Always call `base.WndProc(ref m)`.
2. Filter for `WM_LBUTTONDOWN` (0x0201) and log only those.
3. In a button handler, run `Thread.Sleep(5000)`. Try to drag the window during
   it — it's frozen. Explain why in one sentence (the pump can't dispatch
   `WM_PAINT`/input while your handler hogs the thread).

**Done when:** you've seen raw messages flowing through `WndProc` and can
articulate why blocking the UI thread freezes the window.
