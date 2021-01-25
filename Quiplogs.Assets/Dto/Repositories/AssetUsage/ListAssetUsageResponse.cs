using System.Collections.Generic;
using Quiplogs.Core.Dto;
using Quiplogs.Core.Dto.Repositories;

namespace Quiplogs.Assets.Dto.Repositories.AssetUsage
{
    public class ListAssetUsageResponse : BaseRepositoryResponse
    {
        public List<Domain.Entities.AssetUsage> AssetUsageList { get; set; }

        public ListAssetUsageResponse(List<Domain.Entities.AssetUsage> assetUsageList, bool success = false, IEnumerable<Error> errors = null) : base(success, errors)
        {
            AssetUsageList = assetUsageList;
        }
    }
}
