# Exercise — Lesson 31

1. Add a `System.Windows.Forms.Timer` with `Interval = 1000` that updates a
   clock label to `DateTime.Now.ToLongTimeString()` on each `Tick`.
2. Add a **Start/Stop** button toggling `timer.Enabled`.
3. Add a countdown that decrements from 10 each tick and shows "Done!" at zero
   (then ignores further ticks).
4. Dispose/stop the timer in `FormClosed`.

**Done when:** the clock ticks every second, Start/Stop works, and the countdown
stops cleanly at zero.
