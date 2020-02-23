using Api.Core.Domain.Entities;
using Api.Core.Dto;
using Api.Core.Interfaces;
using System.Collections.Generic;

namespace Quiplogs.Assets.Dto.Responses.Asset
{
    public class FetchAssetResponse : WorkOrderResponseMessage
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
