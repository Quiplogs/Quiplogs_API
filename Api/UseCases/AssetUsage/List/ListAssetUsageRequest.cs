using System;

namespace Api.UseCases.AssetUsage.List
{
    public class ListAssetUsageRequest
    {
        public Guid AssetId { get; set; }
        public int PageNumber { get; set; }
    }
}
