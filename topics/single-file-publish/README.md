# Topic: Single-file publish

Hand someone **one `.exe`** that just runs.

## The goal

`dotnet publish` can bundle your app — and optionally the .NET runtime — into a
single executable, so there's no folder of DLLs and (optionally) no .NET
install required on the target machine.

## The knobs

```bash
dotnet publish -c Release -r win-x64 \
  --self-contained true \
  -p:PublishSingleFile=true
```

- **`-r win-x64`** — the target runtime identifier (required for single-file).
- **`--self-contained true`** — bundle the .NET runtime (portable, ~60–150 MB).
  `false` = framework-dependent (small, needs .NET on the target).
- **`-p:PublishSingleFile=true`** — pack everything into one exe (native libs
  are extracted to a temp dir at first run, or set
  `IncludeNativeLibrariesForSelfExtract`).
- **`-p:PublishTrimmed=true`** — remove unused IL to shrink it. **Test
  thoroughly** — trimming can break reflection-based code (WinForms uses some).
- **`-p:EnableCompressionInSingleFile=true`** — compress the bundle (smaller,
  slightly slower first start).

## Choosing a configuration

| Need | Use |
| --- | --- |
| Smallest download, .NET is present | framework-dependent |
| Portable, runs anywhere | self-contained + single-file |
| As small as portable can get | + trimmed (test!) + compression |

## Set identity in the csproj

```xml
<ApplicationIcon>app.ico</ApplicationIcon>
<Version>1.0.0</Version>
<AssemblyTitle>My App</AssemblyTitle>
```

## Example

See `examples/publish.txt`.

## Exercise

1. Publish self-contained + single-file for `win-x64`; copy the lone `.exe` to a
   clean folder and run it.
2. Publish framework-dependent and compare the size.
3. Try `-p:PublishTrimmed=true -p:EnableCompressionInSingleFile=true` and verify
   the app still runs (watch for trimming-related runtime errors).

**Done when:** you can produce a single portable `.exe` and explain the
size/portability trade-offs of each flag.
