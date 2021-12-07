using System;
using Quiplogs.Core.Domain.Entities;

namespace Quiplogs.Assets.Domain.Entities
{
    public class AssetUsage : BaseEntity
    {
        public decimal WorkDone { get; set; }

        public DateTime? DateCaptured { get; set; }

        public string AssetId { get; set; }

        public Asset Asset { get; set; }
    }
}
