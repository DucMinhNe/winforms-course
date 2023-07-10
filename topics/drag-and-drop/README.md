# Topic: Drag & drop

Move data between controls (or from Explorer) with the mouse.

## The four pieces

1. **Start the drag** on the source: in `MouseDown` (or `ItemDrag` for
   ListView/TreeView), call `DoDragDrop(data, DragDropEffects.Copy | Move)`.
2. **Allow drops** on the target: set `AllowDrop = true`.
3. **`DragEnter`** on the target: inspect `e.Data`, and set `e.Effect` to show
   the right cursor (a drop is only allowed if you set a non-`None` effect).
4. **`DragDrop`** on the target: read `e.Data.GetData(...)` and apply it.

```csharp
// Source
listBox.MouseDown += (s, e) =>
{
    if (listBox.SelectedItem is string item)
        listBox.DoDragDrop(item, DragDropEffects.Copy);
};

// Target
target.AllowDrop = true;
target.DragEnter += (s, e) =>
    e.Effect = e.Data!.GetDataPresent(DataFormats.Text) ? DragDropEffects.Copy : DragDropEffects.None;
target.DragDrop += (s, e) =>
    target.Text = (string)e.Data!.GetData(DataFormats.Text)!;
```

## Files from Explorer

Accept dropped files by checking `DataFormats.FileDrop`:

```csharp
if (e.Data!.GetDataPresent(DataFormats.FileDrop))
{
    var paths = (string[])e.Data.GetData(DataFormats.FileDrop)!;
}
```

## Tips

- `DragOver` fires continuously — keep it cheap.
- Use `DragDropEffects` to communicate Copy vs Move; the modifier keys
  (Ctrl/Shift) influence what the user expects.

## Example

See `examples/DragDropForm.cs`.

## Exercise

1. Two `ListBox`es; drag an item from one and drop (copy) it into the other.
2. Make the target accept **files** dropped from Explorer and list their paths.
3. Set `e.Effect` correctly so the cursor shows copy/no-drop appropriately.
