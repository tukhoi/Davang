using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Davang.Parser.Dto
{
    public class Feed : BaseEntity<Guid>
    {
        public Feed()
        {
            Items = new List<Item>();
        }

        public string Name { get; set; }
        public Publisher Publisher { get; set ;}
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime LastUpdatedTime { get; set; }
        public string Link { get; set; }
        public int Order { get; set; }
        public bool Enabled { get; set; }
        public bool Default { get; set; }

        //public bool Reading { get; set; }

        public IList<Item> Items { get; set; }

        public void AddItem(Item item)
        {
            if (item == null) return;
            if (Items.Select(i => i.Id).Contains(item.Id)) return;

            item.FeedId = this.Id;
            Items.Add(item);
        }

        public Feed Clone()
        {
            var feed = new Feed()
            {
                Id = this.Id,
                Name = this.Name,
                Publisher = this.Publisher.Clone(),
                Title = this.Title,
                Description = this.Description,
                LastUpdatedTime = this.LastUpdatedTime,
                Link = this.Link,
                Order = this.Order,
                Enabled = this.Enabled,
                Default = this.Default,
            };

            return feed;
        }
    }
}
