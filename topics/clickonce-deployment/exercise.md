# Exercise — ClickOnce deployment

1. In Visual Studio, create a ClickOnce publish profile for a small app and
   publish to a local folder. Choose "available offline" so it gets a Start-menu
   shortcut.
2. Run the generated `setup.exe` to install it; launch from the Start menu.
3. Make a visible change (e.g. the form title), **bump the Publish version**,
   and re-publish to the same folder.
4. Relaunch the installed app and confirm it detects and applies the update.

**Done when:** you have an installed, auto-updating app and you can explain when
to choose ClickOnce vs MSIX vs a plain published exe.
