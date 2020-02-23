using Api.Core.Dto;
using Api.Core.Dto.Responses;
using System.Collections.Generic;

namespace Quiplogs.Assets.Dto.Repositories.Asset
{
    public class GetAssetResponse : BaseResponse
    {
        public Domain.Entities.Asset Asset { get; set; }

        public GetAssetResponse(Domain.Entities.Asset asset, bool success = false, IEnumerable<Error> errors = null) : base(success, errors)
        {
            Asset = asset;
        }
    }
}
