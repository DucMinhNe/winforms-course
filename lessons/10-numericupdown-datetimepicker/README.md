# Lesson 10: NumericUpDown & DateTimePicker

Typed input for numbers and dates — no parsing strings.

## What you'll learn

- **NumericUpDown** — a spinner for numbers. Props: `Minimum`, `Maximum`,
  `Value` (a `decimal`), `Increment`, `DecimalPlaces`, `ThousandsSeparator`.
  React with `ValueChanged`. No need to validate "is this a number" — it can't
  be anything else.
- **DateTimePicker** — a calendar/clock picker. Props: `Value` (a `DateTime`),
  `Format` (`Long`, `Short`, `Time`, `Custom`), `MinDate`, `MaxDate`. For
  `Custom`, set `CustomFormat = "yyyy-MM-dd"`. React with `ValueChanged`.
- Both give you a strongly-typed value, so your code does math/date logic, not
  `int.TryParse`.

```csharp
numQty.Minimum = 1; numQty.Maximum = 99; numQty.Value = 1;
dtpWhen.Format = DateTimePickerFormat.Custom;
dtpWhen.CustomFormat = "yyyy-MM-dd HH:mm";
lblTotal.Text = (numQty.Value * price).ToString("C");
```

## Example

See `examples/OrderForm.cs`.

## Exercise

1. A `NumericUpDown` quantity (1–99) and a fixed unit price; show
   `Value * price` formatted as currency, updating on `ValueChanged`.
2. A `DateTimePicker` with `MinDate = today`; show the number of days until the
   picked date.
