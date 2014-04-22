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
            return await client.DownloadStringTaskAsync(new Uri(requestUri));
        }
    }
}
