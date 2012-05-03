using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Razr.Services.Criteria
{
    public abstract class Criteria<T> where T : Razr.Models.BaseModel
    {
        public abstract IQueryable<T> ApplyTo(IQueryable<T> query);
    }
}
