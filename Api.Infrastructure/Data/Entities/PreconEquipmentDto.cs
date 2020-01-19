using System.Collections.Generic;

namespace Api.Infrastructure.Data.Entities
{
    public class PreconEquipmentDto : BaseEntity
    {
        public string Make { get; set; }

        public string Model { get; set; }

        public string UoM { get; set; }

        public bool IsReviewed { get; set; }

        public List<PreconServiceIntervalDto> ServicesIntervals { get; set; }
    }
}
