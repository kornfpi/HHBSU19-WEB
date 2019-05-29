using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using HabitatWebApp.Models;

namespace HabitatWebApp.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        //DbSets for EF Core to access database tables

        public DbSet<Issue> Issues { get; set; }
        public DbSet<PartSystem> PartSystems { get; set; }
        public DbSet<Part> Parts { get; set; }
        public DbSet<Symptom> Symptoms { get; set; }
        public DbSet<IssuePartSystem> IssuePartSystems { get; set; }
        public DbSet<MaintenanceItem> MaintenanceItems { get; set; }

        // protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
           //  => optionsBuilder.UseSqlServer("Server=tcp:habitat-homeowner-buddy-dbserver.database.windows.net,1433;Initial Catalog=habitat-homeowner-buddy-db;Persist Security Info=False;User ID=habitat_dev_team;Password=7263_buddyHomeowners!_?;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);

            builder.Entity<IssuePartSystem>()
                .HasKey(ips => new { ips.IssueID, ips.PartSystemID });

            builder.Entity<PartSystemPart>()
                .HasKey(psp => new { psp.PartSystemID, psp.PartID });

            builder.Entity<PartSystemSymptom>()
                .HasKey(pss => new { pss.PartSystemID, pss.SymptomID });
        }

        
    }
}
