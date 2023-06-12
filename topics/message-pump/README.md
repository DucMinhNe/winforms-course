# Topic: The message pump

What `Application.Run()` actually does.

## The loop

Windows delivers input (clicks, keys, paint requests) as **messages** to a
queue per UI thread. `Application.Run(form)` starts a loop that:

1. pulls the next message from the queue,
2. translates it,
3. dispatches it to the target window's **window procedure** (WndProc),
4. repeats until the form closes (a `WM_QUIT` message).

Every event you handle (`Click`, `Paint`, `KeyDown`) ultimately originates as a
Windows message dispatched by this pump.

## Why "don't block the UI thread" matters

The pump runs on **one thread**. While your `Click` handler runs, the pump
can't pull the next message — so the window stops repainting and responding
("Not Responding"). That's the whole reason for async/background work
(see [async-ui-thread](../async-ui-thread/)).

## Hooking it

- Override `WndProc(ref Message m)` on a form/control to inspect or handle raw
  messages (e.g. `WM_KEYDOWN`, custom messages, `WM_NCHITTEST`). Call
  `base.WndProc(ref m)` for default handling.
- `Application.DoEvents()` *manually* pumps pending messages — it looks like it
  "unfreezes" the UI mid-loop, but it's a footgun (re-entrancy, stack growth).
  Use async instead; treat `DoEvents()` as a code smell.

## Example

See `examples/RawMessages.cs`.

## Exercise

1. Override `WndProc` on a form and `Debug.WriteLine(m.Msg)` to watch the flood
   of messages as you move the mouse and click.
2. Add a 5-second `Thread.Sleep` in a button click and watch the window go
   "Not Responding" — then explain why in terms of the pump.
