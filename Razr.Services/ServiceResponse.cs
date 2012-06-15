using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Razr.Models;

namespace Razr.Services
{
    /// <summary>
    /// Standard response
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ServiceResponse<T>
    {
        /// <summary>
        /// Gets or sets a value that indicates whether this service call had an error
        /// </summary>
        public bool HasError { get; set; }

        /// <summary>
        /// Gets or sets any exception thrown during execution
        /// </summary>
        public Exception Exception { get; set; }

        /// <summary>
        /// Gets or sets the results
        /// </summary>
        public T Result { get; set; }
    }


}
