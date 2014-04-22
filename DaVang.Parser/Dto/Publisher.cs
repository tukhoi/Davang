using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Davang.Parser.Dto
{
    public class Publisher : BaseEntity<Guid>
    {
        public string Name { get; set; }
        public string Link { get; set; }
        public IList<Feed> Feeds { get; set; }
        public Uri ImageUri { get; set; }

        public Publisher()
        {
            Feeds = new List<Feed>();
        }

        public void AddFeed(Feed feed)
        {
            if (feed == null) return;
            if (Feeds.FirstOrDefault(f => f.Id.Equals(feed.Id)) != null) return;

            feed.Publisher = this;
            Feeds.Add(feed);
        }
    }
}
