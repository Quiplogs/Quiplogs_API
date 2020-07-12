using Api.Core.Domain.Entities;
using Api.Core.Dto;
using Api.Core.Interfaces;
using System.Collections.Generic;

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
