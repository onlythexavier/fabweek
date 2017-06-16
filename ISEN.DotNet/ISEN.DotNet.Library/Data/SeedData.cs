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
                    MaxProduction = 400,
                    IdObject = "SolarPanel123",
                };
                _equipmentRepository.Update(equipment);
                _equipmentRepository.Save();
                
                var statement1 = new Statement()
                {
                    Production = 50,
                    Consommation = 100,
                    OverProduction = 0,
                    Equipment = equipment,
                    Date = new DateTime(2017,06,16,08,55,15)
                };
                var statement2 = new Statement()
                {
                    Production = 100,
                    Consommation = 150,
                    OverProduction = 0,
                    Equipment = equipment,
                    Date = new DateTime(2017,06,16,09,33,22)
                };
                var statement3 = new Statement()
                {
                    Production = 150,
                    Consommation = 0,
                    OverProduction = 100,
                    Equipment = equipment,
                    Date = new DateTime(2017,06,16,10,42,06)
                };
                var statement4 = new Statement()
                {
                    Production = 200,
                    Consommation = 0,
                    OverProduction = 150,
                    Equipment = equipment,
                    Date = new DateTime(2017,06,16,11,02,01)
                };
                var statement5 = new Statement()
                {
                    Production = 250,
                    Consommation = 0,
                    OverProduction = 200,
                    Equipment = equipment,
                    Date = new DateTime(2017,06,16,12,02,01)
                };
                var statement6 = new Statement()
                {
                    Production = 300,
                    Consommation = 0,
                    OverProduction = 250,
                    Equipment = equipment,
                    Date = new DateTime(2017,06,16,13,53,11)
                };
                var statement7 = new Statement()
                {
                    Production = 350,
                    Consommation = 0,
                    OverProduction = 300,
                    Equipment = equipment,
                    Date = new DateTime(2017,06,16,14,23,35)
                };
                var statement8 = new Statement()
                {
                    Production = 300,
                    Consommation = 0,
                    OverProduction = 250,
                    Equipment = equipment,
                    Date = new DateTime(2017,06,16,15,15,21)
                };
                var statement9 = new Statement()
                {
                    Production = 250,
                    Consommation = 0,
                    OverProduction = 200,
                    Equipment = equipment,
                    Date = new DateTime(2017,06,16,16,08,31)
                };
                var statement10 = new Statement()
                {
                    Production = 200,
                    Consommation = 250,
                    OverProduction = 0,
                    Equipment = equipment,
                    Date = new DateTime(2017,06,16,17,59,59)
                };
                var statement11 = new Statement()
                {
                    Production = 100,
                    Consommation = 300,
                    OverProduction = 0,
                    Equipment = equipment,
                    Date = new DateTime(2017,06,16,18,32,23)
                };
                var statement12 = new Statement()
                {
                    Production = 0,
                    Consommation = 350,
                    OverProduction = 0,
                    Equipment = equipment,
                    Date = new DateTime(2017,06,16,23,59,59)
                };
                _statementRepository.UpdateRange(statement1, statement2, statement3, statement5, statement6, statement7, statement8, statement9, statement10, statement11, statement12);
                _statementRepository.Save();
            }
        }
        /*public void AddOwner()
         {
             if (_ownerRepository.GetAll().Any()) return;



             _logger.LogWarning("Ajout des owner");

 #region 2 owner random
             var p1 = new Owner()
             {
                 Email = "xavier.dupont@isen.fr",
                 UserName = "xavierdupont",
                 Password = "xavier",
                 LastName = "DUPONT",
                 FirstName = "Xavier",
                 City = "Toulon",
                 Country = "France"
             };    
             var p2 = new Owner()
             {
                 Email = "xavier.mallat@isen.fr",
                 UserName = "xaviermalalt",
                 Password = "xavier",
                 LastName = "MALLAT DESMORTIERS",
                 FirstName = "Xavier",
                 City = "Marseille",
                 Country = "France"
             };
 #endregion

             _ownerRepository.UpdateRange(p1, p2);
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

 #region 10 statement random
             var r1 = new Statement(){
                 Equipment = (Equipment)t1,
                 Production = 100,
                 Consommation = 300,
             };
             var r2 = new Statement(){
                 Equipment = (Equipment)t1,
                 Production = 200,
                 Consommation = 300
             };
             var r3 = new Statement(){
                 Equipment = (Equipment)t1,
                 Production = 300,
                 Consommation = 300
             };
             var r4 = new Statement(){
                 Equipment = (Equipment)t1,
                 Production = 400,
                 Consommation = 300
             };
 #endregion
             _statementRepository.UpdateRange(r1, r2, r3, r4, r5);
             _statementRepository.Save();

             _logger.LogWarning("Statement added");
         }*/
    }
}