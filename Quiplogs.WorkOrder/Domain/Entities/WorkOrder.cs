﻿using Api.Core.Domain.Entities;
using Quiplogs.Assets.Domain.Entities;
using System;
using System.Collections.Generic;

namespace Quiplogs.WorkOrder.Domain.Entities
{
    public class WorkOrderEntity : BaseEntity
    {
        public string ReferenceNumber { get; set; }

        public DateTime? DateCompleted { get; set; }

        public string Notes { get; set; }

        public decimal HoursWorked { get; set; }

        public decimal MintuesWorked { get; set; }

        public Guid TechnicianId { get; set; }

        public AppUser Technician { get; set; }

        public string TechnicianName { get; set; }

        public Guid ResponsableUserId { get; set; }

        public AppUser ResponsableUser { get; set; }

        public string ResponsableUserName { get; set; }

        public Guid AssetId { get; set; }

        public Asset Asset { get; set; }

        public Guid CompanyId { get; set; }

        public Company Company { get; set; }

        public Guid LocationId { get; set; }

        public Location Location { get; set; }

        public int Status { get; set; }

        public List<WorkOrderPart> WorkOrderParts { get; set; }

        public List<WorkOrderTask> WorkOrderTasks { get; set; }
    }
}
