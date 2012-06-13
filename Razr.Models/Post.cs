namespace Razr.Models
{
    using System;

    /// <summary>
    /// A blog post
    /// </summary>
    public class Post : BaseModel
    {
        /// <summary>
        /// Constructs a new instance of <see cref="Post"/>
        /// </summary>
        public Post()
        {
            this.Draft = true;
        }

        /// <summary>
        /// Gets or sets the body of the post
        /// </summary>
        public string Body { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this post is published or not
        /// </summary>
        public bool Draft { get; set; }

        /// <summary>
        /// Gets or sets the date this post was published
        /// </summary>
        public DateTime? PublishedDate { get; set; }

        /// <summary>
        /// Gets or sets a comma delimited list of tags
        /// </summary>
        public string Tags { get; set; }

        /// <summary>
        /// Gets or sets the title of the post
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Publish this post
        /// </summary>
        public void Publish()
        {
            this.Draft = false;
            this.PublishedDate = DateTime.Now;
        }

        /// <summary>
        /// Retract this post
        /// </summary>
        public void Retract()
        {
            this.Draft = true;
            this.PublishedDate = null;
        }
    }
}