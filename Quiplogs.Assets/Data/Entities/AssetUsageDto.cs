using Quiplogs.Core.Data.Entities;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Quiplogs.Assets.Data.Entities
{
    public class AssetUsageDto : BaseEntityDto
    {
        [Column(TypeName = "decimal(18, 6)")]
        public decimal WorkDone { get; set; }

        public DateTime? DateCaptured { get; set; }

        [ForeignKey("AssetId")]
        public Guid AssetId { get; set; }

        public AssetDto Asset { get; set; }
    }
}
