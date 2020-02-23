using Api.Core.Interfaces;
using Quiplogs.Assets.Dto.Responses.Asset;

namespace Quiplogs.Assets.Dto.Requests.Asset
{
    public class PutAssetRequest : IRequest<PutAssetResponse>
    {
        public Assets.Domain.Entities.Asset Asset { get; }
        public PutAssetRequest(Assets.Domain.Entities.Asset asset)
        {
            Asset = asset;
        }
    }
}
