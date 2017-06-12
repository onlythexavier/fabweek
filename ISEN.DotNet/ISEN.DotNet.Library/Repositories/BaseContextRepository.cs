using System.Linq;
using ISEN.DotNet.Library.Data;
using ISEN.DotNet.Library.Models;
using Microsoft.Extensions.Logging;

namespace ISEN.DotNet.Library.Repositories
{
    public abstract class BaseContextRepository<T> : BaseRepository<T>
        where T : BaseEntity
    {
        protected readonly ApplicationDbContext Context;

        public BaseContextRepository(
            ILogger<BaseContextRepository<T>> logger,
            ApplicationDbContext context) 
        : base(logger)
        {
            Context = context;
        }
        
        public override void Update(T entity)
        {
            if (entity.IsNew) Context.Add(entity);
            else Context.Update(entity);
        }

        public override void Delete(int id)
        {
            var entity = Context.Set<T>()                
                .SingleOrDefault(e => e.Id == id);
            if (entity != null) Context.Remove(entity);
        }

        public override void Save()
        {
            Context.SaveChanges();
        }
    }
}