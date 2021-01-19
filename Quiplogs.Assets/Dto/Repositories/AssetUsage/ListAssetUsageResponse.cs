using Api.Core.Domain.Entities;
using Api.Core.Dto;
using Api.Core.Dto.Responses;
using System.Collections.Generic;

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
