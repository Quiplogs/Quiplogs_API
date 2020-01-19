using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Api.Infrastructure.Data.Entities
{
    public class ServiceDto : BaseEntity
    {
        public string ReferenceNumber { get; set; }

        public DateTime? DateToBeServiced { get; set; }

        public DateTime? DateCompleted { get; set; }

        public string UserId { get; set; }

        [ForeignKey("UserId")]
        public UserEntity ResponsableUser { get; set; }

        [ForeignKey("EquipmentId")]
        public string EquipmentId { get; set; }

        public EquipmentDto Equipment { get; set; }

        public string CompanyId { get; set; }

        [ForeignKey("CompanyId")]
        public CompanyDto Company { get; set; }

        public List<ServicePart> ServiceParts { get; set; }
    }
}
