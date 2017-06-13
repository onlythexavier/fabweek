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
            var createdString = created ? "created" : "not created";
            _logger.LogWarning($"Database was {createdString}");
        }   
        public void AddOwner()
        {
            if (_ownerRepository.GetAll().Any()) return;

            var c1 = _equipmentRepository.Single(p => p.Id == 1);
            var c2 = _equipmentRepository.Single(p => p.Id == 2);
            if(c1 == null){
                _logger.LogWarning("c1 is null");
            }
            if(c2 == null){
                _logger.LogWarning("c2 is null");
            }
            _logger.LogWarning(c1.ToString());
            _logger.LogWarning(c2.Id.ToString());

            _logger.LogWarning("Ajout des owner");

#region 5 owner random
            var p1 = new Owner()
            {
                LastName = "DUPONT",
                FirstName = "Xavier",
                City = "Toulon",
                Country = "France",
                Equipment = (Equipment)c1
            };    
            var p2 = new Owner()
            {
                LastName = "MALLAT DESMORTIERS",
                FirstName = "Xavier",
                City = "Marseille",
                Country = "France"
            };
            var p3 = new Owner()
            {
                LastName = "MAROUN",
                FirstName = "Marc",
                City = "Marseille",
                Country = "France",
                Equipment = (Equipment)c2
            };
            var p4 = new Owner()
            {
                LastName = "HIVERT",
                FirstName = "Thomas",
                City = "La Seyne-sur-Mer",
                Country = "France"
            };
            var p5 = new Owner()
            {
                LastName = "BOTTEMER",
                FirstName = "Alexis",
                City = "Toulon",
                Country = "France"
            };
#endregion

            _ownerRepository.UpdateRange(p1, p2, p3, p4, p5);
            _ownerRepository.Save();

            _logger.LogWarning("Owner added");
        }

        public void AddEquipment()
        {
            if (_equipmentRepository.GetAll().Any()) return;

            
            _logger.LogWarning("Ajout des equipments");
#region 2 equipment random
            var e1 = new Equipment()
            {
                Id = 1,
                MaxProduction = 630,
                Type = "WindTurbine"
            };    
            var e2 = new Equipment()
            {
                Id = 2,
                MaxProduction = 430,
                Type = "SolarPanel"
            };
#endregion
_logger.LogWarning(e1.ToString());
            _logger.LogWarning(e2.Type.ToString());
            _equipmentRepository.UpdateRange(e1, e2);
            _equipmentRepository.Save();

            _logger.LogWarning("Equipment added");
        }

        public void AddStatement()
        {
               if (_statementRepository.GetAll().Any()) return;

               var t1 = _equipmentRepository.Single(p => p.Id == 1);
               var t2 = _equipmentRepository.Single(p => p.Id == 2);

            _logger.LogWarning("Ajout des reservations");

#region 2 statement random
            var r1 = new Statement(){
                Equipment = (Equipment)t1,
                Production = 400,
                Consommation = 300
            };
            var r2 = new Statement(){
                Equipment = (Equipment)t2,
                Production = 200,
                Consommation = 100
            };
#endregion
            _statementRepository.UpdateRange(r1, r2);
            _statementRepository.Save();

            _logger.LogWarning("Statement added");
        }
    }
}