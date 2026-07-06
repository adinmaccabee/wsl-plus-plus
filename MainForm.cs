using System;
using System.Windows.Forms;

namespace WSLPlusPlus;

public class MainForm : Form
{
    private TabControl tabs = new();
    private MenuStrip menu = new();

    public MainForm()
    {
        Text = "WSL++";
        Width = 1000;
        Height = 700;

        BuildMenu();

        tabs.Dock = DockStyle.Fill;
        Controls.Add(tabs);
        Controls.Add(menu);

        MainMenuStrip = menu;

        if (!WslHelper.IsWslInstalled())
        {
            var r = MessageBox.Show(
                "WSL is not installed. Install now?",
                "WSL++",
                MessageBoxButtons.YesNo);

            if (r == DialogResult.Yes)
                WslHelper.InstallWsl();

            Close();
            return;
        }

        NewTab();
    }

    private void BuildMenu()
    {
        var file = new ToolStripMenuItem("File");
        file.DropDownItems.Add("New Tab", null, (_, _) => NewTab());
        file.DropDownItems.Add("New Window", null, (_, _) => new MainForm().Show());
        file.DropDownItems.Add("Close Tab", null, (_, _) => CloseTab());
        file.DropDownItems.Add("Exit", null, (_, _) => Close());

        var edit = new ToolStripMenuItem("Edit");
        edit.DropDownItems.Add("Copy");
        edit.DropDownItems.Add("Paste");

        var view = new ToolStripMenuItem("View");
        view.DropDownItems.Add("Zoom In");
        view.DropDownItems.Add("Zoom Out");

        menu.Items.Add(file);
        menu.Items.Add(edit);
        menu.Items.Add(view);
    }

    private void NewTab()
    {
        var distros = WslHelper.GetDistros();
        string distro = distros.Count > 0 ? distros[0] : "Ubuntu";

        var page = new TabPage(distro);

        var term = new TerminalTab(distro);
        page.Controls.Add(term);

        tabs.TabPages.Add(page);
        tabs.SelectedTab = page;

        term.Start();
    }

    private void CloseTab()
    {
        if (tabs.TabPages.Count > 0)
            tabs.TabPages.Remove(tabs.SelectedTab);
    }
}
