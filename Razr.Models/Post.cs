using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Razr.Models
{
    public class Post : BaseModel
    {
        /// <summary>
        /// Gets or sets the body of the post
        /// </summary>
        public string Body { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this post is published or not
        /// </summary>
        public bool Draft { get; set; }

        /// <summary>
        /// Gets or sets a comma delimited list of tags
        /// </summary>
        public string Tags { get; set; }

        /// <summary>
        /// Gets or sets the title of the post
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Constructs a new instance of <see cref="Post"/>
        /// </summary>
        public Post()
        {
            this.Draft = true;
        }
    }
}
