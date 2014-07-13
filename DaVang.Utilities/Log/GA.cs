using GoogleAnalytics.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Davang.Utilities.Log
{
    public class GA
    {
        private static string _clientId;
        private static string _gaId;
        private static string _appName;
        private static string _appVersion;

        public static void Initialize(string clientID, string gaId, string appName, string appVersion)
        {
            try
            {
                _clientId = clientID;
                _gaId = gaId;
                _appName = appName;
                _appVersion = appVersion;
            }
            catch (Exception)
            {
            }
        }

        private static Tracker GetTracker()
        {
            var tracker = new Tracker(_gaId, new PlatformInfoProvider(), GAServiceManager.Current);
            tracker.AppName = _appName;
            tracker.AppVersion = _appVersion;

            return tracker;
        }

        public static void LogException(Exception exception, string addtionalMessage = "")
        {
            LogException(exception, false, addtionalMessage);
        }

        public static void LogException(Exception exception, bool fatal, string addtionalMessage = "")
        {
            var tracker = GetTracker();

            var message = new StringBuilder();
            message.Append("*****ClientId: ");
            message.AppendLine(_clientId);
            message.AppendLine("*****");

            if (!string.IsNullOrEmpty(addtionalMessage))
            {
                message.AppendLine("*****");
                message.AppendLine(addtionalMessage);
                message.AppendLine("*****");
            }

            message.AppendLine(CreateExceptionData(exception));

            if (exception.InnerException != null)
            {
                message.AppendLine("***Inner***");
                message.AppendLine(CreateExceptionData(exception.InnerException));
                message.AppendLine("***");
            }

            tracker.SendException(message.ToString(), fatal);
        }

        public static void LogBackgroundAgent(string message, long itemUpdated)
        {
            var tracker = GetTracker();
            tracker.SendEvent(_clientId + " - BackgroundAgent", message, null, itemUpdated);
        }

        public static void LogPage(string pageName)
        {
            var tracker = GetTracker();
            tracker.SendView(_clientId + " - " + pageName);
        }

        public static void LogAdsClicked(string pageName, string adsControl)
        {
            var tracker = GetTracker();
            tracker.SendEvent(_clientId + " - AdsClicked", adsControl, null, 0);
        }

        public static void LogStartSession()
        {
            var tracker = GetTracker();
            tracker.SendEvent(_clientId + " - Start", "start on " + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss tt"), null, 0);
        }

        public static void LogEndSession()
        {
            var tracker = GetTracker();
            tracker.SendEvent(_clientId + " - Stop", "stop on " + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss tt"), null, 0);
        }

        private static string CreateExceptionData(Exception exception)
        {
            var data = new StringBuilder();

            data.AppendLine("*****Message: ");
            data.AppendLine(exception.Message);
            data.AppendLine("*****");
            data.AppendLine("*****Source: ");
            data.AppendLine(exception.Source);
            data.AppendLine("*****");
            data.AppendLine("*****Stack trace: ");
            data.AppendLine(exception.StackTrace);
            data.AppendLine("*****");

            return data.ToString();
        }
    }
}
