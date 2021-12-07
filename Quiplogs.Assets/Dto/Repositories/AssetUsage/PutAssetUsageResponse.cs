using System.Collections.Generic;
using Quiplogs.Core.Dto;
using Quiplogs.Core.Dto.Repositories;

namespace Quiplogs.Assets.Dto.Repositories.AssetUsage
{
    public class PutAssetUsageResponse : BaseRepositoryResponse
    {
        public Domain.Entities.AssetUsage AssetUsage { get; set; }

        public PutAssetUsageResponse(Domain.Entities.AssetUsage assetUsage, bool success = false, IEnumerable<Error> errors = null) : base(success, errors)
        {
            AssetUsage = assetUsage;
        }
    }
}
