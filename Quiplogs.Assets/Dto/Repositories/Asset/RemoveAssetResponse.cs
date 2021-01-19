using Api.Core.Dto;
using Api.Core.Dto.Responses;
using System.Collections.Generic;

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
