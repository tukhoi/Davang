using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.ServiceModel.Syndication;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Davang.Utilities.Extensions;
using Davang.Parser.Dto;
using Davang.Utilities.Tasks;
using Davang.Utilities;
using System.Xml.Linq;
using Davang.Utilities.Helpers;
using System.Net;

namespace Davang.Parser
{
    public class RssParser : BaseParser
    {
        protected string _baseUrl = string.Empty;

        #region overrride

        protected override string BaseUrl
        {
            get { return _baseUrl; }
        }

        protected internal override Feed ParseFeed(string data)
        {
            Feed feed = null;
            XmlFormater.Format(ref data);
            var xmlDoc = XDocument.Parse(data);
            if (xmlDoc.Root != null)
            {
                var xmlns = xmlDoc.Root.GetDefaultNamespace();
                var channelElement = xmlDoc.Root.Element(xmlns + "channel");
                if (channelElement != null)
                    feed = CreateFeed(channelElement, xmlns);
                else
                    feed = new Feed();
                if (feed != null)
                    xmlDoc.Root.Descendants(xmlns + "item").ToList().ForEach(element => feed.AddItem(CreateFeedItem(element, xmlns)));
            }
            return feed;
        }

        #endregion

        #region private

        private Feed CreateFeed(XElement xElement, XNamespace xmlns)
        {
            try
            {
                var title = xElement.Element(xmlns + "title") != null ? xElement.Element(xmlns + "title").Value : string.Empty;
                var description = xElement.Element(xmlns + "description") != null ? xElement.Element(xmlns + "description").Value : string.Empty;
                var link = xElement.Element(xmlns + "link") != null ? xElement.Element(xmlns + "link").Value : string.Empty;
                var pubDate = xElement.Element(xmlns + "pubDate") != null ? xElement.Element(xmlns + "pubDate").Value : string.Empty;

                var feed = new Feed()
                {
                    Title = title.Trim(),
                    Description = description.Trim(),
                    Link = link.Trim(),
                };
                DateTime dtPubDate;
                if (DateTime.TryParse(pubDate.Trim(), out dtPubDate))
                    feed.LastUpdatedTime = dtPubDate;
                else
                    feed.LastUpdatedTime = DateTime.Now;

                return feed;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private Item CreateFeedItem(XElement xElement, XNamespace xmlns)
        {
            try
            {
                var title = xElement.Element(xmlns + "title") != null ? xElement.Element(xmlns + "title").Value : string.Empty;
                var description = xElement.Element(xmlns + "description") != null ? xElement.Element(xmlns + "description").Value : string.Empty;
                var clickUrl = xElement.Element(xmlns + "link") != null ? xElement.Element(xmlns + "link").Value : string.Empty;
                var id = xElement.Element(xmlns + "guid") != null ? xElement.Element(xmlns + "guid").Value : string.Empty;
                var pubDate = xElement.Element(xmlns + "pubDate") != null ? xElement.Element(xmlns + "pubDate").Value : string.Empty;
                if (string.IsNullOrEmpty(pubDate))
                    pubDate = xElement.Element(xmlns + "pubdate") != null ? xElement.Element(xmlns + "pubdate").Value : string.Empty;

                var item = new Item
                {
                    Title = title.Trim(),
                    Summary = description.Trim(),
                    Link = clickUrl.Trim(),
                    Id = string.IsNullOrEmpty(id) || default(Guid).ToString().Equals(id.Trim()) ? clickUrl.Trim() : id.Trim()
                };
                DateTime dtPubDate;
                if (DateTime.TryParse(pubDate.Trim(), out dtPubDate))
                    item.PublishDate = dtPubDate;
                else item.PublishDate = DateTime.Now;

                return item;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion
    }
}
