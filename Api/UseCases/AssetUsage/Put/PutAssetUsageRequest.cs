using System;

namespace Api.UseCases.AssetUsage.Put
{
    public class PutAssetUsageRequest
    {
        public decimal WorkDone { get; set; }

        public DateTime? DateCaptured { get; set; }

        public string AssetId { get; set; }
    }
}
