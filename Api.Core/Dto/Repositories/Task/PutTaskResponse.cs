using Api.Core.Dto.Responses;
using System.Collections.Generic;

namespace Api.Core.Dto.Repositories.Task
{
    public class PutTaskResponse : BaseResponse
    {
        public Domain.Entities.TaskEntity Task { get; set; }

        public PutTaskResponse(Domain.Entities.TaskEntity task, bool success = false, IEnumerable<Error> errors = null) : base(success, errors)
        {
            Task = task;
        }
    }
}
