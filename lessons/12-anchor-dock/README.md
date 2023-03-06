# Lesson 12: Anchor & Dock

Make controls respond when the window resizes — the #1 beginner pain point.

## What you'll learn

- By default a control keeps its `Location`/`Size` when the form resizes — so it
  looks wrong on any other window size.
- **`Anchor`** — pins edges. Anchored to `Top|Left` (default) it stays put;
  anchor `Top|Right` and it slides with the right edge; anchor
  `Left|Right` (both) and it **stretches** horizontally.
- **`Dock`** — glues the control to a side (`Top`, `Bottom`, `Left`, `Right`)
  or `Fill` (takes all remaining space). Docking order matters: earlier-docked
  controls claim their edge first.
- Rule of thumb: `Dock` for big regions (a toolbar on top, content filling the
  rest); `Anchor` for buttons that should hug a corner.

```csharp
txtSearch.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right; // stretches wide
btnOk.Anchor     = AnchorStyles.Bottom | AnchorStyles.Right;                  // hugs bottom-right
grid.Dock        = DockStyle.Fill;                                            // fills the rest
```

## Example

See `examples/ResizeForm.cs`.

## Exercise

1. A textbox anchored `Top|Left|Right` so it widens with the form.
2. OK/Cancel buttons anchored `Bottom|Right` so they stay in the corner.
3. A `ListBox` docked `Fill` (add it last so anchored controls keep their spot,
   or place it in its own panel).
4. Resize the window and confirm everything behaves.
