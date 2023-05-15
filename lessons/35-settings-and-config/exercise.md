# Exercise — Lesson 35

1. In the project's **Settings** designer (Properties ▸ Settings), add two
   **User**-scope settings: `UserName` (string) and `WindowSize` (System.Drawing.Size).
2. On the form's `Load`, restore them: pre-fill a textbox with `UserName` and
   set the form `Size` to `WindowSize` (fall back to a default if empty).
3. On `FormClosing`, write the current values back and call
   `Properties.Settings.Default.Save()`.
4. Run, change the name, resize the window, close, reopen — both should be
   remembered.

**Done when:** user preferences survive a restart, stored in the per-user
settings file (not hard-coded).
