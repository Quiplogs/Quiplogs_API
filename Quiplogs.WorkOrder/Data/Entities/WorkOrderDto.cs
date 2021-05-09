using Quiplogs.Assets.Data.Entities;
using Quiplogs.Core.Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Quiplogs.WorkOrder.Data.Entities
{
    public class WorkOrderDto : BaseLocationDto
    {
        public string ReferenceNumber { get; set; }

        public DateTime? DueDate { get; set; }

        public DateTime? DateCompleted { get; set; }

        public string Notes { get; set; }

        [Column(TypeName = "decimal(18, 6)")]
        public decimal HoursWorked { get; set; }

        [Column(TypeName = "decimal(18, 6)")]
        public decimal MinutesWorked { get; set; }

        public bool IsDeleted { get; set; }

        public Guid TechnicianId { get; set; }

        [ForeignKey("TechnicianId")]
        public UserEntity Technician { get; set; }

        public string TechnicianName { get; set; }
                
        public Guid AssetId { get; set; }

        [ForeignKey("AssetId")]
        public AssetDto Asset { get; set; }

        public string AssetName { get; set; }

        public string LocationName { get; set; }

        public int Status { get; set; }

        public int Priority { get; set; }

        public bool IsPlanned { get; set; }

        public List<WorkOrderPartDto> WorkOrderParts { get; set; }

        public List<WorkOrderTaskDto> WorkOrderTasks { get; set; }
    }
}
