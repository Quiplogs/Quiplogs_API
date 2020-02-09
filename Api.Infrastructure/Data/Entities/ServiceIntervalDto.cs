using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Api.Infrastructure.Data.Entities
{
    public class ServiceIntervalDto : BaseEntity
    {
        public string EquipmentId { get; set; }

        [ForeignKey("EquipmentId")]
        public EquipmentDto Equipment { get; set; }

        public bool IsRecurring { get; set; }

        public decimal Interval { get; set; }

        public string UoM { get; set; }

        public IList<ServiceIntervalPartDto> ServiceIntervalParts { get; set; }
    }
}
