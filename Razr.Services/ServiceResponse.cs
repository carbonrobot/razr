using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Razr.Services
{
    public class ServiceResponse<T>
    {
        public bool HasError { get; set; }
        public Exception Exception { get; set; }
        public T Result { get; set; }
    }
}
