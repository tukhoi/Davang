using Davang.Utilities.Helpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Davang.Utilities.ErrorHandler
{
    public class ErrorHandler : IErrorHandler
    {
        private static string _errorFileName = string.Empty;
        private static string _remoteErrorStoreUrl = string.Empty;
        private static Mutex _mutex;
        private static IErrorHandler _instance;

        public static void Initialize(string errorFileName, string remoteErrorStoreUrl)
        {
            _errorFileName = errorFileName;
            _remoteErrorStoreUrl = remoteErrorStoreUrl;
            _mutex = new Mutex(false, "ErrorData");
        }

        public static IErrorHandler GetInstance()
        {
            if (_instance == null)
                _instance = new ErrorHandler();

            return _instance;
        }

        public void Log(ErrorLogged error)
        {
            if (!LogToRemoteStore(error))
                LogToDisk(error);
        }

        private bool LogToRemoteStore(ErrorLogged errorLogged)
        {
            return true;
        }

        private bool LogToDisk(ErrorLogged errorLogged)
        {
            if (errorLogged == null) return false;

            _mutex.WaitOne();
            try
            {
                using (var stream = StorageHelper.GetFileStream(_errorFileName, System.IO.FileMode.Append))
                {
                    using (var writer = new StreamWriter(stream))
                    {
                        writer.WriteLine(errorLogged.ErrorTime);
                        writer.WriteLine(errorLogged.Message);
                        writer.WriteLine(errorLogged.Type);
                        writer.WriteLine(errorLogged.Source);
                        writer.WriteLine(errorLogged.Details);

                        writer.WriteLine(errorLogged.Client.AppMemoryUsage.ToString());
                        writer.WriteLine(errorLogged.Client.AppMemoryLimit.ToString());
                        writer.WriteLine(errorLogged.Client.DeviceMemory.ToString());
                        writer.WriteLine(errorLogged.Client.FirmwareVersion);
                        writer.WriteLine(errorLogged.Client.HardwareVersion);
                        writer.WriteLine(errorLogged.Client.Manufacturer);
                        writer.WriteLine(errorLogged.Client.Name);

                        return true;
                    }
                }
            }
            catch (Exception)
            {
                return false;
            }
            finally
            {
                _mutex.ReleaseMutex();
            }
        }
    }
}
