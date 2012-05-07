using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Razr.Models
{
    public class Blog : BaseModel
    {
        public string SiteName { get; set; }
        public string Title { get; set; }
        public List<User> Users { get; set; }

        public Blog()
        {
            this.Users = new List<User>();
        }

        public void AddUser(User user)
        {
            if (!this.Users.Contains(user))
            {
                this.Users.Add(user);
            }
        }
    }
}
