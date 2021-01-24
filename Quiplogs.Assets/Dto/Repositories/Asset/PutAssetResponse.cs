using Api.Core.Dto;
using Api.Core.Dto.Repositories;
using System.Collections.Generic;

namespace Quiplogs.Assets.Dto.Repositories.Asset
{
    public class PutAssetResponse : BaseRepositoryResponse
    {
        public Assets.Domain.Entities.Asset Asset { get; set; }

        public PutAssetResponse(Assets.Domain.Entities.Asset asset, bool success = false, IEnumerable<Error> errors = null) : base(success, errors)
        {
            Asset = asset;
        }
    }
}
