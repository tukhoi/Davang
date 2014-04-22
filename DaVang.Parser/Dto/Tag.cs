using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Davang.Parser.Dto
{
    public class Tag
    {
        public string Name { get; set; }
        public IList<Feed> Feeds { get; set; }

        public Tag()
        {
            Feeds = new List<Feed>();
        }
    }
}
