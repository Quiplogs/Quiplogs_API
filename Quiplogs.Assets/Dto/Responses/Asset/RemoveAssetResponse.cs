using System.Collections.Generic;
using Quiplogs.Core.Dto;
using Quiplogs.Core.Interfaces;

namespace Quiplogs.Assets.Dto.Responses.Asset
{
    public class RemoveAssetResponse : ServiceResponseMessage
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
