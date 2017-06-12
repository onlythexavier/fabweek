using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using ISEN.DotNet.Library.Models;
using ISEN.DotNet.Library.Repositories.Interfaces;
using Microsoft.Extensions.Logging;

namespace ISEN.DotNet.Library.Repositories
{
    public abstract class BaseRepository<T> : IBaseRepository<T>
        where T : BaseEntity
    {
        protected readonly ILogger<BaseRepository<T>> Logger;
        public BaseRepository(ILogger<BaseRepository<T>> logger)
        {
            Logger = logger;
        }

        public abstract IQueryable<T> EntityCollection { get; }

        public virtual IQueryable<T> Includes(IQueryable<T> queryable)
            => queryable;

        public virtual IEnumerable<T> GetAll()
        {
            var queryable = EntityCollection;
            queryable = Includes(queryable);
            return queryable;
        }

       public virtual IEnumerable<T> Find(
            Expression<Func<T, bool>> predicate)
        {
            var queryable = EntityCollection;
            queryable = Includes(queryable);
            queryable = queryable.Where(predicate);
            return queryable;
        }

        public virtual T Single(int id)
        {
            var queryable = EntityCollection;
            queryable = Includes(queryable);
            return queryable.SingleOrDefault(p => p.Id == id);
        }

        public virtual T Single(string name)
        {
            var queryable = EntityCollection;
            queryable = Includes(queryable);
            return queryable.SingleOrDefault(p => 
                p.Name.Equals(name, StringComparison.CurrentCultureIgnoreCase));
        }

        public virtual T Single(Expression<Func<T, bool>> predicate)
        {
            var queryable = EntityCollection;
            queryable = Includes(queryable);
            return queryable.SingleOrDefault(predicate);
        }

        public abstract void Update(T entity);
        public void UpdateRange(IEnumerable<T> entities)
        {
            foreach(var e in entities) Update(e);
        }

        public void UpdateRange(params T[] entities)
        {
            UpdateRange(entities.AsEnumerable());
        }

        public abstract void Delete(int id);
        public abstract void Save();
    }


}