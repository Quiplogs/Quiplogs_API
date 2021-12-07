using Quiplogs.Assets.Dto.Responses.Asset;
using System;
using Quiplogs.Core.Interfaces;

namespace Quiplogs.Assets.Dto.Requests.Asset
{
    public class GetAssetRequest : IRequest<GetAssetResponse>
    {
        public Guid Id { get; }
        public GetAssetRequest(Guid id)
        {
            Id = id;
        }
    }
}
