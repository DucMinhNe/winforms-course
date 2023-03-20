# Exercise — Lesson 16

1. A **Delete** button that shows `MessageBoxButtons.YesNo` +
   `MessageBoxIcon.Warning`. Update a status label based on the `DialogResult`.
2. An **About** button showing an `Information` box (pass `this` as owner so it
   centres).
3. Handle `FormClosing`: ask "Quit?" and set `e.Cancel = true` when the user
   chooses No, so the window stays open.

**Done when:** delete only happens on Yes, About is informational, and the app
refuses to close unless confirmed.
