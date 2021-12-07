using Quiplogs.Assets.Dto.Responses.Asset;
using System;
using Quiplogs.Core.Interfaces;

namespace Quiplogs.Assets.Dto.Requests.Asset
{
    public class RemoveAssetRequest : IRequest<RemoveAssetResponse>
    {
        public Guid Id { get; }
        public RemoveAssetRequest(Guid id)
        {
            Id = id;
        }
    }
}
