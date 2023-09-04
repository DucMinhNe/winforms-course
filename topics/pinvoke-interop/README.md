# Topic: P/Invoke & Win32 interop

Call native Windows APIs when .NET doesn't expose what you need.

## What P/Invoke is

**Platform Invoke** lets managed code call functions in native DLLs
(`user32.dll`, `kernel32.dll`, …). You declare the function with
`[LibraryImport]` (the modern, source-generated way) or `[DllImport]` (classic)
and call it like a normal method.

```csharp
using System.Runtime.InteropServices;

internal static partial class Native
{
    [LibraryImport("user32.dll")]
    [return: MarshalAs(UnmanagedType.Bool)]
    internal static partial bool FlashWindow(IntPtr hWnd, [MarshalAs(UnmanagedType.Bool)] bool invert);
}

// Flash the taskbar button to get attention:
Native.FlashWindow(this.Handle, true);
```

`this.Handle` is the form's native window handle (HWND) — the bridge between
WinForms and Win32.

## Common real uses

- Flash/peek the taskbar, set window attributes you can't reach in WinForms.
- Read system metrics (`GetSystemMetrics`), media controls, global hotkeys
  (`RegisterHotKey`).
- Send messages with `SendMessage` for fine control over native controls.

## Marshalling & safety

- Match the native signature exactly: types, `[MarshalAs]`, `CharSet`/string
  marshalling. A mismatch corrupts memory.
- `[LibraryImport]` (.NET 7+) generates marshalling at compile time — faster and
  AOT-friendly than `[DllImport]`.
- Wrap native handles in `SafeHandle` when you own their lifetime.
- P/Invoke is **Windows-only** and bypasses .NET safety — reach for it only when
  there's no managed API.

## Example

See `examples/Native.cs`.

## Exercise

1. Declare `FlashWindow` (or `MessageBeep`) via `[LibraryImport]` in a `partial`
   class.
2. Call it from a button using `this.Handle`.
3. (Bonus) P/Invoke `GetSystemMetrics(SM_CXSCREEN/SM_CYSCREEN)` and show the
   primary screen size.
