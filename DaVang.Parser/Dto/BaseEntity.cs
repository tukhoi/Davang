using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Davang.Parser.Dto
{
    public abstract class BaseEntity<TId>
    {
        public TId Id { get; set; }
    }
}
