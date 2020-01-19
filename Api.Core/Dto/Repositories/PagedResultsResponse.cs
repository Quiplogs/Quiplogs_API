using Api.Core.Dto.Responses;
using System.Collections.Generic;

namespace Api.Core.Dto.Repositories
{
    public class PagedResultsResponse<T> : BaseResponse
    {
        public PagedResult<T> Result { get; set; }

        public PagedResultsResponse(PagedResult<T> results, bool success = false, IEnumerable<Error> errors = null) : base(success, errors)
        {
            Result = results;
        }
    }
}
