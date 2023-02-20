# Lesson 08: CheckBox & RadioButton

Boolean choices and mutually-exclusive choices.

## What you'll learn

- **CheckBox** — independent on/off. Read `Checked` (bool); react to
  `CheckedChanged`. (`ThreeState = true` adds an indeterminate state via
  `CheckState`.)
- **RadioButton** — pick **one** from a group. Radios are grouped by their
  **container**: all radios in the same `GroupBox`/`Panel` are mutually
  exclusive. Put separate groups in separate containers.
- Read which radio is selected by checking each one's `Checked`, or track it in
  the `CheckedChanged` handler.

```csharp
chkAgree.CheckedChanged += (s, e) => btnNext.Enabled = chkAgree.Checked;

// Radios inside a GroupBox are automatically exclusive:
if (rbSmall.Checked) size = "S";
else if (rbMedium.Checked) size = "M";
else if (rbLarge.Checked) size = "L";
```

## Example

See `examples/OptionsForm.cs`.

## Exercise

1. A CheckBox "I agree" that enables a "Continue" button only when checked.
2. A `GroupBox` with three RadioButtons (Small/Medium/Large); show the chosen
   size in a label as it changes.
3. Add a **second** GroupBox of radios and confirm the two groups don't
   interfere.
