# Exercise — Lesson 04

1. Create a form in the **designer**. Drop a `Label` and a `Button`.
2. Use the **Properties window (F4)** to set:
   - the button's `(Name)` to `btnGo` and `Text` to "Go"
   - the label's `(Name)` to `lblResult`.
3. Open `Form1.Designer.cs` and find the lines matching each change.
4. Double-click `btnGo` to generate `btnGo_Click` in `Form1.cs`. In it, set
   `lblResult.Text = "Clicked at " + DateTime.Now;`.

**Done when:** you can trace a designer change to its generated line, and your
hand-written handler lives in `Form1.cs` (not the designer file).
