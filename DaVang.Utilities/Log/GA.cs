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
        private static Tracker _tracker;
        private static string _clientId;

        public static void Initialize(string appID, string gaID, string appName, string appVersion)
        {
            try
            {
                _clientId = appID;
                _tracker = new Tracker(gaID, new PlatformInfoProvider(), GAServiceManager.Current);
                _tracker.AppName = appName;
                _tracker.AppVersion = appVersion;
            }
            catch (Exception)
            {
            }
        }

        public static void LogException(Exception exception, string addtionalMessage = "")
        {
            LogException(exception, false, addtionalMessage);
        }

        public static void LogException(Exception exception, bool fatal, string addtionalMessage = "")
        {
            if (_tracker == null)
                return;

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

            _tracker.SendException(message.ToString(), fatal);
        }

        public static void LogBackgroundAgent(string message, long itemUpdated)
        {
            if (_tracker == null)
                return;
            _tracker.SendEvent(_clientId + " - BackgroundAgent", message, null, itemUpdated);
        }

        public static void LogPage(string pageName)
        {
            if (_tracker == null)
                return;
            _tracker.SendView(_clientId + " - " + pageName);
        }

        public static void LogAdsClicked(string pageName, string adsControl)
        {
            if (_tracker == null)
                return;
            _tracker.SendEvent(_clientId + " - AdsClicked", adsControl, null, 0);
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
