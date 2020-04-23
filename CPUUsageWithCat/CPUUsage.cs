using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows.Forms;

namespace CPUUsageWithCat
{
    class CPUUsage
    {
        private static PerformanceCounter cpuCounter = new PerformanceCounter("Processor", @"% Processor Time", @"_Total");
        private static Timer timer = new Timer { 
            Interval = 1000
        };
        public static void StartCPUDiagnostic()
        {
            timer.Tick += new EventHandler(GetCPUUsage);
            timer.Start();
            cpuCounter.NextValue();
            CatAnimation.Start(150 - (int)cpuCounter.NextValue());
        }
        public static void GetCPUUsage(object sender, EventArgs e)
        {
            CatAnimation.SetInterval(150 - (int)cpuCounter.NextValue());
        }
    }
}
