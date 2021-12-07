using Quiplogs.Assets.Dto.Responses.AssetUsage;
using System;
using Quiplogs.Core.Interfaces;

namespace Quiplogs.Assets.Dto.Requests.AssetUsage
{
    public class ListAssetUsageRequest : IRequest<ListAssetUsageResponse>
    {
        public Guid AssetId { get; }
        public int PageNumber { get; }
        public ListAssetUsageRequest(Guid assetId, int pageNumber)
        {
            AssetId = assetId;
            PageNumber = pageNumber;
        }
    }
}
