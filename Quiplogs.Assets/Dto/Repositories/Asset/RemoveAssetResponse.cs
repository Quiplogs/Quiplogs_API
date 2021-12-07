using System.Collections.Generic;
using Quiplogs.Core.Dto;
using Quiplogs.Core.Dto.Repositories;

namespace Quiplogs.Assets.Dto.Repositories.Asset
{
    public class RemoveAssetResponse : BaseRepositoryResponse
    {
        public string AssetDescription { get; set; }

        public RemoveAssetResponse(string assetDescription, bool success = false, IEnumerable<Error> errors = null) : base(success, errors)
        {
            AssetDescription = assetDescription;
        }
    }
}
