using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Davang.Utilities.Extensions
{
    public static class QueryStringExtensions
    {
        public static string GetQueryString(this IDictionary<string, string> queryString, string key)
        {
            if (queryString.Keys.Contains(key))
                return queryString[key];
            return string.Empty;
        }

        public static Guid GetQueryStringToGuid(this IDictionary<string, string> queryString, string key)
        {
            if (queryString.Keys.Contains(key))
            {
                Guid value;
                if (Guid.TryParse(queryString[key], out value))
                    return value;
            }
            return default(Guid);
        }
    }
}
