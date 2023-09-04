# Exercise — Single-file publish

1. Publish a portable single exe:
   ```bash
   dotnet publish -c Release -r win-x64 --self-contained true -p:PublishSingleFile=true
   ```
   Copy the single `.exe` to an empty folder (or another machine) and run it.
2. Publish framework-dependent and compare the output size — note the
   portability/size trade-off.
3. Add `-p:PublishTrimmed=true -p:EnableCompressionInSingleFile=true`; confirm
   the app still launches and works (WinForms uses reflection — watch for
   missing-type errors after trimming).
4. Set `<Version>` and `<ApplicationIcon>` in the csproj and verify the exe's
   file properties.

**Done when:** you have a single portable `.exe` that runs on a clean machine,
and you can justify when to use self-contained vs framework-dependent vs
trimmed.
