using Api.Core.Interfaces;
using Quiplogs.Assets.Dto.Responses.Asset;
using System;

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
