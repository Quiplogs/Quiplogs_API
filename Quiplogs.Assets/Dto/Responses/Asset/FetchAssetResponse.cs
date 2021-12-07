using System.Collections.Generic;
using Quiplogs.Core.Domain;
using Quiplogs.Core.Dto;
using Quiplogs.Core.Interfaces;

namespace Quiplogs.Assets.Dto.Responses.Asset
{
    public class FetchAssetResponse : ServiceResponseMessage
    {
        public PagedResult<Domain.Entities.Asset> PagedResult { get; }
        public IEnumerable<Error> Errors { get; }

        public FetchAssetResponse(IEnumerable<Error> errors, bool success = false, string message = null) : base(success, message)
        {
            Errors = errors;
        }

        public FetchAssetResponse(PagedResult<Domain.Entities.Asset> pagedResult, bool success = false, string message = null) : base(success, message)
        {
            PagedResult = pagedResult;
        }
    }
}
