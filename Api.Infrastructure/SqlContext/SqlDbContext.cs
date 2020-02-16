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

        public DbSet<EquipmentUsageDto> EquipmentUsage { get; set; }
        public DbSet<LocationDto> Locations { get; set; }
        public DbSet<PartDto> Parts { get; set; }
        public DbSet<ServiceDto> Services { get; set; }
        public DbSet<ServiceIntervalDto> ServiceIntervals { get; set; }
        public DbSet<ServiceIntervalPartDto> ServiceIntervalParts { get; set; }
        public DbSet<ServicePartDto> ServiceParts { get; set; }
        public DbSet<TaskDto> Tasks { get; set; }
        public DbSet<ServiceTaskDto> ServiceTasks { get; set; }
        public DbSet<ServiceIntervalTaskDto> ServiceIntervalTasks { get; set; }


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

            modelBuilder.Entity<EquipmentUsageDto>()
                .Property(e => e.Id)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<ServicePartDto>()
                .Property(e => e.Id)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<ServiceIntervalPartDto>()
                .Property(e => e.Id)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<TaskDto>()
                .Property(e => e.Id)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<ServiceTaskDto>()
              .Property(e => e.Id)
              .ValueGeneratedOnAdd();

            modelBuilder.Entity<ServiceIntervalTaskDto>()
                .Property(e => e.Id)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<ServicePartDto>().HasKey(sc => new { sc.PartId, sc.ServiceId });

            modelBuilder.Entity<ServiceIntervalPartDto>().HasKey(sc => new { sc.PartId, sc.ServiceIntervalId });

            modelBuilder.Entity<ServiceTaskDto>().HasKey(sc => new { sc.TaskId, sc.ServiceId });

            modelBuilder.Entity<ServiceIntervalTaskDto>().HasKey(sc => new { sc.TaskId, sc.ServiceIntervalId });

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
