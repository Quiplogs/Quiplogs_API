using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Api.Infrastructure.Data.Entities
{
    public class PartStockDto : BaseEntity
    {
        public decimal Quantity { get; set; }

        public bool InStock { get; set; }

        public string PartId { get; set; }

        [ForeignKey("PartId")]
        public PartDto Part { get; set; }

        public string LocationId { get; set; }

        [ForeignKey("LocationId")]
        public LocationDto Location { get; set; }

        public string CompanyId { get; set; }

        [ForeignKey("CompanyId")]
        public CompanyDto Company { get; set; }
    }
}
