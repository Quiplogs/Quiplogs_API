using Api.Core.Domain.Entities;
using Api.Core.Interfaces;
using System.Collections.Generic;

namespace Api.Core.Dto.Responses.Task
{
    public class ListTaskResponse : ServiceResponseMessage
    {
        public PagedResult<Domain.Entities.TaskEntity> PagedResult { get; }
        public IEnumerable<Error> Errors { get; }

        public ListTaskResponse(IEnumerable<Error> errors, bool success = false, string message = null) : base(success, message)
        {
            Errors = errors;
        }

        public ListTaskResponse(PagedResult<Domain.Entities.TaskEntity> pagedResult, bool success = false, string message = null) : base(success, message)
        {
            PagedResult = pagedResult;
        }
    }
}
