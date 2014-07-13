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
            //client.Headers["UserAgent"] = "Mozilla/5.0 (Windows NT 6.3; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/35.0.1916.153 Safari/537.36";
            return await client.DownloadStringTaskAsync(new Uri(requestUri));
        }
    }
}
