using Api.Core.Dto;
using Api.Core.Interfaces;
using System.Collections.Generic;

namespace Quiplogs.Assets.Dto.Responses.AssetUsage
{
    public class PutAssetUsageResponse : ServiceResponseMessage
    {
        public Domain.Entities.AssetUsage AssetUsage { get; }
        public IEnumerable<Error> Errors { get; }

        public PutAssetUsageResponse(IEnumerable<Error> errors, bool success = false, string message = null) : base(success, message)
        {
            Errors = errors;
        }

        public PutAssetUsageResponse(Domain.Entities.AssetUsage assetUsage, bool success = false, string message = null) : base(success, message)
        {
            AssetUsage = assetUsage;
        }
    }
}
