# Lesson 11: Common control properties

Properties shared by (almost) every control — learn once, use everywhere.

## What you'll learn

Every control inherits from `Control`, so these apply broadly:

- **`Name`** — the field name you reference in code (`btnSave`). Prefix
  conventions: `btn`, `txt`, `lbl`, `cmb`, `lst`, `chk`, `dgv`…
- **`Text`** — caption/content (meaning varies by control).
- **`Enabled`** — greyed-out and non-interactive when `false`.
- **`Visible`** — shown/hidden (still exists; `Hide()`/`Show()` toggle it).
- **`Location` / `Size` / `Bounds`** — position and dimensions in pixels.
- **`Anchor` / `Dock`** — resize behaviour (next lesson).
- **`Tag`** — a free `object?` slot to stash data on a control (great with
  shared handlers).
- **`Font`, `ForeColor`, `BackColor`** — appearance.
- **`TabIndex` / `TabStop`** — keyboard tab order.
- **`Focus()`** — give it keyboard focus; **`Parent`** — its container;
  **`Controls`** — its children (for containers).

```csharp
// Stash data on the control with Tag, read it in a shared handler:
foreach (var p in products)
{
    var btn = new Button { Text = p.Name, Tag = p };
    btn.Click += (s, e) => Select((Product)((Button)s!).Tag!);
    panel.Controls.Add(btn);
}
```

## Example

See `examples/CommonProps.cs`.

## Exercise

1. Generate 5 buttons in a loop, each with a different `Tag` (an int 1–5).
2. One shared `Click` handler reads `Tag` and shows it in a label.
3. A "toggle" button that flips another control's `Enabled` and `Visible`.
4. Set `TabIndex` so tabbing moves in the order you want.
