# Exercise — Lesson 07

1. Create buttons "1", "2", "3". Attach the **same** `Click` handler to all
   three; inside it, cast `sender` to `Button` and append its `Text` to a
   read-only textbox.
2. Add a `TextChanged` handler that shows the live length in a label.
3. Add a "Clear" button (its own handler) that empties the textbox.

**Bonus:** detach the digit handler with `-=` after 10 characters and confirm
the buttons stop responding.

**Done when:** one handler serves three buttons via `sender`, and the count
updates as the text changes.
