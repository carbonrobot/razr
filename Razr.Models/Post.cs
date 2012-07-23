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
        /// Gets or sets the slug of the post
        /// </summary>
        public string Slug { get; set; }

        /// <summary>
        /// Publish this post
        /// </summary>
        public void Publish()
        {
            this.Draft = false;
            this.PublishedDate = DateTime.Now;
            this.Slug = this.createSlug();
        }

        /// <summary>
        /// Retract this post
        /// </summary>
        public void Retract()
        {
            this.Draft = true;
            this.PublishedDate = null;
        }

        /// <summary>
        /// Create a slug from the title of the post
        /// </summary>
        private string createSlug()
        {
            // http://stackoverflow.com/a/2921135/118224
            
            // lowercase only
            var slug = this.Title.ToLower();
            
            // invalid chars           
            slug = System.Text.RegularExpressions.Regex.Replace(slug, @"[^a-z0-9\s-]", "");
            
            // convert multiple spaces into one space   
            slug = System.Text.RegularExpressions.Regex.Replace(slug, @"\s+", " ").Trim();
            
            // cut and trim 
            slug = slug.Substring(0, slug.Length <= 45 ? slug.Length : 45).Trim();
            slug = System.Text.RegularExpressions.Regex.Replace(slug, @"\s", "-"); // hyphens   
            return slug; 
        }

    }
}