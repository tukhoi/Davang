using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.Text;

namespace Davang.ErrorStore
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "ErrorStoreService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select ErrorStoreService.svc or ErrorStoreService.svc.cs at the Solution Explorer and start debugging.
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class ErrorStoreService : IErrorStoreService
    {
        public void Collect(string errorTime, string message, string type, string source, string details,
            long appMemoryUsage, long appMemoryLimit, long deviceMemory, string firmwareVersion, string hardwareVersion,
            string manufacturer, string name)
        { 
            using (var writer = new StreamWriter("errors.txt", true))
            {
                writer.WriteLine(errorTime);
                writer.WriteLine(message);
                writer.WriteLine(type);
                writer.WriteLine(source);
                writer.WriteLine(details);

                writer.WriteLine(appMemoryUsage.ToString());
                writer.WriteLine(appMemoryLimit.ToString());
                writer.WriteLine(deviceMemory.ToString());
                writer.WriteLine(firmwareVersion);
                writer.WriteLine(hardwareVersion);
                writer.WriteLine(manufacturer);
                writer.WriteLine(name);
            }
        }

        public string Test()
        {
            return "hello";
        }
    }
}
