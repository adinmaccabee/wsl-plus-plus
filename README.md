# WSL++

WSL++ is a lightweight WinForms GUI wrapper for Windows Subsystem for Linux (WSL) that provides a tabbed interface for running multiple WSL sessions.

---

## Features

- Tabbed WSL sessions
- Native WSL execution (no terminal emulation)
- Simple menu bar (File / Edit / View)
- Automatic WSL detection
- Optional WSL installation prompt
- Multi-distro support

---

## Requirements

- Windows 11
- .NET 8 SDK
- WSL (will be installed automatically if missing)
- At least one Linux distribution (e.g. Ubuntu)

---

## Quick Start (One Command)

Open **PowerShell as Administrator** and run:

```powershell
wsl --status > $null 2>&1
if ($LASTEXITCODE -ne 0) {
    Write-Host "WSL not found. Installing WSL..."
    wsl --install
    Write-Host "WSL installation started. Please restart your PC and rerun this command."
    exit
}

Write-Host "WSL detected. Installing and running WSL++..."

git clone https://github.com/adinmaccabee/wsl-plus-plus.git
cd wsl-plus-plus
dotnet run
