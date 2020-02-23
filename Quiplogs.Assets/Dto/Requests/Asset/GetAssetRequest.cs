using Api.Core.Interfaces;
using Quiplogs.Assets.Dto.Responses.Asset;

namespace Quiplogs.Assets.Dto.Requests.Asset
{
    public class GetAssetRequest : IRequest<GetAssetResponse>
    {
        public string Id { get; }
        public GetAssetRequest(string id)
        {
            Id = id;
        }
    }
}
