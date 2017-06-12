using System;
using System.Linq;
using ISEN.DotNet.Library.Models;
using ISEN.DotNet.Library.Repositories.Interfaces;
using Microsoft.Extensions.Logging;

namespace ISEN.DotNet.Library.Data
{
    public class SeedData
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<SeedData> _logger;
        private readonly IOwnerRepository _ownerRepository;
        private readonly IStatementRepository _statementRepository;
        private readonly IEquipmentRepository _equipmentRepository;

        public SeedData(
            ApplicationDbContext context,
            ILogger<SeedData> logger,
            IOwnerRepository ownerRepository,
            IStatementRepository statementRepository,
            IEquipmentRepository equipmentRepository)
        {
            _context = context;
            _logger = logger;
            _ownerRepository = ownerRepository;
            _statementRepository = statementRepository;
            _equipmentRepository = equipmentRepository;
        }

        public void DropCreateDatabase()
        {           
            var deleted = _context.Database.EnsureDeleted();
            var deletedString = deleted ? "dropped" : "not dropped";
            _logger.LogWarning($"Database was {deletedString}");

            var created = _context.Database.EnsureCreated();
            var createdString = deleted ? "created" : "not created";
            _logger.LogWarning($"Database was {createdString}");
        }   
    }
}