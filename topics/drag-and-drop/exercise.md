# Exercise — Drag & drop

1. Two `ListBox`es. On the source's `MouseDown`, start
   `DoDragDrop(selectedItem, DragDropEffects.Copy)`.
2. On the target (`AllowDrop = true`): in `DragEnter` set
   `e.Effect = Copy` when `DataFormats.Text` is present; in `DragDrop` add the
   text to the target list.
3. Extend the target to also accept **files** from Explorer
   (`DataFormats.FileDrop`) and add their paths.
4. Confirm the cursor shows "copy" over the target and "no-drop" elsewhere.

**Done when:** you can drag items between the lists and drop files from
Explorer, with correct drop-effect cursors.
