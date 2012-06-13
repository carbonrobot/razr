namespace Razr.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Razr.Models;
    using Razr.Services.Criteria;

    public class ModelService : BaseService
    {
        /// <summary>
        /// Contructs a new instance of <see cref="ModelService"/>
        /// </summary>
        /// <param name="context">The database context</param>
        /// <param name="logger">The error logging engine</param>
        public ModelService(IContext context, ILogger logger) : base(context, logger) { }
        
        /// <summary>
        /// Configure a new blog application with a default admin user
        /// </summary>
        /// <param name="sitename">The name of the blog</param>
        /// <param name="title">The title of the blog</param>
        /// <param name="name">The name of the default user</param>
        /// <param name="email">The email of the user</param>
        /// <param name="password">The password</param>
        /// <returns></returns>
        public ServiceResponse<bool> Configure(string sitename, string title, string name, string email, string password)
        {
            Func<bool> func = delegate
            {
                var blog = new Blog()
                {
                    SiteName = sitename,
                    Title = title
                };

                var salt = DevOne.Security.Cryptography.BCrypt.BCryptHelper.GenerateSalt();
                var hash = DevOne.Security.Cryptography.BCrypt.BCryptHelper.HashPassword(password, salt);
                var user = new User()
                {
                    DisplayName = name,
                    Email = email,
                    PasswordHash = hash
                };
                blog.AddUser(user);

                return context.Save(blog).Id > 0;
            };
            return this.Execute(func);
        }

        /// <summary>
        /// Creates a quick draft of an idea
        /// </summary>
        /// <param name="title">The name of the brilliant idea</param>
        /// <returns></returns>
        public ServiceResponse<Post> CreateQuickDraft(string title)
        {
            Func<Post> func = delegate
            {
                if (string.IsNullOrEmpty(title))
                    throw new ArgumentNullException("Idea can not be null or blank");

                var entity = new Post() { Title = title };
                return context.Save(entity);
            };
            return this.Execute(func);
        }

        /// <summary>
        /// Validate the email address and password
        /// </summary>
        /// <param name="email">The users email address</param>
        /// <param name="password">The users password</param>
        /// <returns></returns>
        public ServiceResponse<User> Login(string email, string password)
        {
            Func<User> func = delegate
            {
                var user = context.AsQueryable<User>()
                    .Where(x => x.Email == email)
                    .SingleOrDefault();

                // TODO: replace with authentication exception
                if (user == null)
                    throw new ArgumentException("Email address not found");

                var valid = DevOne.Security.Cryptography.BCrypt.BCryptHelper.CheckPassword(password, user.PasswordHash);
                if (valid)
                {
                    return user;
                }
                else
                {
                    throw new ArgumentException("Password incorrect");
                }
            };
            return this.Execute(func);
        }

        /// <summary>
        /// Get a paged set of recent posts
        /// </summary>
        /// <param name="page"></param>
        /// <returns></returns>
        public ServiceResponse<IList<Post>> GetRecentPosts(string tag, int page, int pagesize)
        {
            Func<IList<Post>> func = delegate
            {
                var query = this.context.AsQueryable<Post>()
                    .Where(x => x.Draft == false);
                
                if(!string.IsNullOrEmpty(tag)){
                    query = query.Where(x => x.Tags.Contains(tag));
                }

                query = query.OrderByDescending(x => x.PublishedDate)
                    .Skip((page - 1) * pagesize)
                    .Take(pagesize);

                return query.ToList();
            };
            return this.Execute(func);
        }

        /// <summary>
        /// Publishes the selected post
        /// </summary>
        /// <param name="postId">The id of the post to publish</param>
        /// <returns></returns>
        public ServiceResponse<Post> Publish(int postId)
        {
            Func<Post> func = delegate
            {
                var entity = context.Get<Post>(postId);
                if (entity == null)
                    throw new ArgumentOutOfRangeException("No post was found with an id of " + postId.ToString());

                entity.Publish();

                return context.Save(entity);
            };
            return this.Execute(func);
        }

        /// <summary>
        /// Retracts the selected post
        /// </summary>
        /// <param name="postId">The id of the post to retract</param>
        /// <returns></returns>
        public ServiceResponse<Post> Retract(int postId)
        {
            Func<Post> func = delegate
            {
                var entity = context.Get<Post>(postId);
                if (entity == null)
                    throw new ArgumentOutOfRangeException("No post was found with an id of " + postId.ToString());

                entity.Retract();

                return context.Save(entity);
            };
            return this.Execute(func);
        }
        
    }
}
