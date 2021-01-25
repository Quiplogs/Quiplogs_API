using System.Collections.Generic;
using Quiplogs.Core.Domain;
using Quiplogs.Core.Interfaces;

namespace Quiplogs.Core.Dto.Responses.Location
{
    public class ListLocationResponse : ServiceResponseMessage
    {
        public PagedResult<Domain.Entities.Location> PagedResult { get; }
        public IEnumerable<Error> Errors { get; }

        public ListLocationResponse(IEnumerable<Error> errors, bool success = false, string message = null) : base(success, message)
        {
            Errors = errors;
        }

        public ListLocationResponse(PagedResult<Domain.Entities.Location> pagedResult, bool success = false, string message = null) : base(success, message)
        {
            PagedResult = pagedResult;
        }
    }
}
