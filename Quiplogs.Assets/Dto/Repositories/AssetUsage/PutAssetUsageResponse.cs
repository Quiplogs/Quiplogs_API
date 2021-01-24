using Api.Core.Dto;
using Api.Core.Dto.Repositories;
using Api.Core.Dto.Responses;
using System.Collections.Generic;

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
