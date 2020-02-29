using Api.Core.Dto;
using Api.Core.Interfaces;
using System.Collections.Generic;

namespace Quiplogs.Assets.Dto.Responses.Asset
{
    public class PutAssetResponse : ServiceResponseMessage
    {
        public Domain.Entities.Asset Asset { get; }
        public IEnumerable<Error> Errors { get; }

        public PutAssetResponse(IEnumerable<Error> errors, bool success = false, string message = null) : base(success, message)
        {
            Errors = errors;
        }

        public PutAssetResponse(Domain.Entities.Asset asset, bool success = false, string message = null) : base(success, message)
        {
            Asset = asset;
        }
    }
}
