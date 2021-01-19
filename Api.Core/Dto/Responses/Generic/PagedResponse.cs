using Api.Core.Domain.Entities;
using Api.Core.Dto;
using Api.Core.Interfaces;
using System.Collections.Generic;

namespace Quiplogs.Core.Dto.Responses.Generic
{
    public class PagedResponse<T> : ServiceResponseMessage where T : BaseEntity
    {
        public PagedResult<T> PagedResult { get; }
        public IEnumerable<Error> Errors { get; }

        public PagedResponse(IEnumerable<Error> errors, bool success = false, string message = null) : base(success, message)
        {
            Errors = errors;
        }

        public PagedResponse(PagedResult<T> pagedResult, bool success = false, string message = null) : base(success, message)
        {
            PagedResult = pagedResult;
        }
    }
}
