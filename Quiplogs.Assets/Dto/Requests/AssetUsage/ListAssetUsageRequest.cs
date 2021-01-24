using Api.Core.Interfaces;
using Quiplogs.Assets.Dto.Responses.AssetUsage;
using System;

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
