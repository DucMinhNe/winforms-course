# Exercise — Lesson 34

1. Build a signup form with Name, Email, and an Age `NumericUpDown` (0–120).
2. Add an `ErrorProvider`. In each field's `Validating` handler:
   - Name empty → `SetError(name, "Name is required"); e.Cancel = true;`
   - Email without `@` → `SetError(email, "Enter a valid email"); e.Cancel = true;`
   - otherwise clear the error with `SetError(ctrl, "")`.
3. The **Submit** button calls `ValidateChildren()` and only shows "Welcome!"
   when it returns `true`.

**Done when:** invalid fields show the red ⚠ with a tooltip, focus won't leave a
bad field, and Submit is blocked until everything is valid.
