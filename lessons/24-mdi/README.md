# Lesson 24: MDI applications

Multiple Document Interface — many child windows inside one parent window.

## What you'll learn

- Make a form an MDI container: `IsMdiContainer = true`. It gets a grey work
  area that hosts child windows.
- Open a child: set `child.MdiParent = this; child.Show();`. Children are
  clipped to the parent's client area.
- Track children with `MdiChildren`; the focused one is `ActiveMdiChild`.
- Arrange them: `LayoutMdi(MdiLayout.Cascade | TileHorizontal | TileVertical)`.
- A `MenuStrip` item can auto-list open windows via `MdiWindowListItem`.
- MDI is classic (think old Office). Modern apps often prefer **tabs** instead,
  but MDI is still common in line-of-business WinForms apps.

```csharp
IsMdiContainer = true;
var doc = new DocumentForm { MdiParent = this, Text = $"Document {++_count}" };
doc.Show();
LayoutMdi(MdiLayout.Cascade);
```

## Example

See `examples/MdiParentForm.cs`.

## Exercise

1. A parent form with `IsMdiContainer = true` and a **Window** menu.
2. **Window ▸ New** opens a numbered child (`MdiParent = this`).
3. **Window ▸ Cascade / Tile** call `LayoutMdi(...)`.
4. Set the menu's `MdiWindowListItem` so open documents are listed
   automatically.
