# 🪟 winforms-course

> A full Windows Forms course in C# — from your first form to data binding,
> async UI, custom controls, and publishing.
>
> Built from the material I taught as an IT lecturer at **Cao Thắng Technical
> College** (Trường Cao đẳng Kỹ thuật Cao Thắng).

![license](https://img.shields.io/badge/license-MIT-green.svg) ![csharp](https://img.shields.io/badge/C%23-10-239120.svg) ![dotnet](https://img.shields.io/badge/.NET-6%2F7-512BD4.svg) ![winforms](https://img.shields.io/badge/Windows%20Forms-desktop-0078D6.svg) ![lessons](https://img.shields.io/badge/lessons-36-blue.svg) ![topics](https://img.shields.io/badge/topics-24-orange.svg)

---

## How this course is organised

- **`lessons/`** — the structured curriculum. Start here and go in order. Each
  lesson covers one concept with notes, a runnable example, and an exercise.
- **`topics/`** — deeper dives (the message pump, async on the UI thread, GDI+,
  data binding internals, MVP, deployment). Reference these once the basics
  click.

Every lesson and topic is a folder with a `README.md`, an `examples/` directory
of `.cs` snippets, and an `exercise.md`.

## Requirements

- **C# / .NET 6 or 7** SDK — `dotnet --version`
- Windows (WinForms is Windows-only)
- **Visual Studio 2022** (for the visual designer) or VS Code + `dotnet` CLI
- New project: `dotnet new winforms -n MyApp` then `dotnet run`

## Curriculum (lessons/)

### Part 1 — Getting started
1. [Setting up .NET & WinForms](./lessons/01-setup/)
2. [Project structure](./lessons/02-project-structure/)
3. [Your first form](./lessons/03-first-form/)
4. [The designer vs code](./lessons/04-designer-vs-code/)
5. [Form properties](./lessons/05-form-properties/)

### Part 2 — Core controls
6. [Label, TextBox & Button](./lessons/06-label-textbox-button/)
7. [Handling events](./lessons/07-events-basics/)
8. [CheckBox & RadioButton](./lessons/08-checkbox-radiobutton/)
9. [ComboBox & ListBox](./lessons/09-combobox-listbox/)
10. [NumericUpDown & DateTimePicker](./lessons/10-numericupdown-datetimepicker/)
11. [Common control properties](./lessons/11-control-common-properties/)

### Part 3 — Layout
12. [Anchor & Dock](./lessons/12-anchor-dock/)
13. [TableLayoutPanel](./lessons/13-tablelayoutpanel/)
14. [FlowLayoutPanel](./lessons/14-flowlayoutpanel/)
15. [GroupBox, Panel & TabControl](./lessons/15-groupbox-panel-tabcontrol/)

### Part 4 — Events & dialogs
16. [MessageBox](./lessons/16-message-box/)
17. [Common dialogs](./lessons/17-common-dialogs/)
18. [Menus](./lessons/18-menus/)
19. [Toolbar & status bar](./lessons/19-toolbar-statusbar/)
20. [Keyboard & mouse events](./lessons/20-keyboard-mouse-events/)

### Part 5 — Multiple forms
21. [Opening forms: Show vs ShowDialog](./lessons/21-opening-forms/)
22. [Passing data between forms](./lessons/22-passing-data-between-forms/)
23. [Owner & DialogResult](./lessons/23-owner-and-dialogresult/)
24. [MDI applications](./lessons/24-mdi/)

### Part 6 — Data
25. [DataGridView basics](./lessons/25-datagridview-basics/)
26. [Data binding](./lessons/26-data-binding/)
27. [Working with lists](./lessons/27-working-with-lists/)
28. [ADO.NET connections](./lessons/28-ado-net-connection/)
29. [CRUD with a database](./lessons/29-crud-with-database/)
30. [Reading & writing files](./lessons/30-reading-writing-files/)

### Part 7 — Advanced & polish
31. [Timers](./lessons/31-timers/)
32. [Background work & async](./lessons/32-background-work/)
33. [User controls](./lessons/33-user-controls/)
34. [Validation & ErrorProvider](./lessons/34-validation/)
35. [Settings & configuration](./lessons/35-settings-and-config/)
36. [Publishing your app](./lessons/36-publishing/)

## Deep dives (topics/)

### Under the hood
- [The message pump](./topics/message-pump/)
- [Control lifecycle](./topics/control-lifecycle/)
- [Designer-generated code](./topics/designer-generated-code/)
- [Memory & disposal](./topics/disposal-and-leaks/)

### UI thread & responsiveness
- [Async on the UI thread](./topics/async-ui-thread/)
- [Progress & cancellation](./topics/progress-and-cancellation/)

### Data
- [Data binding, deeper](./topics/data-binding-deep/)
- [DataGridView, advanced](./topics/datagridview-advanced/)
- [Binding validation (IDataErrorInfo)](./topics/databinding-validation/)

### Graphics
- [GDI+ drawing](./topics/gdi-plus-drawing/)
- [Custom-painted controls](./topics/custom-painting/)
- [Drag & drop](./topics/drag-and-drop/)
- [High-DPI awareness](./topics/dpi-awareness/)

### Architecture & quality
- [The MVP pattern](./topics/mvp-pattern/)
- [Dependency injection](./topics/dependency-injection/)
- [Unit-testing UI logic](./topics/unit-testing-ui-logic/)
- [Global error handling](./topics/global-error-handling/)

### Polish & platform
- [Settings, deeper](./topics/settings-deep/)
- [Keyboard shortcuts & mnemonics](./topics/keyboard-shortcuts/)
- [Resources & localization](./topics/resources-localization/)
- [P/Invoke & Win32 interop](./topics/pinvoke-interop/)
- [Modern .NET WinForms](./topics/modern-dotnet-winforms/)
- [ClickOnce deployment](./topics/clickonce-deployment/)
- [Single-file publish](./topics/single-file-publish/)

## License

MIT — see [LICENSE](./LICENSE). Use it, fork it, teach with it.
