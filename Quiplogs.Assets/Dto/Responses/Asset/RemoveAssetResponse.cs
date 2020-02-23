using Api.Core.Dto;
using Api.Core.Interfaces;
using System.Collections.Generic;

namespace Quiplogs.Assets.Dto.Responses.Asset
{
    public class RemoveAssetResponse : WorkOrderResponseMessage
    {
        public string Description { get; }
        public IEnumerable<Error> Errors { get; }

        public RemoveAssetResponse(IEnumerable<Error> errors, bool success = false, string message = null) : base(success, message)
        {
            Errors = errors;
        }

        public RemoveAssetResponse(string description, bool success = false, string message = null) : base(success, message)
        {
            Description = description;
        }
    }
}
