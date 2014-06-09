using Davang.Parser.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Davang.Parser
{
    public interface IParser
    {
        Task<Feed> GetFeedAsync(string keyword);
    }
}
