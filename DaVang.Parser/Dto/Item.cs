using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Davang.Parser.Dto
{
    public class Item : BaseEntity<string>
    {
        //public Feed Feed { get; set; }
        public Guid FeedId { get; set; }
        public bool Read { get; set; }
        public bool Reading { get; set; }

        #region Syndication

        //public string Id { get; set; }
        public string Authors { get; set; }
        public DateTime PublishDate { get; set; }
        public string Title { get; set; }
        public string Summary { get; set; }
        public string Link { get; set; }

        #endregion
    }

    public class ItemComparer : IComparer<Item>
    {
        #region IComparer

        public int Compare(Item x, Item y)
        {
            return x.PublishDate.CompareTo(y.PublishDate);
        }

        #endregion
    }
}
