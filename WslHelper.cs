using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace WSLPlusPlus;

public static class WslHelper
{
    public static bool IsWslInstalled()
    {
        try
        {
            var p = Process.Start(new ProcessStartInfo
            {
                FileName = "wsl.exe",
                Arguments = "--status",
                RedirectStandardOutput = true,
                UseShellExecute = false,
                CreateNoWindow = true
            });

            p!.WaitForExit();
            return true;
        }
        catch
        {
            return false;
        }
    }

    public static void InstallWsl()
    {
        Process.Start(new ProcessStartInfo
        {
            FileName = "powershell.exe",
            Arguments = "Start-Process wsl -ArgumentList '--install' -Verb runAs",
            UseShellExecute = true
        });
    }

    public static List<string> GetDistros()
    {
        var list = new List<string>();

        var p = Process.Start(new ProcessStartInfo
        {
            FileName = "wsl.exe",
            Arguments = "-l -q",
            RedirectStandardOutput = true,
            UseShellExecute = false,
            CreateNoWindow = true
        });

        string output = p!.StandardOutput.ReadToEnd();
        p.WaitForExit();

        foreach (var line in output.Split('\n'))
        {
            var d = line.Trim();
            if (!string.IsNullOrWhiteSpace(d))
                list.Add(d);
        }

        return list;
    }
}
