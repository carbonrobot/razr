namespace Razr.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Razr.Models;
    using Razr.Services.Criteria;

    public class BaseService
    {
        protected IContext context;
        protected ILogger logger;

        public BaseService(IContext context, ILogger logger)
        {
            this.context = context;
            this.logger = logger;
        }

        /// <summary>
        /// Returns the count of the given key
        /// </summary>
        /// <typeparam name="T">Type of entity</typeparam>
        /// <param name="id">Entity key</param>
        /// <returns></returns>
        public ServiceResponse<int> Count<T>() where T : BaseModel
        {
            Func<int> func = delegate
            {
                return this.context.Count<T>();
            };
            return this.Execute(func);
        }

        /// <summary>
        /// Returns the entity with the given key. If not found, throws an ArgumentOutOfRangeException
        /// </summary>
        /// <typeparam name="T">Type of entity</typeparam>
        /// <param name="id">Entity key</param>
        /// <returns></returns>
        public ServiceResponse<T> Get<T>(int id) where T : BaseModel
        {
            Func<T> func = delegate
            {
                var entity = this.context.Get<T>(id);
                if (entity == null)
                    throw new ArgumentOutOfRangeException("Entity not found");

                return entity;
            };
            return this.Execute(func);
        }

        /// <summary>
        /// Returns the entity with the given key. Returns null if not found.
        /// </summary>
        /// <typeparam name="T">Type of entity</typeparam>
        /// <param name="id">Entity key</param>
        /// <returns></returns>
        public ServiceResponse<T> Find<T>(int id) where T : BaseModel
        {
            Func<T> func = delegate
            {
                var entity = this.context.Get<T>(id);
                return entity;
            };
            return this.Execute(func);
        }

        /// <summary>
        /// Returns a list of entities of that the given type based on the criteria.
        /// </summary>
        /// <typeparam name="T">Type of entity list</typeparam>
        /// <param name="criteria">If criteria is null, this will return the entire list</param>
        /// <returns></returns>
        public ServiceResponse<IList<T>> Find<T>(Criteria<T> criteria) where T : BaseModel
        {
            Func<IList<T>> func = delegate
            {
                var query = this.context.AsQueryable<T>();
                if (criteria == null)
                {
                    return query.ToList();
                }
                else
                {
                    return query.Apply(criteria).ToList();
                }
            };
            return this.Execute(func);
        }

        /// <summary>
        /// Returns all entities of a given type
        /// </summary>
        /// <typeparam name="T">Type of entity list</typeparam>
        /// <returns></returns>
        public ServiceResponse<IList<T>> List<T>() where T : BaseModel
        {
            Func<IList<T>> func = delegate
            {
                return this.context.AsQueryable<T>().ToList();
            };
            return this.Execute(func);
        }

        /// <summary>
        /// Deletes the entity with the given key
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="id"></param>
        /// <returns></returns>
        public ServiceResponse<bool> Delete<T>(int id) where T : BaseModel
        {
            Func<bool> func = delegate
            {
                return context.Delete<T>(id);
            };
            return this.Execute(func);
        }

        /// <summary>
        /// Save a new or update entity. This method should be used rarely and other methods created/called that are 
        /// more specific to the task being performed so the business logic remains in this class
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        /// <returns></returns>
        public ServiceResponse<T> Save<T>(T entity) where T : BaseModel
        {
            Func<T> func = delegate
            {
                return context.Save(entity);
            };
            return this.Execute(func);
        }


        /// <summary>
        /// Executes a method in a wrapper with logging
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="func"></param>
        /// <returns></returns>
        protected ServiceResponse<T> Execute<T>(Func<T> func)
        {
            var response = new ServiceResponse<T>();
            try
            {
                response.Result = func.Invoke();
                response.HasError = false;
            }
            catch (Exception ex)
            {
                this.logger.Error(ex);
                response.Result = default(T);
                response.Exception = ex;
                response.HasError = true;
            }

            return response;
        }
    }
}
