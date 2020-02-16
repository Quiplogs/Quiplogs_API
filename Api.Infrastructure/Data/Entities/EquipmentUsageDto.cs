using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Api.Infrastructure.Data.Entities
{
    public class EquipmentUsageDto : BaseEntity
    {
        public decimal WorkDone { get; set; }

        public DateTime? DateCaptured { get; set; }

        [ForeignKey("EquipmentId")]
        public string EquipmentId { get; set; }

        public EquipmentDto Equipment { get; set; }
    }
}
