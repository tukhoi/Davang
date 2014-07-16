using Microsoft.Phone.Info;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace Davang.Utilities
{
    public class MemoryDiagnostic
    {
        private static Timer _timer = null;
        private static double _last = 0;
        private static object lockObj = new object();

        public static void BeginRecording()
        {

            // start a timer to report memory conditions every 3 seconds 
            // 
            _timer = new Timer(state =>
            {
                string c = "unassigned";
                try
                {
                    //  
                }
                catch (ArgumentOutOfRangeException ar)
                {
                    var c1 = ar.Message;
                }
                catch
                {
                    c = "unassigned";
                }


                string report = "";
                //report += Environment.NewLine +
                //    "Current: " + (DeviceStatus.ApplicationCurrentMemoryUsage / 1000000).ToString() + "MB\n" +
                //    "Peak: " + (DeviceStatus.ApplicationPeakMemoryUsage / 1000000).ToString() + "MB\n" +
                //    "Memory Limit: " + (DeviceStatus.ApplicationMemoryUsageLimit / 1000000).ToString() + "MB\n\n" +
                //    "Device Total Memory: " + (DeviceStatus.DeviceTotalMemory / 1000000).ToString() + "MB\n" +
                //    "Working Limit: " + Convert.ToInt32((Convert.ToDouble(DeviceExtendedProperties.GetValue("ApplicationWorkingSetLimit")) / 1000000)).ToString() + "MB";

                double current = 0;
                double rate = 0;
                double rateMb = 0;
                lock (lockObj)
                {
                    current = DeviceStatus.ApplicationCurrentMemoryUsage / (1024 * 1024);
                    rate = 0;
                    if (_last != 0)
                    {
                        rateMb = current - _last;
                        rate = (rateMb / current) * 100;
                    }

                    _last = current;
                }

                var limit = DeviceStatus.ApplicationMemoryUsageLimit / (1024 * 1024);
                var available = limit - current;

                report += Environment.NewLine +
                    "Current: " + current.ToString() + "MB\n" +
                    "Increased: " + rateMb.ToString() + "MB (" + rate.ToString("00.00") + "%)\n" +
                    "Available: " + available.ToString() + "MB\n" + 
                    "Peak: " + (DeviceStatus.ApplicationPeakMemoryUsage / (1024 * 1024)).ToString() + "MB\n" +
                    "Memory Limit: " + limit.ToString() + "MB\n" +
                    "Working Limit: " + Convert.ToInt32((Convert.ToDouble(DeviceExtendedProperties.GetValue("ApplicationWorkingSetLimit")) / (1024 * 1024))).ToString() + "MB";

                Deployment.Current.Dispatcher.BeginInvoke(delegate
                {
                    Debug.WriteLine(report);
                });

            },
                null,
                TimeSpan.FromSeconds(2),
                TimeSpan.FromSeconds(2));
        }
    }
}
