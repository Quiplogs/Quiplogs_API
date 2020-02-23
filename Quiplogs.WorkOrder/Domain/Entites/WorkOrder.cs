using Api.Core.Domain.Entities;
using Quiplogs.Assets.Domain.Entities;
using System;

namespace Quiplogs.WorkOrder.Domain.Entities
{
    public class WorkOrder : BaseEntity
    {
        public string ReferenceNumber { get; set; }

        public DateTime? DateCompleted { get; set; }

        public string FaultNotes { get; set; }

        public string Notes { get; set; }

        public decimal HoursWorked { get; set; }

        public string MechanicId { get; set; }

        //public UserEntity Mechanic { get; set; }

        public string MechanicName { get; set; }

        public string ResponsableUserId { get; set; }

        //public UserEntity ResponsableUser { get; set; }

        public string ResponsableUserName { get; set; }

        public string AssetId { get; set; }

        public Asset Asset { get; set; }

        public string CompanyId { get; set; }

        public Company Company { get; set; }

        public string LocationId { get; set; }

        public Location Location { get; set; }

        //public List<WorkOrderPartDto> WorkOrderParts { get; set; }
    }
}
