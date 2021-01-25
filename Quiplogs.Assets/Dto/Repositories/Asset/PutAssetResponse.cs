using System.Collections.Generic;
using Quiplogs.Core.Dto;
using Quiplogs.Core.Dto.Repositories;

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
