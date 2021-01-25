using Quiplogs.Assets.Dto.Responses.AssetUsage;
using System;
using Quiplogs.Core.Interfaces;

namespace Quiplogs.Assets.Dto.Requests.AssetUsage
{
    public class RemoveAssetUsageRequest : IRequest<RemoveAssetUsageResponse>
    {
        public Guid Id { get; }
        public RemoveAssetUsageRequest(Guid id)
        {
            Id = id;
        }
    }
}
