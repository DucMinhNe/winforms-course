# Exercise — P/Invoke & Win32 interop

1. Create an `internal static partial class Native` and declare `FlashWindow`
   from `user32.dll` with `[LibraryImport]`.
2. Call `Native.FlashWindow(this.Handle, true)` from a button — watch the
   taskbar button flash.
3. Declare `GetSystemMetrics(int)` and use `SM_CXSCREEN`/`SM_CYSCREEN` (0/1) to
   show the primary screen resolution.
4. Note: this only runs on Windows, and getting the signature wrong corrupts
   memory — match types and marshalling exactly.

**Done when:** you can call a native Win32 function from your form via the form's
`Handle`, and you understand when P/Invoke is (and isn't) worth it.
