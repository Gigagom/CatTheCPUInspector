using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CPUUsageWithCat
{
    class CatAnimation
    {
        private static Icon[] icons = { Properties.Resources.cat0, Properties.Resources.cat1, Properties.Resources.cat2,
                                 Properties.Resources.cat3, Properties.Resources.cat4 };
        private static Timer timer = new Timer();
        private static int currentImage = 0;
        public static void Start(int interval)
        {
            timer.Interval = interval;
            timer.Tick += new EventHandler(ChangeImage);
            timer.Start();
        }
        public static void SetInterval(int interval) => timer.Interval = interval;
        public static void Stop() => timer.Stop();
        public static void ChangeImage(object sender, EventArgs e)
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
