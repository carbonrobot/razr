using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Razr.Models;

namespace Razr.Web.Models
{
    public class ConfigViewModel
    {
        public string DisplayName { get; set; }
        public string EmailAddress { get; set; }
        public string Password { get; set; }
        public string PasswordMatch { get; set; }
    }
}