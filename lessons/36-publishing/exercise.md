# Exercise — Lesson 36

1. Publish framework-dependent and check the size:
   ```bash
   dotnet publish -c Release -r win-x64 --self-contained false
   ```
2. Publish self-contained single-file and run the standalone exe:
   ```bash
   dotnet publish -c Release -r win-x64 --self-contained true -p:PublishSingleFile=true
   ```
   Copy the resulting `.exe` somewhere outside your project and run it.
3. In the `.csproj`, set `<Version>1.0.0</Version>` and an `<ApplicationIcon>`;
   republish and verify the exe's properties show them.

**Done when:** you can produce both a small framework-dependent build and a
portable single-file exe, and explain when to use each.
