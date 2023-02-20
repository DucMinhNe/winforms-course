# Exercise — Lesson 10

1. Add a `NumericUpDown` (Min 1, Max 99, Value 1) and compute
   `Value * 19.99m`, shown as currency (`.ToString("C")`) on `ValueChanged`.
2. Add a `DateTimePicker` with `CustomFormat = "yyyy-MM-dd"` and
   `MinDate = DateTime.Today`. Show how many days until the chosen date.
3. (Bonus) Add a `DecimalPlaces = 2` NumericUpDown for a custom unit price and
   recompute the total live.

**Done when:** the total updates as quantity changes (typed as `decimal`, no
string parsing) and the day-count tracks the picked date.
