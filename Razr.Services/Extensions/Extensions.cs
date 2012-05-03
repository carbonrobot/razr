using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Razr.Services.Criteria;
using Razr.Models;

namespace Razr.Services
{
    public static class Extensions
    {
        public static IQueryable<T> Apply<T>(this IQueryable<T> query, Criteria<T> criteria) where T : BaseModel
        {
            return criteria.ApplyTo(query);
        }
    }
}
