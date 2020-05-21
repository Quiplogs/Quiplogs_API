using Quiplogs.Assets.Data.Entities;
using Quiplogs.Core.Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Quiplogs.WorkOrder.Data.Entities
{
    public class WorkOrderDto : BaseEntity
    {
        public string ReferenceNumber { get; set; }

        public DateTime? DueDate { get; set; }

        public DateTime? DateCompleted { get; set; }

        public string Notes { get; set; }

        [Column(TypeName = "decimal(18, 6)")]
        public decimal HoursWorked { get; set; }

        [Column(TypeName = "decimal(18, 6)")]
        public decimal MintuesWorked { get; set; }

        public bool IsDeleted { get; set; }

        public string TechnicianId { get; set; }

        [ForeignKey("MechanicId")]
        public UserEntity Technician { get; set; }

        public string TechnicianName { get; set; }

        public string ResponsableUserId { get; set; }

        [ForeignKey("ResponsableUserId")]
        public UserEntity ResponsableUser { get; set; }

        public string ResponsableUserName { get; set; }

        [ForeignKey("AssetId")]
        public string AssetId { get; set; }

        public AssetDto Asset { get; set; }

        public string CompanyId { get; set; }

        [ForeignKey("CompanyId")]
        public CompanyDto Company { get; set; }

        public string LocationId { get; set; }

        [ForeignKey("LocationId")]
        public LocationDto Location { get; set; }

        public List<WorkOrderPartDto> WorkOrderParts { get; set; }

        public List<WorkOrderTaskDto> WorkOrderTasks { get; set; }
    }
}
