using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Api.Infrastructure.Data.Entities
{
    public class PreconServiceIntervalDto : BaseEntity
    {
        public string PreconEquipmentId { get; set; }

        [ForeignKey("PreconEquipmentId")]
        public PreconEquipmentDto PreconEquipment { get; set; }

        public decimal Interval { get; set; }

        public string UoM { get; set; }

        public List<PreconPartDto> PreconParts { get; set; }
    }
}
