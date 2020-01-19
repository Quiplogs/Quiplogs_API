using Api.Infrastructure.Data.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Infrastructure.SqlContext
{
    public class SqlDbContext : IdentityDbContext<UserEntity>
    {
        public SqlDbContext(DbContextOptions<SqlDbContext> options) : base(options) { }

        public DbSet<CompanyDto> Companies { get; set; }
        public DbSet<EquipmentDto> Equipment { get; set; }
        public DbSet<LocationDto> Locations { get; set; }
        public DbSet<PartDto> Parts { get; set; }
        public DbSet<PartStockDto> PartStock { get; set; }
        public DbSet<PreconEquipmentDto> PreconEquipment { get; set; }
        public DbSet<PreconPartDto> PreconParts { get; set; }
        public DbSet<PreconServiceIntervalDto> PreconServiceIntervals { get; set; }
        public DbSet<ServiceDto> Services { get; set; }
        public DbSet<ServiceIntervalDto> ServiceIntervals { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema(schema: DbGlobals.SchemaName);

            modelBuilder.Entity<UserEntity>()
                .Property(e => e.Id)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<ServiceIntervalDto>()
                .Property(e => e.Id)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<ServiceDto>()
                .Property(e => e.Id)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<PreconServiceIntervalDto>()
                .Property(e => e.Id)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<PreconPartDto>()
                .Property(e => e.Id)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<PreconEquipmentDto>()
                .Property(e => e.Id)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<PartStockDto>()
                .Property(e => e.Id)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<PartDto>()
                .Property(e => e.Id)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<LocationDto>()
                .Property(e => e.Id)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<CompanyDto>()
                .Property(e => e.Id)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<EquipmentDto>()
                .Property(e => e.Id)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<ServicePart>()
                .Property(e => e.Id)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<ServiceIntervalPart>()
                .Property(e => e.Id)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<ServicePart>().HasKey(sc => new { sc.PartId, sc.ServiceId });

            modelBuilder.Entity<ServiceIntervalPart>().HasKey(sc => new { sc.PartId, sc.ServiceIntervalId });

            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }

            base.OnModelCreating(modelBuilder);
        }

        public override int SaveChanges()
        {
            AddAuditInfo();
            return base.SaveChanges();
        }

        public async Task<int> SaveChangesAsync()
        {
            AddAuditInfo();
            return await base.SaveChangesAsync();
        }

        private void AddAuditInfo()
        {
            var entries = ChangeTracker.Entries().Where(x => x.Entity is BaseEntity && (x.State == EntityState.Added || x.State == EntityState.Modified));
            foreach (var entry in entries)
            {
                if (entry.State == EntityState.Added)
                {
                    ((BaseEntity)entry.Entity).DateCreated = DateTime.Now;
                }
                ((BaseEntity)entry.Entity).DateUpdated = DateTime.Now;
            }
        }
    }
}
