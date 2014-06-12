using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Davang.Utilities.ErrorHandler
{
    public interface IErrorHandler
    {
        void Log(ErrorLogged errorLogged);
    }
}
