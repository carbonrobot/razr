using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Razr.Models
{
    public class User : BaseModel
    {
        public string DisplayName { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }

        public Blog Blog { get; internal set; }

        public User() { }
    }
}
