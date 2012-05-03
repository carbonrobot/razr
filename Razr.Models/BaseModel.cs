using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Razr.Models
{
    public class BaseModel
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ChangedDate { get; set; }

        protected BaseModel()
        {
            this.Id = -1;
            this.CreatedDate = DateTime.Now;
            this.ChangedDate = DateTime.Now;
        }
    }
}
