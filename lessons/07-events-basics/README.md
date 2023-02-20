# Lesson 07: Handling events

How WinForms tells your code that something happened.

## What you'll learn

- An **event** is a notification (`Click`, `TextChanged`, `Load`). You attach a
  **handler** with `+=`.
- The standard handler signature: `void Handler(object? sender, EventArgs e)`.
  - `sender` — the control that raised it (cast it to reuse one handler for
    many controls).
  - `e` — extra data; specialised types like `MouseEventArgs`,
    `KeyEventArgs`, `KeyPressEventArgs`.
- Three ways to attach:
  - Designer Events tab (generates `btn_Click`).
  - Code: `btn.Click += Btn_Click;`
  - Lambda: `btn.Click += (s, e) => { ... };`
- Detach with `-=` (matters for long-lived objects to avoid leaks).

```csharp
// One handler shared by several buttons, using sender
void Digit_Click(object? sender, EventArgs e)
{
    var btn = (Button)sender!;
    display.Text += btn.Text;     // each digit button appends its caption
}
```

## Example

See `examples/EventsForm.cs`.

## Exercise

1. Add three buttons "1", "2", "3" and one shared `Click` handler that appends
   the clicked button's `Text` to a textbox (use `sender`).
2. Add a `TextChanged` handler on the textbox that updates a character-count
   label live.
