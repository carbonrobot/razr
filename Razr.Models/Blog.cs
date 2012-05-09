namespace Razr.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// An instance of a Blog
    /// </summary>
    public class Blog : BaseModel
    {
        /// <summary>
        /// Gets or sets the name of the blog
        /// </summary>
        public string SiteName { get; set; }

        /// <summary>
        /// Gets or sets a short description of the blog
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Gets the list of users
        /// </summary>
        public List<User> Users { get; protected set; }


        /// <summary>
        /// Creates a new instance of <see cref="Blog"/>
        /// </summary>
        public Blog()
        {
            this.Users = new List<User>();
        }


        /// <summary>
        /// Adds a new user to this blog
        /// </summary>
        /// <param name="user">The user to allow access to</param>
        public void AddUser(User user)
        {
            if (!this.Users.Contains(user))
            {
                this.Users.Add(user);
            }
        }
    
    }
}
