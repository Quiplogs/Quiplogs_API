using Api.Core.Dto;
using Api.Core.Dto.Responses;
using System.Collections.Generic;

namespace Quiplogs.Assets.Dto.Repositories.Asset
{
    public class FetchAssetResponse : BaseResponse
    {
        public List<Domain.Entities.Asset> Assets { get; set; }

        public FetchAssetResponse(List<Domain.Entities.Asset> assets, bool success = false, IEnumerable<Error> errors = null) : base(success, errors)
        {
            Assets = assets;
        }
    }
}
