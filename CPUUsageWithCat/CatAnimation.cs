using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CPUUsageWithCat
{
    class CatAnimation
    {
        static private Icon[] icons = { Properties.Resources.cat0, Properties.Resources.cat1, Properties.Resources.cat2,
                                 Properties.Resources.cat3, Properties.Resources.cat4 };
        static Timer timer = new Timer();
        static private int currentImage = 0;
        static public void Start(int interval)
        {
            timer.Interval = interval;
            timer.Tick += new EventHandler(ChangeImage);
            timer.Start();
        }
        static public void SetInterval(int interval)
        {
            timer.Interval = interval;
        }
        static public void Stop()
        {
            timer.Stop();
        }
        static public void ChangeImage(object sender, EventArgs e)
        {
            if (timer.Interval >= 145)
            {
                CatInTrayIcon.SetIcon(Properties.Resources.SleepingCat);
                currentImage = 0;
            }
            else
            {
                CatInTrayIcon.SetIcon(icons[currentImage]);
                currentImage++;
                if (currentImage == 5)
                    currentImage = 0;
            }
        }
    }
}
