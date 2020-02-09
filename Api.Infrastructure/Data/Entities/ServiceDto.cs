using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Api.Infrastructure.Data.Entities
{
    public class ServiceDto : BaseEntity
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

        [ForeignKey("EquipmentId")]
        public string EquipmentId { get; set; }

        public EquipmentDto Equipment { get; set; }

        public string CompanyId { get; set; }

        [ForeignKey("CompanyId")]
        public CompanyDto Company { get; set; }

        public string LocationId { get; set; }

        [ForeignKey("LocationId")]
        public LocationDto Location { get; set; }

        public List<ServicePartDto> ServiceParts { get; set; }
    }
}
