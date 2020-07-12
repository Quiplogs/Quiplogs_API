using Api.Core.Interfaces;
using Quiplogs.Assets.Dto.Responses.AssetUsage;

namespace Quiplogs.Assets.Dto.Requests.AssetUsage
{
    public class RemoveAssetUsageRequest : IRequest<RemoveAssetUsageResponse>
    {
        public string Id { get; }
        public RemoveAssetUsageRequest(string id)
        {
            Id = id;
        }
    }
}
