using Api.Core.Interfaces;
using Quiplogs.Assets.Dto.Responses.AssetUsage;
using System;

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
