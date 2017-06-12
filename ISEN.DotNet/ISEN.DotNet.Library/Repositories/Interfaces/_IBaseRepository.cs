using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using ISEN.DotNet.Library.Models;

namespace ISEN.DotNet.Library.Repositories.Interfaces
{
    public interface IBaseRepository<T>
        where T : BaseEntity
    {
        IEnumerable<T> GetAll();
        IEnumerable<T> Find(Expression<Func<T, bool>> predicate);
        T Single(int id);
        T Single(string name);
        T Single(Expression<Func<T, bool>> predicate);
        void Update(T entity);
        void UpdateRange(IEnumerable<T> entities);
        void UpdateRange(params T[] entities);
        void Delete(int id);
        void Save();
    }
}