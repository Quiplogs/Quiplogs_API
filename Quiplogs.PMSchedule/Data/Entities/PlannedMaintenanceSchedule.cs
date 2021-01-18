﻿using Quiplogs.Assets.Data.Entities;
using Quiplogs.Core.Data.Entities;
using Quiplogs.WorkOrder.Data.Entities;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Quiplogs.PMSchedule.Data.Entities
{
    public abstract class PlannedMaintenanceSchedule : BaseEntity
    {
        public Guid PlannedMaintenanceId { get; set; }

        [ForeignKey("PlannedMaintenanceId")]
        public PlannedMaintenanceDto PlannedMaintenance { get; set; }

        public Guid AssetId { get; set; }

        [ForeignKey("AssetId")]
        public AssetDto Asset { get; set; }

        public DateTime? DateLastProcessed { get; set; }

        public DateTime? DateNextDue { get; set; }

        public DateTime? EndDate { get; set; }
    }
}
