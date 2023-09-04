# Topic: Resources & localization

Ship your app in multiple languages.

## Resources (.resx)

`.resx` files hold strings, images, icons, and other assets, compiled into the
assembly and accessed in a type-safe way:

- Add a `Strings.resx` to the project; entries become
  `Properties.Strings.Greeting`.
- Form-level `Form1.resx` stores that form's icon/images and (when localized)
  its control text and layout.

## Localizing a form

1. Set the form's **`Localizable = true`** in the designer.
2. Set **`Language`** to a culture (e.g. `vi`, `fr`). The designer now writes
   changes into a culture-specific `Form1.<culture>.resx`.
3. Translate each control's `Text` for that culture. Switch `Language` back to
   `(Default)` for the base.

At runtime WinForms loads the resources for the current UI culture from
**satellite assemblies** (`<culture>\App.resources.dll`).

## Switching culture

Set the culture **before** creating localized forms:

```csharp
var culture = new CultureInfo("vi");
Thread.CurrentThread.CurrentUICulture = culture;   // which .resx to load
Thread.CurrentThread.CurrentCulture   = culture;   // number/date formatting
Application.Run(new MainForm());
```

To switch at runtime, re-create the form (or re-run `InitializeComponent` logic)
under the new culture.

## Tips

- Keep user-facing strings in `.resx`, not hard-coded literals.
- `CurrentUICulture` picks the translation; `CurrentCulture` controls
  number/date/currency formatting — set both.
- RTL languages: set `RightToLeft` / `RightToLeftLayout`.

## Example

See `examples/localization-notes.txt`.

## Exercise

1. Add a `Strings.resx` with a `Greeting` entry; show it in a label via
   `Properties.Strings.Greeting`.
2. Add `Strings.vi.resx` with the Vietnamese translation.
3. At startup set `CurrentUICulture` to `vi` and confirm the label switches.
