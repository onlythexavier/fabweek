using System;
using Microsoft.AspNetCore.Identity;
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

        public double GetRandomNumber(double minimum, double maximum)
        {
            Random random = new Random();
            return random.NextDouble() * (maximum - minimum) + minimum;
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
                await _roleManager.CreateAsync(new AccountRole { Name = "Admin" });
                await _roleManager.CreateAsync(new AccountRole { Name = "User" });
                const string mail = "admin@admin.fr";
                var user = new AccountUser { UserName = mail, Email = mail };
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
                #region equipments

                var equipment1 = new Equipment()
                {
                    Type = "SolarPanel",
                    MaxProduction = 400,
                    IdObject = "SolarPanel1",
                    Longitude = 15.0,
                    Latitude = 15.0,
                    StatementCollection = { }
                };
                var equipment2 = new Equipment()
                {
                    Type = "SolarPanel",
                    MaxProduction = 400,
                    IdObject = "SolarPanel2",
                    Longitude = 15.0,
                    Latitude = 15.0,
                    StatementCollection = { }
                };
                var equipment3 = new Equipment()
                {
                    Type = "SolarPanel",
                    MaxProduction = 400,
                    IdObject = "SolarPanel3",
                    Longitude = 15.0,
                    Latitude = 15.0,
                    StatementCollection = { }
                };
                var equipment4 = new Equipment()
                {
                    Type = "SolarPanel",
                    MaxProduction = 400,
                    IdObject = "SolarPanel4",
                    Longitude = 15.0,
                    Latitude = 15.0,
                    StatementCollection = { }
                };
                var equipment5 = new Equipment()
                {
                    Type = "SolarPanel",
                    MaxProduction = 400,
                    IdObject = "SolarPanel5",
                    Longitude = 15.0,
                    Latitude = 15.0,
                    StatementCollection = { }
                };
                var equipment6 = new Equipment()
                {
                    Type = "SolarPanel",
                    MaxProduction = 400,
                    IdObject = "SolarPanel6",
                    Longitude = 15.0,
                    Latitude = 15.0,
                    StatementCollection = { }
                };
                var equipment7 = new Equipment()
                {
                    Type = "SolarPanel",
                    MaxProduction = 400,
                    IdObject = "SolarPanel7",
                    Longitude = 15.0,
                    Latitude = 15.0,
                    StatementCollection = { }
                };
                var equipment8 = new Equipment()
                {
                    Type = "SolarPanel",
                    MaxProduction = 400,
                    IdObject = "SolarPanel8",
                    Longitude = 15.0,
                    Latitude = 15.0,
                    StatementCollection = { }
                };
                var equipment9 = new Equipment()
                {
                    Type = "SolarPanel",
                    MaxProduction = 400,
                    IdObject = "SolarPanel9",
                    Longitude = 15.0,
                    Latitude = 15.0,
                    StatementCollection = { }
                };
                var equipment10 = new Equipment()
                {
                    Type = "SolarPanel",
                    MaxProduction = 400,
                    IdObject = "SolarPanel10",
                    Longitude = 15.0,
                    Latitude = 15.0,
                    StatementCollection = { }
                };
                _equipmentRepository.UpdateRange(equipment1, equipment2, equipment3, equipment4, equipment5, equipment6,
                    equipment7, equipment8, equipment9, equipment10);
                _equipmentRepository.Save();

                #endregion

                #region statemenst equipment1

                var statement1 = new Statement()
                {
                    Production = 0,
                    Consommation = 0.5,
                    OverProduction = 0,
                    Date = new DateTime(2017, 06, 16, 00, 01, 12)
                };
                equipment1.AddStatement(statement1);
                var statement2 = new Statement()
                {
                    Production = 0,
                    Consommation = 0.5,
                    OverProduction = 0,
                    Date = new DateTime(2017, 06, 16, 00, 33, 22)
                };
                equipment1.AddStatement(statement2);
                var statement3 = new Statement()
                {
                    Production = 0,
                    Consommation = 0.5,
                    OverProduction = 0,
                    Date = new DateTime(2017, 06, 16, 01, 02, 06)
                };
                equipment1.AddStatement(statement3);
                var statement4 = new Statement()
                {
                    Production = 0,
                    Consommation = 0.5,
                    OverProduction = 0,
                    Date = new DateTime(2017, 06, 16, 01, 32, 01)
                };
                equipment1.AddStatement(statement4);
                var statement5 = new Statement()
                {
                    Production = 0,
                    Consommation = 0.5,
                    OverProduction = 0,
                    Date = new DateTime(2017, 06, 16, 02, 02, 05)
                };
                equipment1.AddStatement(statement5);
                var statement6 = new Statement()
                {
                    Production = 0,
                    Consommation = 0.5,
                    OverProduction = 0,
                    Date = new DateTime(2017, 06, 16, 02, 33, 11)
                };
                equipment1.AddStatement(statement6);
                var statement7 = new Statement()
                {
                    Production = 0,
                    Consommation = 0.5,
                    OverProduction = 0,
                    Date = new DateTime(2017, 06, 16, 02, 59, 35)
                };
                equipment1.AddStatement(statement7);
                var statement8 = new Statement()
                {
                    Production = 0,
                    Consommation = 0.5,
                    OverProduction = 0,
                    Date = new DateTime(2017, 06, 16, 03, 25, 21)
                };
                equipment1.AddStatement(statement8);
                var statement9 = new Statement()
                {
                    Production = 0,
                    Consommation = 0.5,
                    OverProduction = 0,
                    Date = new DateTime(2017, 06, 16, 03, 58, 31)
                };
                equipment1.AddStatement(statement9);
                var statement10 = new Statement()
                {
                    Production = 0,
                    Consommation = 0.5,
                    OverProduction = 0,
                    Date = new DateTime(2017, 06, 16, 04, 32, 23)
                };
                equipment1.AddStatement(statement10);
                var statement11 = new Statement()
                {
                    Production = 0,
                    Consommation = 0.5,
                    OverProduction = 0,
                    Date = new DateTime(2017, 06, 16, 04, 51, 57)
                };
                equipment1.AddStatement(statement11);
                var statement12 = new Statement()
                {
                    Production = 0,
                    Consommation = 0.5,
                    OverProduction = 0,
                    Date = new DateTime(2017, 06, 16, 05, 38, 12)
                };
                equipment1.AddStatement(statement12);
                var statement13 = new Statement()
                {
                    Production = 0 + GetRandomNumber(0, 0.0001),
                    Consommation = 0.5,
                    OverProduction = 0,
                    Date = new DateTime(2017, 06, 16, 05, 58, 01)
                };
                equipment1.AddStatement(statement13);
                var statement14 = new Statement()
                {
                    Production = 0 + GetRandomNumber(0, 0.0005),
                    Consommation = 0.5,
                    OverProduction = 0,
                    Date = new DateTime(2017, 06, 16, 06, 27, 21)
                };
                equipment1.AddStatement(statement14);
                var statement15 = new Statement()
                {
                    Production = 0 + GetRandomNumber(0, 0.01),
                    Consommation = 1.5,
                    OverProduction = 0,
                    Date = new DateTime(2017, 06, 16, 07, 10, 19)
                };
                equipment1.AddStatement(statement15);
                var statement16 = new Statement()
                {
                    Production = 0.001 + GetRandomNumber(0, 0.001),
                    Consommation = 1,
                    OverProduction = 0,
                    Date = new DateTime(2017, 06, 16, 07, 31, 49)
                };
                equipment1.AddStatement(statement16);
                var statement17 = new Statement()
                {
                    Production = 0.001 + GetRandomNumber(0, 0.019),
                    Consommation = 0.5,
                    OverProduction = 0,
                    Date = new DateTime(2017, 06, 16, 08, 02, 07)
                };
                equipment1.AddStatement(statement17);
                var statement18 = new Statement()
                {
                    Production = 0.015 + GetRandomNumber(0, 0.001),
                    Consommation = 0.5,
                    OverProduction = 0,
                    Date = new DateTime(2017, 06, 16, 08, 27, 35)
                };
                equipment1.AddStatement(statement18);
                var statement19 = new Statement()
                {
                    Production = 0.010 + GetRandomNumber(0, 0.009),
                    Consommation = 0.5,
                    OverProduction = 0,
                    Date = new DateTime(2017, 06, 16, 09, 00, 00)
                };
                equipment1.AddStatement(statement19);
                var statement20 = new Statement()
                {
                    Production = 0.012 + GetRandomNumber(0, 0.012),
                    Consommation = 0.5,
                    OverProduction = 0,
                    Date = new DateTime(2017, 06, 16, 09, 27, 42)
                };
                equipment1.AddStatement(statement20);
                var statement21 = new Statement()
                {
                    Production = 0.018 + GetRandomNumber(0, 0.015),
                    Consommation = 0.5,
                    OverProduction = 0,
                    Date = new DateTime(2017, 06, 16, 09, 59, 03)
                };
                equipment1.AddStatement(statement21);
                var statement22 = new Statement()
                {
                    Production = 0.056 + GetRandomNumber(0, 0.05),
                    Consommation = 0.5,
                    OverProduction = 0,
                    Date = new DateTime(2017, 06, 16, 10, 28, 13)
                };
                equipment1.AddStatement(statement22);
                var statement23 = new Statement()
                {
                    Production = 0.084 + GetRandomNumber(0, 0.06),
                    Consommation = 0.5,
                    OverProduction = 0,
                    Date = new DateTime(2017, 06, 16, 10, 59, 59)
                };
                equipment1.AddStatement(statement23);
                var statement24 = new Statement()
                {
                    Production = 0.06 + GetRandomNumber(0, 0.06),
                    Consommation = 0.5,
                    OverProduction = 0,
                    Date = new DateTime(2017, 06, 16, 11, 34, 15)
                };
                equipment1.AddStatement(statement24);
                var statement25 = new Statement()
                {
                    Production = 0.08 + GetRandomNumber(0, 0.05),
                    Consommation = 0.5,
                    OverProduction = 0,
                    Date = new DateTime(2017, 06, 16, 11, 58, 39)
                };
                equipment1.AddStatement(statement25);
                var statement26 = new Statement()
                {
                    Production = 0.08 + GetRandomNumber(0, 0.08),
                    Consommation = 0.5,
                    OverProduction = 0,
                    Date = new DateTime(2017, 06, 16, 12, 32, 57)
                };
                equipment1.AddStatement(statement26);
                var statement27 = new Statement()
                {
                    Production = 0.08 + GetRandomNumber(0, 0.08),
                    Consommation = 0.5,
                    OverProduction = 0,
                    Date = new DateTime(2017, 06, 16, 12, 52, 49)
                };
                equipment1.AddStatement(statement27);
                var statement28 = new Statement()
                {
                    Production = 0.10 + GetRandomNumber(0, 0.10),
                    Consommation = 0.5,
                    OverProduction = 0,
                    Date = new DateTime(2017, 06, 16, 13, 24, 33)
                };
                equipment1.AddStatement(statement28);
                var statement29 = new Statement()
                {
                    Production = 0.14 + GetRandomNumber(0, 0.10),
                    Consommation = 0.5,
                    OverProduction = 0.2,
                    Date = new DateTime(2017, 06, 16, 13, 51, 47)
                };
                equipment1.AddStatement(statement29);
                var statement30 = new Statement()
                {
                    Production = 0.14 + GetRandomNumber(0, 0.12),
                    Consommation = 0.5,
                    OverProduction = 0.2,
                    Date = new DateTime(2017, 06, 16, 14, 21, 12)
                };
                equipment1.AddStatement(statement30);
                var statement31 = new Statement()
                {
                    Production = 0.16 + GetRandomNumber(0, 0.16),
                    Consommation = 0.5,
                    OverProduction = 0.3,
                    Date = new DateTime(2017, 06, 16, 14, 59, 47)
                };
                equipment1.AddStatement(statement31);
                var statement32 = new Statement()
                {
                    Production = 0.250 + GetRandomNumber(0, 0.15),
                    Consommation = 0.5,
                    OverProduction = 0.75,
                    Date = new DateTime(2017, 06, 16, 15, 29, 53)
                };
                equipment1.AddStatement(statement32);
                var statement33 = new Statement()
                {
                    Production = 0.250 + GetRandomNumber(0, 0.15),
                    Consommation = 0.5,
                    OverProduction = 0.75,
                    Date = new DateTime(2017, 06, 16, 15, 57, 38)
                };
                equipment1.AddStatement(statement33);
                var statement34 = new Statement()
                {
                    Production = 0.240 + GetRandomNumber(0, 0.15),
                    Consommation = 0.5,
                    OverProduction = 0.7,
                    Date = new DateTime(2017, 06, 16, 16, 33, 12)
                };
                equipment1.AddStatement(statement34);
                var statement35 = new Statement()
                {
                    Production = 0.220 + GetRandomNumber(0, 0.16),
                    Consommation = 0.5,
                    OverProduction = 0.6,
                    Date = new DateTime(2017, 06, 16, 16, 59, 01)
                };
                equipment1.AddStatement(statement35);
                var statement36 = new Statement()
                {
                    Production = 0.220 + GetRandomNumber(0, 0.16),
                    Consommation = 0.5,
                    OverProduction = 0.6,
                    Date = new DateTime(2017, 06, 16, 17, 23, 07)
                };
                equipment1.AddStatement(statement36);
                var statement37 = new Statement()
                {
                    Production = 0.18 + GetRandomNumber(0, 0.08),
                    Consommation = 0.5,
                    OverProduction = 0.4,
                    Date = new DateTime(2017, 06, 16, 17, 57, 31)
                };
                equipment1.AddStatement(statement37);
                var statement38 = new Statement()
                {
                    Production = 0.14 + GetRandomNumber(0, 0.05),
                    Consommation = 1,
                    OverProduction = 0,
                    Date = new DateTime(2017, 06, 16, 18, 37, 46)
                };
                equipment1.AddStatement(statement38);
                var statement39 = new Statement()
                {
                    Production = 0.12 + GetRandomNumber(0, 0.09),
                    Consommation = 1,
                    OverProduction = 0,
                    Date = new DateTime(2017, 06, 16, 18, 51, 12)
                };
                equipment1.AddStatement(statement39);
                var statement40 = new Statement()
                {
                    Production = 0.10 + GetRandomNumber(0, 0.06),
                    Consommation = 2,
                    OverProduction = 0,
                    Date = new DateTime(2017, 06, 16, 19, 21, 56)
                };
                equipment1.AddStatement(statement40);
                var statement41 = new Statement()
                {
                    Production = 0.08 + GetRandomNumber(0, 0.06),
                    Consommation = 2.5,
                    OverProduction = 0,
                    Date = new DateTime(2017, 06, 16, 19, 51, 13)
                };
                equipment1.AddStatement(statement41);
                var statement42 = new Statement()
                {
                    Production = 0.04 + GetRandomNumber(0, 0.015),
                    Consommation = 2.5,
                    OverProduction = 0,
                    Date = new DateTime(2017, 06, 16, 20, 30, 01)
                };
                equipment1.AddStatement(statement42);
                var statement43 = new Statement()
                {
                    Production = 0.04 + GetRandomNumber(0, 0.015),
                    Consommation = 3,
                    OverProduction = 0,
                    Date = new DateTime(2017, 06, 16, 20, 55, 57)
                };
                equipment1.AddStatement(statement43);
                var statement44 = new Statement()
                {
                    Production = 0.04 + GetRandomNumber(0, 0.02),
                    Consommation = 2,
                    OverProduction = 0,
                    Date = new DateTime(2017, 06, 16, 21, 30, 00)
                };
                equipment1.AddStatement(statement44);
                var statement45 = new Statement()
                {
                    Production = 0.04 + GetRandomNumber(0, 0.01),
                    Consommation = 1.5,
                    OverProduction = 0,
                    Date = new DateTime(2017, 06, 16, 22, 07, 00)
                };
                equipment1.AddStatement(statement45);
                var statement46 = new Statement()
                {
                    Production = 0.024 + GetRandomNumber(0, 0.019),
                    Consommation = 1,
                    OverProduction = 0,
                    Date = new DateTime(2017, 06, 16, 22, 29, 57)
                };
                equipment1.AddStatement(statement46);
                var statement47 = new Statement()
                {
                    Production = 0.016 + GetRandomNumber(0, 0.01),
                    Consommation = 0.5,
                    OverProduction = 0,
                    Date = new DateTime(2017, 06, 16, 23, 01, 06)
                };
                equipment1.AddStatement(statement47);
                var statement48 = new Statement()
                {
                    Production = 0 + GetRandomNumber(0, 0.0001),
                    Consommation = 0.5,
                    OverProduction = 0,
                    Date = new DateTime(2017, 06, 16, 23, 35, 09)
                };
                equipment1.AddStatement(statement48);
                _statementRepository.UpdateRange(statement1, statement2, statement3, statement4, statement5, statement6,
                    statement7,
                    statement8, statement9, statement10, statement11, statement12, statement13, statement14, statement15,
                    statement16, statement17, statement18, statement19, statement20, statement21, statement22, statement23,
                    statement24, statement25, statement26, statement27, statement28, statement29, statement30, statement31,
                    statement32, statement33, statement34, statement35, statement36, statement37, statement38, statement39,
                    statement40, statement41, statement42, statement43, statement44, statement45, statement46, statement47,
                    statement48);

                #endregion

                #region statements equipment2

                var statement49 = new Statement()
                {
                    Production = 0,
                    Consommation = 0.5,
                    OverProduction = 0,
                    Date = new DateTime(2017, 06, 16, 00, 01, 12)
                };
                equipment2.AddStatement(statement49);
                var statement50 = new Statement()
                {
                    Production = 0,
                    Consommation = 0.5,
                    OverProduction = 0,
                    Date = new DateTime(2017, 06, 16, 00, 33, 22)
                };
                equipment2.AddStatement(statement50);
                var statement51 = new Statement()
                {
                    Production = 0,
                    Consommation = 0.5,
                    OverProduction = 0,
                    Date = new DateTime(2017, 06, 16, 01, 02, 06)
                };
                equipment2.AddStatement(statement51);
                var statement52 = new Statement()
                {
                    Production = 0,
                    Consommation = 0.5,
                    OverProduction = 0,
                    Date = new DateTime(2017, 06, 16, 01, 32, 01)
                };
                equipment2.AddStatement(statement52);
                var statement53 = new Statement()
                {
                    Production = 0,
                    Consommation = 0.5,
                    OverProduction = 0,
                    Date = new DateTime(2017, 06, 16, 02, 02, 05)
                };
                equipment2.AddStatement(statement53);
                var statement96 = new Statement()
                {
                    Production = 0,
                    Consommation = 0.5,
                    OverProduction = 0,
                    Date = new DateTime(2017, 06, 16, 02, 33, 11)
                };
                equipment2.AddStatement(statement96);
                var statement54 = new Statement()
                {
                    Production = 0,
                    Consommation = 0.5,
                    OverProduction = 0,
                    Date = new DateTime(2017, 06, 16, 02, 59, 35)
                };
                equipment2.AddStatement(statement54);
                var statement55 = new Statement()
                {
                    Production = 0,
                    Consommation = 0.5,
                    OverProduction = 0,
                    Date = new DateTime(2017, 06, 16, 03, 25, 21)
                };
                equipment2.AddStatement(statement55);
                var statement56 = new Statement()
                {
                    Production = 0,
                    Consommation = 0.5,
                    OverProduction = 0,
                    Date = new DateTime(2017, 06, 16, 03, 58, 31)
                };
                equipment2.AddStatement(statement56);
                var statement57 = new Statement()
                {
                    Production = 0,
                    Consommation = 0.5,
                    OverProduction = 0,
                    Date = new DateTime(2017, 06, 16, 04, 32, 23)
                };
                equipment2.AddStatement(statement57);
                var statement58 = new Statement()
                {
                    Production = 0,
                    Consommation = 0.5,
                    OverProduction = 0,
                    Date = new DateTime(2017, 06, 16, 04, 51, 57)
                };
                equipment2.AddStatement(statement58);
                var statement59 = new Statement()
                {
                    Production = 0,
                    Consommation = 0.5,
                    OverProduction = 0,
                    Date = new DateTime(2017, 06, 16, 05, 38, 12)
                };
                equipment2.AddStatement(statement59);
                var statement60 = new Statement()
                {
                    Production = 0 + GetRandomNumber(0, 0.0001),
                    Consommation = 0.5,
                    OverProduction = 0,
                    Date = new DateTime(2017, 06, 16, 05, 58, 01)
                };
                equipment2.AddStatement(statement60);
                var statement61 = new Statement()
                {
                    Production = 0 + GetRandomNumber(0, 0.0005),
                    Consommation = 0.5,
                    OverProduction = 0,
                    Date = new DateTime(2017, 06, 16, 06, 27, 21)
                };
                equipment2.AddStatement(statement61);
                var statement62 = new Statement()
                {
                    Production = 0 + GetRandomNumber(0, 0.01),
                    Consommation = 1.5,
                    OverProduction = 0,
                    Date = new DateTime(2017, 06, 16, 07, 10, 19)
                };
                equipment2.AddStatement(statement62);
                var statement63 = new Statement()
                {
                    Production = 0.001 + GetRandomNumber(0, 0.001),
                    Consommation = 1,
                    OverProduction = 0,
                    Date = new DateTime(2017, 06, 16, 07, 31, 49)
                };
                equipment2.AddStatement(statement63);
                var statement64 = new Statement()
                {
                    Production = 0.001 + GetRandomNumber(0, 0.019),
                    Consommation = 0.5,
                    OverProduction = 0,
                    Date = new DateTime(2017, 06, 16, 08, 02, 07)
                };
                equipment2.AddStatement(statement64);
                var statement65 = new Statement()
                {
                    Production = 0.015 + GetRandomNumber(0, 0.001),
                    Consommation = 0.5,
                    OverProduction = 0,
                    Date = new DateTime(2017, 06, 16, 08, 27, 35)
                };
                equipment2.AddStatement(statement65);
                var statement66 = new Statement()
                {
                    Production = 0.010 + GetRandomNumber(0, 0.009),
                    Consommation = 0.5,
                    OverProduction = 0,
                    Date = new DateTime(2017, 06, 16, 09, 00, 00)
                };
                equipment2.AddStatement(statement66);
                var statement67 = new Statement()
                {
                    Production = 0.012 + GetRandomNumber(0, 0.012),
                    Consommation = 0.5,
                    OverProduction = 0,
                    Date = new DateTime(2017, 06, 16, 09, 27, 42)
                };
                equipment2.AddStatement(statement67);
                var statement68 = new Statement()
                {
                    Production = 0.018 + GetRandomNumber(0, 0.015),
                    Consommation = 0.5,
                    OverProduction = 0,
                    Date = new DateTime(2017, 06, 16, 09, 59, 03)
                };
                equipment2.AddStatement(statement68);
                var statement69 = new Statement()
                {
                    Production = 0.056 + GetRandomNumber(0, 0.05),
                    Consommation = 0.5,
                    OverProduction = 0,
                    Date = new DateTime(2017, 06, 16, 10, 28, 13)
                };
                equipment2.AddStatement(statement69);
                var statement70 = new Statement()
                {
                    Production = 0.084 + GetRandomNumber(0, 0.06),
                    Consommation = 0.5,
                    OverProduction = 0,
                    Date = new DateTime(2017, 06, 16, 10, 59, 59)
                };
                equipment2.AddStatement(statement70);
                var statement71 = new Statement()
                {
                    Production = 0.06 + GetRandomNumber(0, 0.06),
                    Consommation = 0.5,
                    OverProduction = 0,
                    Date = new DateTime(2017, 06, 16, 11, 34, 15)
                };
                equipment2.AddStatement(statement71);
                var statement72 = new Statement()
                {
                    Production = 0.08 + GetRandomNumber(0, 0.05),
                    Consommation = 0.5,
                    OverProduction = 0,
                    Date = new DateTime(2017, 06, 16, 11, 58, 39)
                };
                equipment2.AddStatement(statement72);
                var statement73 = new Statement()
                {
                    Production = 0.08 + GetRandomNumber(0, 0.08),
                    Consommation = 0.5,
                    OverProduction = 0,
                    Date = new DateTime(2017, 06, 16, 12, 32, 57)
                };
                equipment2.AddStatement(statement73);
                var statement74 = new Statement()
                {
                    Production = 0.08 + GetRandomNumber(0, 0.08),
                    Consommation = 0.5,
                    OverProduction = 0,
                    Date = new DateTime(2017, 06, 16, 12, 52, 49)
                };
                equipment2.AddStatement(statement74);
                var statement75 = new Statement()
                {
                    Production = 0.10 + GetRandomNumber(0, 0.10),
                    Consommation = 0.5,
                    OverProduction = 0,
                    Date = new DateTime(2017, 06, 16, 13, 24, 33)
                };
                equipment2.AddStatement(statement75);
                var statement76 = new Statement()
                {
                    Production = 0.14 + GetRandomNumber(0, 0.10),
                    Consommation = 0.5,
                    OverProduction = 0.2,
                    Date = new DateTime(2017, 06, 16, 13, 51, 47)
                };
                equipment2.AddStatement(statement76);
                var statement77 = new Statement()
                {
                    Production = 0.14 + GetRandomNumber(0, 0.12),
                    Consommation = 0.5,
                    OverProduction = 0.2,
                    Date = new DateTime(2017, 06, 16, 14, 21, 12)
                };
                equipment2.AddStatement(statement77);
                var statement78 = new Statement()
                {
                    Production = 0.16 + GetRandomNumber(0, 0.16),
                    Consommation = 0.5,
                    OverProduction = 0.3,
                    Date = new DateTime(2017, 06, 16, 14, 59, 47)
                };
                equipment2.AddStatement(statement78);
                var statement79 = new Statement()
                {
                    Production = 0.250 + GetRandomNumber(0, 0.15),
                    Consommation = 0.5,
                    OverProduction = 0.75,
                    Date = new DateTime(2017, 06, 16, 15, 29, 53)
                };
                equipment2.AddStatement(statement79);
                var statement80 = new Statement()
                {
                    Production = 0.250 + GetRandomNumber(0, 0.15),
                    Consommation = 0.5,
                    OverProduction = 0.75,
                    Date = new DateTime(2017, 06, 16, 15, 57, 38)
                };
                equipment2.AddStatement(statement80);
                var statement81 = new Statement()
                {
                    Production = 0.240 + GetRandomNumber(0, 0.15),
                    Consommation = 0.5,
                    OverProduction = 0.7,
                    Date = new DateTime(2017, 06, 16, 16, 33, 12)
                };
                equipment2.AddStatement(statement81);
                var statement82 = new Statement()
                {
                    Production = 0.220 + GetRandomNumber(0, 0.16),
                    Consommation = 0.5,
                    OverProduction = 0.6,
                    Date = new DateTime(2017, 06, 16, 16, 59, 01)
                };
                equipment2.AddStatement(statement82);
                var statement83 = new Statement()
                {
                    Production = 0.220 + GetRandomNumber(0, 0.16),
                    Consommation = 0.5,
                    OverProduction = 0.6,
                    Date = new DateTime(2017, 06, 16, 17, 23, 07)
                };
                equipment2.AddStatement(statement83);
                var statement84 = new Statement()
                {
                    Production = 0.18 + GetRandomNumber(0, 0.08),
                    Consommation = 0.5,
                    OverProduction = 0.4,
                    Date = new DateTime(2017, 06, 16, 17, 57, 31)
                };
                equipment2.AddStatement(statement84);
                var statement85 = new Statement()
                {
                    Production = 0.14 + GetRandomNumber(0, 0.05),
                    Consommation = 1,
                    OverProduction = 0,
                    Date = new DateTime(2017, 06, 16, 18, 37, 46)
                };
                equipment2.AddStatement(statement85);
                var statement86 = new Statement()
                {
                    Production = 0.12 + GetRandomNumber(0, 0.09),
                    Consommation = 1,
                    OverProduction = 0,
                    Date = new DateTime(2017, 06, 16, 18, 51, 12)
                };
                equipment2.AddStatement(statement86);
                var statement87 = new Statement()
                {
                    Production = 0.10 + GetRandomNumber(0, 0.06),
                    Consommation = 2,
                    OverProduction = 0,
                    Date = new DateTime(2017, 06, 16, 19, 21, 56)
                };
                equipment2.AddStatement(statement87);
                var statement88 = new Statement()
                {
                    Production = 0.08 + GetRandomNumber(0, 0.06),
                    Consommation = 2.5,
                    OverProduction = 0,
                    Date = new DateTime(2017, 06, 16, 19, 51, 13)
                };
                equipment2.AddStatement(statement88);
                var statement89 = new Statement()
                {
                    Production = 0.04 + GetRandomNumber(0, 0.015),
                    Consommation = 2.5,
                    OverProduction = 0,
                    Date = new DateTime(2017, 06, 16, 20, 30, 01)
                };
                equipment2.AddStatement(statement89);
                var statement90 = new Statement()
                {
                    Production = 0.04 + GetRandomNumber(0, 0.015),
                    Consommation = 3,
                    OverProduction = 0,
                    Date = new DateTime(2017, 06, 16, 20, 55, 57)
                };
                equipment2.AddStatement(statement90);
                var statement91 = new Statement()
                {
                    Production = 0.04 + GetRandomNumber(0, 0.02),
                    Consommation = 2,
                    OverProduction = 0,
                    Date = new DateTime(2017, 06, 16, 21, 30, 00)
                };
                equipment2.AddStatement(statement91);
                var statement92 = new Statement()
                {
                    Production = 0.04 + GetRandomNumber(0, 0.01),
                    Consommation = 1.5,
                    OverProduction = 0,
                    Date = new DateTime(2017, 06, 16, 22, 07, 00)
                };
                equipment2.AddStatement(statement92);
                var statement93 = new Statement()
                {
                    Production = 0.024 + GetRandomNumber(0, 0.019),
                    Consommation = 1,
                    OverProduction = 0,
                    Date = new DateTime(2017, 06, 16, 22, 29, 57)
                };
                equipment2.AddStatement(statement93);
                var statement94 = new Statement()
                {
                    Production = 0.016 + GetRandomNumber(0, 0.01),
                    Consommation = 0.5,
                    OverProduction = 0,
                    Date = new DateTime(2017, 06, 16, 23, 01, 06)
                };
                equipment2.AddStatement(statement94);
                var statement95 = new Statement()
                {
                    Production = 0 + GetRandomNumber(0, 0.0001),
                    Consommation = 0.5,
                    OverProduction = 0,
                    Date = new DateTime(2017, 06, 16, 23, 35, 09)
                };
                equipment2.AddStatement(statement95);
                _statementRepository.UpdateRange(statement49, statement50, statement51, statement52, statement53,
                    statement54,
                    statement55, statement56, statement57, statement58, statement59, statement60, statement61, statement62,
                    statement63, statement64, statement65, statement66, statement67, statement68, statement69, statement70,
                    statement71, statement72, statement73, statement74, statement75, statement76, statement77, statement78,
                    statement79, statement80, statement81, statement82, statement83, statement84, statement85, statement86,
                    statement87, statement88, statement89, statement90, statement91, statement92, statement93, statement94,
                    statement95, statement96);

                #endregion

                #region statements equipment3

                var statement97 = new Statement()
                {
                    Production = 0,
                    Consommation = 0.5,
                    OverProduction = 0,
                    Date = new DateTime(2017, 06, 16, 00, 01, 12)
                };
                equipment3.AddStatement(statement97);
                var statement98 = new Statement()
                {
                    Production = 0,
                    Consommation = 0.5,
                    OverProduction = 0,
                    Date = new DateTime(2017, 06, 16, 00, 33, 22)
                };
                equipment3.AddStatement(statement98);
                var statement99 = new Statement()
                {
                    Production = 0,
                    Consommation = 0.5,
                    OverProduction = 0,
                    Date = new DateTime(2017, 06, 16, 01, 02, 06)
                };
                equipment3.AddStatement(statement99);
                var statement100 = new Statement()
                {
                    Production = 0,
                    Consommation = 0.5,
                    OverProduction = 0,
                    Date = new DateTime(2017, 06, 16, 01, 32, 01)
                };
                equipment3.AddStatement(statement100);
                var statement101 = new Statement()
                {
                    Production = 0,
                    Consommation = 0.5,
                    OverProduction = 0,
                    Date = new DateTime(2017, 06, 16, 02, 02, 05)
                };
                equipment3.AddStatement(statement101);
                var statement144 = new Statement()
                {
                    Production = 0,
                    Consommation = 0.5,
                    OverProduction = 0,
                    Date = new DateTime(2017, 06, 16, 02, 33, 11)
                };
                equipment3.AddStatement(statement144);
                var statement102 = new Statement()
                {
                    Production = 0,
                    Consommation = 0.5,
                    OverProduction = 0,
                    Date = new DateTime(2017, 06, 16, 02, 59, 35)
                };
                equipment3.AddStatement(statement102);
                var statement103 = new Statement()
                {
                    Production = 0,
                    Consommation = 0.5,
                    OverProduction = 0,
                    Date = new DateTime(2017, 06, 16, 03, 25, 21)
                };
                equipment3.AddStatement(statement103);
                var statement104 = new Statement()
                {
                    Production = 0,
                    Consommation = 0.5,
                    OverProduction = 0,
                    Date = new DateTime(2017, 06, 16, 03, 58, 31)
                };
                equipment3.AddStatement(statement104);
                var statement105 = new Statement()
                {
                    Production = 0,
                    Consommation = 0.5,
                    OverProduction = 0,
                    Date = new DateTime(2017, 06, 16, 04, 32, 23)
                };
                equipment3.AddStatement(statement105);
                var statement106 = new Statement()
                {
                    Production = 0,
                    Consommation = 0.5,
                    OverProduction = 0,
                    Date = new DateTime(2017, 06, 16, 04, 51, 57)
                };
                equipment3.AddStatement(statement106);
                var statement107 = new Statement()
                {
                    Production = 0,
                    Consommation = 0.5,
                    OverProduction = 0,
                    Date = new DateTime(2017, 06, 16, 05, 38, 12)
                };
                equipment3.AddStatement(statement107);
                var statement108 = new Statement()
                {
                    Production = 0 + GetRandomNumber(0, 0.0001),
                    Consommation = 0.5,
                    OverProduction = 0,
                    Date = new DateTime(2017, 06, 16, 05, 58, 01)
                };
                equipment3.AddStatement(statement108);
                var statement109 = new Statement()
                {
                    Production = 0 + GetRandomNumber(0, 0.0005),
                    Consommation = 0.5,
                    OverProduction = 0,
                    Date = new DateTime(2017, 06, 16, 06, 27, 21)
                };
                equipment3.AddStatement(statement109);
                var statement110 = new Statement()
                {
                    Production = 0 + GetRandomNumber(0, 0.01),
                    Consommation = 1.5,
                    OverProduction = 0,
                    Date = new DateTime(2017, 06, 16, 07, 10, 19)
                };
                equipment3.AddStatement(statement110);
                var statement111 = new Statement()
                {
                    Production = 0.001 + GetRandomNumber(0, 0.001),
                    Consommation = 1,
                    OverProduction = 0,
                    Date = new DateTime(2017, 06, 16, 07, 31, 49)
                };
                equipment3.AddStatement(statement111);
                var statement112 = new Statement()
                {
                    Production = 0.001 + GetRandomNumber(0, 0.019),
                    Consommation = 0.5,
                    OverProduction = 0,
                    Date = new DateTime(2017, 06, 16, 08, 02, 07)
                };
                equipment3.AddStatement(statement112);
                var statement113 = new Statement()
                {
                    Production = 0.015 + GetRandomNumber(0, 0.001),
                    Consommation = 0.5,
                    OverProduction = 0,
                    Date = new DateTime(2017, 06, 16, 08, 27, 35)
                };
                equipment3.AddStatement(statement113);
                var statement114 = new Statement()
                {
                    Production = 0.010 + GetRandomNumber(0, 0.009),
                    Consommation = 0.5,
                    OverProduction = 0,
                    Date = new DateTime(2017, 06, 16, 09, 00, 00)
                };
                equipment3.AddStatement(statement114);
                var statement115 = new Statement()
                {
                    Production = 0.012 + GetRandomNumber(0, 0.012),
                    Consommation = 0.5,
                    OverProduction = 0,
                    Date = new DateTime(2017, 06, 16, 09, 27, 42)
                };
                equipment3.AddStatement(statement115);
                var statement116 = new Statement()
                {
                    Production = 0.018 + GetRandomNumber(0, 0.015),
                    Consommation = 0.5,
                    OverProduction = 0,
                    Date = new DateTime(2017, 06, 16, 09, 59, 03)
                };
                equipment3.AddStatement(statement116);
                var statement117 = new Statement()
                {
                    Production = 0.056 + GetRandomNumber(0, 0.05),
                    Consommation = 0.5,
                    OverProduction = 0,
                    Date = new DateTime(2017, 06, 16, 10, 28, 13)
                };
                equipment3.AddStatement(statement117);
                var statement118 = new Statement()
                {
                    Production = 0.084 + GetRandomNumber(0, 0.06),
                    Consommation = 0.5,
                    OverProduction = 0,
                    Date = new DateTime(2017, 06, 16, 10, 59, 59)
                };
                equipment3.AddStatement(statement118);
                var statement119 = new Statement()
                {
                    Production = 0.06 + GetRandomNumber(0, 0.06),
                    Consommation = 0.5,
                    OverProduction = 0,
                    Date = new DateTime(2017, 06, 16, 11, 34, 15)
                };
                equipment3.AddStatement(statement119);
                var statement120 = new Statement()
                {
                    Production = 0.08 + GetRandomNumber(0, 0.05),
                    Consommation = 0.5,
                    OverProduction = 0,
                    Date = new DateTime(2017, 06, 16, 11, 58, 39)
                };
                equipment3.AddStatement(statement120);
                var statement121 = new Statement()
                {
                    Production = 0.08 + GetRandomNumber(0, 0.08),
                    Consommation = 0.5,
                    OverProduction = 0,
                    Date = new DateTime(2017, 06, 16, 12, 32, 57)
                };
                equipment3.AddStatement(statement121);
                var statement122 = new Statement()
                {
                    Production = 0.08 + GetRandomNumber(0, 0.08),
                    Consommation = 0.5,
                    OverProduction = 0,
                    Date = new DateTime(2017, 06, 16, 12, 52, 49)
                };
                equipment3.AddStatement(statement122);
                var statement123 = new Statement()
                {
                    Production = 0.10 + GetRandomNumber(0, 0.10),
                    Consommation = 0.5,
                    OverProduction = 0,
                    Date = new DateTime(2017, 06, 16, 13, 24, 33)
                };
                equipment3.AddStatement(statement123);
                var statement124 = new Statement()
                {
                    Production = 0.14 + GetRandomNumber(0, 0.10),
                    Consommation = 0.5,
                    OverProduction = 0.2,
                    Date = new DateTime(2017, 06, 16, 13, 51, 47)
                };
                equipment3.AddStatement(statement124);
                var statement125 = new Statement()
                {
                    Production = 0.14 + GetRandomNumber(0, 0.12),
                    Consommation = 0.5,
                    OverProduction = 0.2,
                    Date = new DateTime(2017, 06, 16, 14, 21, 12)
                };
                equipment3.AddStatement(statement125);
                var statement126 = new Statement()
                {
                    Production = 0.16 + GetRandomNumber(0, 0.16),
                    Consommation = 0.5,
                    OverProduction = 0.3,
                    Date = new DateTime(2017, 06, 16, 14, 59, 47)
                };
                equipment3.AddStatement(statement126);
                var statement127 = new Statement()
                {
                    Production = 0.250 + GetRandomNumber(0, 0.15),
                    Consommation = 0.5,
                    OverProduction = 0.75,
                    Date = new DateTime(2017, 06, 16, 15, 29, 53)
                };
                equipment3.AddStatement(statement127);
                var statement128 = new Statement()
                {
                    Production = 0.250 + GetRandomNumber(0, 0.15),
                    Consommation = 0.5,
                    OverProduction = 0.75,
                    Date = new DateTime(2017, 06, 16, 15, 57, 38)
                };
                equipment3.AddStatement(statement128);
                var statement129 = new Statement()
                {
                    Production = 0.240 + GetRandomNumber(0, 0.15),
                    Consommation = 0.5,
                    OverProduction = 0.7,
                    Date = new DateTime(2017, 06, 16, 16, 33, 12)
                };
                equipment3.AddStatement(statement129);
                var statement130 = new Statement()
                {
                    Production = 0.220 + GetRandomNumber(0, 0.16),
                    Consommation = 0.5,
                    OverProduction = 0.6,
                    Date = new DateTime(2017, 06, 16, 16, 59, 01)
                };
                equipment3.AddStatement(statement130);
                var statement131 = new Statement()
                {
                    Production = 0.220 + GetRandomNumber(0, 0.16),
                    Consommation = 0.5,
                    OverProduction = 0.6,
                    Date = new DateTime(2017, 06, 16, 17, 23, 07)
                };
                equipment3.AddStatement(statement131);
                var statement132 = new Statement()
                {
                    Production = 0.18 + GetRandomNumber(0, 0.08),
                    Consommation = 0.5,
                    OverProduction = 0.4,
                    Date = new DateTime(2017, 06, 16, 17, 57, 31)
                };
                equipment3.AddStatement(statement132);
                var statement133 = new Statement()
                {
                    Production = 0.14 + GetRandomNumber(0, 0.05),
                    Consommation = 1,
                    OverProduction = 0,
                    Date = new DateTime(2017, 06, 16, 18, 37, 46)
                };
                equipment3.AddStatement(statement133);
                var statement134 = new Statement()
                {
                    Production = 0.12 + GetRandomNumber(0, 0.09),
                    Consommation = 1,
                    OverProduction = 0,
                    Date = new DateTime(2017, 06, 16, 18, 51, 12)
                };
                equipment3.AddStatement(statement134);
                var statement135 = new Statement()
                {
                    Production = 0.10 + GetRandomNumber(0, 0.06),
                    Consommation = 2,
                    OverProduction = 0,
                    Date = new DateTime(2017, 06, 16, 19, 21, 56)
                };
                equipment3.AddStatement(statement135);
                var statement136 = new Statement()
                {
                    Production = 0.08 + GetRandomNumber(0, 0.06),
                    Consommation = 2.5,
                    OverProduction = 0,
                    Date = new DateTime(2017, 06, 16, 19, 51, 13)
                };
                equipment3.AddStatement(statement136);
                var statement137 = new Statement()
                {
                    Production = 0.04 + GetRandomNumber(0, 0.015),
                    Consommation = 2.5,
                    OverProduction = 0,
                    Date = new DateTime(2017, 06, 16, 20, 30, 01)
                };
                equipment3.AddStatement(statement137);
                var statement138 = new Statement()
                {
                    Production = 0.04 + GetRandomNumber(0, 0.015),
                    Consommation = 3,
                    OverProduction = 0,
                    Date = new DateTime(2017, 06, 16, 20, 55, 57)
                };
                equipment3.AddStatement(statement138);
                var statement139 = new Statement()
                {
                    Production = 0.04 + GetRandomNumber(0, 0.02),
                    Consommation = 2,
                    OverProduction = 0,
                    Date = new DateTime(2017, 06, 16, 21, 30, 00)
                };
                equipment3.AddStatement(statement139);
                var statement140 = new Statement()
                {
                    Production = 0.04 + GetRandomNumber(0, 0.01),
                    Consommation = 1.5,
                    OverProduction = 0,
                    Date = new DateTime(2017, 06, 16, 22, 07, 00)
                };
                equipment3.AddStatement(statement140);
                var statement141 = new Statement()
                {
                    Production = 0.024 + GetRandomNumber(0, 0.019),
                    Consommation = 1,
                    OverProduction = 0,
                    Date = new DateTime(2017, 06, 16, 22, 29, 57)
                };
                equipment3.AddStatement(statement141);
                var statement142 = new Statement()
                {
                    Production = 0.016 + GetRandomNumber(0, 0.01),
                    Consommation = 0.5,
                    OverProduction = 0,
                    Date = new DateTime(2017, 06, 16, 23, 01, 06)
                };
                equipment3.AddStatement(statement142);
                var statement143 = new Statement()
                {
                    Production = 0 + GetRandomNumber(0, 0.0001),
                    Consommation = 0.5,
                    OverProduction = 0,
                    Date = new DateTime(2017, 06, 16, 23, 35, 09)
                };
                equipment3.AddStatement(statement143);
                _statementRepository.UpdateRange(statement97, statement98, statement99, statement100, statement101,
                    statement102,
                    statement103, statement104, statement105, statement106, statement107, statement108, statement109,
                    statement110,
                    statement111, statement112, statement113, statement114, statement115, statement116, statement117,
                    statement118,
                    statement119, statement120, statement121, statement122, statement123, statement124, statement125,
                    statement126,
                    statement127, statement128, statement129, statement130, statement131, statement132, statement133,
                    statement134,
                    statement135, statement136, statement137, statement138, statement139, statement140, statement141,
                    statement142,
                    statement143, statement144);

                #endregion

                #region statements equipment4

                var statement145 = new Statement()
                {
                    Production = 0,
                    Consommation = 0.5,
                    OverProduction = 0,
                    Date = new DateTime(2017, 06, 16, 00, 01, 12)
                };
                equipment4.AddStatement(statement145);
                var statement146 = new Statement()
                {
                    Production = 0,
                    Consommation = 0.5,
                    OverProduction = 0,
                    Date = new DateTime(2017, 06, 16, 00, 33, 22)
                };
                equipment4.AddStatement(statement146);
                var statement147 = new Statement()
                {
                    Production = 0,
                    Consommation = 0.5,
                    OverProduction = 0,
                    Date = new DateTime(2017, 06, 16, 01, 02, 06)
                };
                equipment4.AddStatement(statement147);
                var statement148 = new Statement()
                {
                    Production = 0,
                    Consommation = 0.5,
                    OverProduction = 0,
                    Date = new DateTime(2017, 06, 16, 01, 32, 01)
                };
                equipment4.AddStatement(statement148);
                var statement149 = new Statement()
                {
                    Production = 0,
                    Consommation = 0.5,
                    OverProduction = 0,
                    Date = new DateTime(2017, 06, 16, 02, 02, 05)
                };
                equipment4.AddStatement(statement149);
                var statement192 = new Statement()
                {
                    Production = 0,
                    Consommation = 0.5,
                    OverProduction = 0,
                    Date = new DateTime(2017, 06, 16, 02, 33, 11)
                };
                equipment4.AddStatement(statement192);
                var statement150 = new Statement()
                {
                    Production = 0,
                    Consommation = 0.5,
                    OverProduction = 0,
                    Date = new DateTime(2017, 06, 16, 02, 59, 35)
                };
                equipment4.AddStatement(statement150);
                var statement151 = new Statement()
                {
                    Production = 0,
                    Consommation = 0.5,
                    OverProduction = 0,
                    Date = new DateTime(2017, 06, 16, 03, 25, 21)
                };
                equipment4.AddStatement(statement151);
                var statement152 = new Statement()
                {
                    Production = 0,
                    Consommation = 0.5,
                    OverProduction = 0,
                    Date = new DateTime(2017, 06, 16, 03, 58, 31)
                };
                equipment4.AddStatement(statement152);
                var statement153 = new Statement()
                {
                    Production = 0,
                    Consommation = 0.5,
                    OverProduction = 0,
                    Date = new DateTime(2017, 06, 16, 04, 32, 23)
                };
                equipment4.AddStatement(statement153);
                var statement154 = new Statement()
                {
                    Production = 0,
                    Consommation = 0.5,
                    OverProduction = 0,
                    Date = new DateTime(2017, 06, 16, 04, 51, 57)
                };
                equipment4.AddStatement(statement154);
                var statement155 = new Statement()
                {
                    Production = 0,
                    Consommation = 0.5,
                    OverProduction = 0,
                    Date = new DateTime(2017, 06, 16, 05, 38, 12)
                };
                equipment4.AddStatement(statement155);
                var statement156 = new Statement()
                {
                    Production = 0 + GetRandomNumber(0, 0.0001),
                    Consommation = 0.5,
                    OverProduction = 0,
                    Date = new DateTime(2017, 06, 16, 05, 58, 01)
                };
                equipment4.AddStatement(statement156);
                var statement157 = new Statement()
                {
                    Production = 0 + GetRandomNumber(0, 0.0005),
                    Consommation = 0.5,
                    OverProduction = 0,
                    Date = new DateTime(2017, 06, 16, 06, 27, 21)
                };
                equipment4.AddStatement(statement157);
                var statement158 = new Statement()
                {
                    Production = 0 + GetRandomNumber(0, 0.01),
                    Consommation = 1.5,
                    OverProduction = 0,
                    Date = new DateTime(2017, 06, 16, 07, 10, 19)
                };
                equipment4.AddStatement(statement158);
                var statement159 = new Statement()
                {
                    Production = 0.001 + GetRandomNumber(0, 0.001),
                    Consommation = 1,
                    OverProduction = 0,
                    Date = new DateTime(2017, 06, 16, 07, 31, 49)
                };
                equipment4.AddStatement(statement159);
                var statement160 = new Statement()
                {
                    Production = 0.001 + GetRandomNumber(0, 0.019),
                    Consommation = 0.5,
                    OverProduction = 0,
                    Date = new DateTime(2017, 06, 16, 08, 02, 07)
                };
                equipment4.AddStatement(statement160);
                var statement161 = new Statement()
                {
                    Production = 0.015 + GetRandomNumber(0, 0.001),
                    Consommation = 0.5,
                    OverProduction = 0,
                    Date = new DateTime(2017, 06, 16, 08, 27, 35)
                };
                equipment4.AddStatement(statement161);
                var statement162 = new Statement()
                {
                    Production = 0.010 + GetRandomNumber(0, 0.009),
                    Consommation = 0.5,
                    OverProduction = 0,
                    Date = new DateTime(2017, 06, 16, 09, 00, 00)
                };
                equipment4.AddStatement(statement162);
                var statement163 = new Statement()
                {
                    Production = 0.012 + GetRandomNumber(0, 0.012),
                    Consommation = 0.5,
                    OverProduction = 0,
                    Date = new DateTime(2017, 06, 16, 09, 27, 42)
                };
                equipment4.AddStatement(statement163);
                var statement164 = new Statement()
                {
                    Production = 0.018 + GetRandomNumber(0, 0.015),
                    Consommation = 0.5,
                    OverProduction = 0,
                    Date = new DateTime(2017, 06, 16, 09, 59, 03)
                };
                equipment4.AddStatement(statement164);
                var statement165 = new Statement()
                {
                    Production = 0.056 + GetRandomNumber(0, 0.05),
                    Consommation = 0.5,
                    OverProduction = 0,
                    Date = new DateTime(2017, 06, 16, 10, 28, 13)
                };
                equipment4.AddStatement(statement165);
                var statement166 = new Statement()
                {
                    Production = 0.084 + GetRandomNumber(0, 0.06),
                    Consommation = 0.5,
                    OverProduction = 0,
                    Date = new DateTime(2017, 06, 16, 10, 59, 59)
                };
                equipment4.AddStatement(statement166);
                var statement167 = new Statement()
                {
                    Production = 0.06 + GetRandomNumber(0, 0.06),
                    Consommation = 0.5,
                    OverProduction = 0,
                    Date = new DateTime(2017, 06, 16, 11, 34, 15)
                };
                equipment4.AddStatement(statement167);
                var statement168 = new Statement()
                {
                    Production = 0.08 + GetRandomNumber(0, 0.05),
                    Consommation = 0.5,
                    OverProduction = 0,
                    Date = new DateTime(2017, 06, 16, 11, 58, 39)
                };
                equipment4.AddStatement(statement168);
                var statement169 = new Statement()
                {
                    Production = 0.08 + GetRandomNumber(0, 0.08),
                    Consommation = 0.5,
                    OverProduction = 0,
                    Date = new DateTime(2017, 06, 16, 12, 32, 57)
                };
                equipment4.AddStatement(statement169);
                var statement170 = new Statement()
                {
                    Production = 0.08 + GetRandomNumber(0, 0.08),
                    Consommation = 0.5,
                    OverProduction = 0,
                    Date = new DateTime(2017, 06, 16, 12, 52, 49)
                };
                equipment4.AddStatement(statement170);
                var statement171 = new Statement()
                {
                    Production = 0.10 + GetRandomNumber(0, 0.10),
                    Consommation = 0.5,
                    OverProduction = 0,
                    Date = new DateTime(2017, 06, 16, 13, 24, 33)
                };
                equipment4.AddStatement(statement171);
                var statement172 = new Statement()
                {
                    Production = 0.14 + GetRandomNumber(0, 0.10),
                    Consommation = 0.5,
                    OverProduction = 0.2,
                    Date = new DateTime(2017, 06, 16, 13, 51, 47)
                };
                equipment4.AddStatement(statement172);
                var statement173 = new Statement()
                {
                    Production = 0.14 + GetRandomNumber(0, 0.12),
                    Consommation = 0.5,
                    OverProduction = 0.2,
                    Date = new DateTime(2017, 06, 16, 14, 21, 12)
                };
                equipment4.AddStatement(statement173);
                var statement174 = new Statement()
                {
                    Production = 0.16 + GetRandomNumber(0, 0.16),
                    Consommation = 0.5,
                    OverProduction = 0.3,
                    Date = new DateTime(2017, 06, 16, 14, 59, 47)
                };
                equipment4.AddStatement(statement174);
                var statement175 = new Statement()
                {
                    Production = 0.250 + GetRandomNumber(0, 0.15),
                    Consommation = 0.5,
                    OverProduction = 0.75,
                    Date = new DateTime(2017, 06, 16, 15, 29, 53)
                };
                equipment4.AddStatement(statement175);
                var statement176 = new Statement()
                {
                    Production = 0.250 + GetRandomNumber(0, 0.15),
                    Consommation = 0.5,
                    OverProduction = 0.75,
                    Date = new DateTime(2017, 06, 16, 15, 57, 38)
                };
                equipment4.AddStatement(statement176);
                var statement177 = new Statement()
                {
                    Production = 0.240 + GetRandomNumber(0, 0.15),
                    Consommation = 0.5,
                    OverProduction = 0.7,
                    Date = new DateTime(2017, 06, 16, 16, 33, 12)
                };
                equipment4.AddStatement(statement177);
                var statement178 = new Statement()
                {
                    Production = 0.220 + GetRandomNumber(0, 0.16),
                    Consommation = 0.5,
                    OverProduction = 0.6,
                    Date = new DateTime(2017, 06, 16, 16, 59, 01)
                };
                equipment4.AddStatement(statement178);
                var statement179 = new Statement()
                {
                    Production = 0.220 + GetRandomNumber(0, 0.16),
                    Consommation = 0.5,
                    OverProduction = 0.6,
                    Date = new DateTime(2017, 06, 16, 17, 23, 07)
                };
                equipment4.AddStatement(statement179);
                var statement180 = new Statement()
                {
                    Production = 0.18 + GetRandomNumber(0, 0.08),
                    Consommation = 0.5,
                    OverProduction = 0.4,
                    Date = new DateTime(2017, 06, 16, 17, 57, 31)
                };
                equipment4.AddStatement(statement180);
                var statement181 = new Statement()
                {
                    Production = 0.14 + GetRandomNumber(0, 0.05),
                    Consommation = 1,
                    OverProduction = 0,
                    Date = new DateTime(2017, 06, 16, 18, 37, 46)
                };
                equipment4.AddStatement(statement181);
                var statement182 = new Statement()
                {
                    Production = 0.12 + GetRandomNumber(0, 0.09),
                    Consommation = 1,
                    OverProduction = 0,
                    Date = new DateTime(2017, 06, 16, 18, 51, 12)
                };
                equipment4.AddStatement(statement182);
                var statement183 = new Statement()
                {
                    Production = 0.10 + GetRandomNumber(0, 0.06),
                    Consommation = 2,
                    OverProduction = 0,
                    Date = new DateTime(2017, 06, 16, 19, 21, 56)
                };
                equipment4.AddStatement(statement183);
                var statement184 = new Statement()
                {
                    Production = 0.08 + GetRandomNumber(0, 0.06),
                    Consommation = 2.5,
                    OverProduction = 0,
                    Date = new DateTime(2017, 06, 16, 19, 51, 13)
                };
                equipment4.AddStatement(statement184);
                var statement185 = new Statement()
                {
                    Production = 0.04 + GetRandomNumber(0, 0.015),
                    Consommation = 2.5,
                    OverProduction = 0,
                    Date = new DateTime(2017, 06, 16, 20, 30, 01)
                };
                equipment4.AddStatement(statement185);
                var statement186 = new Statement()
                {
                    Production = 0.04 + GetRandomNumber(0, 0.015),
                    Consommation = 3,
                    OverProduction = 0,
                    Date = new DateTime(2017, 06, 16, 20, 55, 57)
                };
                equipment4.AddStatement(statement186);
                var statement187 = new Statement()
                {
                    Production = 0.04 + GetRandomNumber(0, 0.02),
                    Consommation = 2,
                    OverProduction = 0,
                    Date = new DateTime(2017, 06, 16, 21, 30, 00)
                };
                equipment4.AddStatement(statement187);
                var statement188 = new Statement()
                {
                    Production = 0.04 + GetRandomNumber(0, 0.01),
                    Consommation = 1.5,
                    OverProduction = 0,
                    Date = new DateTime(2017, 06, 16, 22, 07, 00)
                };
                equipment4.AddStatement(statement188);
                var statement189 = new Statement()
                {
                    Production = 0.024 + GetRandomNumber(0, 0.019),
                    Consommation = 1,
                    OverProduction = 0,
                    Date = new DateTime(2017, 06, 16, 22, 29, 57)
                };
                equipment4.AddStatement(statement189);
                var statement190 = new Statement()
                {
                    Production = 0.016 + GetRandomNumber(0, 0.01),
                    Consommation = 0.5,
                    OverProduction = 0,
                    Date = new DateTime(2017, 06, 16, 23, 01, 06)
                };
                equipment4.AddStatement(statement190);
                var statement191 = new Statement()
                {
                    Production = 0 + GetRandomNumber(0, 0.0001),
                    Consommation = 0.5,
                    OverProduction = 0,
                    Date = new DateTime(2017, 06, 16, 23, 35, 09)
                };
                equipment4.AddStatement(statement191);
                _statementRepository.UpdateRange(statement145, statement146, statement147, statement148, statement149,
                    statement150,
                    statement151, statement152, statement153, statement154, statement155, statement156, statement157,
                    statement158,
                    statement159, statement160, statement161, statement162, statement163, statement164, statement165,
                    statement166,
                    statement167, statement168, statement169, statement170, statement171, statement172, statement173,
                    statement174,
                    statement175, statement176, statement177, statement178, statement179, statement180, statement181,
                    statement182,
                    statement183, statement184, statement185, statement186, statement187, statement188, statement189,
                    statement190,
                    statement191, statement192);

                #endregion

                #region statements equipment7

                var statement289 = new Statement()
                {
                    Production = 0,
                    Consommation = 0.5,
                    OverProduction = 0,
                    Date = new DateTime(2017, 06, 16, 00, 01, 12)
                };
                equipment7.AddStatement(statement289);
                var statement290 = new Statement()
                {
                    Production = 0,
                    Consommation = 0.5,
                    OverProduction = 0,
                    Date = new DateTime(2017, 06, 16, 00, 33, 22)
                };
                equipment7.AddStatement(statement290);
                var statement291 = new Statement()
                {
                    Production = 0,
                    Consommation = 0.5,
                    OverProduction = 0,
                    Date = new DateTime(2017, 06, 16, 01, 02, 06)
                };
                equipment7.AddStatement(statement291);
                var statement292 = new Statement()
                {
                    Production = 0,
                    Consommation = 0.5,
                    OverProduction = 0,
                    Date = new DateTime(2017, 06, 16, 01, 32, 01)
                };
                equipment7.AddStatement(statement292);
                var statement293 = new Statement()
                {
                    Production = 0,
                    Consommation = 0.5,
                    OverProduction = 0,
                    Date = new DateTime(2017, 06, 16, 02, 02, 05)
                };
                equipment7.AddStatement(statement293);
                var statement336 = new Statement()
                {
                    Production = 0,
                    Consommation = 0.5,
                    OverProduction = 0,
                    Date = new DateTime(2017, 06, 16, 02, 33, 11)
                };
                equipment7.AddStatement(statement336);
                var statement294 = new Statement()
                {
                    Production = 0,
                    Consommation = 0.5,
                    OverProduction = 0,
                    Date = new DateTime(2017, 06, 16, 02, 59, 35)
                };
                equipment7.AddStatement(statement294);
                var statement295 = new Statement()
                {
                    Production = 0,
                    Consommation = 0.5,
                    OverProduction = 0,
                    Date = new DateTime(2017, 06, 16, 03, 25, 21)
                };
                equipment7.AddStatement(statement295);
                var statement296 = new Statement()
                {
                    Production = 0,
                    Consommation = 0.5,
                    OverProduction = 0,
                    Date = new DateTime(2017, 06, 16, 03, 58, 31)
                };
                equipment7.AddStatement(statement296);
                var statement297 = new Statement()
                {
                    Production = 0,
                    Consommation = 0.5,
                    OverProduction = 0,
                    Date = new DateTime(2017, 06, 16, 04, 32, 23)
                };
                equipment7.AddStatement(statement297);
                var statement298 = new Statement()
                {
                    Production = 0,
                    Consommation = 0.5,
                    OverProduction = 0,
                    Date = new DateTime(2017, 06, 16, 04, 51, 57)
                };
                equipment7.AddStatement(statement298);
                var statement299 = new Statement()
                {
                    Production = 0,
                    Consommation = 0.5,
                    OverProduction = 0,
                    Date = new DateTime(2017, 06, 16, 05, 38, 12)
                };
                equipment7.AddStatement(statement299);
                var statement300 = new Statement()
                {
                    Production = 0 + GetRandomNumber(0, 0.0001),
                    Consommation = 0.5,
                    OverProduction = 0,
                    Date = new DateTime(2017, 06, 16, 05, 58, 01)
                };
                equipment7.AddStatement(statement300);
                var statement301 = new Statement()
                {
                    Production = 0 + GetRandomNumber(0, 0.0005),
                    Consommation = 0.5,
                    OverProduction = 0,
                    Date = new DateTime(2017, 06, 16, 06, 27, 21)
                };
                equipment7.AddStatement(statement301);
                var statement302 = new Statement()
                {
                    Production = 0 + GetRandomNumber(0, 0.01),
                    Consommation = 1.5,
                    OverProduction = 0,
                    Date = new DateTime(2017, 06, 16, 07, 10, 19)
                };
                equipment7.AddStatement(statement302);
                var statement303 = new Statement()
                {
                    Production = 0.001 + GetRandomNumber(0, 0.001),
                    Consommation = 1,
                    OverProduction = 0,
                    Date = new DateTime(2017, 06, 16, 07, 31, 49)
                };
                equipment7.AddStatement(statement303);
                var statement304 = new Statement()
                {
                    Production = 0.001 + GetRandomNumber(0, 0.019),
                    Consommation = 0.5,
                    OverProduction = 0,
                    Date = new DateTime(2017, 06, 16, 08, 02, 07)
                };
                equipment7.AddStatement(statement304);
                var statement305 = new Statement()
                {
                    Production = 0.015 + GetRandomNumber(0, 0.001),
                    Consommation = 0.5,
                    OverProduction = 0,
                    Date = new DateTime(2017, 06, 16, 08, 27, 35)
                };
                equipment7.AddStatement(statement305);
                var statement306 = new Statement()
                {
                    Production = 0.010 + GetRandomNumber(0, 0.009),
                    Consommation = 0.5,
                    OverProduction = 0,
                    Date = new DateTime(2017, 06, 16, 09, 00, 00)
                };
                equipment7.AddStatement(statement306);
                var statement307 = new Statement()
                {
                    Production = 0.012 + GetRandomNumber(0, 0.012),
                    Consommation = 0.5,
                    OverProduction = 0,
                    Date = new DateTime(2017, 06, 16, 09, 27, 42)
                };
                equipment7.AddStatement(statement307);
                var statement308 = new Statement()
                {
                    Production = 0.018 + GetRandomNumber(0, 0.015),
                    Consommation = 0.5,
                    OverProduction = 0,
                    Date = new DateTime(2017, 06, 16, 09, 59, 03)
                };
                equipment7.AddStatement(statement308);
                var statement309 = new Statement()
                {
                    Production = 0.056 + GetRandomNumber(0, 0.05),
                    Consommation = 0.5,
                    OverProduction = 0,
                    Date = new DateTime(2017, 06, 16, 10, 28, 13)
                };
                equipment7.AddStatement(statement309);
                var statement310 = new Statement()
                {
                    Production = 0.084 + GetRandomNumber(0, 0.06),
                    Consommation = 0.5,
                    OverProduction = 0,
                    Date = new DateTime(2017, 06, 16, 10, 59, 59)
                };
                equipment7.AddStatement(statement310);
                var statement311 = new Statement()
                {
                    Production = 0.06 + GetRandomNumber(0, 0.06),
                    Consommation = 0.5,
                    OverProduction = 0,
                    Date = new DateTime(2017, 06, 16, 11, 34, 15)
                };
                equipment7.AddStatement(statement311);
                var statement312 = new Statement()
                {
                    Production = 0.08 + GetRandomNumber(0, 0.05),
                    Consommation = 0.5,
                    OverProduction = 0,
                    Date = new DateTime(2017, 06, 16, 11, 58, 39)
                };
                equipment7.AddStatement(statement312);
                var statement313 = new Statement()
                {
                    Production = 0.08 + GetRandomNumber(0, 0.08),
                    Consommation = 0.5,
                    OverProduction = 0,
                    Date = new DateTime(2017, 06, 16, 12, 32, 57)
                };
                equipment7.AddStatement(statement313);
                var statement314 = new Statement()
                {
                    Production = 0.08 + GetRandomNumber(0, 0.08),
                    Consommation = 0.5,
                    OverProduction = 0,
                    Date = new DateTime(2017, 06, 16, 12, 52, 49)
                };
                equipment7.AddStatement(statement314);
                var statement315 = new Statement()
                {
                    Production = 0.10 + GetRandomNumber(0, 0.10),
                    Consommation = 0.5,
                    OverProduction = 0,
                    Date = new DateTime(2017, 06, 16, 13, 24, 33)
                };
                equipment7.AddStatement(statement315);
                var statement316 = new Statement()
                {
                    Production = 0.14 + GetRandomNumber(0, 0.10),
                    Consommation = 0.5,
                    OverProduction = 0.2,
                    Date = new DateTime(2017, 06, 16, 13, 51, 47)
                };
                equipment7.AddStatement(statement316);
                var statement317 = new Statement()
                {
                    Production = 0.14 + GetRandomNumber(0, 0.12),
                    Consommation = 0.5,
                    OverProduction = 0.2,
                    Date = new DateTime(2017, 06, 16, 14, 21, 12)
                };
                equipment7.AddStatement(statement317);
                var statement318 = new Statement()
                {
                    Production = 0.16 + GetRandomNumber(0, 0.16),
                    Consommation = 0.5,
                    OverProduction = 0.3,
                    Date = new DateTime(2017, 06, 16, 14, 59, 47)
                };
                equipment7.AddStatement(statement318);
                var statement319 = new Statement()
                {
                    Production = 0.250 + GetRandomNumber(0, 0.15),
                    Consommation = 0.5,
                    OverProduction = 0.75,
                    Date = new DateTime(2017, 06, 16, 15, 29, 53)
                };
                equipment7.AddStatement(statement319);
                var statement320 = new Statement()
                {
                    Production = 0.250 + GetRandomNumber(0, 0.15),
                    Consommation = 0.5,
                    OverProduction = 0.75,
                    Date = new DateTime(2017, 06, 16, 15, 57, 38)
                };
                equipment7.AddStatement(statement320);
                var statement321 = new Statement()
                {
                    Production = 0.240 + GetRandomNumber(0, 0.15),
                    Consommation = 0.5,
                    OverProduction = 0.7,
                    Date = new DateTime(2017, 06, 16, 16, 33, 12)
                };
                equipment7.AddStatement(statement321);
                var statement322 = new Statement()
                {
                    Production = 0.220 + GetRandomNumber(0, 0.16),
                    Consommation = 0.5,
                    OverProduction = 0.6,
                    Date = new DateTime(2017, 06, 16, 16, 59, 01)
                };
                equipment7.AddStatement(statement322);
                var statement323 = new Statement()
                {
                    Production = 0.220 + GetRandomNumber(0, 0.16),
                    Consommation = 0.5,
                    OverProduction = 0.6,
                    Date = new DateTime(2017, 06, 16, 17, 23, 07)
                };
                equipment7.AddStatement(statement323);
                var statement324 = new Statement()
                {
                    Production = 0.18 + GetRandomNumber(0, 0.08),
                    Consommation = 0.5,
                    OverProduction = 0.4,
                    Date = new DateTime(2017, 06, 16, 17, 57, 31)
                };
                equipment7.AddStatement(statement324);
                var statement325 = new Statement()
                {
                    Production = 0.14 + GetRandomNumber(0, 0.05),
                    Consommation = 1,
                    OverProduction = 0,
                    Date = new DateTime(2017, 06, 16, 18, 37, 46)
                };
                equipment7.AddStatement(statement325);
                var statement326 = new Statement()
                {
                    Production = 0.12 + GetRandomNumber(0, 0.09),
                    Consommation = 1,
                    OverProduction = 0,
                    Date = new DateTime(2017, 06, 16, 18, 51, 12)
                };
                equipment7.AddStatement(statement326);
                var statement327 = new Statement()
                {
                    Production = 0.10 + GetRandomNumber(0, 0.06),
                    Consommation = 2,
                    OverProduction = 0,
                    Date = new DateTime(2017, 06, 16, 19, 21, 56)
                };
                equipment7.AddStatement(statement327);
                var statement328 = new Statement()
                {
                    Production = 0.08 + GetRandomNumber(0, 0.06),
                    Consommation = 2.5,
                    OverProduction = 0,
                    Date = new DateTime(2017, 06, 16, 19, 51, 13)
                };
                equipment7.AddStatement(statement328);
                var statement329 = new Statement()
                {
                    Production = 0.04 + GetRandomNumber(0, 0.015),
                    Consommation = 2.5,
                    OverProduction = 0,
                    Date = new DateTime(2017, 06, 16, 20, 30, 01)
                };
                equipment7.AddStatement(statement329);
                var statement330 = new Statement()
                {
                    Production = 0.04 + GetRandomNumber(0, 0.015),
                    Consommation = 3,
                    OverProduction = 0,
                    Date = new DateTime(2017, 06, 16, 20, 55, 57)
                };
                equipment7.AddStatement(statement330);
                var statement331 = new Statement()
                {
                    Production = 0.04 + GetRandomNumber(0, 0.02),
                    Consommation = 2,
                    OverProduction = 0,
                    Date = new DateTime(2017, 06, 16, 21, 30, 00)
                };
                equipment7.AddStatement(statement331);
                var statement332 = new Statement()
                {
                    Production = 0.04 + GetRandomNumber(0, 0.01),
                    Consommation = 1.5,
                    OverProduction = 0,
                    Date = new DateTime(2017, 06, 16, 22, 07, 00)
                };
                equipment7.AddStatement(statement332);
                var statement333 = new Statement()
                {
                    Production = 0.024 + GetRandomNumber(0, 0.019),
                    Consommation = 1,
                    OverProduction = 0,
                    Date = new DateTime(2017, 06, 16, 22, 29, 57)
                };
                equipment7.AddStatement(statement333);
                var statement334 = new Statement()
                {
                    Production = 0.016 + GetRandomNumber(0, 0.01),
                    Consommation = 0.5,
                    OverProduction = 0,
                    Date = new DateTime(2017, 06, 16, 23, 01, 06)
                };
                equipment7.AddStatement(statement334);
                var statement335 = new Statement()
                {
                    Production = 0 + GetRandomNumber(0, 0.0001),
                    Consommation = 0.5,
                    OverProduction = 0,
                    Date = new DateTime(2017, 06, 16, 23, 35, 09)
                };
                equipment7.AddStatement(statement335);
                _statementRepository.UpdateRange(statement289, statement290, statement291, statement292, statement293,
                    statement294,
                    statement295, statement296, statement297, statement298, statement299, statement300, statement301,
                    statement302,
                    statement303, statement304, statement305, statement306, statement307, statement308, statement309,
                    statement310,
                    statement311, statement312, statement313, statement314, statement315, statement316, statement317,
                    statement318,
                    statement319, statement320, statement321, statement322, statement323, statement324, statement325,
                    statement326,
                    statement327, statement328, statement329, statement330, statement331, statement332, statement333,
                    statement334,
                    statement335, statement336);

                #endregion

                #region statements equipment6

                var statement241 = new Statement()
                {
                    Production = 0,
                    Consommation = 0.5,
                    OverProduction = 0,
                    Date = new DateTime(2017, 06, 16, 00, 01, 12)
                };
                equipment6.AddStatement(statement241);
                var statement242 = new Statement()
                {
                    Production = 0,
                    Consommation = 0.5,
                    OverProduction = 0,
                    Date = new DateTime(2017, 06, 16, 00, 33, 22)
                };
                equipment6.AddStatement(statement242);
                var statement243 = new Statement()
                {
                    Production = 0,
                    Consommation = 0.5,
                    OverProduction = 0,
                    Date = new DateTime(2017, 06, 16, 01, 02, 06)
                };
                equipment6.AddStatement(statement243);
                var statement244 = new Statement()
                {
                    Production = 0,
                    Consommation = 0.5,
                    OverProduction = 0,
                    Date = new DateTime(2017, 06, 16, 01, 32, 01)
                };
                equipment6.AddStatement(statement244);
                var statement245 = new Statement()
                {
                    Production = 0,
                    Consommation = 0.5,
                    OverProduction = 0,
                    Date = new DateTime(2017, 06, 16, 02, 02, 05)
                };
                equipment6.AddStatement(statement245);
                var statement246 = new Statement()
                {
                    Production = 0,
                    Consommation = 0.5,
                    OverProduction = 0,
                    Date = new DateTime(2017, 06, 16, 02, 33, 11)
                };
                equipment6.AddStatement(statement246);
                var statement247 = new Statement()
                {
                    Production = 0,
                    Consommation = 0.5,
                    OverProduction = 0,
                    Date = new DateTime(2017, 06, 16, 02, 59, 35)
                };
                equipment6.AddStatement(statement247);
                var statement248 = new Statement()
                {
                    Production = 0,
                    Consommation = 0.5,
                    OverProduction = 0,
                    Date = new DateTime(2017, 06, 16, 03, 25, 21)
                };
                equipment6.AddStatement(statement248);
                var statement249 = new Statement()
                {
                    Production = 0,
                    Consommation = 0.5,
                    OverProduction = 0,
                    Date = new DateTime(2017, 06, 16, 03, 58, 31)
                };
                equipment6.AddStatement(statement249);
                var statement250 = new Statement()
                {
                    Production = 0,
                    Consommation = 0.5,
                    OverProduction = 0,
                    Date = new DateTime(2017, 06, 16, 04, 32, 23)
                };
                equipment6.AddStatement(statement250);
                var statement251 = new Statement()
                {
                    Production = 0,
                    Consommation = 0.5,
                    OverProduction = 0,
                    Date = new DateTime(2017, 06, 16, 04, 51, 57)
                };
                equipment6.AddStatement(statement251);
                var statement252 = new Statement()
                {
                    Production = 0,
                    Consommation = 0.5,
                    OverProduction = 0,
                    Date = new DateTime(2017, 06, 16, 05, 38, 12)
                };
                equipment6.AddStatement(statement252);
                var statement253 = new Statement()
                {
                    Production = 0 + GetRandomNumber(0, 0.0001),
                    Consommation = 0.5,
                    OverProduction = 0,
                    Date = new DateTime(2017, 06, 16, 05, 58, 01)
                };
                equipment6.AddStatement(statement253);
                var statement254 = new Statement()
                {
                    Production = 0 + GetRandomNumber(0, 0.0005),
                    Consommation = 0.5,
                    OverProduction = 0,
                    Date = new DateTime(2017, 06, 16, 06, 27, 21)
                };
                equipment6.AddStatement(statement254);
                var statement255 = new Statement()
                {
                    Production = 0 + GetRandomNumber(0, 0.01),
                    Consommation = 1.5,
                    OverProduction = 0,
                    Date = new DateTime(2017, 06, 16, 07, 10, 19)
                };
                equipment6.AddStatement(statement255);
                var statement256 = new Statement()
                {
                    Production = 0.001 + GetRandomNumber(0, 0.001),
                    Consommation = 1,
                    OverProduction = 0,
                    Date = new DateTime(2017, 06, 16, 07, 31, 49)
                };
                equipment6.AddStatement(statement256);
                var statement257 = new Statement()
                {
                    Production = 0.001 + GetRandomNumber(0, 0.019),
                    Consommation = 0.5,
                    OverProduction = 0,
                    Date = new DateTime(2017, 06, 16, 08, 02, 07)
                };
                equipment6.AddStatement(statement257);
                var statement258 = new Statement()
                {
                    Production = 0.015 + GetRandomNumber(0, 0.001),
                    Consommation = 0.5,
                    OverProduction = 0,
                    Date = new DateTime(2017, 06, 16, 08, 27, 35)
                };
                equipment6.AddStatement(statement258);
                var statement259 = new Statement()
                {
                    Production = 0.010 + GetRandomNumber(0, 0.009),
                    Consommation = 0.5,
                    OverProduction = 0,
                    Date = new DateTime(2017, 06, 16, 09, 00, 00)
                };
                equipment6.AddStatement(statement259);
                var statement260 = new Statement()
                {
                    Production = 0.012 + GetRandomNumber(0, 0.012),
                    Consommation = 0.5,
                    OverProduction = 0,
                    Date = new DateTime(2017, 06, 16, 09, 27, 42)
                };
                equipment6.AddStatement(statement260);
                var statement261 = new Statement()
                {
                    Production = 0.018 + GetRandomNumber(0, 0.015),
                    Consommation = 0.5,
                    OverProduction = 0,
                    Date = new DateTime(2017, 06, 16, 09, 59, 03)
                };
                equipment6.AddStatement(statement261);
                var statement262 = new Statement()
                {
                    Production = 0.056 + GetRandomNumber(0, 0.05),
                    Consommation = 0.5,
                    OverProduction = 0,
                    Date = new DateTime(2017, 06, 16, 10, 28, 13)
                };
                equipment6.AddStatement(statement262);
                var statement263 = new Statement()
                {
                    Production = 0.084 + GetRandomNumber(0, 0.06),
                    Consommation = 0.5,
                    OverProduction = 0,
                    Date = new DateTime(2017, 06, 16, 10, 59, 59)
                };
                equipment6.AddStatement(statement263);
                var statement264 = new Statement()
                {
                    Production = 0.06 + GetRandomNumber(0, 0.06),
                    Consommation = 0.5,
                    OverProduction = 0,
                    Date = new DateTime(2017, 06, 16, 11, 34, 15)
                };
                equipment6.AddStatement(statement264);
                var statement265 = new Statement()
                {
                    Production = 0.08 + GetRandomNumber(0, 0.05),
                    Consommation = 0.5,
                    OverProduction = 0,
                    Date = new DateTime(2017, 06, 16, 11, 58, 39)
                };
                equipment6.AddStatement(statement265);
                var statement266 = new Statement()
                {
                    Production = 0.08 + GetRandomNumber(0, 0.08),
                    Consommation = 0.5,
                    OverProduction = 0,
                    Date = new DateTime(2017, 06, 16, 12, 32, 57)
                };
                equipment6.AddStatement(statement266);
                var statement267 = new Statement()
                {
                    Production = 0.08 + GetRandomNumber(0, 0.08),
                    Consommation = 0.5,
                    OverProduction = 0,
                    Date = new DateTime(2017, 06, 16, 12, 52, 49)
                };
                equipment6.AddStatement(statement267);
                var statement268 = new Statement()
                {
                    Production = 0.10 + GetRandomNumber(0, 0.10),
                    Consommation = 0.5,
                    OverProduction = 0,
                    Date = new DateTime(2017, 06, 16, 13, 24, 33)
                };
                equipment6.AddStatement(statement268);
                var statement269 = new Statement()
                {
                    Production = 0.14 + GetRandomNumber(0, 0.10),
                    Consommation = 0.5,
                    OverProduction = 0.2,
                    Date = new DateTime(2017, 06, 16, 13, 51, 47)
                };
                equipment6.AddStatement(statement269);
                var statement270 = new Statement()
                {
                    Production = 0.14 + GetRandomNumber(0, 0.12),
                    Consommation = 0.5,
                    OverProduction = 0.2,
                    Date = new DateTime(2017, 06, 16, 14, 21, 12)
                };
                equipment6.AddStatement(statement270);
                var statement271 = new Statement()
                {
                    Production = 0.16 + GetRandomNumber(0, 0.16),
                    Consommation = 0.5,
                    OverProduction = 0.3,
                    Date = new DateTime(2017, 06, 16, 14, 59, 47)
                };
                equipment6.AddStatement(statement271);
                var statement272 = new Statement()
                {
                    Production = 0.250 + GetRandomNumber(0, 0.15),
                    Consommation = 0.5,
                    OverProduction = 0.75,
                    Date = new DateTime(2017, 06, 16, 15, 29, 53)
                };
                equipment6.AddStatement(statement272);
                var statement273 = new Statement()
                {
                    Production = 0.250 + GetRandomNumber(0, 0.15),
                    Consommation = 0.5,
                    OverProduction = 0.75,
                    Date = new DateTime(2017, 06, 16, 15, 57, 38)
                };
                equipment6.AddStatement(statement273);
                var statement274 = new Statement()
                {
                    Production = 0.240 + GetRandomNumber(0, 0.15),
                    Consommation = 0.5,
                    OverProduction = 0.7,
                    Date = new DateTime(2017, 06, 16, 16, 33, 12)
                };
                equipment6.AddStatement(statement274);
                var statement275 = new Statement()
                {
                    Production = 0.220 + GetRandomNumber(0, 0.16),
                    Consommation = 0.5,
                    OverProduction = 0.6,
                    Date = new DateTime(2017, 06, 16, 16, 59, 01)
                };
                equipment6.AddStatement(statement275);
                var statement276 = new Statement()
                {
                    Production = 0.220 + GetRandomNumber(0, 0.16),
                    Consommation = 0.5,
                    OverProduction = 0.6,
                    Date = new DateTime(2017, 06, 16, 17, 23, 07)
                };
                equipment6.AddStatement(statement276);
                var statement277 = new Statement()
                {
                    Production = 0.18 + GetRandomNumber(0, 0.08),
                    Consommation = 0.5,
                    OverProduction = 0.4,
                    Date = new DateTime(2017, 06, 16, 17, 57, 31)
                };
                equipment6.AddStatement(statement277);
                var statement278 = new Statement()
                {
                    Production = 0.14 + GetRandomNumber(0, 0.05),
                    Consommation = 1,
                    OverProduction = 0,
                    Date = new DateTime(2017, 06, 16, 18, 37, 46)
                };
                equipment6.AddStatement(statement278);
                var statement279 = new Statement()
                {
                    Production = 0.12 + GetRandomNumber(0, 0.09),
                    Consommation = 1,
                    OverProduction = 0,
                    Date = new DateTime(2017, 06, 16, 18, 51, 12)
                };
                equipment6.AddStatement(statement279);
                var statement280 = new Statement()
                {
                    Production = 0.10 + GetRandomNumber(0, 0.06),
                    Consommation = 2,
                    OverProduction = 0,
                    Date = new DateTime(2017, 06, 16, 19, 21, 56)
                };
                equipment6.AddStatement(statement280);
                var statement281 = new Statement()
                {
                    Production = 0.08 + GetRandomNumber(0, 0.06),
                    Consommation = 2.5,
                    OverProduction = 0,
                    Date = new DateTime(2017, 06, 16, 19, 51, 13)
                };
                equipment6.AddStatement(statement281);
                var statement282 = new Statement()
                {
                    Production = 0.04 + GetRandomNumber(0, 0.015),
                    Consommation = 2.5,
                    OverProduction = 0,
                    Date = new DateTime(2017, 06, 16, 20, 30, 01)
                };
                equipment6.AddStatement(statement282);
                var statement283 = new Statement()
                {
                    Production = 0.04 + GetRandomNumber(0, 0.015),
                    Consommation = 3,
                    OverProduction = 0,
                    Date = new DateTime(2017, 06, 16, 20, 55, 57)
                };
                equipment6.AddStatement(statement283);
                var statement284 = new Statement()
                {
                    Production = 0.04 + GetRandomNumber(0, 0.02),
                    Consommation = 2,
                    OverProduction = 0,
                    Date = new DateTime(2017, 06, 16, 21, 30, 00)
                };
                equipment6.AddStatement(statement284);
                var statement285 = new Statement()
                {
                    Production = 0.04 + GetRandomNumber(0, 0.01),
                    Consommation = 1.5,
                    OverProduction = 0,
                    Date = new DateTime(2017, 06, 16, 22, 07, 00)
                };
                equipment6.AddStatement(statement285);
                var statement286 = new Statement()
                {
                    Production = 0.024 + GetRandomNumber(0, 0.019),
                    Consommation = 1,
                    OverProduction = 0,
                    Date = new DateTime(2017, 06, 16, 22, 29, 57)
                };
                equipment6.AddStatement(statement286);
                var statement287 = new Statement()
                {
                    Production = 0.016 + GetRandomNumber(0, 0.01),
                    Consommation = 0.5,
                    OverProduction = 0,
                    Date = new DateTime(2017, 06, 16, 23, 01, 06)
                };
                equipment6.AddStatement(statement287);
                var statement288 = new Statement()
                {
                    Production = 0 + GetRandomNumber(0, 0.0001),
                    Consommation = 0.5,
                    OverProduction = 0,
                    Date = new DateTime(2017, 06, 16, 23, 35, 09)
                };
                equipment6.AddStatement(statement288);
                _statementRepository.UpdateRange(statement241, statement242, statement243, statement244, statement245,
                    statement246,
                    statement247, statement248, statement249, statement250, statement251, statement252, statement253,
                    statement254,
                    statement255, statement256, statement257, statement258, statement259, statement260, statement261,
                    statement262, statement263,
                    statement264, statement265, statement266, statement267, statement268, statement269, statement270,
                    statement271,
                    statement272, statement273, statement274, statement275, statement276, statement277, statement278,
                    statement279,
                    statement280, statement281, statement282, statement283, statement284, statement285, statement286,
                    statement287,
                    statement288);

                #endregion

                #region statements equipment5

                var statement193 = new Statement()
                {
                    Production = 0,
                    Consommation = 0.5,
                    OverProduction = 0,
                    Date = new DateTime(2017, 06, 16, 00, 01, 12)
                };
                equipment5.AddStatement(statement193);
                var statement194 = new Statement()
                {
                    Production = 0,
                    Consommation = 0.5,
                    OverProduction = 0,
                    Date = new DateTime(2017, 06, 16, 00, 33, 22)
                };
                equipment5.AddStatement(statement194);
                var statement195 = new Statement()
                {
                    Production = 0,
                    Consommation = 0.5,
                    OverProduction = 0,
                    Date = new DateTime(2017, 06, 16, 01, 02, 06)
                };
                equipment5.AddStatement(statement195);
                var statement196 = new Statement()
                {
                    Production = 0,
                    Consommation = 0.5,
                    OverProduction = 0,
                    Date = new DateTime(2017, 06, 16, 01, 32, 01)
                };
                equipment5.AddStatement(statement196);
                var statement197 = new Statement()
                {
                    Production = 0,
                    Consommation = 0.5,
                    OverProduction = 0,
                    Date = new DateTime(2017, 06, 16, 02, 02, 05)
                };
                equipment5.AddStatement(statement197);
                var statement198 = new Statement()
                {
                    Production = 0,
                    Consommation = 0.5,
                    OverProduction = 0,
                    Date = new DateTime(2017, 06, 16, 02, 33, 11)
                };
                equipment5.AddStatement(statement198);
                var statement199 = new Statement()
                {
                    Production = 0,
                    Consommation = 0.5,
                    OverProduction = 0,
                    Date = new DateTime(2017, 06, 16, 02, 59, 35)
                };
                equipment5.AddStatement(statement199);
                var statement200 = new Statement()
                {
                    Production = 0,
                    Consommation = 0.5,
                    OverProduction = 0,
                    Date = new DateTime(2017, 06, 16, 03, 25, 21)
                };
                equipment5.AddStatement(statement200);
                var statement201 = new Statement()
                {
                    Production = 0,
                    Consommation = 0.5,
                    OverProduction = 0,
                    Date = new DateTime(2017, 06, 16, 03, 58, 31)
                };
                equipment5.AddStatement(statement201);
                var statement202 = new Statement()
                {
                    Production = 0,
                    Consommation = 0.5,
                    OverProduction = 0,
                    Date = new DateTime(2017, 06, 16, 04, 32, 23)
                };
                equipment5.AddStatement(statement202);
                var statement203 = new Statement()
                {
                    Production = 0,
                    Consommation = 0.5,
                    OverProduction = 0,
                    Date = new DateTime(2017, 06, 16, 04, 51, 57)
                };
                equipment5.AddStatement(statement203);
                var statement204 = new Statement()
                {
                    Production = 0,
                    Consommation = 0.5,
                    OverProduction = 0,
                    Date = new DateTime(2017, 06, 16, 05, 38, 12)
                };
                equipment5.AddStatement(statement204);
                var statement205 = new Statement()
                {
                    Production = 0 + GetRandomNumber(0, 0.0001),
                    Consommation = 0.5,
                    OverProduction = 0,
                    Date = new DateTime(2017, 06, 16, 05, 58, 01)
                };
                equipment5.AddStatement(statement205);
                var statement206 = new Statement()
                {
                    Production = 0 + GetRandomNumber(0, 0.0005),
                    Consommation = 0.5,
                    OverProduction = 0,
                    Date = new DateTime(2017, 06, 16, 06, 27, 21)
                };
                equipment5.AddStatement(statement206);
                var statement207 = new Statement()
                {
                    Production = 0 + GetRandomNumber(0, 0.01),
                    Consommation = 1.5,
                    OverProduction = 0,
                    Date = new DateTime(2017, 06, 16, 07, 10, 19)
                };
                equipment5.AddStatement(statement207);
                var statement208 = new Statement()
                {
                    Production = 0.001 + GetRandomNumber(0, 0.001),
                    Consommation = 1,
                    OverProduction = 0,
                    Date = new DateTime(2017, 06, 16, 07, 31, 49)
                };
                equipment5.AddStatement(statement208);
                var statement209 = new Statement()
                {
                    Production = 0.001 + GetRandomNumber(0, 0.019),
                    Consommation = 0.5,
                    OverProduction = 0,
                    Date = new DateTime(2017, 06, 16, 08, 02, 07)
                };
                equipment5.AddStatement(statement209);
                var statement210 = new Statement()
                {
                    Production = 0.015 + GetRandomNumber(0, 0.001),
                    Consommation = 0.5,
                    OverProduction = 0,
                    Date = new DateTime(2017, 06, 16, 08, 27, 35)
                };
                equipment5.AddStatement(statement210);
                var statement211 = new Statement()
                {
                    Production = 0.010 + GetRandomNumber(0, 0.009),
                    Consommation = 0.5,
                    OverProduction = 0,
                    Date = new DateTime(2017, 06, 16, 09, 00, 00)
                };
                equipment5.AddStatement(statement211);
                var statement212 = new Statement()
                {
                    Production = 0.012 + GetRandomNumber(0, 0.012),
                    Consommation = 0.5,
                    OverProduction = 0,
                    Date = new DateTime(2017, 06, 16, 09, 27, 42)
                };
                equipment5.AddStatement(statement212);
                var statement213 = new Statement()
                {
                    Production = 0.018 + GetRandomNumber(0, 0.015),
                    Consommation = 0.5,
                    OverProduction = 0,
                    Date = new DateTime(2017, 06, 16, 09, 59, 03)
                };
                equipment5.AddStatement(statement213);
                var statement214 = new Statement()
                {
                    Production = 0.056 + GetRandomNumber(0, 0.05),
                    Consommation = 0.5,
                    OverProduction = 0,
                    Date = new DateTime(2017, 06, 16, 10, 28, 13)
                };
                equipment5.AddStatement(statement214);
                var statement215 = new Statement()
                {
                    Production = 0.084 + GetRandomNumber(0, 0.06),
                    Consommation = 0.5,
                    OverProduction = 0,
                    Date = new DateTime(2017, 06, 16, 10, 59, 59)
                };
                equipment5.AddStatement(statement215);
                var statement216 = new Statement()
                {
                    Production = 0.06 + GetRandomNumber(0, 0.06),
                    Consommation = 0.5,
                    OverProduction = 0,
                    Date = new DateTime(2017, 06, 16, 11, 34, 15)
                };
                equipment5.AddStatement(statement216);
                var statement217 = new Statement()
                {
                    Production = 0.08 + GetRandomNumber(0, 0.05),
                    Consommation = 0.5,
                    OverProduction = 0,
                    Date = new DateTime(2017, 06, 16, 11, 58, 39)
                };
                equipment5.AddStatement(statement217);
                var statement218 = new Statement()
                {
                    Production = 0.08 + GetRandomNumber(0, 0.08),
                    Consommation = 0.5,
                    OverProduction = 0,
                    Date = new DateTime(2017, 06, 16, 12, 32, 57)
                };
                equipment5.AddStatement(statement218);
                var statement219 = new Statement()
                {
                    Production = 0.08 + GetRandomNumber(0, 0.08),
                    Consommation = 0.5,
                    OverProduction = 0,
                    Date = new DateTime(2017, 06, 16, 12, 52, 49)
                };
                equipment5.AddStatement(statement219);
                var statement220 = new Statement()
                {
                    Production = 0.10 + GetRandomNumber(0, 0.10),
                    Consommation = 0.5,
                    OverProduction = 0,
                    Date = new DateTime(2017, 06, 16, 13, 24, 33)
                };
                equipment5.AddStatement(statement220);
                var statement221 = new Statement()
                {
                    Production = 0.14 + GetRandomNumber(0, 0.10),
                    Consommation = 0.5,
                    OverProduction = 0.2,
                    Date = new DateTime(2017, 06, 16, 13, 51, 47)
                };
                equipment5.AddStatement(statement221);
                var statement222 = new Statement()
                {
                    Production = 0.14 + GetRandomNumber(0, 0.12),
                    Consommation = 0.5,
                    OverProduction = 0.2,
                    Date = new DateTime(2017, 06, 16, 14, 21, 12)
                };
                equipment5.AddStatement(statement222);
                var statement223 = new Statement()
                {
                    Production = 0.16 + GetRandomNumber(0, 0.16),
                    Consommation = 0.5,
                    OverProduction = 0.3,
                    Date = new DateTime(2017, 06, 16, 14, 59, 47)
                };
                equipment5.AddStatement(statement223);
                var statement224 = new Statement()
                {
                    Production = 0.250 + GetRandomNumber(0, 0.15),
                    Consommation = 0.5,
                    OverProduction = 0.75,
                    Date = new DateTime(2017, 06, 16, 15, 29, 53)
                };
                equipment5.AddStatement(statement224);
                var statement225 = new Statement()
                {
                    Production = 0.250 + GetRandomNumber(0, 0.15),
                    Consommation = 0.5,
                    OverProduction = 0.75,
                    Date = new DateTime(2017, 06, 16, 15, 57, 38)
                };
                equipment5.AddStatement(statement225);
                var statement226 = new Statement()
                {
                    Production = 0.240 + GetRandomNumber(0, 0.15),
                    Consommation = 0.5,
                    OverProduction = 0.7,
                    Date = new DateTime(2017, 06, 16, 16, 33, 12)
                };
                equipment5.AddStatement(statement226);
                var statement227 = new Statement()
                {
                    Production = 0.220 + GetRandomNumber(0, 0.16),
                    Consommation = 0.5,
                    OverProduction = 0.6,
                    Date = new DateTime(2017, 06, 16, 16, 59, 01)
                };
                equipment5.AddStatement(statement227);
                var statement228 = new Statement()
                {
                    Production = 0.220 + GetRandomNumber(0, 0.16),
                    Consommation = 0.5,
                    OverProduction = 0.6,
                    Date = new DateTime(2017, 06, 16, 17, 23, 07)
                };
                equipment5.AddStatement(statement228);
                var statement229 = new Statement()
                {
                    Production = 0.18 + GetRandomNumber(0, 0.08),
                    Consommation = 0.5,
                    OverProduction = 0.4,
                    Date = new DateTime(2017, 06, 16, 17, 57, 31)
                };
                equipment5.AddStatement(statement229);
                var statement230 = new Statement()
                {
                    Production = 0.14 + GetRandomNumber(0, 0.05),
                    Consommation = 1,
                    OverProduction = 0,
                    Date = new DateTime(2017, 06, 16, 18, 37, 46)
                };
                equipment5.AddStatement(statement230);
                var statement231 = new Statement()
                {
                    Production = 0.12 + GetRandomNumber(0, 0.09),
                    Consommation = 1,
                    OverProduction = 0,
                    Date = new DateTime(2017, 06, 16, 18, 51, 12)
                };
                equipment5.AddStatement(statement231);
                var statement232 = new Statement()
                {
                    Production = 0.10 + GetRandomNumber(0, 0.06),
                    Consommation = 2,
                    OverProduction = 0,
                    Date = new DateTime(2017, 06, 16, 19, 21, 56)
                };
                equipment5.AddStatement(statement232);
                var statement233 = new Statement()
                {
                    Production = 0.08 + GetRandomNumber(0, 0.06),
                    Consommation = 2.5,
                    OverProduction = 0,
                    Date = new DateTime(2017, 06, 16, 19, 51, 13)
                };
                equipment5.AddStatement(statement233);
                var statement234 = new Statement()
                {
                    Production = 0.04 + GetRandomNumber(0, 0.015),
                    Consommation = 2.5,
                    OverProduction = 0,
                    Date = new DateTime(2017, 06, 16, 20, 30, 01)
                };
                equipment5.AddStatement(statement234);
                var statement235 = new Statement()
                {
                    Production = 0.04 + GetRandomNumber(0, 0.015),
                    Consommation = 3,
                    OverProduction = 0,
                    Date = new DateTime(2017, 06, 16, 20, 55, 57)
                };
                equipment5.AddStatement(statement235);
                var statement236 = new Statement()
                {
                    Production = 0.04 + GetRandomNumber(0, 0.02),
                    Consommation = 2,
                    OverProduction = 0,
                    Date = new DateTime(2017, 06, 16, 21, 30, 00)
                };
                equipment5.AddStatement(statement236);
                var statement237 = new Statement()
                {
                    Production = 0.04 + GetRandomNumber(0, 0.01),
                    Consommation = 1.5,
                    OverProduction = 0,
                    Date = new DateTime(2017, 06, 16, 22, 07, 00)
                };
                equipment5.AddStatement(statement237);
                var statement238 = new Statement()
                {
                    Production = 0.024 + GetRandomNumber(0, 0.019),
                    Consommation = 1,
                    OverProduction = 0,
                    Date = new DateTime(2017, 06, 16, 22, 29, 57)
                };
                equipment5.AddStatement(statement238);
                var statement239 = new Statement()
                {
                    Production = 0.016 + GetRandomNumber(0, 0.01),
                    Consommation = 0.5,
                    OverProduction = 0,
                    Date = new DateTime(2017, 06, 16, 23, 01, 06)
                };
                equipment5.AddStatement(statement239);
                var statement240 = new Statement()
                {
                    Production = 0 + GetRandomNumber(0, 0.0001),
                    Consommation = 0.5,
                    OverProduction = 0,
                    Date = new DateTime(2017, 06, 16, 23, 35, 09)
                };
                equipment5.AddStatement(statement240);
                _statementRepository.UpdateRange(statement193, statement194, statement195, statement196, statement197,
                    statement198,
                    statement199, statement200, statement201, statement202, statement203, statement204, statement205,
                    statement206,
                    statement207, statement208, statement209, statement210, statement211, statement212, statement213,
                    statement214, statement215,
                    statement216, statement217, statement218, statement219, statement220, statement221, statement222,
                    statement223,
                    statement224, statement225, statement226, statement227, statement228, statement229, statement230,
                    statement231,
                    statement232, statement233, statement234, statement235, statement236, statement237, statement238,
                    statement239,
                    statement240);

                #endregion

                #region statements equipment8

                var statement337 = new Statement()
                {
                    Production = 0,
                    Consommation = 0.5,
                    OverProduction = 0,
                    Date = new DateTime(2017, 06, 16, 00, 01, 12)
                };
                equipment8.AddStatement(statement337);
                var statement338 = new Statement()
                {
                    Production = 0,
                    Consommation = 0.5,
                    OverProduction = 0,
                    Date = new DateTime(2017, 06, 16, 00, 33, 22)
                };
                equipment8.AddStatement(statement338);
                var statement339 = new Statement()
                {
                    Production = 0,
                    Consommation = 0.5,
                    OverProduction = 0,
                    Date = new DateTime(2017, 06, 16, 01, 02, 06)
                };
                equipment8.AddStatement(statement339);
                var statement340 = new Statement()
                {
                    Production = 0,
                    Consommation = 0.5,
                    OverProduction = 0,
                    Date = new DateTime(2017, 06, 16, 01, 32, 01)
                };
                equipment8.AddStatement(statement340);
                var statement341 = new Statement()
                {
                    Production = 0,
                    Consommation = 0.5,
                    OverProduction = 0,
                    Date = new DateTime(2017, 06, 16, 02, 02, 05)
                };
                equipment8.AddStatement(statement341);
                var statement384 = new Statement()
                {
                    Production = 0,
                    Consommation = 0.5,
                    OverProduction = 0,
                    Date = new DateTime(2017, 06, 16, 02, 33, 11)
                };
                equipment8.AddStatement(statement384);
                var statement342 = new Statement()
                {
                    Production = 0,
                    Consommation = 0.5,
                    OverProduction = 0,
                    Date = new DateTime(2017, 06, 16, 02, 59, 35)
                };
                equipment8.AddStatement(statement342);
                var statement343 = new Statement()
                {
                    Production = 0,
                    Consommation = 0.5,
                    OverProduction = 0,
                    Date = new DateTime(2017, 06, 16, 03, 25, 21)
                };
                equipment8.AddStatement(statement343);
                var statement344 = new Statement()
                {
                    Production = 0,
                    Consommation = 0.5,
                    OverProduction = 0,
                    Date = new DateTime(2017, 06, 16, 03, 58, 31)
                };
                equipment8.AddStatement(statement344);
                var statement345 = new Statement()
                {
                    Production = 0,
                    Consommation = 0.5,
                    OverProduction = 0,
                    Date = new DateTime(2017, 06, 16, 04, 32, 23)
                };
                equipment8.AddStatement(statement345);
                var statement346 = new Statement()
                {
                    Production = 0,
                    Consommation = 0.5,
                    OverProduction = 0,
                    Date = new DateTime(2017, 06, 16, 04, 51, 57)
                };
                equipment8.AddStatement(statement346);
                var statement347 = new Statement()
                {
                    Production = 0,
                    Consommation = 0.5,
                    OverProduction = 0,
                    Date = new DateTime(2017, 06, 16, 05, 38, 12)
                };
                equipment8.AddStatement(statement347);
                var statement348 = new Statement()
                {
                    Production = 0 + GetRandomNumber(0, 0.0001),
                    Consommation = 0.5,
                    OverProduction = 0,
                    Date = new DateTime(2017, 06, 16, 05, 58, 01)
                };
                equipment8.AddStatement(statement348);
                var statement349 = new Statement()
                {
                    Production = 0 + GetRandomNumber(0, 0.0005),
                    Consommation = 0.5,
                    OverProduction = 0,
                    Date = new DateTime(2017, 06, 16, 06, 27, 21)
                };
                equipment8.AddStatement(statement349);
                var statement350 = new Statement()
                {
                    Production = 0 + GetRandomNumber(0, 0.01),
                    Consommation = 1.5,
                    OverProduction = 0,
                    Date = new DateTime(2017, 06, 16, 07, 10, 19)
                };
                equipment8.AddStatement(statement350);
                var statement351 = new Statement()
                {
                    Production = 0.001 + GetRandomNumber(0, 0.001),
                    Consommation = 1,
                    OverProduction = 0,
                    Date = new DateTime(2017, 06, 16, 07, 31, 49)
                };
                equipment8.AddStatement(statement351);
                var statement352 = new Statement()
                {
                    Production = 0.001 + GetRandomNumber(0, 0.019),
                    Consommation = 0.5,
                    OverProduction = 0,
                    Date = new DateTime(2017, 06, 16, 08, 02, 07)
                };
                equipment8.AddStatement(statement352);
                var statement353 = new Statement()
                {
                    Production = 0.015 + GetRandomNumber(0, 0.001),
                    Consommation = 0.5,
                    OverProduction = 0,
                    Date = new DateTime(2017, 06, 16, 08, 27, 35)
                };
                equipment8.AddStatement(statement353);
                var statement354 = new Statement()
                {
                    Production = 0.010 + GetRandomNumber(0, 0.009),
                    Consommation = 0.5,
                    OverProduction = 0,
                    Date = new DateTime(2017, 06, 16, 09, 00, 00)
                };
                equipment8.AddStatement(statement354);
                var statement355 = new Statement()
                {
                    Production = 0.012 + GetRandomNumber(0, 0.012),
                    Consommation = 0.5,
                    OverProduction = 0,
                    Date = new DateTime(2017, 06, 16, 09, 27, 42)
                };
                equipment8.AddStatement(statement355);
                var statement356 = new Statement()
                {
                    Production = 0.018 + GetRandomNumber(0, 0.015),
                    Consommation = 0.5,
                    OverProduction = 0,
                    Date = new DateTime(2017, 06, 16, 09, 59, 03)
                };
                equipment8.AddStatement(statement356);
                var statement357 = new Statement()
                {
                    Production = 0.056 + GetRandomNumber(0, 0.05),
                    Consommation = 0.5,
                    OverProduction = 0,
                    Date = new DateTime(2017, 06, 16, 10, 28, 13)
                };
                equipment8.AddStatement(statement357);
                var statement358 = new Statement()
                {
                    Production = 0.084 + GetRandomNumber(0, 0.06),
                    Consommation = 0.5,
                    OverProduction = 0,
                    Date = new DateTime(2017, 06, 16, 10, 59, 59)
                };
                equipment8.AddStatement(statement358);
                var statement359 = new Statement()
                {
                    Production = 0.06 + GetRandomNumber(0, 0.06),
                    Consommation = 0.5,
                    OverProduction = 0,
                    Date = new DateTime(2017, 06, 16, 11, 34, 15)
                };
                equipment8.AddStatement(statement359);
                var statement360 = new Statement()
                {
                    Production = 0.08 + GetRandomNumber(0, 0.05),
                    Consommation = 0.5,
                    OverProduction = 0,
                    Date = new DateTime(2017, 06, 16, 11, 58, 39)
                };
                equipment8.AddStatement(statement360);
                var statement361 = new Statement()
                {
                    Production = 0.08 + GetRandomNumber(0, 0.08),
                    Consommation = 0.5,
                    OverProduction = 0,
                    Date = new DateTime(2017, 06, 16, 12, 32, 57)
                };
                equipment8.AddStatement(statement361);
                var statement362 = new Statement()
                {
                    Production = 0.08 + GetRandomNumber(0, 0.08),
                    Consommation = 0.5,
                    OverProduction = 0,
                    Date = new DateTime(2017, 06, 16, 12, 52, 49)
                };
                equipment8.AddStatement(statement362);
                var statement363 = new Statement()
                {
                    Production = 0.10 + GetRandomNumber(0, 0.10),
                    Consommation = 0.5,
                    OverProduction = 0,
                    Date = new DateTime(2017, 06, 16, 13, 24, 33)
                };
                equipment8.AddStatement(statement363);
                var statement364 = new Statement()
                {
                    Production = 0.14 + GetRandomNumber(0, 0.10),
                    Consommation = 0.5,
                    OverProduction = 0.2,
                    Date = new DateTime(2017, 06, 16, 13, 51, 47)
                };
                equipment8.AddStatement(statement364);
                var statement365 = new Statement()
                {
                    Production = 0.14 + GetRandomNumber(0, 0.12),
                    Consommation = 0.5,
                    OverProduction = 0.2,
                    Date = new DateTime(2017, 06, 16, 14, 21, 12)
                };
                equipment8.AddStatement(statement365);
                var statement366 = new Statement()
                {
                    Production = 0.16 + GetRandomNumber(0, 0.16),
                    Consommation = 0.5,
                    OverProduction = 0.3,
                    Date = new DateTime(2017, 06, 16, 14, 59, 47)
                };
                equipment8.AddStatement(statement366);
                var statement367 = new Statement()
                {
                    Production = 0.250 + GetRandomNumber(0, 0.15),
                    Consommation = 0.5,
                    OverProduction = 0.75,
                    Date = new DateTime(2017, 06, 16, 15, 29, 53)
                };
                equipment8.AddStatement(statement367);
                var statement368 = new Statement()
                {
                    Production = 0.250 + GetRandomNumber(0, 0.15),
                    Consommation = 0.5,
                    OverProduction = 0.75,
                    Date = new DateTime(2017, 06, 16, 15, 57, 38)
                };
                equipment8.AddStatement(statement368);
                var statement369 = new Statement()
                {
                    Production = 0.240 + GetRandomNumber(0, 0.15),
                    Consommation = 0.5,
                    OverProduction = 0.7,
                    Date = new DateTime(2017, 06, 16, 16, 33, 12)
                };
                equipment8.AddStatement(statement369);
                var statement370 = new Statement()
                {
                    Production = 0.220 + GetRandomNumber(0, 0.16),
                    Consommation = 0.5,
                    OverProduction = 0.6,
                    Date = new DateTime(2017, 06, 16, 16, 59, 01)
                };
                equipment8.AddStatement(statement370);
                var statement371 = new Statement()
                {
                    Production = 0.220 + GetRandomNumber(0, 0.16),
                    Consommation = 0.5,
                    OverProduction = 0.6,
                    Date = new DateTime(2017, 06, 16, 17, 23, 07)
                };
                equipment8.AddStatement(statement371);
                var statement372 = new Statement()
                {
                    Production = 0.18 + GetRandomNumber(0, 0.08),
                    Consommation = 0.5,
                    OverProduction = 0.4,
                    Date = new DateTime(2017, 06, 16, 17, 57, 31)
                };
                equipment8.AddStatement(statement372);
                var statement373 = new Statement()
                {
                    Production = 0.14 + GetRandomNumber(0, 0.05),
                    Consommation = 1,
                    OverProduction = 0,
                    Date = new DateTime(2017, 06, 16, 18, 37, 46)
                };
                equipment8.AddStatement(statement373);
                var statement374 = new Statement()
                {
                    Production = 0.12 + GetRandomNumber(0, 0.09),
                    Consommation = 1,
                    OverProduction = 0,
                    Date = new DateTime(2017, 06, 16, 18, 51, 12)
                };
                equipment8.AddStatement(statement374);
                var statement375 = new Statement()
                {
                    Production = 0.10 + GetRandomNumber(0, 0.06),
                    Consommation = 2,
                    OverProduction = 0,
                    Date = new DateTime(2017, 06, 16, 19, 21, 56)
                };
                equipment8.AddStatement(statement375);
                var statement376 = new Statement()
                {
                    Production = 0.08 + GetRandomNumber(0, 0.06),
                    Consommation = 2.5,
                    OverProduction = 0,
                    Date = new DateTime(2017, 06, 16, 19, 51, 13)
                };
                equipment8.AddStatement(statement376);
                var statement377 = new Statement()
                {
                    Production = 0.04 + GetRandomNumber(0, 0.015),
                    Consommation = 2.5,
                    OverProduction = 0,
                    Date = new DateTime(2017, 06, 16, 20, 30, 01)
                };
                equipment8.AddStatement(statement377);
                var statement378 = new Statement()
                {
                    Production = 0.04 + GetRandomNumber(0, 0.015),
                    Consommation = 3,
                    OverProduction = 0,
                    Date = new DateTime(2017, 06, 16, 20, 55, 57)
                };
                equipment8.AddStatement(statement378);
                var statement379 = new Statement()
                {
                    Production = 0.04 + GetRandomNumber(0, 0.02),
                    Consommation = 2,
                    OverProduction = 0,
                    Date = new DateTime(2017, 06, 16, 21, 30, 00)
                };
                equipment8.AddStatement(statement379);
                var statement380 = new Statement()
                {
                    Production = 0.04 + GetRandomNumber(0, 0.01),
                    Consommation = 1.5,
                    OverProduction = 0,
                    Date = new DateTime(2017, 06, 16, 22, 07, 00)
                };
                equipment8.AddStatement(statement380);
                var statement381 = new Statement()
                {
                    Production = 0.024 + GetRandomNumber(0, 0.019),
                    Consommation = 1,
                    OverProduction = 0,
                    Date = new DateTime(2017, 06, 16, 22, 29, 57)
                };
                equipment8.AddStatement(statement381);
                var statement382 = new Statement()
                {
                    Production = 0.016 + GetRandomNumber(0, 0.01),
                    Consommation = 0.5,
                    OverProduction = 0,
                    Date = new DateTime(2017, 06, 16, 23, 01, 06)
                };
                equipment8.AddStatement(statement382);
                var statement383 = new Statement()
                {
                    Production = 0 + GetRandomNumber(0, 0.0001),
                    Consommation = 0.5,
                    OverProduction = 0,
                    Date = new DateTime(2017, 06, 16, 23, 35, 09)
                };
                equipment8.AddStatement(statement383);
                _statementRepository.UpdateRange(statement337, statement338, statement339, statement340, statement341,
                    statement342,
                    statement343, statement344, statement345, statement346, statement347, statement348, statement349,
                    statement350,
                    statement351, statement352, statement353, statement354, statement355, statement356, statement357,
                    statement358,
                    statement359, statement360, statement361, statement362, statement363, statement364, statement365,
                    statement366,
                    statement367, statement368, statement369, statement370, statement371, statement372, statement373,
                    statement374,
                    statement375, statement376, statement377, statement378, statement379, statement380, statement381,
                    statement382,
                    statement383, statement384);

                #endregion

                #region statements equipment9

                var statement385 = new Statement()
                {
                    Production = 0,
                    Consommation = 0.5,
                    OverProduction = 0,
                    Date = new DateTime(2017, 06, 16, 00, 01, 12)
                };
                equipment9.AddStatement(statement385);
                var statement386 = new Statement()
                {
                    Production = 0,
                    Consommation = 0.5,
                    OverProduction = 0,
                    Date = new DateTime(2017, 06, 16, 00, 33, 22)
                };
                equipment9.AddStatement(statement386);
                var statement387 = new Statement()
                {
                    Production = 0,
                    Consommation = 0.5,
                    OverProduction = 0,
                    Date = new DateTime(2017, 06, 16, 01, 02, 06)
                };
                equipment9.AddStatement(statement387);
                var statement388 = new Statement()
                {
                    Production = 0,
                    Consommation = 0.5,
                    OverProduction = 0,
                    Date = new DateTime(2017, 06, 16, 01, 32, 01)
                };
                equipment9.AddStatement(statement388);
                var statement389 = new Statement()
                {
                    Production = 0,
                    Consommation = 0.5,
                    OverProduction = 0,
                    Date = new DateTime(2017, 06, 16, 02, 02, 05)
                };
                equipment9.AddStatement(statement389);
                var statement390 = new Statement()
                {
                    Production = 0,
                    Consommation = 0.5,
                    OverProduction = 0,
                    Date = new DateTime(2017, 06, 16, 02, 33, 11)
                };
                equipment9.AddStatement(statement390);
                var statement391 = new Statement()
                {
                    Production = 0,
                    Consommation = 0.5,
                    OverProduction = 0,
                    Date = new DateTime(2017, 06, 16, 02, 59, 35)
                };
                equipment9.AddStatement(statement391);
                var statement392 = new Statement()
                {
                    Production = 0,
                    Consommation = 0.5,
                    OverProduction = 0,
                    Date = new DateTime(2017, 06, 16, 03, 25, 21)
                };
                equipment9.AddStatement(statement392);
                var statement393 = new Statement()
                {
                    Production = 0,
                    Consommation = 0.5,
                    OverProduction = 0,
                    Date = new DateTime(2017, 06, 16, 03, 58, 31)
                };
                equipment9.AddStatement(statement393);
                var statement394 = new Statement()
                {
                    Production = 0,
                    Consommation = 0.5,
                    OverProduction = 0,
                    Date = new DateTime(2017, 06, 16, 04, 32, 23)
                };
                equipment9.AddStatement(statement394);
                var statement395 = new Statement()
                {
                    Production = 0,
                    Consommation = 0.5,
                    OverProduction = 0,
                    Date = new DateTime(2017, 06, 16, 04, 51, 57)
                };
                equipment9.AddStatement(statement395);
                var statement396 = new Statement()
                {
                    Production = 0,
                    Consommation = 0.5,
                    OverProduction = 0,
                    Date = new DateTime(2017, 06, 16, 05, 38, 12)
                };
                equipment9.AddStatement(statement396);
                var statement397 = new Statement()
                {
                    Production = 0 + GetRandomNumber(0, 0.0001),
                    Consommation = 0.5,
                    OverProduction = 0,
                    Date = new DateTime(2017, 06, 16, 05, 58, 01)
                };
                equipment9.AddStatement(statement397);
                var statement398 = new Statement()
                {
                    Production = 0 + GetRandomNumber(0, 0.0005),
                    Consommation = 0.5,
                    OverProduction = 0,
                    Date = new DateTime(2017, 06, 16, 06, 27, 21)
                };
                equipment9.AddStatement(statement398);
                var statement399 = new Statement()
                {
                    Production = 0 + GetRandomNumber(0, 0.01),
                    Consommation = 1.5,
                    OverProduction = 0,
                    Date = new DateTime(2017, 06, 16, 07, 10, 19)
                };
                equipment9.AddStatement(statement399);
                var statement400 = new Statement()
                {
                    Production = 0.001 + GetRandomNumber(0, 0.001),
                    Consommation = 1,
                    OverProduction = 0,
                    Date = new DateTime(2017, 06, 16, 07, 31, 49)
                };
                equipment9.AddStatement(statement400);
                var statement401 = new Statement()
                {
                    Production = 0.001 + GetRandomNumber(0, 0.019),
                    Consommation = 0.5,
                    OverProduction = 0,
                    Date = new DateTime(2017, 06, 16, 08, 02, 07)
                };
                equipment9.AddStatement(statement401);
                var statement402 = new Statement()
                {
                    Production = 0.015 + GetRandomNumber(0, 0.001),
                    Consommation = 0.5,
                    OverProduction = 0,
                    Date = new DateTime(2017, 06, 16, 08, 27, 35)
                };
                equipment9.AddStatement(statement402);
                var statement403 = new Statement()
                {
                    Production = 0.010 + GetRandomNumber(0, 0.009),
                    Consommation = 0.5,
                    OverProduction = 0,
                    Date = new DateTime(2017, 06, 16, 09, 00, 00)
                };
                equipment9.AddStatement(statement403);
                var statement404 = new Statement()
                {
                    Production = 0.012 + GetRandomNumber(0, 0.012),
                    Consommation = 0.5,
                    OverProduction = 0,
                    Date = new DateTime(2017, 06, 16, 09, 27, 42)
                };
                equipment9.AddStatement(statement404);
                var statement405 = new Statement()
                {
                    Production = 0.018 + GetRandomNumber(0, 0.015),
                    Consommation = 0.5,
                    OverProduction = 0,
                    Date = new DateTime(2017, 06, 16, 09, 59, 03)
                };
                equipment9.AddStatement(statement405);
                var statement406 = new Statement()
                {
                    Production = 0.056 + GetRandomNumber(0, 0.05),
                    Consommation = 0.5,
                    OverProduction = 0,
                    Date = new DateTime(2017, 06, 16, 10, 28, 13)
                };
                equipment9.AddStatement(statement406);
                var statement407 = new Statement()
                {
                    Production = 0.084 + GetRandomNumber(0, 0.06),
                    Consommation = 0.5,
                    OverProduction = 0,
                    Date = new DateTime(2017, 06, 16, 10, 59, 59)
                };
                equipment9.AddStatement(statement407);
                var statement408 = new Statement()
                {
                    Production = 0.06 + GetRandomNumber(0, 0.06),
                    Consommation = 0.5,
                    OverProduction = 0,
                    Date = new DateTime(2017, 06, 16, 11, 34, 15)
                };
                equipment9.AddStatement(statement408);
                var statement409 = new Statement()
                {
                    Production = 0.08 + GetRandomNumber(0, 0.05),
                    Consommation = 0.5,
                    OverProduction = 0,
                    Date = new DateTime(2017, 06, 16, 11, 58, 39)
                };
                equipment9.AddStatement(statement409);
                var statement410 = new Statement()
                {
                    Production = 0.08 + GetRandomNumber(0, 0.08),
                    Consommation = 0.5,
                    OverProduction = 0,
                    Date = new DateTime(2017, 06, 16, 12, 32, 57)
                };
                equipment9.AddStatement(statement410);
                var statement411 = new Statement()
                {
                    Production = 0.08 + GetRandomNumber(0, 0.08),
                    Consommation = 0.5,
                    OverProduction = 0,
                    Date = new DateTime(2017, 06, 16, 12, 52, 49)
                };
                equipment9.AddStatement(statement411);
                var statement412 = new Statement()
                {
                    Production = 0.10 + GetRandomNumber(0, 0.10),
                    Consommation = 0.5,
                    OverProduction = 0,
                    Date = new DateTime(2017, 06, 16, 13, 24, 33)
                };
                equipment9.AddStatement(statement412);
                var statement413 = new Statement()
                {
                    Production = 0.14 + GetRandomNumber(0, 0.10),
                    Consommation = 0.5,
                    OverProduction = 0.2,
                    Date = new DateTime(2017, 06, 16, 13, 51, 47)
                };
                equipment9.AddStatement(statement413);
                var statement414 = new Statement()
                {
                    Production = 0.14 + GetRandomNumber(0, 0.12),
                    Consommation = 0.5,
                    OverProduction = 0.2,
                    Date = new DateTime(2017, 06, 16, 14, 21, 12)
                };
                equipment9.AddStatement(statement414);
                var statement415 = new Statement()
                {
                    Production = 0.16 + GetRandomNumber(0, 0.16),
                    Consommation = 0.5,
                    OverProduction = 0.3,
                    Date = new DateTime(2017, 06, 16, 14, 59, 47)
                };
                equipment9.AddStatement(statement415);
                var statement416 = new Statement()
                {
                    Production = 0.250 + GetRandomNumber(0, 0.15),
                    Consommation = 0.5,
                    OverProduction = 0.75,
                    Date = new DateTime(2017, 06, 16, 15, 29, 53)
                };
                equipment9.AddStatement(statement416);
                var statement417 = new Statement()
                {
                    Production = 0.250 + GetRandomNumber(0, 0.15),
                    Consommation = 0.5,
                    OverProduction = 0.75,
                    Date = new DateTime(2017, 06, 16, 15, 57, 38)
                };
                equipment9.AddStatement(statement417);
                var statement418 = new Statement()
                {
                    Production = 0.240 + GetRandomNumber(0, 0.15),
                    Consommation = 0.5,
                    OverProduction = 0.7,
                    Date = new DateTime(2017, 06, 16, 16, 33, 12)
                };
                equipment9.AddStatement(statement418);
                var statement419 = new Statement()
                {
                    Production = 0.220 + GetRandomNumber(0, 0.16),
                    Consommation = 0.5,
                    OverProduction = 0.6,
                    Date = new DateTime(2017, 06, 16, 16, 59, 01)
                };
                equipment9.AddStatement(statement419);
                var statement420 = new Statement()
                {
                    Production = 0.220 + GetRandomNumber(0, 0.16),
                    Consommation = 0.5,
                    OverProduction = 0.6,
                    Date = new DateTime(2017, 06, 16, 17, 23, 07)
                };
                equipment9.AddStatement(statement420);
                var statement421 = new Statement()
                {
                    Production = 0.18 + GetRandomNumber(0, 0.08),
                    Consommation = 0.5,
                    OverProduction = 0.4,
                    Date = new DateTime(2017, 06, 16, 17, 57, 31)
                };
                equipment9.AddStatement(statement421);
                var statement422 = new Statement()
                {
                    Production = 0.14 + GetRandomNumber(0, 0.05),
                    Consommation = 1,
                    OverProduction = 0,
                    Date = new DateTime(2017, 06, 16, 18, 37, 46)
                };
                equipment9.AddStatement(statement422);
                var statement423 = new Statement()
                {
                    Production = 0.12 + GetRandomNumber(0, 0.09),
                    Consommation = 1,
                    OverProduction = 0,
                    Date = new DateTime(2017, 06, 16, 18, 51, 12)
                };
                equipment9.AddStatement(statement423);
                var statement424 = new Statement()
                {
                    Production = 0.10 + GetRandomNumber(0, 0.06),
                    Consommation = 2,
                    OverProduction = 0,
                    Date = new DateTime(2017, 06, 16, 19, 21, 56)
                };
                equipment9.AddStatement(statement424);
                var statement425 = new Statement()
                {
                    Production = 0.08 + GetRandomNumber(0, 0.06),
                    Consommation = 2.5,
                    OverProduction = 0,
                    Date = new DateTime(2017, 06, 16, 19, 51, 13)
                };
                equipment9.AddStatement(statement425);
                var statement426 = new Statement()
                {
                    Production = 0.04 + GetRandomNumber(0, 0.015),
                    Consommation = 2.5,
                    OverProduction = 0,
                    Date = new DateTime(2017, 06, 16, 20, 30, 01)
                };
                equipment9.AddStatement(statement426);
                var statement427 = new Statement()
                {
                    Production = 0.04 + GetRandomNumber(0, 0.015),
                    Consommation = 3,
                    OverProduction = 0,
                    Date = new DateTime(2017, 06, 16, 20, 55, 57)
                };
                equipment9.AddStatement(statement427);
                var statement428 = new Statement()
                {
                    Production = 0.04 + GetRandomNumber(0, 0.02),
                    Consommation = 2,
                    OverProduction = 0,
                    Date = new DateTime(2017, 06, 16, 21, 30, 00)
                };
                equipment9.AddStatement(statement428);
                var statement429 = new Statement()
                {
                    Production = 0.04 + GetRandomNumber(0, 0.01),
                    Consommation = 1.5,
                    OverProduction = 0,
                    Date = new DateTime(2017, 06, 16, 22, 07, 00)
                };
                equipment9.AddStatement(statement429);
                var statement430 = new Statement()
                {
                    Production = 0.024 + GetRandomNumber(0, 0.019),
                    Consommation = 1,
                    OverProduction = 0,
                    Date = new DateTime(2017, 06, 16, 22, 29, 57)
                };
                equipment9.AddStatement(statement430);
                var statement431 = new Statement()
                {
                    Production = 0.016 + GetRandomNumber(0, 0.01),
                    Consommation = 0.5,
                    OverProduction = 0,
                    Date = new DateTime(2017, 06, 16, 23, 01, 06)
                };
                equipment9.AddStatement(statement431);
                var statement432 = new Statement()
                {
                    Production = 0 + GetRandomNumber(0, 0.0001),
                    Consommation = 0.5,
                    OverProduction = 0,
                    Date = new DateTime(2017, 06, 16, 23, 35, 09)
                };
                equipment9.AddStatement(statement432);
                _statementRepository.UpdateRange(statement385, statement386, statement387, statement388, statement389,
                    statement390,
                    statement391, statement392, statement393, statement394, statement395, statement396, statement397,
                    statement398,
                    statement399, statement400, statement401, statement402, statement403, statement404, statement405,
                    statement406, statement407,
                    statement408, statement409, statement410, statement411, statement412, statement413, statement414,
                    statement415,
                    statement416, statement417, statement418, statement419, statement420, statement421, statement422,
                    statement423,
                    statement424, statement425, statement426, statement427, statement428, statement429, statement430,
                    statement431,
                    statement432);

                #endregion
                #region statements equipment10
                var statement433 = new Statement()
                {
                    Production = 0,
                    Consommation = 0.5,
                    OverProduction = 0,
                    Date = new DateTime(2017, 06, 16, 00, 01, 12)
                };
                equipment10.AddStatement(statement433);
                var statement434 = new Statement()
                {
                    Production = 0,
                    Consommation = 0.5,
                    OverProduction = 0,
                    Date = new DateTime(2017, 06, 16, 00, 33, 22)
                };
                equipment10.AddStatement(statement434);
                var statement435 = new Statement()
                {
                    Production = 0,
                    Consommation = 0.5,
                    OverProduction = 0,
                    Date = new DateTime(2017, 06, 16, 01, 02, 06)
                };
                equipment10.AddStatement(statement435);
                var statement436 = new Statement()
                {
                    Production = 0,
                    Consommation = 0.5,
                    OverProduction = 0,
                    Date = new DateTime(2017, 06, 16, 01, 32, 01)
                };
                equipment10.AddStatement(statement436);
                var statement437 = new Statement()
                {
                    Production = 0,
                    Consommation = 0.5,
                    OverProduction = 0,
                    Date = new DateTime(2017, 06, 16, 02, 02, 05)
                };
                equipment10.AddStatement(statement437);
                var statement438 = new Statement()
                {
                    Production = 0,
                    Consommation = 0.5,
                    OverProduction = 0,
                    Date = new DateTime(2017, 06, 16, 02, 33, 11)
                };
                equipment10.AddStatement(statement438);
                var statement439 = new Statement()
                {
                    Production = 0,
                    Consommation = 0.5,
                    OverProduction = 0,
                    Date = new DateTime(2017, 06, 16, 02, 59, 35)
                };
                equipment10.AddStatement(statement439);
                var statement440 = new Statement()
                {
                    Production = 0,
                    Consommation = 0.5,
                    OverProduction = 0,
                    Date = new DateTime(2017, 06, 16, 03, 25, 21)
                };
                equipment10.AddStatement(statement440);
                var statement441 = new Statement()
                {
                    Production = 0,
                    Consommation = 0.5,
                    OverProduction = 0,
                    Date = new DateTime(2017, 06, 16, 03, 58, 31)
                };
                equipment10.AddStatement(statement441);
                var statement442 = new Statement()
                {
                    Production = 0,
                    Consommation = 0.5,
                    OverProduction = 0,
                    Date = new DateTime(2017, 06, 16, 04, 32, 23)
                };
                equipment10.AddStatement(statement442);
                var statement443 = new Statement()
                {
                    Production = 0,
                    Consommation = 0.5,
                    OverProduction = 0,
                    Date = new DateTime(2017, 06, 16, 04, 51, 57)
                };
                equipment10.AddStatement(statement443);
                var statement444 = new Statement()
                {
                    Production = 0,
                    Consommation = 0.5,
                    OverProduction = 0,
                    Date = new DateTime(2017, 06, 16, 05, 38, 12)
                };
                equipment10.AddStatement(statement444);
                var statement445 = new Statement()
                {
                    Production = 0 + GetRandomNumber(0, 0.0001),
                    Consommation = 0.5,
                    OverProduction = 0,
                    Date = new DateTime(2017, 06, 16, 05, 58, 01)
                };
                equipment10.AddStatement(statement445);
                var statement446 = new Statement()
                {
                    Production = 0 + GetRandomNumber(0, 0.0005),
                    Consommation = 0.5,
                    OverProduction = 0,
                    Date = new DateTime(2017, 06, 16, 06, 27, 21)
                };
                equipment10.AddStatement(statement446);
                var statement447 = new Statement()
                {
                    Production = 0 + GetRandomNumber(0, 0.01),
                    Consommation = 1.5,
                    OverProduction = 0,
                    Date = new DateTime(2017, 06, 16, 07, 10, 19)
                };
                equipment10.AddStatement(statement447);
                var statement448 = new Statement()
                {
                    Production = 0.001 + GetRandomNumber(0, 0.001),
                    Consommation = 1,
                    OverProduction = 0,
                    Date = new DateTime(2017, 06, 16, 07, 31, 49)
                };
                equipment10.AddStatement(statement448);
                var statement449 = new Statement()
                {
                    Production = 0.001 + GetRandomNumber(0, 0.019),
                    Consommation = 0.5,
                    OverProduction = 0,
                    Date = new DateTime(2017, 06, 16, 08, 02, 07)
                };
                equipment10.AddStatement(statement449);
                var statement450 = new Statement()
                {
                    Production = 0.015 + GetRandomNumber(0, 0.001),
                    Consommation = 0.5,
                    OverProduction = 0,
                    Date = new DateTime(2017, 06, 16, 08, 27, 35)
                };
                equipment10.AddStatement(statement450);
                var statement451 = new Statement()
                {
                    Production = 0.010 + GetRandomNumber(0, 0.009),
                    Consommation = 0.5,
                    OverProduction = 0,
                    Date = new DateTime(2017, 06, 16, 09, 00, 00)
                };
                equipment10.AddStatement(statement451);
                var statement452 = new Statement()
                {
                    Production = 0.012 + GetRandomNumber(0, 0.012),
                    Consommation = 0.5,
                    OverProduction = 0,
                    Date = new DateTime(2017, 06, 16, 09, 27, 42)
                };
                equipment10.AddStatement(statement452);
                var statement453 = new Statement()
                {
                    Production = 0.018 + GetRandomNumber(0, 0.015),
                    Consommation = 0.5,
                    OverProduction = 0,
                    Date = new DateTime(2017, 06, 16, 09, 59, 03)
                };
                equipment10.AddStatement(statement453);
                var statement454 = new Statement()
                {
                    Production = 0.056 + GetRandomNumber(0, 0.05),
                    Consommation = 0.5,
                    OverProduction = 0,
                    Date = new DateTime(2017, 06, 16, 10, 28, 13)
                };
                equipment10.AddStatement(statement454);
                var statement455 = new Statement()
                {
                    Production = 0.084 + GetRandomNumber(0, 0.06),
                    Consommation = 0.5,
                    OverProduction = 0,
                    Date = new DateTime(2017, 06, 16, 10, 59, 59)
                };
                equipment10.AddStatement(statement455);
                var statement456 = new Statement()
                {
                    Production = 0.06 + GetRandomNumber(0, 0.06),
                    Consommation = 0.5,
                    OverProduction = 0,
                    Date = new DateTime(2017, 06, 16, 11, 34, 15)
                };
                equipment10.AddStatement(statement456);
                var statement457 = new Statement()
                {
                    Production = 0.08 + GetRandomNumber(0, 0.05),
                    Consommation = 0.5,
                    OverProduction = 0,
                    Date = new DateTime(2017, 06, 16, 11, 58, 39)
                };
                equipment10.AddStatement(statement457);
                var statement458 = new Statement()
                {
                    Production = 0.08 + GetRandomNumber(0, 0.08),
                    Consommation = 0.5,
                    OverProduction = 0,
                    Date = new DateTime(2017, 06, 16, 12, 32, 57)
                };
                equipment10.AddStatement(statement458);
                var statement459 = new Statement()
                {
                    Production = 0.08 + GetRandomNumber(0, 0.08),
                    Consommation = 0.5,
                    OverProduction = 0,
                    Date = new DateTime(2017, 06, 16, 12, 52, 49)
                };
                equipment10.AddStatement(statement459);
                var statement460 = new Statement()
                {
                    Production = 0.10 + GetRandomNumber(0, 0.10),
                    Consommation = 0.5,
                    OverProduction = 0,
                    Date = new DateTime(2017, 06, 16, 13, 24, 33)
                };
                equipment10.AddStatement(statement460);
                var statement461 = new Statement()
                {
                    Production = 0.14 + GetRandomNumber(0, 0.10),
                    Consommation = 0.5,
                    OverProduction = 0.2,
                    Date = new DateTime(2017, 06, 16, 13, 51, 47)
                };
                equipment10.AddStatement(statement461);
                var statement462 = new Statement()
                {
                    Production = 0.14 + GetRandomNumber(0, 0.12),
                    Consommation = 0.5,
                    OverProduction = 0.2,
                    Date = new DateTime(2017, 06, 16, 14, 21, 12)
                };
                equipment10.AddStatement(statement462);
                var statement463 = new Statement()
                {
                    Production = 0.16 + GetRandomNumber(0, 0.16),
                    Consommation = 0.5,
                    OverProduction = 0.3,
                    Date = new DateTime(2017, 06, 16, 14, 59, 47)
                };
                equipment10.AddStatement(statement463);
                var statement464 = new Statement()
                {
                    Production = 0.250 + GetRandomNumber(0, 0.15),
                    Consommation = 0.5,
                    OverProduction = 0.75,
                    Date = new DateTime(2017, 06, 16, 15, 29, 53)
                };
                equipment10.AddStatement(statement464);
                var statement465 = new Statement()
                {
                    Production = 0.250 + GetRandomNumber(0, 0.15),
                    Consommation = 0.5,
                    OverProduction = 0.75,
                    Date = new DateTime(2017, 06, 16, 15, 57, 38)
                };
                equipment10.AddStatement(statement465);
                var statement466 = new Statement()
                {
                    Production = 0.240 + GetRandomNumber(0, 0.15),
                    Consommation = 0.5,
                    OverProduction = 0.7,
                    Date = new DateTime(2017, 06, 16, 16, 33, 12)
                };
                equipment10.AddStatement(statement466);
                var statement467 = new Statement()
                {
                    Production = 0.220 + GetRandomNumber(0, 0.16),
                    Consommation = 0.5,
                    OverProduction = 0.6,
                    Date = new DateTime(2017, 06, 16, 16, 59, 01)
                };
                equipment10.AddStatement(statement467);
                var statement468 = new Statement()
                {
                    Production = 0.220 + GetRandomNumber(0, 0.16),
                    Consommation = 0.5,
                    OverProduction = 0.6,
                    Date = new DateTime(2017, 06, 16, 17, 23, 07)
                };
                equipment10.AddStatement(statement468);
                var statement469 = new Statement()
                {
                    Production = 0.18 + GetRandomNumber(0, 0.08),
                    Consommation = 0.5,
                    OverProduction = 0.4,
                    Date = new DateTime(2017, 06, 16, 17, 57, 31)
                };
                equipment10.AddStatement(statement469);
                var statement470 = new Statement()
                {
                    Production = 0.14 + GetRandomNumber(0, 0.05),
                    Consommation = 1,
                    OverProduction = 0,
                    Date = new DateTime(2017, 06, 16, 18, 37, 46)
                };
                equipment10.AddStatement(statement470);
                var statement471 = new Statement()
                {
                    Production = 0.12 + GetRandomNumber(0, 0.09),
                    Consommation = 1,
                    OverProduction = 0,
                    Date = new DateTime(2017, 06, 16, 18, 51, 12)
                };
                equipment10.AddStatement(statement471);
                var statement472 = new Statement()
                {
                    Production = 0.10 + GetRandomNumber(0, 0.06),
                    Consommation = 2,
                    OverProduction = 0,
                    Date = new DateTime(2017, 06, 16, 19, 21, 56)
                };
                equipment10.AddStatement(statement472);
                var statement473 = new Statement()
                {
                    Production = 0.08 + GetRandomNumber(0, 0.06),
                    Consommation = 2.5,
                    OverProduction = 0,
                    Date = new DateTime(2017, 06, 16, 19, 51, 13)
                };
                equipment10.AddStatement(statement473);
                var statement474 = new Statement()
                {
                    Production = 0.04 + GetRandomNumber(0, 0.015),
                    Consommation = 2.5,
                    OverProduction = 0,
                    Date = new DateTime(2017, 06, 16, 20, 30, 01)
                };
                equipment10.AddStatement(statement474);
                var statement475 = new Statement()
                {
                    Production = 0.04 + GetRandomNumber(0, 0.015),
                    Consommation = 3,
                    OverProduction = 0,
                    Date = new DateTime(2017, 06, 16, 20, 55, 57)
                };
                equipment10.AddStatement(statement475);
                var statement476 = new Statement()
                {
                    Production = 0.04 + GetRandomNumber(0, 0.02),
                    Consommation = 2,
                    OverProduction = 0,
                    Date = new DateTime(2017, 06, 16, 21, 30, 00)
                };
                equipment10.AddStatement(statement476);
                var statement477 = new Statement()
                {
                    Production = 0.04 + GetRandomNumber(0, 0.01),
                    Consommation = 1.5,
                    OverProduction = 0,
                    Date = new DateTime(2017, 06, 16, 22, 07, 00)
                };
                equipment10.AddStatement(statement477);
                var statement478 = new Statement()
                {
                    Production = 0.024 + GetRandomNumber(0, 0.019),
                    Consommation = 1,
                    OverProduction = 0,
                    Date = new DateTime(2017, 06, 16, 22, 29, 57)
                };
                equipment10.AddStatement(statement478);
                var statement479 = new Statement()
                {
                    Production = 0.016 + GetRandomNumber(0, 0.01),
                    Consommation = 0.5,
                    OverProduction = 0,
                    Date = new DateTime(2017, 06, 16, 23, 01, 06)
                };
                equipment10.AddStatement(statement479);
                var statement480 = new Statement()
                {
                    Production = 0 + GetRandomNumber(0, 0.0001),
                    Consommation = 0.5,
                    OverProduction = 0,
                    Date = new DateTime(2017, 06, 16, 23, 35, 09)
                };
                equipment10.AddStatement(statement480);
                _statementRepository.UpdateRange(statement433, statement434, statement435, statement436, statement437, statement438,
                    statement439, statement440, statement441, statement442, statement443, statement444, statement445, statement446,
                    statement447, statement448, statement449, statement450, statement451, statement452, statement453, statement454, statement455,
                    statement456, statement457, statement458, statement459, statement460, statement461, statement462, statement463,
                    statement464, statement465, statement466, statement467, statement468, statement469, statement470, statement471,
                    statement472, statement473, statement474, statement475, statement476, statement477, statement478, statement479,
                    statement480);
                #endregion
                _statementRepository.Save();
            }
        }
    }
}