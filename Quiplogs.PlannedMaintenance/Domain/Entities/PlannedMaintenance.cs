﻿using System;
using System.Collections.Generic;
using Quiplogs.Assets.Domain.Entities;
using Quiplogs.Core.Domain.Entities;

namespace Quiplogs.PlannedMaintenance.Domain.Entities
{
    public class PlannedMaintenance : BaseEntity
    {
        public string Name { get; set; }
        public Guid AssetId { get; set; }
        public Asset Asset { get; set; }
        public Guid DefaultTechnicianId { get; set; }
        public AppUser DefaultTechnician { get; set; }
        public string Notes { get; set; }
        public bool IsDeleted { get; set; }
        public Guid LocationId { get; set; }
        public Location Location { get; set; }
        public List<PlannedMaintenancePart> PlannedMaintenanceParts { get; set; }
        public List<PlannedMaintenanceTask> PlannedMaintenanceTasks { get; set; }
    }
}
