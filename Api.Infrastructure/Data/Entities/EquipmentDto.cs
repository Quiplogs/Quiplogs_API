using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Api.Infrastructure.Data.Entities
{
    public class EquipmentDto : BaseEntity
    {
        public string Code { get; set; }

        public string Make { get; set; }

        public string Model { get; set; }

        public int BuildYear { get; set; }

        public decimal CurrentWorkDone { get; set; }

        public string UoM { get; set; }
        
        public string ImgUrl { get; set; }

        public string LocationId { get; set; }

        [ForeignKey("LocationId")]
        public LocationDto Location { get; set; }

        public string CompanyId { get; set; }

        [ForeignKey("CompanyId")]
        public CompanyDto Company { get; set; }

        public List<ServiceIntervalDto> ServicesIntervals { get; set; }

        public List<ServiceDto> Services { get; set; }
    }
}
