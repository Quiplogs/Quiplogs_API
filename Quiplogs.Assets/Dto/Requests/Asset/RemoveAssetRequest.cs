using Api.Core.Interfaces;
using Quiplogs.Assets.Dto.Responses.Asset;
using System;

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
