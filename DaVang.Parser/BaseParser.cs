using Davang.Parser.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Davang.Utilities.Tasks;

namespace Davang.Parser
{
    public abstract class BaseParser : IParser
    {
        #region Properties

        protected abstract string BaseUrl
        {
            get;
        }

        public virtual string Name
        {
            get
            {
                return this.GetType().Name;
            }
        }

        #endregion

        #region Public methods

        public virtual async Task<Feed> GetFeedAsync(string keyword)
        {
            Feed feedResult = null;
            var feedUrl = "";
            try
            {
                feedUrl = GetFeedUrl(keyword);
                var responseData = await GetRawResult(feedUrl);
                if (!string.IsNullOrEmpty(responseData.Trim()))
                    feedResult = ParseFeed(responseData);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return feedResult;
        }

        public virtual async Task<string> GetRawResult(string requestUri)
        {
            return await WebTasks.GetRawResult(requestUri);
        }

        #endregion

        #region Internals methods

        internal virtual string GetFeedUrl(string keyword)
        {
            return string.Format(BaseUrl, keyword);
        }

        protected internal abstract Feed ParseFeed(string data);

        #endregion
    }
}
