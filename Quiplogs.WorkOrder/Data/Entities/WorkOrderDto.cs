using Quiplogs.Assets.Data.Entities;
using Quiplogs.Core.Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Quiplogs.Infrastructure.Data.Entities
{
    public class WorkOrderDto : BaseEntity
    {
        public string ReferenceNumber { get; set; }

        public DateTime? DateCompleted { get; set; }

        public string FaultNotes { get; set; }

        public string Notes { get; set; }

        public decimal HoursWorked { get; set; }

        public string MechanicId { get; set; }

        [ForeignKey("MechanicId")]
        public UserEntity Mechanic { get; set; }

        public string MechanicName { get; set; }

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
    }
}
