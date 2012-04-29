using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Razr.Models
{
    public class Post : BaseModel
    {
        public string Body { get; set; }
        public string Summary { get; set; }
        public string Tags { get; set; }
    }
}
