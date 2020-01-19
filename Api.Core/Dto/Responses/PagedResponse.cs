using Api.Core.Interfaces;
using System.Collections.Generic;

namespace Api.Core.Dto.Responses
{
    public abstract class PagedResponse<T> : ServiceResponseMessage
    {
        public PagedResult<T> Results { get; }
        public IEnumerable<string> Errors { get; }

        public PagedResponse(IEnumerable<string> errors, bool success = false, string message = null) : base(success, message)
        {
            Errors = errors;
        }

        public PagedResponse(PagedResult<T> pagedResult, bool success = false, string message = null) : base(success, message)
        {
            Results = pagedResult;
        }
    }
}
