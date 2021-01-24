using Api.Core.Interfaces;
using Quiplogs.Assets.Dto.Responses.AssetUsage;
using System;

namespace Quiplogs.Assets.Dto.Requests.AssetUsage
{
    public class GetAssetUsageRequest : IRequest<GetAssetUsageResponse>
    {
        public Guid Id { get; }
        public GetAssetUsageRequest(Guid id)
        {
            Id = id;
        }
    }
}
