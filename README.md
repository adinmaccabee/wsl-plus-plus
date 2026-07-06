# WSL++

WSL++ is a lightweight WinForms GUI wrapper for Windows Subsystem for Linux (WSL) that provides tabbed Linux sessions inside a simple Windows interface.

## Requirements

You may need the following before running:

1. .NET 8 SDK  
Download: https://dotnet.microsoft.com/download/dotnet/8.0  
Check:
```bash
dotnet --version
```

2. WSL (Windows Subsystem for Linux)  
If missing, install:
```powershell
wsl --install
```
Restart PC if required.

3. Git (optional but recommended)  
Download: https://git-scm.com/download/win  
Check:
```bash
git --version
```

## Install & Run

If using Git:
```bash
git clone https://github.com/adinmaccabee/wsl-plus-plus.git
cd wsl-plus-plus
dotnet run
```

If NOT using Git:
1. Download ZIP from GitHub
2. Extract it
3. Open terminal in folder
4. Run:
```bash
dotnet run
```

## Build EXE (optional)

```bash
dotnet publish -c Release -r win-x64 --self-contained true
```

Output:
```
bin/Release/net8.0-windows/win-x64/publish/
```

Run:
```
WSL++.exe
```

## Notes

- WSL++ does not emulate a terminal
- It launches real `wsl.exe` sessions
- Each tab is a separate WSL process
- First run may require WSL install + restart
```
