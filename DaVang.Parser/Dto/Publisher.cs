using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Davang.Utilities.Extensions;
using Newtonsoft.Json;
using Davang.Utilities.ApplicationServices;

namespace Davang.Parser.Dto
{
    public class Publisher : BaseEntity<Guid>
    {
        public string Name { get; set; }
        public string Link { get; set; }
        public IList<Guid> FeedIds { get; set; }
        public Uri ImageUri { get; set; }
        public int Order { get; set; }
        [JsonIgnore]
        public bool Enabled { get; set; }
        [JsonIgnore]
        public bool Default { get; set; }

        public Publisher()
        {
            FeedIds = new List<Guid>();
        }

        public void AddFeedId(Guid feedId)
        {
            if (default(Guid).Equals(feedId)) return;
            if (!FeedIds.FirstOrDefault(fid => fid.Equals(feedId)).Equals(default(Guid))) return;

            FeedIds.Add(feedId);
        }

        public Publisher Clone()
        {
            var publisher = new Publisher()
            {
                Id = this.Id,
                Name = this.Name,
                Link = this.Link,
                ImageUri = this.ImageUri,
                Order = this.Order,
                Enabled = this.Enabled,
                Default = this.Default,
            };

            this.FeedIds.ForEach(fid => publisher.FeedIds.Add(fid));

            return publisher;
        }
    }

    public class PublisherComparer : IEqualityComparer<Publisher>
    {
        public bool Equals(Publisher publisher1, Publisher publisher2)
        {
            return publisher1.Id.Equals(publisher2.Id);
        }

        public int GetHashCode(Publisher publisher)
        {
            return publisher.Id.GetHashCode();
        }
    }
}
