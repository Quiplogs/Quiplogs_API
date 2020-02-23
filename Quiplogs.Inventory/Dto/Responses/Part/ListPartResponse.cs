using Api.Core.Domain.Entities;
using Api.Core.Dto;
using Api.Core.Interfaces;
using System.Collections.Generic;

namespace Quiplogs.Inventory.Dto.Responses.Part
{
    public class ListPartResponse : WorkOrderResponseMessage
    {
        public PagedResult<Domain.Entities.Part> PagedResult { get; }
        public IEnumerable<Error> Errors { get; }

        public ListPartResponse(IEnumerable<Error> errors, bool success = false, string message = null) : base(success, message)
        {
            Errors = errors;
        }

        public ListPartResponse(PagedResult<Domain.Entities.Part> pagedResult, bool success = false, string message = null) : base(success, message)
        {
            PagedResult = pagedResult;
        }
    }
}
