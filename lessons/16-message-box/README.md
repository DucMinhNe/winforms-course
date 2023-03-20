# Lesson 16: MessageBox

Pop up a quick message, warning, or yes/no question.

## What you'll learn

- `MessageBox.Show(...)` is a static, **modal** dialog — it blocks until the
  user answers and returns a `DialogResult`.
- Overloads add a caption, buttons, and an icon:
  ```csharp
  var result = MessageBox.Show(
      "Delete this file?",                 // text
      "Confirm",                            // caption
      MessageBoxButtons.YesNo,              // buttons
      MessageBoxIcon.Warning);              // icon
  if (result == DialogResult.Yes) { /* delete */ }
  ```
- `MessageBoxButtons`: `OK`, `OKCancel`, `YesNo`, `YesNoCancel`, `RetryCancel`.
- `MessageBoxIcon`: `Information`, `Warning`, `Error`, `Question`.
- Pass the form as `owner` so it centres on your window:
  `MessageBox.Show(this, ...)`.
- Don't overuse it — for inline feedback prefer a status label or ErrorProvider.

## Example

See `examples/ConfirmForm.cs`.

## Exercise

1. A "Delete" button that asks `YesNo` + `Warning`; only act on `Yes`.
2. An "About" button showing an `Information` box with your app name.
3. On `FormClosing`, ask "Are you sure you want to quit?" and cancel the close
   if the user picks No (`e.Cancel = true`).
