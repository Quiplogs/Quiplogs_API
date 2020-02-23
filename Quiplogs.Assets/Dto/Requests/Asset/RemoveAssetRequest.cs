using Api.Core.Interfaces;
using Quiplogs.Assets.Dto.Responses.Asset;

namespace Quiplogs.Assets.Dto.Requests.Asset
{
    public class RemoveAssetRequest : IRequest<RemoveAssetResponse>
    {
        public string Id { get; }
        public RemoveAssetRequest(string id)
        {
            Id = id;
        }
    }
}
