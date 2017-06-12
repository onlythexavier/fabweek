using System.Linq;
using ISEN.DotNet.Library.Data;
using ISEN.DotNet.Library.Models;
using ISEN.DotNet.Library.Repositories.Interfaces;
using Microsoft.Extensions.Logging;

namespace ISEN.DotNet.Library.Repositories.Implementations
{
    public class EquipmentRepository : BaseContextRepository<Equipment>, IEquipmentRepository
    {
        public EquipmentRepository(ILogger<BaseContextRepository<Equipment>> logger,
            ApplicationDbContext context) : base(logger, context)
        {
            Logger.LogWarning("Equipment was neewed");
        }

        public override IQueryable<Equipment> EntityCollection =>
            Context.EquipmentCollection.AsQueryable();
    }
}