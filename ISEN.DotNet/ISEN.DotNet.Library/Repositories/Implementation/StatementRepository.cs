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
    public class StatementRepository : BaseContextRepository<Statement>, IStatementRepository
    {        
        public StatementRepository(
            ILogger<StatementRepository> logger,
            ApplicationDbContext context) : base(logger, context)
        {
            Logger.LogWarning("StatementRepository was newed");
        }

        public override IQueryable<Statement> EntityCollection
            => Context.StatementCollection.AsQueryable();
    }
}