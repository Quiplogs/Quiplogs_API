using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Quiplogs.Assets.Data.Entities;
using Quiplogs.Core.Data.Entities;
using Quiplogs.Dashboard.StoredProcedureModels;
using Quiplogs.Inventory.Data.Entities;
using Quiplogs.PMSchedule.Data.Entities;
using Quiplogs.WorkOrder.Data.Entities;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Infrastructure.SqlContext
{
    public class SqlDbContext : IdentityDbContext<UserEntity>
    {
        public SqlDbContext(DbContextOptions<SqlDbContext> options) : base(options) { }

        public DbSet<CompanyDto> Companies { get; set; }
        public DbSet<AssetDto> Asset { get; set; }
        public DbSet<AssetUsageDto> AssetUsage { get; set; }
        public DbSet<LocationDto> Locations { get; set; }
        public DbSet<PartDto> Parts { get; set; }
        public DbSet<WorkOrderDto> WorkOrders { get; set; }
        public DbSet<PlannedMaintenanceDto> PlannedMaintenances { get; set; }
        public DbSet<PlannedMaintenancePartDto> PlannedMaintenanceParts { get; set; }
        public DbSet<WorkOrderPartDto> WorkOrderParts { get; set; }
        public DbSet<TaskDto> Tasks { get; set; }
        public DbSet<WorkOrderTaskDto> WorkOrderTasks { get; set; }
        public DbSet<PlannedMaintenanceTaskDto> PlannedMaintenanceTasks { get; set; }

        public DbSet<PlannedMaintenanceScheduleCustomDto> PlannedMaintenanceScheduleCustom { get; set; }
        public DbSet<PlannedMaintenanceScheduleDailyDto> PlannedMaintenanceScheduleDaily { get; set; }
        public DbSet<PlannedMaintenanceScheduleWeeklyDto> PlannedMaintenanceScheduleWeekly { get; set; }
        public DbSet<PlannedMaintenanceScheduleMonthlyDto> PlannedMaintenanceScheduleMonthly { get; set; }        
        public DbSet<PlannedMaintenanceScheduleYearlyDto> PlannedMaintenanceScheduleYearly { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema(schema: DbGlobals.SchemaName);

            modelBuilder.Entity<UserEntity>()
                .Property(e => e.Id)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<PlannedMaintenanceDto>()
                .Property(e => e.Id)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<WorkOrderDto>()
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

            modelBuilder.Entity<AssetDto>()
                .Property(e => e.Id)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<AssetUsageDto>()
                .Property(e => e.Id)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<WorkOrderPartDto>()
                .Property(e => e.Id)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<PlannedMaintenancePartDto>()
                .Property(e => e.Id)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<TaskDto>()
                .Property(e => e.Id)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<WorkOrderTaskDto>()
              .Property(e => e.Id)
              .ValueGeneratedOnAdd();

            modelBuilder.Entity<PlannedMaintenanceTaskDto>()
                .Property(e => e.Id)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<PlannedMaintenanceScheduleCustomDto>()
                .Property(e => e.Id)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<PlannedMaintenanceScheduleDailyDto>()
                .Property(e => e.Id)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<PlannedMaintenanceScheduleWeeklyDto>()
                .Property(e => e.Id)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<PlannedMaintenanceScheduleMonthlyDto>()
                .Property(e => e.Id)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<PlannedMaintenanceScheduleYearlyDto>()
                .Property(e => e.Id)
                .ValueGeneratedOnAdd();

            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }

            modelBuilder.Entity<WorkOrdersCompletedByDayForWeek>(entity =>
            {
                entity.HasNoKey();
            });

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
            var entries = ChangeTracker.Entries().Where(x => x.Entity is BaseEntityDto && (x.State == EntityState.Added || x.State == EntityState.Modified));
            foreach (var entry in entries)
            {
                if (entry.State == EntityState.Added)
                {
                    ((BaseEntityDto)entry.Entity).DateCreated = DateTime.Now;
                }
                ((BaseEntityDto)entry.Entity).DateUpdated = DateTime.Now;
            }
        }
    }
}
