using Api.Core.Interfaces;
using Quiplogs.Assets.Dto.Responses.AssetUsage;

namespace Quiplogs.Assets.Dto.Requests.AssetUsage
{
    public class ListAssetUsageRequest : IRequest<ListAssetUsageResponse>
    {
        public string AssetId { get; }
        public int PageNumber { get; }
        public ListAssetUsageRequest(string assetId, int pageNumber)
        {
            AssetId = assetId;
            PageNumber = pageNumber;
        }
    }
}
