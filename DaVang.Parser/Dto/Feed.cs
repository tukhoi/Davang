using Davang.Utilities.ApplicationServices;
using Newtonsoft.Json;
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
            Publisher = new Publisher();
        }

        public string Name { get; set; }
        public Publisher Publisher { get; set ;}
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime LastUpdatedTime { get; set; }
        public string Link { get; set; }
        public int Order { get; set; }
        [JsonIgnore]
        public bool Enabled { get; set; }
        [JsonIgnore]
        public bool Default { get; set; }

        public IList<Item> Items { get; set; }

        public bool AddItem(Item item)
        {
            if (item == null
                || string.IsNullOrEmpty(item.Id)
                || string.IsNullOrEmpty(item.Title)
                || string.IsNullOrEmpty(item.Link)) 
                return false;

            if (Items.Select(i => i.Id).Contains(item.Id)) return false;

            item.FeedId = this.Id;
            Items.Insert(0, item);
            return true;
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
