using System.Diagnostics;
using System.Windows.Forms;

namespace WSLPlusPlus;

public class TerminalTab : UserControl
{
    private Process? process;
    private string distro;

    public TerminalTab(string distro)
    {
        this.distro = distro;
        Dock = DockStyle.Fill;
    }

    public void Start()
    {
        process = new Process
        {
            StartInfo = new ProcessStartInfo
            {
                FileName = "wsl.exe",
                Arguments = $"-d {distro}",
                UseShellExecute = true
            }
        };

        process.Start();
    }

    protected override void Dispose(bool disposing)
    {
        if (disposing)
        {
            try { process?.Kill(); } catch { }
        }
        base.Dispose(disposing);
    }
}
