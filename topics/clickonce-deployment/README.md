# Topic: ClickOnce deployment

Ship a Windows desktop app that installs per-user and **auto-updates**.

## What it gives you

ClickOnce produces a publish location (folder, network share, or web server)
with a `setup.exe` + manifests. Users install with one click, no admin rights
(per-user), and the app **checks for updates** on launch. Ideal for internal
line-of-business tools.

## Publishing (Visual Studio)

`Project ▸ Publish ▸ ClickOnce`:
- Choose the publish folder/URL.
- Set the **Publish version** (auto-increment each publish — this is how clients
  detect updates).
- Configure **Update** behaviour: check before/after start, minimum required
  version (force-upgrade).
- Optionally sign the manifests with a certificate (recommended; avoids
  SmartScreen friction).

## How updates work

Each publish bumps the version and writes new manifests. On launch the installed
app compares its version to the deployment manifest and downloads the delta. You
can also update programmatically with `ApplicationDeployment` (classic) — modern
.NET uses the manifest flow.

## ClickOnce vs alternatives

- **ClickOnce** — easiest auto-update story for internal Windows apps.
- **MSIX** — modern packaging, Store-compatible, cleaner install/uninstall;
  more setup.
- **Plain `dotnet publish`** (next topic) — a portable exe/folder you distribute
  yourself (no auto-update).

Pick ClickOnce when you want painless updates for a known user base; MSIX for
Store or modern packaging; raw publish for "just give me an exe".

## Example

See `examples/clickonce-notes.txt`.

## Exercise

1. In Visual Studio, publish a small app via **ClickOnce** to a local folder.
2. Install it from the generated `setup.exe`.
3. Change something, bump the Publish version, re-publish, relaunch the installed
   app — confirm it offers/installs the update.
