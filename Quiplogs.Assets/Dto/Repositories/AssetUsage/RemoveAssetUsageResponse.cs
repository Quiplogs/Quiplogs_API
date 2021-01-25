using System.Collections.Generic;
using Quiplogs.Core.Dto;
using Quiplogs.Core.Dto.Repositories;

namespace Quiplogs.Assets.Dto.Repositories.AssetUsage
{
    public class RemoveAssetUsageResponse : BaseRepositoryResponse
    {
        public string Description { get; set; }

        public RemoveAssetUsageResponse(string description, bool success = false, IEnumerable<Error> errors = null) : base(success, errors)
        {
            Description = description;
        }
    }
}
