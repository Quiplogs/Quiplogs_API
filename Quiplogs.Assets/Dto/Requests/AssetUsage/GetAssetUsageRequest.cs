using Api.Core.Interfaces;
using Quiplogs.Assets.Dto.Responses.AssetUsage;

namespace Quiplogs.Assets.Dto.Requests.AssetUsage
{
    public class GetAssetUsageRequest : IRequest<GetAssetUsageResponse>
    {
        public string Id { get; }
        public GetAssetUsageRequest(string id)
        {
            Id = id;
        }
    }
}
