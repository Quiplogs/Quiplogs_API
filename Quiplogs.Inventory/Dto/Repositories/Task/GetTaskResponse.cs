using Api.Core.Dto;
using Api.Core.Dto.Responses;
using System.Collections.Generic;

namespace Quiplogs.Inventory.Dto.Repositories.Task
{
    public class GetTaskResponse : BaseResponse
    {
        public Domain.Entities.TaskEntity Task { get; set; }

        public GetTaskResponse(Domain.Entities.TaskEntity task, bool success = false, IEnumerable<Error> errors = null) : base(success, errors)
        {
            Task = task;
        }
    }
}
