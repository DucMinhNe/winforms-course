# Lesson 19: Toolbar & status bar

Quick-action buttons up top, live status down below.

## What you'll learn

- **ToolStrip** — a toolbar. Add `ToolStripButton`s (icon and/or text via
  `DisplayStyle`), `ToolStripSeparator`s, and even `ToolStripComboBox` /
  `ToolStripTextBox`. Each button has a `Click` event like any button.
- **StatusStrip** — the bar at the bottom. Add `ToolStripStatusLabel`s; one can
  `Spring = true` to stretch and push others to the right. Show progress with
  `ToolStripProgressBar`.
- Both dock automatically (`Top` / `Bottom`). Add them after your `Fill`ed
  content so docking order is right.

```csharp
var tool = new ToolStrip();
tool.Items.Add(new ToolStripButton("Save", null, (s, e) => Save()));
var status = new StatusStrip();
var info = new ToolStripStatusLabel { Spring = true, TextAlign = ContentAlignment.MiddleLeft };
status.Items.Add(info);
info.Text = "Ready";
```

## Example

See `examples/ToolbarForm.cs`.

## Exercise

1. A `ToolStrip` with **New / Open / Save** buttons (text display style).
2. A `StatusStrip` with a `Spring`ed label on the left showing "Ready", and a
   right-aligned label showing the character count of a textbox (update on
   `TextChanged`).
3. Clicking a toolbar button updates the status label to name the action.
