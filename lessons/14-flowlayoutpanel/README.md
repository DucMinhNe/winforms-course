# Lesson 14: FlowLayoutPanel

Lay controls out in a flow — left-to-right or top-to-bottom — that wraps.

## What you'll learn

- `FlowLayoutPanel` stacks its children in order, wrapping to the next line like
  text. No coordinates needed.
- `FlowDirection`: `LeftToRight` (default), `TopDown`, `RightToLeft`, `BottomUp`.
- `WrapContents` (default true) wraps to a new row/column when space runs out;
  set false + `AutoScroll = true` for a single scrolling strip.
- Spacing via each child's `Margin`; container padding via `Padding`.
- Perfect for toolbars, tag lists, button bars, and dynamic galleries where you
  add an unknown number of items at runtime.

```csharp
var flow = new FlowLayoutPanel { Dock = DockStyle.Fill, FlowDirection = FlowDirection.LeftToRight, WrapContents = true };
foreach (var tag in tags)
    flow.Controls.Add(new Button { Text = tag, AutoSize = true, Margin = new Padding(4) });
```

## Example

See `examples/TagsForm.cs`.

## Exercise

1. A `FlowLayoutPanel` docked `Fill`. A textbox + "Add" button at the top let
   the user add a tag button to the flow.
2. Clicking a tag removes it (`flow.Controls.Remove(btn)`).
3. Resize the window and watch the tags re-wrap automatically.
