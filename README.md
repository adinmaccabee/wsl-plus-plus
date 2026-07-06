# WSL++

WSL++ is a lightweight WinForms GUI wrapper for Windows Subsystem for Linux (WSL).

It provides a tabbed interface for running multiple WSL sessions with a simple menu bar.

---

## ✨ Features

- Tabbed WSL sessions
- Native WSL execution (no emulation or custom terminal)
- Simple menu bar (File / Edit / View)
- Automatic WSL detection
- Optional WSL installation prompt
- Multi-distro support

---

## ⚙️ Requirements

- Windows 11
- .NET 8 SDK
- WSL installed (`wsl --install` if not already installed)
- At least one Linux distribution installed (e.g. Ubuntu)

Check WSL status:

```bash
wsl --status
