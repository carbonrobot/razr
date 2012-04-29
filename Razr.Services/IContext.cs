using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Razr.Services
{
    /// <summary>
    /// Defines the database contract
    /// </summary>
    public interface IContext
    {
        int Count<T>() where T : Razr.Models.BaseModel;
        
        T Get<T>(int id, params string[] includes) where T : Razr.Models.BaseModel;
        IQueryable<T> AsQueryable<T>(params string[] includes) where T : Razr.Models.BaseModel;
        
        T Save<T>(T entity) where T : Razr.Models.BaseModel;
        
        bool Delete<T>(int id) where T : Razr.Models.BaseModel;
        bool Delete<T>(T entity) where T : Razr.Models.BaseModel;

    }
}
