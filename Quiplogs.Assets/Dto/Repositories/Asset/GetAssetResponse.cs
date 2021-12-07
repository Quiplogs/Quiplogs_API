using System.Collections.Generic;
using Quiplogs.Core.Dto;
using Quiplogs.Core.Dto.Repositories;

namespace Quiplogs.Assets.Dto.Repositories.Asset
{
    public class GetAssetResponse : BaseRepositoryResponse
    {
        public Domain.Entities.Asset Asset { get; set; }

        public GetAssetResponse(Domain.Entities.Asset asset, bool success = false, IEnumerable<Error> errors = null) : base(success, errors)
        {
            Asset = asset;
        }
    }
}
