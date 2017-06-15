using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ISEN.DotNet.Library.Repositories.Interfaces;
using ISEN.DotNet.Library.Models;

namespace ISEN.DotNet.Library.Data
{
    public class SeedData
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<SeedData> _logger;
        private readonly IOwnerRepository _ownerRepository;
        private readonly IStatementRepository _statementRepository;
        private readonly IEquipmentRepository _equipmentRepository;
        private readonly UserManager<AccountUser> _userManager;
        private readonly RoleManager<AccountRole> _roleManager;


        public SeedData(
            ApplicationDbContext context,
            ILogger<SeedData> logger,
            IOwnerRepository ownerRepository,
            IStatementRepository statementRepository,
            IEquipmentRepository equipmentRepository,
            UserManager<AccountUser> userManager,
            RoleManager<AccountRole> roleManager)
        {
            _context = context;
            _logger = logger;
            _ownerRepository = ownerRepository;
            _statementRepository = statementRepository;
            _equipmentRepository = equipmentRepository;
            _userManager = userManager;
            _roleManager = roleManager;
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
        public async void AddAdminAndRole()
        {
            var roleExist = await _roleManager.RoleExistsAsync("Admin");            
            if (!roleExist)
            {                
                var r1 = await _roleManager.CreateAsync(new AccountRole { Name = "Admin" });
                var r2 = await _roleManager.CreateAsync(new AccountRole { Name = "User" });
                const string mail = "admin@admin.fr";
                var user = new AccountUser {UserName = mail, Email = mail};
                var result = await _userManager.CreateAsync(user,
                    "Admin123!");
                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(user, "Admin");
                    _logger.LogWarning("Admin user has been created");
                }
                var user1 = new AccountUser { UserName = "alo", Email = "test@test.fr" };
                var result1 = await _userManager.CreateAsync(user1, "xavier");
                if (result1.Succeeded)
                {
                    await _userManager.AddToRoleAsync(user1, "User");
                    _logger.LogWarning("Admin user has been created");
                }
                var owner = new Owner()
                {
                    FirstName = "Xavier",
                    LastName = "Xavier",
                    City = "Xavier",
                    Country = "Xavier",
                    Account = user1
                };
                _ownerRepository.Update(owner);
                _ownerRepository.Save();
                var equipment = new Equipment()
                {
                    Type = "SolarPanel",
                    MaxProduction = 123,
                    IdObject = "SolarPanel123",
                };
                _equipmentRepository.Update(equipment);
                _equipmentRepository.Save();
            }
        }
        /*public void AddOwner()
         {
             if (_ownerRepository.GetAll().Any()) return;



             _logger.LogWarning("Ajout des owner");

 #region 5 owner random
             var p1 = new Owner()
             {
                 LastName = "DUPONT",
                 FirstName = "Xavier",
                 City = "Toulon",
                 Country = "France"
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
                 Country = "France"
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
             var o1 = _ownerRepository.Single(p => p.Id == 1);
             var o2 = _ownerRepository.Single(p => p.Id == 2);
             if (o1 == null)
             {
                 _logger.LogWarning("o1 is null");
             }
             if (o2 == null)
             {
                 _logger.LogWarning("o2 is null");
             }

             _logger.LogWarning("Ajout des equipments");
 #region 2 equipment random
             var e1 = new Equipment()
             {
                 MaxProduction = 630,
                 Type = "WindTurbine",
                 Owner = o1
             };    
             var e2 = new Equipment()
             {
                 MaxProduction = 430,
                 Type = "SolarPanel",
                 Owner = o2
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
         }*/
    }
}