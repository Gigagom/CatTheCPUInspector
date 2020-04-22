using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows.Forms;

namespace CPUUsageWithCat
{
    class CPUUsage
    {
        static PerformanceCounter cpuCounter = new PerformanceCounter("Processor", @"% Processor Time", @"_Total");
        static Timer timer = new Timer { 
            Interval = 1000
        };
        static public void StartCPUDiagnostic()
        {
            timer.Tick += new EventHandler(GetCPUUsage);
            timer.Start();
            cpuCounter.NextValue();
            CatAnimation.Start(150 - (int)cpuCounter.NextValue());
        }
        static public void GetCPUUsage(object sender, EventArgs e)
        {
            CatAnimation.SetInterval(150 - (int)cpuCounter.NextValue());
        }
    }
}
