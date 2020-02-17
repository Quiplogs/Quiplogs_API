using System;

namespace Api.Core.Domain.Entities
{
    public class Service : BaseEntity
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

        public string EquipmentId { get; set; }

        public Equipment Equipment { get; set; }

        public string CompanyId { get; set; }

        public Company Company { get; set; }

        public string LocationId { get; set; }

        public Location Location { get; set; }

        //public List<ServicePartDto> ServiceParts { get; set; }
    }
}
