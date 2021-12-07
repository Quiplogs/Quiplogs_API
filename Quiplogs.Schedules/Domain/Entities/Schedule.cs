using Quiplogs.Assets.Data.Entities;
using Quiplogs.Core.Domain.Entities;
using Quiplogs.PlannedMaintenance.Data.Entities;
using System;

namespace Quiplogs.Schedules.Domain.Entities
{
    public class Schedule :BaseEntity
    {
        public Guid PlannedMaintenanceId { get; set; }
        public PlannedMaintenanceDto PlannedMaintenance { get; set; }
        public Guid AssetId { get; set; }
        public AssetDto Asset { get; set; }
        public DateTime? DateLastProcessed { get; set; }
        public DateTime? DateNextDue { get; set; }
        public DateTime? EndDate { get; set; }
        public string Type { get; set; }
    }
}
