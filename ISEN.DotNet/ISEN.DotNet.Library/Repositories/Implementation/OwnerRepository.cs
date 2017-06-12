using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using ISEN.DotNet.Library.Data;
using ISEN.DotNet.Library.Models;
using ISEN.DotNet.Library.Repositories;
using ISEN.DotNet.Library.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace ISEN.DotNet.Library.Repositories.Implementation
{
    public class OwnerRepository : BaseContextRepository<Owner>, IOwnerRepository
    {        
        public OwnerRepository(
            ILogger<OwnerRepository> logger,
            ApplicationDbContext context) : base(logger, context)
        {
            Logger.LogWarning("OwnerRepository was newed");
        }

        public override IQueryable<Owner> EntityCollection
            => Context.OwnerCollection.AsQueryable();
            public override IQueryable<Owner> Includes(IQueryable<Owner> queryable)
        {
            queryable = base.Includes(queryable);
            queryable = queryable.Include(e => e.Equipment);
            return queryable;
        }
    }
}