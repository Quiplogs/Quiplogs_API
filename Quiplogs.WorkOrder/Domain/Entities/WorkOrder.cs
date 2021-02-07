using Quiplogs.Assets.Domain.Entities;
using System;
using System.Collections.Generic;
using Quiplogs.Core.Domain.Entities;

namespace Quiplogs.WorkOrder.Domain.Entities
{
    public class WorkOrderEntity : BaseEntity
    {
        public string ReferenceNumber { get; set; }
        public DateTime? DateCompleted { get; set; }
        public string Notes { get; set; }
        public decimal HoursWorked { get; set; }
        public decimal MinutesWorked { get; set; }
        public Guid TechnicianId { get; set; }
        public AppUser Technician { get; set; }
        public string TechnicianName { get; set; }
        public Guid AssetId { get; set; }
        public string AssetName { get; set; }
        public int Status { get; set; }
        public Guid LocationId { get; set; }
        public string LocationName { get; set; }
        public List<WorkOrderPart> WorkOrderParts { get; set; }
        public List<WorkOrderTask> WorkOrderTasks { get; set; }
    }
}
