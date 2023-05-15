# Lesson 34: Validation & ErrorProvider

Stop bad input at the form, with clear inline feedback.

## What you'll learn

- The **`Validating`** event fires when a control loses focus (if
  `CausesValidation = true`, the default). Set `e.Cancel = true` to keep focus
  there until it's fixed.
- **`ErrorProvider`** shows a red ⚠ icon next to a control with a tooltip
  message — far better UX than a `MessageBox` per field.
  ```csharp
  if (string.IsNullOrWhiteSpace(txtEmail.Text))
  {
      errorProvider.SetError(txtEmail, "Email is required");
      e.Cancel = true;
  }
  else errorProvider.SetError(txtEmail, "");   // clear it
  ```
- Validate everything before submit with `this.ValidateChildren()` — it runs
  every control's `Validating` and returns false if any cancelled.
- Disable the Submit button until the form is valid, or validate on click.

## Example

See `examples/SignupForm.cs`.

## Exercise

1. A signup form: Name (required), Email (required + contains `@`), Age
   (NumericUpDown 0–120).
2. Use an `ErrorProvider` + `Validating` handlers to flag empty/invalid fields
   inline.
3. The **Submit** button calls `ValidateChildren()`; only proceed (show
   "Welcome!") when it returns true.
