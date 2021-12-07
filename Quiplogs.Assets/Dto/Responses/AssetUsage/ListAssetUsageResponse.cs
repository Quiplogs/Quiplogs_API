using System.Collections.Generic;
using Quiplogs.Core.Domain;
using Quiplogs.Core.Dto;
using Quiplogs.Core.Interfaces;

namespace Quiplogs.Assets.Dto.Responses.AssetUsage
{
    public class ListAssetUsageResponse : ServiceResponseMessage
    {
        public PagedResult<Domain.Entities.AssetUsage> PagedResult { get; }
        public IEnumerable<Error> Errors { get; }

        public ListAssetUsageResponse(IEnumerable<Error> errors, bool success = false, string message = null) : base(success, message)
        {
            Errors = errors;
        }

        public ListAssetUsageResponse(PagedResult<Domain.Entities.AssetUsage> pagedResult, bool success = false, string message = null) : base(success, message)
        {
            PagedResult = pagedResult;
        }
    }
}
