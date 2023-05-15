# Lesson 33: User controls

Bundle several controls into one reusable component.

## What you'll learn

- A **UserControl** is a mini-form you compose once and drop in many places.
  `Add ▸ User Control` (or inherit `UserControl`).
- Lay out child controls inside it; expose a clean API with **public
  properties** and **events** — don't let consumers poke at the inner controls.
- Raise your own events so the parent can react:
  ```csharp
  public event EventHandler? Search;
  protected virtual void OnSearch() => Search?.Invoke(this, EventArgs.Empty);
  ```
- Once built, it shows in the Toolbox and can be dragged onto forms like any
  control.
- Great for: a labelled input, a search bar, a star-rating widget, a reusable
  address block.

## Example

See `examples/SearchBox.cs` — a textbox + button packaged with a `Query`
property and a `Search` event.

## Exercise

1. Build a `SearchBox : UserControl` containing a `TextBox` + a "Go" `Button`.
2. Expose `public string Query { get; set; }` (proxying the textbox `Text`).
3. Raise a `public event EventHandler Search;` when Go is clicked or Enter is
   pressed.
4. Drop two `SearchBox`es on a form and wire their `Search` events to different
   handlers.

**Done when:** the parent uses `Query` and `Search` only — never the inner
controls.
