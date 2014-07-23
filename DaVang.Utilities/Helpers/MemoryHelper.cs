using Microsoft.Phone.Info;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Davang.Utilities.Helpers
{
    public static class MemoryHelper
    {
        public static bool IsLowMemDevice { get; set; }

        static MemoryHelper()
        {
            try
            {
                Int64 result = (Int64)DeviceExtendedProperties.GetValue("ApplicationWorkingSetLimit");
                var resultInMb = result / (1024 * 1024);
                IsLowMemDevice = resultInMb < 200;
            }
            catch (ArgumentOutOfRangeException)
            {
                //windows phone OS not updated, then 512mb
                IsLowMemDevice = true;
            }
        }

    }
}
