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
        public bool Subscribed { get; set; }

        public IList<Item> Items { get; set; }

        public void AddItem(Item item)
        {
            if (item == null) return;
            if (Items.Select(i => i.Id).Contains(item.Id)) return;

            item.Feed = this;
            Items.Add(item);
        }
    }
}
