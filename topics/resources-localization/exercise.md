# Exercise — Resources & localization

1. Add `Properties/Strings.resx` with `Greeting = "Hello"`; bind a label to
   `Properties.Strings.Greeting`.
2. Add `Properties/Strings.vi.resx` with `Greeting = "Xin chào"`.
3. In `Program.Main`, set `Thread.CurrentThread.CurrentUICulture =
   new CultureInfo("vi")` before `Application.Run(...)` and confirm the label
   shows the Vietnamese text.
4. (Bonus) Set a form's `Localizable = true`, switch `Language` to `vi`,
   translate a button, and verify the satellite assembly loads at runtime.

**Done when:** the same code shows English or Vietnamese based purely on the UI
culture, with strings coming from `.resx` (not literals).
