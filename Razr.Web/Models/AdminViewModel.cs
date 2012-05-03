using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Razr.Models;

namespace Razr.Web.Models
{
    public class AdminViewModel
    {
        /// <summary>
        /// Gets or sets the list of posts
        /// </summary>
        public IList<Post> Posts { get; set; }

        /// <summary>
        /// Gets a list of posts in a draft status
        /// </summary>
        public List<Post> Drafts
        {
            get
            {
                return this.Posts.Where(x => x.Draft == true).ToList();
            }
        }

        /// <summary>
        /// Gets a list of published posts
        /// </summary>
        public List<Post> Published
        {
            get
            {
                return this.Posts.Where(x => x.Draft == false).ToList();
            }
        }
    }
}