using System.Collections.Generic;
using Quiplogs.Core.Dto;
using Quiplogs.Core.Interfaces;

namespace Quiplogs.Assets.Dto.Responses.AssetUsage
{
    public class GetAssetUsageResponse : ServiceResponseMessage
    {
        public Domain.Entities.AssetUsage AssetUsage { get; }
        public IEnumerable<Error> Errors { get; }

        public GetAssetUsageResponse(IEnumerable<Error> errors, bool success = false, string message = null) : base(success, message)
        {
            Errors = errors;
        }

        public GetAssetUsageResponse(Domain.Entities.AssetUsage assetUsage, bool success = false, string message = null) : base(success, message)
        {
            AssetUsage = assetUsage;
        }
    }
}
