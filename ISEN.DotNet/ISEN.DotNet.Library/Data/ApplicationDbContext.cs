using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ISEN.DotNet.Library.Models;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace ISEN.DotNet.Library.Data
{
    public class ApplicationDbContext : IdentityDbContext<AccountUser, AccountRole, int>
    {
        // Ajouter les DbSets<> ici
        public DbSet<Equipment> EquipmentCollection { get; set; }
        public DbSet<Owner> OwnerCollection { get; set; }
        public DbSet<Statement> StatementCollection { get; set; }
        public DbSet<AccountUser> AccountUserCollection { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
         protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("DataSource=.\\MyWebApp.db");
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);

            // Ajouter la définition des mappings d'entités avec les tables, et les relations ici
            // ...
            builder.Entity<Equipment>()
                .ToTable("Equipment");
            builder.Entity<Owner>()
                .ToTable("Owner");

            builder.Entity<Statement>()
                .ToTable("Statement");
        }
    }

    public class TempDbContextFactory :
        IDbContextFactory<ApplicationDbContext>
    {
        public ApplicationDbContext Create(DbContextFactoryOptions options)
        {
            var dbContextBuilder = 
                new DbContextOptionsBuilder<ApplicationDbContext>();
            dbContextBuilder.UseSqlite("DataSource=.\\MyWebApp.db");
            return new ApplicationDbContext(dbContextBuilder.Options);
        }
    }
}
