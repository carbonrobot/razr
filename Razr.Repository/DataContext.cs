using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using Razr.Models;

namespace Razr.Repository
{
    public class DataContext : DbContext, Razr.Services.IContext
    {
        public DbSet<Post> Posts { get; set; }
        public DbSet<User> Users { get; set; }

        public int Count<T>() where T : Models.BaseModel
        {
            return this.Set<T>().Count();
        }
        public T Get<T>(int id, params string[] includes) where T : Models.BaseModel
        {
            if (includes == null)
            {
                return this.Set<T>().Find(id);
            }
            else
            {
                return this.AsQueryable<T>(includes).FirstOrDefault(x => x.Id == id);
            }
        }
        public IQueryable<T> AsQueryable<T>(params string[] includes) where T : BaseModel
        {
            var query = this.Set<T>().AsQueryable();
            if (includes != null)
            {
                foreach (var include in includes)
                {
                    query = query.Include(include);
                }
            }
            return query;
        }
        public T Save<T>(T entity) where T : BaseModel
        {
            var set = this.Set<T>();

            // reattach or add as needed
            if (entity.Id > 0)
            {
                this.Entry(entity).State = System.Data.EntityState.Modified;
                entity.ChangedDate = DateTime.Now;
            }
            else
            {
                set.Add(entity);
            }

            this.SaveChanges();
            return entity;
        }
        public bool Delete<T>(int id) where T : BaseModel
        {
            var dbset = this.Set<T>();
            var entity = dbset.Find(id);
            return this.Delete(entity);
        }
        public bool Delete<T>(T entity) where T : BaseModel
        {
            var dbset = this.Set<T>();
            dbset.Remove(entity);
            return this.SaveChanges() > 0;
        }

        public override int SaveChanges()
        {
            var result = base.SaveChanges();
            if (result > 0)
            {
                return result;
            }
            else
            {
                throw new ContextException("Could not save changes to database");
            }
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }

    public static class ContextExtensions
    {
        /// <summary>
        /// Determines whether the entity needs to be added or attached to the DBSet
        /// and updates the changed date
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="set"></param>
        /// <param name="entity"></param>
        public static void AttachOrAdd<T>(this DbSet<T> set, T entity) where T : BaseModel
        {
            if (entity.Id == -1)
            {
                set.Add(entity);
            }
            else
            {
                set.Attach(entity);
                entity.ChangedDate = DateTime.Now;
            }
        }
    }

    /// <summary>
    /// Datastore context specific exception
    /// </summary>
    public class ContextException : Exception
    {
        public ContextException()
            : base()
        {

        }

        public ContextException(string message)
            : base(message)
        {

        }
    }
}
