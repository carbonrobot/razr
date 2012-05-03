using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Razr.Models;

namespace Razr.Web.Models
{
    public class HomeViewModel
    {
        /// <summary>
        /// Gets or sets the list of posts
        /// </summary>
        public IList<Post> Posts { get; set; }
    }
}