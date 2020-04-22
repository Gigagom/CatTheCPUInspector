using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CPUUsageWithCat
{
    public class CatInTrayIcon : ApplicationContext
    {
        static private NotifyIcon trayIcon;

        public CatInTrayIcon()
        {
            ContextMenuStrip menu = new ContextMenuStrip();
            menu.Items.AddRange(new[] {
                new ToolStripMenuItem("Exit", null, Exit)
            });
            trayIcon = new NotifyIcon()
            {
                Icon = Properties.Resources.SleepingCat,
                ContextMenuStrip = menu,
                Visible = true
            };
            CPUUsage.StartCPUDiagnostic();
        }

        void Exit(object sender, EventArgs e)
        {
            trayIcon.Visible = false;
            Application.Exit();
        }

        static public void SetIcon(Icon image) => trayIcon.Icon = image;
    }
}
