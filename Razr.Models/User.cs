namespace Razr.Models
{
    using System.ComponentModel.DataAnnotations;
    using Razr.Models.Annotations;

    /// <summary>
    /// A Blog User
    /// </summary>
    public class User : BaseModel
    {
        /// <summary>
        /// Constructs a new instance of <see cref="User"/>
        /// </summary>
        public User() { }

        /// <summary>
        /// Gets the blog this user is attached to
        /// </summary>
        public Blog Blog { get; internal set; }

        /// <summary>
        /// Gets or sets the name the user will post as
        /// </summary>
        [Required]
        public string DisplayName { get; set; }

        /// <summary>
        /// Gets or sets the email address for authentication
        /// </summary>
        [Required, Email]
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets the hashed password
        /// </summary>
        [Required]
        public string PasswordHash { get; set; }
    }
}