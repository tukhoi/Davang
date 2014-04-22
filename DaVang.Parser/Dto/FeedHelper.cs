using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Syndication;
using System.Text;
using System.Threading.Tasks;
using Davang.Utilities.Extensions;

namespace Davang.Parser.Dto
{
    public class FeedHelper
    {
        public static bool ShouldUpdateItems(Feed feed)
        {
            if (feed.Items.Count == 0) return true;
            var lastestUpdate = feed.Items.Max(i => i.PublishDate);
            if (lastestUpdate.AddHours(1) < DateTime.Now)
                return true;

            return false;
        }

        //public static Feed SyncFeed(SyndicationFeed syndicationFeed)
        //{
        //    if (syndicationFeed == null) return null;

        //    var feed = new Feed();
        //    feed.Title = syndicationFeed.Title != null ? syndicationFeed.Title.Text : string.Empty;
        //    feed.Description = syndicationFeed.Description != null ? syndicationFeed.Description.Text : string.Empty;
        //    feed.LastUpdatedTime = syndicationFeed.LastUpdatedTime;
        //    feed.Link = syndicationFeed.Links != null ? syndicationFeed.Links.FirstOrDefault().Uri : null;

        //    return feed;
        //}

        //public static IList<Item> SyncItems(IList<SyndicationItem> syndicationItems)
        //{
        //    if (syndicationItems == null || syndicationItems.Count == 0) return null;

        //    var items = new List<Item>();
        //    syndicationItems.ForEach(syndicationItem =>
        //    {
        //        var item = new Item();
        //        item.Id = syndicationItem.Id;
        //        item.Authors = syndicationItem.Authors != null && syndicationItem.Authors.Count > 0 ? 
        //            string.Join(",", syndicationItem.Authors.Select(a=>a.Name).ToArray()) : string.Empty;
        //        item.PublishDate = syndicationItem.PublishDate;
        //        item.Title = syndicationItem.Title != null && syndicationItem.Title.Type.Equals("text") ?
        //            syndicationItem.Title.Text : string.Empty;
        //        item.Summary = syndicationItem.Summary != null && syndicationItem.Summary.Type.Equals("text") ?
        //            syndicationItem.Summary.Text : string.Empty;
        //        item.Link = syndicationItem.Links != null && syndicationItem.Links.ToList().Count() > 0 ?
        //            syndicationItem.Links.Where(l => l.Uri != null).Select(l => l.Uri).FirstOrDefault() : null;
                
        //        items.Add(item);
        //    });

        //    return items;
        //}
    }
}
