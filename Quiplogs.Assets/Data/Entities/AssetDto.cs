using Quiplogs.Core.Data.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace Quiplogs.Assets.Data.Entities
{
    public class AssetDto : BaseEntity
    {
        public string Name { get; set; }

        public string Make { get; set; }

        public string Model { get; set; }

        public string SerialNumber { get; set; }

        public int ManufacuredYear { get; set; }

        public int PurchasedYear { get; set; }

        [Column(TypeName = "decimal(18, 6)")]
        public decimal CurrentWorkDone { get; set; }

        public int UoM { get; set; }

        public string ImgFileName { get; set; }

        public string ImgUrl { get; set; }

        public string WarrantyUrl { get; set; }

        public string InstructionManualUrl { get; set; }

        public string LocationId { get; set; }

        [ForeignKey("LocationId")]
        public LocationDto Location { get; set; }

        public string CompanyId { get; set; }

        [ForeignKey("CompanyId")]
        public CompanyDto Company { get; set; }
    }
}
