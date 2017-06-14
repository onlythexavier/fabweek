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

namespace ISEN.DotNet.Library.Repositories.Implementations
{
    public class EquipmentRepository : BaseContextRepository<Equipment>, IEquipmentRepository
    {        
        public EquipmentRepository(
            ILogger<EquipmentRepository> logger,
            ApplicationDbContext context) : base(logger, context)
        {
            Logger.LogWarning("EquipmentRepository was newed");
        }

        public override IQueryable<Equipment> Includes(IQueryable<Equipment> queryable)
        {
            queryable = base.Includes(queryable)
                .Include(e => e.Owner);
            return queryable;
        }

        public override IQueryable<Equipment> EntityCollection
            => Context.EquipmentCollection.AsQueryable();
    }
}