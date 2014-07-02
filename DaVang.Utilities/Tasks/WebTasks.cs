using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Davang.Utilities.Extensions;

namespace Davang.Utilities.Tasks
{
    public static class WebTasks
    {
        public static async Task<string> GetRawResult(string requestUri)
        {
            var client = new WebClient();
            client.Headers["UserAgent"] = "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; .NET CLR 1.0.3705;)";
            return await client.DownloadStringTaskAsync(new Uri(requestUri));
        }
    }
}
