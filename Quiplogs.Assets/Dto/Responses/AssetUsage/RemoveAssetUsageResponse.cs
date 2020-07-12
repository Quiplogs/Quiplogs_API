using Api.Core.Dto;
using Api.Core.Interfaces;
using System.Collections.Generic;

namespace Quiplogs.Assets.Dto.Responses.AssetUsage
{
    public class RemoveAssetUsageResponse : ServiceResponseMessage
    {
        public string Description { get; }
        public IEnumerable<Error> Errors { get; }

        public RemoveAssetUsageResponse(IEnumerable<Error> errors, bool success = false, string message = null) : base(success, message)
        {
            Errors = errors;
        }

        public RemoveAssetUsageResponse(string description, bool success = false, string message = null) : base(success, message)
        {
            Description = description;
        }
    }
}
