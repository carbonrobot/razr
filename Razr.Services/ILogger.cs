using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Razr.Services
{
    public interface ILogger
    {
        void Error(Exception exception);
    }
}
