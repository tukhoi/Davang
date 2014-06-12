
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Davang.Utilities.ErrorHandler
{
    public class ErrorLogged
    {
        public DateTime ErrorTime { get; set; }
        public string Message { get; set; }
        public string Type { get; set; }
        public string Source { get; set; }
        public string Details { get; set; }
        public ClientInfo Client { get; set; }
    }

    public class ClientInfo
    { 
        public long AppMemoryUsage { get; set; }
        public long AppMemoryLimit { get; set; }
        public long DeviceMemory { get; set; }
        public string FirmwareVersion { get; set; }
        public string HardwareVersion { get; set; }
        public string Manufacturer { get; set; }
        public string Name { get; set; }
                
    }
}
