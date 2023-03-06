# Lesson 15: GroupBox, Panel & TabControl

Containers that organise controls into sections.

## What you'll learn

- **Panel** — a plain rectangular container. Use it to group controls so you can
  move/show/hide them together, add `BorderStyle`, or enable `AutoScroll` for
  overflow.
- **GroupBox** — a Panel with a titled border (`Text`). Also the natural group
  boundary for RadioButtons (Lesson 08).
- **TabControl** — multiple pages. Each tab is a `TabPage` (itself a container)
  in `TabPages`. Read/set the active page with `SelectedTab` /
  `SelectedIndex`; react with `SelectedIndexChanged`.
- Containers nest: a `TabPage` can hold a `TableLayoutPanel` holding controls.
- A control's coordinates are **relative to its parent container**, not the
  form.

```csharp
var tabs = new TabControl { Dock = DockStyle.Fill };
var general = new TabPage("General");
var advanced = new TabPage("Advanced");
general.Controls.Add(new CheckBox { Text = "Enable", Location = new Point(12, 12) });
tabs.TabPages.AddRange(new[] { general, advanced });
```

## Example

See `examples/SettingsForm.cs`.

## Exercise

1. A `TabControl` (Dock Fill) with two tabs: "General" and "Account".
2. Put a couple of controls on each tab (note coordinates are relative to the
   tab page).
3. Add a label that shows the active tab's `Text` on `SelectedIndexChanged`.
4. Inside one tab, group related options in a `GroupBox`.
